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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompaireForm));
            panel3 = new Panel();
            label12 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            treeView1 = new TreeView();
            treeView2 = new TreeView();
            panel4 = new Panel();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label4);
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
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(489, 65);
            label12.Name = "label12";
            label12.RightToLeft = RightToLeft.Yes;
            label12.Size = new Size(21, 20);
            label12.TabIndex = 7;
            label12.Text = "--";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(727, 65);
            label4.Name = "label4";
            label4.Size = new Size(21, 20);
            label4.TabIndex = 6;
            label4.Text = "--";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(727, 32);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 4;
            label2.Text = "test_4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(489, 32);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 3;
            label1.Text = "test_3";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(667, 43);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 42);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(563, 43);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 42);
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
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(0, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(1182, 35);
            panel2.TabIndex = 2;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Location = new Point(666, -1);
            label7.Name = "label7";
            label7.Size = new Size(515, 35);
            label7.TabIndex = 2;
            label7.Text = "Target Object";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Location = new Point(523, 0);
            label6.Name = "label6";
            label6.Size = new Size(149, 33);
            label6.TabIndex = 1;
            label6.Text = "Operation";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Location = new Point(-1, 0);
            label5.Name = "label5";
            label5.Size = new Size(525, 34);
            label5.TabIndex = 0;
            label5.Text = "Source Object";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(0, 144);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(525, 304);
            treeView1.TabIndex = 3;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // treeView2
            // 
            treeView2.Location = new Point(674, 146);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(505, 305);
            treeView2.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Location = new Point(0, 454);
            panel4.Name = "panel4";
            panel4.Size = new Size(1182, 235);
            panel4.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(674, 56);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(505, 151);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(16, 56);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(509, 151);
            textBox1.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(684, 33);
            label11.Name = "label11";
            label11.Size = new Size(52, 20);
            label11.TabIndex = 2;
            label11.Text = "Table2";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 33);
            label10.Name = "label10";
            label10.Size = new Size(52, 20);
            label10.TabIndex = 1;
            label10.Text = "Table1";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 11);
            label9.Name = "label9";
            label9.Size = new Size(122, 20);
            label9.TabIndex = 0;
            label9.Text = "DDL Comparison";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(587, 292);
            label8.Name = "label8";
            label8.Size = new Size(19, 20);
            label8.TabIndex = 7;
            label8.Text = "=";
            // 
            // CompaireForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1182, 686);
            Controls.Add(label8);
            Controls.Add(panel4);
            Controls.Add(treeView2);
            Controls.Add(treeView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "CompaireForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CompareForm";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label6;
        private TreeView treeView1;
        private TreeView treeView2;
        private Label label8;
        private Panel panel4;
        private Label label10;
        private Label label9;
        private Label label11;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label12;
    }
}