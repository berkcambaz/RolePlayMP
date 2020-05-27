namespace RPG
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Join_button = new System.Windows.Forms.Button();
            this.JoinPassword_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.JoinPort_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.JoinIP_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Host_button = new System.Windows.Forms.Button();
            this.HostPort_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HostPassword_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SettingsName_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Join_button);
            this.groupBox1.Controls.Add(this.JoinPassword_textBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.JoinPort_textBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.JoinIP_textBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Join Game";
            // 
            // Join_button
            // 
            this.Join_button.Location = new System.Drawing.Point(10, 140);
            this.Join_button.Name = "Join_button";
            this.Join_button.Size = new System.Drawing.Size(100, 23);
            this.Join_button.TabIndex = 2;
            this.Join_button.Text = "Join";
            this.Join_button.UseVisualStyleBackColor = true;
            this.Join_button.Click += new System.EventHandler(this.Join_button_Click);
            // 
            // JoinPassword_textBox
            // 
            this.JoinPassword_textBox.Location = new System.Drawing.Point(10, 114);
            this.JoinPassword_textBox.Name = "JoinPassword_textBox";
            this.JoinPassword_textBox.Size = new System.Drawing.Size(100, 20);
            this.JoinPassword_textBox.TabIndex = 5;
            this.JoinPassword_textBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Server Password";
            // 
            // JoinPort_textBox
            // 
            this.JoinPort_textBox.Location = new System.Drawing.Point(10, 75);
            this.JoinPort_textBox.Name = "JoinPort_textBox";
            this.JoinPort_textBox.Size = new System.Drawing.Size(100, 20);
            this.JoinPort_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // JoinIP_textBox
            // 
            this.JoinIP_textBox.Location = new System.Drawing.Point(10, 36);
            this.JoinIP_textBox.Name = "JoinIP_textBox";
            this.JoinIP_textBox.Size = new System.Drawing.Size(100, 20);
            this.JoinIP_textBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Host_button);
            this.groupBox2.Controls.Add(this.HostPort_textBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.HostPassword_textBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(252, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Host Game";
            // 
            // Host_button
            // 
            this.Host_button.Location = new System.Drawing.Point(10, 101);
            this.Host_button.Name = "Host_button";
            this.Host_button.Size = new System.Drawing.Size(100, 23);
            this.Host_button.TabIndex = 2;
            this.Host_button.Text = "Host";
            this.Host_button.UseVisualStyleBackColor = true;
            this.Host_button.Click += new System.EventHandler(this.Host_button_Click);
            // 
            // HostPort_textBox
            // 
            this.HostPort_textBox.Location = new System.Drawing.Point(10, 36);
            this.HostPort_textBox.Name = "HostPort_textBox";
            this.HostPort_textBox.Size = new System.Drawing.Size(100, 20);
            this.HostPort_textBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Port";
            // 
            // HostPassword_textBox
            // 
            this.HostPassword_textBox.Location = new System.Drawing.Point(10, 75);
            this.HostPassword_textBox.Name = "HostPassword_textBox";
            this.HostPassword_textBox.Size = new System.Drawing.Size(100, 20);
            this.HostPassword_textBox.TabIndex = 5;
            this.HostPassword_textBox.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Server Password";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SettingsName_textBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(13, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(439, 113);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // SettingsName_textBox
            // 
            this.SettingsName_textBox.Location = new System.Drawing.Point(10, 37);
            this.SettingsName_textBox.MaxLength = 15;
            this.SettingsName_textBox.Name = "SettingsName_textBox";
            this.SettingsName_textBox.Size = new System.Drawing.Size(100, 20);
            this.SettingsName_textBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Player Name";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(464, 321);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPG";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox JoinIP_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Join_button;
        private System.Windows.Forms.TextBox JoinPassword_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox JoinPort_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Host_button;
        private System.Windows.Forms.TextBox HostPassword_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox HostPort_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox SettingsName_textBox;
        private System.Windows.Forms.Label label7;
    }
}

