namespace NavicatClone
{
    partial class FormConnection
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
            label1 = new Label();
            ConnectionNameTextBox = new TextBox();
            label2 = new Label();
            InitialDatabaseTextBox = new TextBox();
            label3 = new Label();
            HostTextBox = new TextBox();
            label4 = new Label();
            UsernameTextBox = new TextBox();
            label5 = new Label();
            PasswordTextBox = new TextBox();
            label6 = new Label();
            connect_ok = new Button();
            cancel_btn = new Button();
            AuthenticationComboBox = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 62);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 0;
            label1.Text = "Connection Name";
            // 
            // ConnectionNameTextBox
            // 
            ConnectionNameTextBox.Location = new Point(151, 55);
            ConnectionNameTextBox.Name = "ConnectionNameTextBox";
            ConnectionNameTextBox.Size = new Size(284, 27);
            ConnectionNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 191);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 2;
            label2.Text = "AuthenticationType";
            // 
            // InitialDatabaseTextBox
            // 
            InitialDatabaseTextBox.Location = new Point(151, 142);
            InitialDatabaseTextBox.Name = "InitialDatabaseTextBox";
            InitialDatabaseTextBox.Size = new Size(284, 27);
            InitialDatabaseTextBox.TabIndex = 5;
            InitialDatabaseTextBox.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 149);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 4;
            label3.Text = "InitialDatabase";
            label3.Visible = false;
            // 
            // HostTextBox
            // 
            HostTextBox.Location = new Point(151, 100);
            HostTextBox.Name = "HostTextBox";
            HostTextBox.Size = new Size(284, 27);
            HostTextBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 107);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 6;
            label4.Text = "Host";
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(151, 229);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(284, 27);
            UsernameTextBox.TabIndex = 9;
            UsernameTextBox.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 236);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 8;
            label5.Text = "Username";
            label5.Visible = false;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(151, 275);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(284, 27);
            PasswordTextBox.TabIndex = 11;
            PasswordTextBox.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 282);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 10;
            label6.Text = "Password";
            label6.Visible = false;
            // 
            // connect_ok
            // 
            connect_ok.Location = new Point(243, 536);
            connect_ok.Name = "connect_ok";
            connect_ok.Size = new Size(94, 29);
            connect_ok.TabIndex = 12;
            connect_ok.Text = "Ok";
            connect_ok.UseVisualStyleBackColor = true;
            connect_ok.Click += connect_ok_Click;
            // 
            // cancel_btn
            // 
            cancel_btn.Location = new Point(343, 536);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(94, 29);
            cancel_btn.TabIndex = 13;
            cancel_btn.Text = "Cancel";
            cancel_btn.UseVisualStyleBackColor = true;
            // 
            // AuthenticationComboBox
            // 
            AuthenticationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AuthenticationComboBox.FormattingEnabled = true;
            AuthenticationComboBox.Location = new Point(151, 188);
            AuthenticationComboBox.Name = "AuthenticationComboBox";
            AuthenticationComboBox.Size = new Size(284, 28);
            AuthenticationComboBox.TabIndex = 14;
            // 
            // FormConnection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(447, 577);
            Controls.Add(AuthenticationComboBox);
            Controls.Add(cancel_btn);
            Controls.Add(connect_ok);
            Controls.Add(PasswordTextBox);
            Controls.Add(label6);
            Controls.Add(UsernameTextBox);
            Controls.Add(label5);
            Controls.Add(HostTextBox);
            Controls.Add(label4);
            Controls.Add(InitialDatabaseTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ConnectionNameTextBox);
            Controls.Add(label1);
            Name = "FormConnection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormConnection";
            Load += FormConnection_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ConnectionNameTextBox;
        private Label label2;
        private TextBox InitialDatabaseTextBox;
        private Label label3;
        private TextBox HostTextBox;
        private Label label4;
        private TextBox UsernameTextBox;
        private Label label5;
        private TextBox PasswordTextBox;
        private Label label6;
        private Button connect_ok;
        private Button cancel_btn;
        private ComboBox AuthenticationComboBox;
    }
}