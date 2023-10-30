using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavicatClone
{
    public partial class UpdateProcedureCompareForm : Form
    {
        private string selectedSourceDatabase;
        private string selectedTargetDatabase;
        private string updateProcedureSql;

        public UpdateProcedureCompareForm(string selectedSourceDatabase, string selectedTargetDatabase)
        {
            InitializeComponent();
            this.selectedSourceDatabase = selectedSourceDatabase;
            this.selectedTargetDatabase = selectedTargetDatabase;
        }

        public void SetUpdateProcedureSql(string updateProcedureSql)
        {
            this.updateProcedureSql = updateProcedureSql;
            textBoxUpdateProcedureSql.Text = updateProcedureSql;

            //label12.Text = selectedSourceDatabase + ".dbo";
            //label4.Text = selectedTargetDatabase + ".dbo";
        }

        private void btnExecuteUpdateProcedure_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(updateProcedureSql))
            {
                // Find the CompaireForm instance by name
                CompaireForm compaireForm = Application.OpenForms["CompaireForm"] as CompaireForm;

                if (compaireForm != null)
                {
                    // Execute the UPDATE PROCEDURE SQL statement from CompaireForm
                    compaireForm.ExecuteUpdateProcedureSql(updateProcedureSql);
                }
                this.Close(); // Close this form after executing the query
            }
            else
            {
                MessageBox.Show("No UPDATE PROCEDURE SQL statement to execute.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
