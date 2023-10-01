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
            panel1 = new Panel();
            sourceTreeView = new TreeView();
            panel2 = new Panel();
            targetTreeView = new TreeView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(sourceTreeView);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(385, 532);
            panel1.TabIndex = 0;
            // 
            // sourceTreeView
            // 
            sourceTreeView.Dock = DockStyle.Fill;
            sourceTreeView.Location = new Point(0, 0);
            sourceTreeView.Name = "sourceTreeView";
            sourceTreeView.Size = new Size(385, 532);
            sourceTreeView.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(targetTreeView);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(387, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(413, 532);
            panel2.TabIndex = 1;
            // 
            // targetTreeView
            // 
            targetTreeView.Dock = DockStyle.Fill;
            targetTreeView.Location = new Point(0, 0);
            targetTreeView.Name = "targetTreeView";
            targetTreeView.Size = new Size(413, 532);
            targetTreeView.TabIndex = 0;
            // 
            // CompaireForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 532);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CompaireForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CompaireForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TreeView sourceTreeView;
        private Panel panel2;
        private TreeView targetTreeView;
    }
}