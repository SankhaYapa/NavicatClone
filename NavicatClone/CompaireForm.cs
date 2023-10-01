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

        public CompaireForm(string selectedSourceDatabase, string selectedTargetDatabase)
        {
            InitializeComponent();
            this.selectedSourceDatabase = selectedSourceDatabase;
            this.selectedTargetDatabase = selectedTargetDatabase;
            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            sourceTreeView.Nodes.Clear();
            targetTreeView.Nodes.Clear();

            TreeNode sourceNode = new TreeNode("Source Database: " + selectedSourceDatabase);
            TreeNode targetNode = new TreeNode("Target Database: " + selectedTargetDatabase);

            sourceNode.Nodes.AddRange(GetTablesForDatabase(selectedSourceDatabase, "Source").ToArray());
            targetNode.Nodes.AddRange(GetTablesForDatabase(selectedTargetDatabase, "Target").ToArray());

            sourceTreeView.Nodes.Add(sourceNode);
            targetTreeView.Nodes.Add(targetNode);

            sourceNode.Expand();
            targetNode.Expand();
        }

        private List<TreeNode> GetTablesForDatabase(string databaseName, string prefix)
        {
            List<TreeNode> tableNodes = new List<TreeNode>();

            // Build a connection string for the selected database
            string connectionString = $"Data Source={selectedSourceDatabase};Initial Catalog={databaseName};Integrated Security=True";

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
                        tableNodes.Add(new TreeNode(prefix + " Table: " + tableName));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            return tableNodes;
        }
    }
}
