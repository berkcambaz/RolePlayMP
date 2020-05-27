using RolePlayMP.src;
using RPG.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ChatMenu_tabControl.Appearance = TabAppearance.FlatButtons;
            ChatMenu_tabControl.ItemSize = new Size(0, 1);
            ChatMenu_tabControl.SizeMode = TabSizeMode.Fixed;
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

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.CloseForm();
        }
    }
}