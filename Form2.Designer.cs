namespace RPG
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChatMenu_tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ChatSend_textBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Players_listBox = new System.Windows.Forms.ListBox();
            this.Players_label = new System.Windows.Forms.Label();
            this.Chat_textBox = new System.Windows.Forms.TextBox();
            this.ChatMenu_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatMenu_tabControl
            // 
            this.ChatMenu_tabControl.Controls.Add(this.tabPage1);
            this.ChatMenu_tabControl.Controls.Add(this.tabPage2);
            this.ChatMenu_tabControl.Location = new System.Drawing.Point(145, 0);
            this.ChatMenu_tabControl.Name = "ChatMenu_tabControl";
            this.ChatMenu_tabControl.SelectedIndex = 0;
            this.ChatMenu_tabControl.Size = new System.Drawing.Size(353, 341);
            this.ChatMenu_tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.Chat_textBox);
            this.tabPage1.Controls.Add(this.ChatSend_textBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(345, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // ChatSend_textBox
            // 
            this.ChatSend_textBox.Location = new System.Drawing.Point(7, 264);
            this.ChatSend_textBox.MaxLength = 128;
            this.ChatSend_textBox.Multiline = true;
            this.ChatSend_textBox.Name = "ChatSend_textBox";
            this.ChatSend_textBox.Size = new System.Drawing.Size(332, 45);
            this.ChatSend_textBox.TabIndex = 1;
            this.ChatSend_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatSend_textBox_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(345, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(139, 341);
            this.panel1.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Location = new System.Drawing.Point(3, 143);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(133, 35);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Location = new System.Drawing.Point(3, 108);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 35);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(3, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(3, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Players_listBox
            // 
            this.Players_listBox.FormattingEnabled = true;
            this.Players_listBox.Location = new System.Drawing.Point(505, 21);
            this.Players_listBox.Name = "Players_listBox";
            this.Players_listBox.Size = new System.Drawing.Size(115, 316);
            this.Players_listBox.TabIndex = 3;
            // 
            // Players_label
            // 
            this.Players_label.AutoSize = true;
            this.Players_label.Location = new System.Drawing.Point(505, 3);
            this.Players_label.Name = "Players_label";
            this.Players_label.Size = new System.Drawing.Size(61, 13);
            this.Players_label.TabIndex = 4;
            this.Players_label.Text = "Oyuncular :";
            // 
            // Chat_textBox
            // 
            this.Chat_textBox.Location = new System.Drawing.Point(7, 7);
            this.Chat_textBox.Multiline = true;
            this.Chat_textBox.Name = "Chat_textBox";
            this.Chat_textBox.ReadOnly = true;
            this.Chat_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Chat_textBox.Size = new System.Drawing.Size(332, 251);
            this.Chat_textBox.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 341);
            this.Controls.Add(this.Players_label);
            this.Controls.Add(this.Players_listBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ChatMenu_tabControl);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ChatMenu_tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl ChatMenu_tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label Players_label;
        public System.Windows.Forms.ListBox Players_listBox;
        public System.Windows.Forms.TextBox ChatSend_textBox;
        public System.Windows.Forms.TextBox Chat_textBox;
    }
}