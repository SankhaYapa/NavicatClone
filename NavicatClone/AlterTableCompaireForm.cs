using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NavicatClone
{
	public partial class AlterTableCompaireForm : Form
	{

		private string selectedSourceDatabase;
		private string selectedTargetDatabase;
		private string alterTableSql;
		public AlterTableCompaireForm(string selectedSourceDatabase, string selectedTargetDatabase)
		{
			InitializeComponent();
			this.selectedSourceDatabase = selectedSourceDatabase;
			this.selectedTargetDatabase = selectedTargetDatabase;

		}
		public void SetAlterTableSql(string alterTableSql)
		{
			this.alterTableSql = alterTableSql;
			textBoxAlterTableSql.Text = alterTableSql;

			label12.Text = selectedSourceDatabase + ".dbo";
			label4.Text = selectedTargetDatabase + ".dbo";
		}

		private void btnExecuteAlterTable_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(alterTableSql))
			{
				// Find the CompaireForm instance by name
				CompaireForm compaireForm = Application.OpenForms["CompaireForm"] as CompaireForm;

				if (compaireForm != null)
				{
					// Execute the ALTER TABLE SQL statement from CompaireForm
					compaireForm.ExecuteAlterTableSql(alterTableSql);
				}
				this.Close(); // Close this form after executing the query
			}
			else
			{
				MessageBox.Show("No ALTER TABLE SQL statement to execute.");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
