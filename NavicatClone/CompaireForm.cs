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
        private string sourceHost;
        private string targetHost;

        public CompaireForm(string selectedSourceDatabase, string selectedTargetDatabase, string sourceHost, string targetHost)
        {
            InitializeComponent();
            this.selectedSourceDatabase = selectedSourceDatabase;
            this.selectedTargetDatabase = selectedTargetDatabase;
            this.sourceHost = sourceHost;
            this.targetHost = targetHost;
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

        private List<TreeNode> GetTablesForDatabase(string databaseName, string prefix)
        {
            List<TreeNode> tableNodes = new List<TreeNode>();

            // Replace the host name in the connection string with "DESKTOP-UKUD1D5"
            string connectionString = $"Data Source={sourceHost};Initial Catalog={databaseName};Integrated Security=True;MultipleActiveResultSets=True";
            // Replace 'username' and 'password' with actual values if needed

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", sqlConnection);
                    using (SqlDataReader reader = command.ExecuteReader()) // Use 'using' here
                    {
                        while (reader.Read())
                        {
                            string tableName = reader["TABLE_NAME"].ToString();
                            TreeNode tableNode = new TreeNode(prefix + " Table: " + tableName);
                            tableNode.Tag = new CheckBox { Text = tableName }; // Add CheckBox to the tableNode

                            // Retrieve column names for the table
                            List<string> columnNames = GetColumnNamesForTable(sqlConnection, tableName);
                            foreach (string columnName in columnNames)
                            {
                                tableNode.Nodes.Add(new TreeNode("Column: " + columnName));
                            }

                            tableNodes.Add(tableNode);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            return tableNodes;
        }

        private List<string> GetColumnNamesForTable(SqlConnection connection, string tableName)
        {
            List<string> columnNames = new List<string>();

            try
            {
                SqlCommand command = new SqlCommand($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", connection);
                using (SqlDataReader reader = command.ExecuteReader()) // Use 'using' here
                {
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        columnNames.Add(columnName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return columnNames;
        }

        private void LoadTableSqlQuery(TreeNode tableNode, TextBox textBox)
        {
            // Check if the selected node has a CheckBox control (assuming it's a table node)
            if (tableNode.Tag is CheckBox checkBox)
            {
                // Get the table name from the CheckBox text
                string tableName = checkBox.Text;
                // Construct the SQL query to create the table
                string sqlQuery = $"CREATE TABLE {tableName} (\n";

                // Retrieve column names and types for the table
                List<string> columnNamesAndTypes = GetColumnNamesAndTypesForTable(tableName);

                // Add column definitions to the SQL query
                foreach (string column in columnNamesAndTypes)
                {
                    sqlQuery += $"    {column},\n";
                }

                // Remove the trailing comma and newline
                sqlQuery = sqlQuery.TrimEnd(',', '\n');

                // Add the closing parenthesis
                sqlQuery += "\n);";

                // Display the SQL query in the TextBox
                textBox.Text = sqlQuery;
            }
        }

        private List<string> GetColumnNamesAndTypesForTable(string tableName)
        {
            List<string> columnNamesAndTypes = new List<string>();

            // Replace the host name in the connection string with "DESKTOP-UKUD1D5"
            string connectionString = $"Data Source={sourceHost};Initial Catalog={selectedSourceDatabase};Integrated Security=True;MultipleActiveResultSets=True";
            // Replace 'username' and 'password' with actual values if needed

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand($"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", sqlConnection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();
                            string dataType = reader["DATA_TYPE"].ToString();
                            columnNamesAndTypes.Add($"{columnName} {dataType}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            return columnNamesAndTypes;
        }


        private TreeNode FindMatchingTableNode(TreeNode sourceNode, TreeNodeCollection targetNodes)
        {
            foreach (TreeNode targetNode in targetNodes)
            {
                if (targetNode.Tag is CheckBox targetCheckBox)
                {
                    string sourceTableName = sourceNode.Text; // Use Text property of sourceNode
                    string targetTableName = targetCheckBox.Text;

                    if (sourceTableName == targetTableName)
                    {
                        return targetNode;
                    }
                }

                TreeNode matchingChildNode = FindMatchingTableNode(sourceNode, targetNode.Nodes);
                if (matchingChildNode != null)
                {
                    return matchingChildNode;
                }
            }

            return null;
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            LoadTableSqlQuery(selectedNode, textBox1);

            TreeNode matchingNode = FindMatchingTableNode(selectedNode, treeView2.Nodes);
            if (matchingNode != null)
            {
                LoadTableSqlQuery(matchingNode, textBox2);
            }
            else
            {
                textBox2.Clear();
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Handle the AfterSelect event for treeView2 (assuming this is the treeView for target database)
            TreeNode selectedNode = e.Node;
            LoadTableSqlQuery(selectedNode, textBox2);
        }

        // The rest of your code remains the same.
    }
}
