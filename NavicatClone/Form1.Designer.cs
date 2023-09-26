namespace NavicatClone
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ConnectButton = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            treeView1 = new TreeView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // ConnectButton
            // 
            ConnectButton.Image = Properties.Resources.link__3_;
            ConnectButton.ImageAlign = ContentAlignment.TopCenter;
            ConnectButton.Location = new Point(12, 12);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Padding = new Padding(0, 5, 0, 5);
            ConnectButton.Size = new Size(127, 61);
            ConnectButton.TabIndex = 0;
            ConnectButton.Text = "Connection";
            ConnectButton.TextAlign = ContentAlignment.BottomCenter;
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(ConnectButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1279, 82);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(treeView1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 667);
            panel2.TabIndex = 2;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(250, 667);
            treeView1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1279, 749);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Navicat Clone";
           
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button ConnectButton;
        private Panel panel1;
        private Panel panel2;
        private TreeView treeView1;
    }
}