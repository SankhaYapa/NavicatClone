namespace NavicatClone
{
    partial class UpdateProcedureCompareForm
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
            textBoxUpdateProcedureSql = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBoxUpdateProcedureSql
            // 
            textBoxUpdateProcedureSql.Location = new Point(12, 59);
            textBoxUpdateProcedureSql.Multiline = true;
            textBoxUpdateProcedureSql.Name = "textBoxUpdateProcedureSql";
            textBoxUpdateProcedureSql.Size = new Size(776, 296);
            textBoxUpdateProcedureSql.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(694, 409);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Execute";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnExecuteUpdateProcedure_Click;
            // 
            // UpdateProcedureCompareForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBoxUpdateProcedureSql);
            Name = "UpdateProcedureCompareForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateProcedureCompareForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUpdateProcedureSql;
        private Button button1;
    }
}