namespace NavicatClone
{
    partial class SyncronizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncronizationForm));
            panel1 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            label24 = new Label();
            label23 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            sourceComboBox = new ComboBox();
            sourceDatabaseComboBox = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label7 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            targetDatabaseComboBox = new ComboBox();
            targetComboBox = new ComboBox();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            pictureBox1 = new PictureBox();
            connectionName = new Label();
            connectionTName = new Label();
            Compaire_btn = new Button();
            label25 = new Label();
            HostLabel = new Label();
            label26 = new Label();
            label27 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label24);
            panel1.Controls.Add(label23);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1182, 79);
            panel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.right_arroW;
            pictureBox4.Location = new Point(578, 39);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(25, 18);
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(667, 31);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(36, 36);
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(477, 31);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 36);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(716, 31);
            label24.Name = "label24";
            label24.Size = new Size(117, 20);
            label24.TabIndex = 1;
            label24.Text = "Target Database";
            label24.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(350, 31);
            label23.Name = "label23";
            label23.Size = new Size(121, 20);
            label23.TabIndex = 0;
            label23.Text = "Source Database";
            label23.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 101);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 1;
            label1.Text = "Source";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 142);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 2;
            label2.Text = "Connection";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 227);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 3;
            label3.Text = "Database";
            // 
            // sourceComboBox
            // 
            sourceComboBox.FormattingEnabled = true;
            sourceComboBox.Location = new Point(60, 175);
            sourceComboBox.Name = "sourceComboBox";
            sourceComboBox.Size = new Size(464, 28);
            sourceComboBox.TabIndex = 4;
            // 
            // sourceDatabaseComboBox
            // 
            sourceDatabaseComboBox.FormattingEnabled = true;
            sourceDatabaseComboBox.Location = new Point(60, 263);
            sourceDatabaseComboBox.Name = "sourceDatabaseComboBox";
            sourceDatabaseComboBox.Size = new Size(464, 28);
            sourceDatabaseComboBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(673, 101);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 6;
            label4.Text = "Target";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(673, 142);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 7;
            label5.Text = "Connection";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(673, 227);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 9;
            label6.Text = "Database";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(78, 374);
            label8.Name = "label8";
            label8.Size = new Size(95, 20);
            label8.TabIndex = 12;
            label8.Text = "Cloud Name:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Blue;
            label7.Location = new Point(78, 327);
            label7.Name = "label7";
            label7.Size = new Size(87, 20);
            label7.TabIndex = 11;
            label7.Text = "Information";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(78, 407);
            label9.Name = "label9";
            label9.Size = new Size(102, 20);
            label9.TabIndex = 13;
            label9.Text = "Project Name:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(78, 441);
            label10.Name = "label10";
            label10.Size = new Size(122, 20);
            label10.TabIndex = 14;
            label10.Text = "Connection Type:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(78, 478);
            label11.Name = "label11";
            label11.Size = new Size(131, 20);
            label11.TabIndex = 15;
            label11.Text = "Connection Name:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(78, 515);
            label12.Name = "label12";
            label12.Size = new Size(43, 20);
            label12.TabIndex = 16;
            label12.Text = "Host:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(78, 550);
            label13.Name = "label13";
            label13.Size = new Size(38, 20);
            label13.TabIndex = 17;
            label13.Text = "Port:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(78, 585);
            label14.Name = "label14";
            label14.Size = new Size(105, 20);
            label14.TabIndex = 18;
            label14.Text = "Server Version:";
            // 
            // targetDatabaseComboBox
            // 
            targetDatabaseComboBox.FormattingEnabled = true;
            targetDatabaseComboBox.Location = new Point(667, 263);
            targetDatabaseComboBox.Name = "targetDatabaseComboBox";
            targetDatabaseComboBox.Size = new Size(464, 28);
            targetDatabaseComboBox.TabIndex = 20;
            // 
            // targetComboBox
            // 
            targetComboBox.FormattingEnabled = true;
            targetComboBox.Location = new Point(667, 175);
            targetComboBox.Name = "targetComboBox";
            targetComboBox.Size = new Size(464, 28);
            targetComboBox.TabIndex = 19;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(702, 585);
            label15.Name = "label15";
            label15.Size = new Size(105, 20);
            label15.TabIndex = 28;
            label15.Text = "Server Version:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(702, 550);
            label16.Name = "label16";
            label16.Size = new Size(38, 20);
            label16.TabIndex = 27;
            label16.Text = "Port:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(702, 515);
            label17.Name = "label17";
            label17.Size = new Size(43, 20);
            label17.TabIndex = 26;
            label17.Text = "Host:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(702, 478);
            label18.Name = "label18";
            label18.Size = new Size(131, 20);
            label18.TabIndex = 25;
            label18.Text = "Connection Name:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(702, 441);
            label19.Name = "label19";
            label19.Size = new Size(122, 20);
            label19.TabIndex = 24;
            label19.Text = "Connection Type:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(702, 407);
            label20.Name = "label20";
            label20.Size = new Size(102, 20);
            label20.TabIndex = 23;
            label20.Text = "Project Name:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(702, 374);
            label21.Name = "label21";
            label21.Size = new Size(95, 20);
            label21.TabIndex = 22;
            label21.Text = "Cloud Name:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.ForeColor = Color.Blue;
            label22.Location = new Point(702, 327);
            label22.Name = "label22";
            label22.Size = new Size(87, 20);
            label22.TabIndex = 21;
            label22.Text = "Information";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.swap;
            pictureBox1.Location = new Point(580, 227);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 41);
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // connectionName
            // 
            connectionName.AutoSize = true;
            connectionName.Location = new Point(215, 478);
            connectionName.Name = "connectionName";
            connectionName.Size = new Size(21, 20);
            connectionName.TabIndex = 30;
            connectionName.Text = "--";
            // 
            // connectionTName
            // 
            connectionTName.AutoSize = true;
            connectionTName.Location = new Point(839, 478);
            connectionTName.Name = "connectionTName";
            connectionTName.Size = new Size(21, 20);
            connectionTName.TabIndex = 31;
            connectionTName.Text = "--";
            // 
            // Compaire_btn
            // 
            Compaire_btn.Location = new Point(1037, 645);
            Compaire_btn.Name = "Compaire_btn";
            Compaire_btn.Size = new Size(94, 29);
            Compaire_btn.TabIndex = 32;
            Compaire_btn.Text = "Compair";
            Compaire_btn.UseVisualStyleBackColor = true;
            Compaire_btn.Click += Compaire_btn_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(216, 445);
            label25.Name = "label25";
            label25.Size = new Size(15, 20);
            label25.TabIndex = 33;
            label25.Text = "-";
            // 
            // HostLabel
            // 
            HostLabel.AutoSize = true;
            HostLabel.Location = new Point(128, 517);
            HostLabel.Name = "HostLabel";
            HostLabel.Size = new Size(21, 20);
            HostLabel.TabIndex = 34;
            HostLabel.Text = "--";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(830, 441);
            label26.Name = "label26";
            label26.Size = new Size(21, 20);
            label26.TabIndex = 35;
            label26.Text = "--";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(751, 517);
            label27.Name = "label27";
            label27.Size = new Size(21, 20);
            label27.TabIndex = 36;
            label27.Text = "--";
            // 
            // SyncronizationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1182, 686);
            Controls.Add(label27);
            Controls.Add(label26);
            Controls.Add(HostLabel);
            Controls.Add(label25);
            Controls.Add(Compaire_btn);
            Controls.Add(connectionTName);
            Controls.Add(connectionName);
            Controls.Add(pictureBox1);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(label18);
            Controls.Add(label19);
            Controls.Add(label20);
            Controls.Add(label21);
            Controls.Add(label22);
            Controls.Add(targetDatabaseComboBox);
            Controls.Add(targetComboBox);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(sourceDatabaseComboBox);
            Controls.Add(sourceComboBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "SyncronizationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SyncronizationForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox sourceComboBox;
        private ComboBox sourceDatabaseComboBox;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label7;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private ComboBox targetDatabaseComboBox;
        private ComboBox targetComboBox;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private PictureBox pictureBox1;
        private Label label24;
        private Label label23;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label connectionName;
        private Label connectionTName;
        private Button Compaire_btn;
        private Label label25;
        private Label HostLabel;
        private Label label26;
        private Label label27;
    }
}