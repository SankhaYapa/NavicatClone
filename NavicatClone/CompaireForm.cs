using System;
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
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();

            // Set the connection name (database name) for label1
            label12.Text = selectedSourceDatabase + ".dbo";
            label4.Text = selectedTargetDatabase + ".dbo";

            TreeNode sourceNode = new TreeNode("Source Database: " + selectedSourceDatabase);
            TreeNode targetNode = new TreeNode("Target Database: " + selectedTargetDatabase);

            sourceNode.Nodes.AddRange(GetTablesForDatabase(selectedSourceDatabase, "Source").ToArray());
            targetNode.Nodes.AddRange(GetTablesForDatabase(selectedTargetDatabase, "Target").ToArray());

            treeView1.Nodes.Add(sourceNode);
            treeView2.Nodes.Add(targetNode);

            sourceNode.Expand();
            targetNode.Expand();
        }
        /*
        16835354
        0212
        1100
        */

        private List<TreeNode> GetTablesForDatabase(string databaseName, string prefix)
        {
            List<TreeNode> tableNodes = new List<TreeNode>();

            // Build a connection string for the selected database
            string connectionString = $"Data Source=DESKTOP-PAKMRAE\\SQLEXPRESS;Initial Catalog={databaseName};Integrated Security=True";

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

                        // Assign the name of the first table to label1

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





        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null) // Check if it's a child node representing a table
            {
                string tableName = e.Node.Text.Split(':')[1].Trim();

                // Build a connection string for the selected source database
                string connectionString = $"Data Source=DESKTOP-PAKMRAE\\SQLEXPRESS;Initial Catalog={selectedSourceDatabase};Integrated Security=True";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand($"SELECT OBJECT_DEFINITION(OBJECT_ID(N'{tableName}'))", sqlConnection);
                        string creationQuery = command.ExecuteScalar()?.ToString();

                        // Display the creation query in textBox1
                        textBox1.Text = creationQuery;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        // Similarly, you can handle treeView2_NodeMouseClick for the target database.
        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null) // Check if it's a child node representing a table
            {
                string tableName = e.Node.Text.Split(':')[1].Trim();

                // Build a connection string for the selected target database
                string connectionString = $"Data Source=DESKTOP-PAKMRAE\\SQLEXPRESS;Initial Catalog={selectedTargetDatabase};Integrated Security=True";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand($"SELECT OBJECT_DEFINITION(OBJECT_ID(N'{tableName}'))", sqlConnection);
                        string creationQuery = command.ExecuteScalar()?.ToString();

                        // Display the creation query in textBox2
                        textBox2.Text = creationQuery;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }
    }
}
