using RolePlayMP.src;
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
        private int totalSeconds = 1;

        public Form2()
        {
            InitializeComponent();

            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

            Room.InitMap();
            ReloadMap();
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

        private void Countdown_button_Click(object sender, EventArgs e)
        {
            // Starts the round
            Packet03RoundStart roundStartPacket = new Packet03RoundStart();
            roundStartPacket.WriteData(Form1.GetGameServer());

            //totalSeconds = 3 * 60;
            //CalculateTimer();

            Countdown_button.Visible = false;
            Countdown_label.Visible = true;

            //Countdown_timer.Start();
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

        private void Countdown_timer_Tick(object sender, EventArgs e)
        {
            totalSeconds--;
            if (totalSeconds < 0)
            {
                // Send packet to server
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
            totalSeconds = 3 * 60 - 10;
            CalculateTimer();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.CloseForm();
        }
    }
}