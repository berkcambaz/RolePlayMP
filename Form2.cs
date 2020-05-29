using RolePlayMP.src;
using RolePlayMP.src.Inventory;
using RPG.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RPG
{
    public partial class Form2 : Form
    {
        private bool roundEndPacketSent = true;
        private int roundTime = 15;    // Default 180
        private int totalSeconds;

        private int destinationListBoxSelectedItemIndex = -1;
        private int inventoryListBoxSelectedItemIndex = -1;

        public Form2()
        {
            InitializeComponent();

            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

            Room.InitMap();
            Item.InitItems();

            ReloadMap();
            ReloadInventory();
        }

        private void ChatSend_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                String message = ChatSend_textBox.Text;
                if (message.Length > 0)
                {
                    Packet02Message messagePacket = new Packet02Message(Form1.GetPlayerMP().username, message.Trim());
                    messagePacket.WriteData(Form1.GetGameClient());

                    ChatSend_textBox.Clear();

                    Chat_textBox.Text += messagePacket.GetUsername() + " : " + messagePacket.GetMessage() + Environment.NewLine;
                    int caretPos = Chat_textBox.Text.Length;
                    Chat_textBox.Select(caretPos, 0);
                    Chat_textBox.ScrollToCaret();
                }
            }
        }

        private void ChatMenu_button_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = ChatMenu_tabPage;
        }

        private void MapMenu_button_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = MapMenu_tabPage;
        }

        private void InventoryMenu_button_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = InventoryMenu_tabPage;
        }

        private void Countdown_button_Click(object sender, EventArgs e)
        {
            // Starts the round
            Packet03RoundStart roundStartPacket = new Packet03RoundStart();
            roundStartPacket.WriteData(Form1.GetGameServer());

            totalSeconds = roundTime - 10;
            CalculateTimer();
            roundEndPacketSent = false;

            Countdown_button.Visible = false;
            Countdown_label.Visible = true;
        }

        public void ReloadMap()
        {
            CurrentRoom_label.Text = Room.GetRoomName(Room.GetCurrentRoom());
            String[] roomDestination = Room.GetRoomDestination(Room.GetCurrentRoom()).Split(',');
            Destination_listBox.Items.Clear();
            foreach (String roomIndex in roomDestination)
            {
                Destination_listBox.Items.Add(Room.GetRoomName(int.Parse(roomIndex)));
            }
        }

        public void ReloadInventory()
        {
            Health_label.Text = Form1.GetPlayerMP().health.ToString();
            Armor_label.Text = Form1.GetPlayerMP().armor.ToString();
            Gold_label.Text = Form1.GetPlayerMP().gold.ToString();

            Inventory_listBox.Items.Clear();
            for (int i = 0; i < Form1.GetPlayerMP().inventory.totalItems; i++)
            {
                Inventory_listBox.Items.Add(Form1.GetPlayerMP().inventory.GetItemName(i));
            }
        }

        private void Countdown_timer_Tick(object sender, EventArgs e)
        {
            totalSeconds--;
            if (totalSeconds < 0)
            {
                if (!roundEndPacketSent)
                {
                    if (Destination_listBox.SelectedItem == null)   // If user hasn't selected a destination to go
                    {
                        Packet04RoundEnd roundEndPacket = new Packet04RoundEnd(Form1.GetPlayerMP().username, Destination_listBox.Items[0].ToString(), Inventory_listBox.SelectedIndex.ToString());
                        roundEndPacket.WriteData(Form1.GetGameClient());
                    }
                    else
                    {
                        Packet04RoundEnd roundEndPacket = new Packet04RoundEnd(Form1.GetPlayerMP().username, Destination_listBox.SelectedItem.ToString(), Inventory_listBox.SelectedIndex.ToString());
                        roundEndPacket.WriteData(Form1.GetGameClient());
                    }
                    roundEndPacketSent = true;
                    if (Form1.GetGameServer() != null)  // If owner of the form is host, make round start button visible
                    {
                        Countdown_button.Visible = true;
                        Countdown_label.Visible = false;
                    }
                }
                Countdown_label.Text = "00 : 00";
                return;
            }
            CalculateTimer();
        }

        private void CalculateTimer()
        {
            int minute = totalSeconds / 60;
            int second = totalSeconds - (minute * 60);
            Countdown_label.Text = minute.ToString() + " : " + second.ToString();
        }

        public void SetTimer()
        {
            totalSeconds = roundTime - 10;
            CalculateTimer();
            roundEndPacketSent = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.CloseForm();
        }

        private void Destination_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (destinationListBoxSelectedItemIndex == Destination_listBox.SelectedIndex)
            {
                Destination_listBox.ClearSelected();    // De-select the selected item
            }
            else
            {
                destinationListBoxSelectedItemIndex = Destination_listBox.SelectedIndex;
            }
        }

        private void Inventory_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inventoryListBoxSelectedItemIndex == Inventory_listBox.SelectedIndex)
            {
                Inventory_listBox.ClearSelected();      // De-select the selected item
            }
            else
            {
                inventoryListBoxSelectedItemIndex = Inventory_listBox.SelectedIndex;
            }
        }
    }
}