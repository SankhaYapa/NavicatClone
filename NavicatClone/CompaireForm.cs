using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NavicatClone
{
    public partial class CompaireForm : Form
    {
        private string selectedSourceDatabase;
        private string selectedTargetDatabase;
        private List<ConnectionDetails> connections;

        public CompaireForm(string selectedSourceDatabase, string selectedTargetDatabase, List<ConnectionDetails> connections)
        {
            InitializeComponent();
            this.selectedSourceDatabase = selectedSourceDatabase;
            this.selectedTargetDatabase = selectedTargetDatabase;
            this.connections = connections;
            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            sourceTreeView.Nodes.Clear();
            targetTreeView.Nodes.Clear();

            if (string.IsNullOrEmpty(selectedSourceDatabase))
            {
                MessageBox.Show("Please select a source database.");
                return;
            }

            string selectedConnectionName = selectedSourceDatabase; // Replace with your actual logic for getting the selected connection name

            ConnectionDetails selectedConnection = connections.Find(c => c.ConnectionName == selectedConnectionName);

            if (selectedConnection == null)
            {
                MessageBox.Show("Selected connection details not found.");
                return;
            }

            string connectionString = "";

            if (selectedConnection.AuthenticationType == "Windows Authentication")
            {
                connectionString = $"Data Source={selectedConnection.Host};Initial Catalog={selectedSourceDatabase};Integrated Security=True";
            }
            else
            {
                connectionString = $"Data Source={selectedConnection.Host};Initial Catalog={selectedSourceDatabase};User ID={selectedConnection.Username};Password={selectedConnection.Password}";
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string tableName = reader["TABLE_NAME"].ToString();
                        sourceTreeView.Nodes.Add(new TreeNode("Source Table: " + tableName));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            
        }

       
    }
}
