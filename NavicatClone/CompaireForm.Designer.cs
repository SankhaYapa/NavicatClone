namespace NavicatClone
{
    partial class CompaireForm
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
            panel3 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1182, 100);
            panel3.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(840, 65);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 6;
            label4.Text = "test2.dbo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(338, 65);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 5;
            label3.Text = "test1.dbo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(840, 32);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 4;
            label2.Text = "test_4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(362, 32);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 3;
            label1.Text = "test_3";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(676, 23);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(125, 62);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(453, 23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 62);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.right_arroW;
            pictureBox1.Location = new Point(616, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(23, 22);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 1;
            // 
            // CompaireForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1182, 686);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "CompaireForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CompairForm";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TreeView sourceTreeView;
        private Panel panel2;
        private TreeView targetTreeView;
        private Panel panel3;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
    }
}