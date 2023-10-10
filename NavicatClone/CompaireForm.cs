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

            sourceNode.Nodes.AddRange(GetTablesForDatabase(selectedSourceDatabase, "Source", sourceHost).ToArray());
            targetNode.Nodes.AddRange(GetTablesForDatabase(selectedTargetDatabase, "Target", targetHost).ToArray());

            treeView1.Nodes.Add(sourceNode);
            treeView2.Nodes.Add(targetNode);

            sourceNode.Expand();
            targetNode.Expand();
        }

        private List<TreeNode> GetTablesForDatabase(string databaseName, string prefix, string con)
        {
            List<TreeNode> tableNodes = new List<TreeNode>();

            // Replace the host name in the connection string with "DESKTOP-UKUD1D5"
            string connectionString = $"Data Source={con};Initial Catalog={databaseName};Integrated Security=True;MultipleActiveResultSets=True";
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
                            tableNode.Tag = tableName; // Store table name in the tag


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

        private Dictionary<string, string> selectedSourceTables = new Dictionary<string, string>();
        private Dictionary<string, string> selectedTargetTables = new Dictionary<string, string>();


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            // For source tables
            LoadTableSqlQuery(selectedNode, textBox1, selectedSourceTables, true); // Pass true for source database


            // Find the corresponding table in the target tree and set its SQL query in textBox2
            TreeNode matchingNode = FindMatchingTableNode(selectedNode, treeView2.Nodes);
            if (matchingNode != null)
            {
                // For target tables
                LoadTableSqlQuery(selectedNode, textBox2, selectedTargetTables, false); // Pass false for target database

            }
            else
            {
                textBox2.Clear();
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            // For target tables
            LoadTableSqlQuery(selectedNode, textBox2, selectedTargetTables, false); // Pass false for target database

            // Find the corresponding table in the target tree and set its SQL query in textBox2
            TreeNode matchingNode = FindMatchingTableNode(selectedNode, treeView1.Nodes);
            if (matchingNode != null)
            {
                // For target tables
                LoadTableSqlQuery(selectedNode, textBox1, selectedTargetTables, true); // Pass false for target database

            }
            else
            {
                textBox1.Clear();
            }

        }



        private void LoadTableSqlQuery(TreeNode tableNode, TextBox textBox, Dictionary<string, string> selectedTables, bool isSourceDatabase)
        {
            // Check if the selected node has a table name in the tag
            if (tableNode.Tag is string tableName)
            {
                // Construct the SQL query to create the table
                string sqlQuery = $"CREATE TABLE {tableName} (\n";

                // Retrieve column names and types for the table based on the database source
                List<string> columnNamesAndTypes = GetColumnNamesAndTypesForTable(tableName, isSourceDatabase);

                // Add column definitions to the SQL query
                foreach (string column in columnNamesAndTypes)
                {
                    sqlQuery += $"    {column},\n";
                }

                // Remove the trailing comma and newline
                sqlQuery = sqlQuery.TrimEnd(',', '\n');

                // Add the closing parenthesis
                sqlQuery += "\n);";

                // Add the selected table and its SQL query to the appropriate dictionary
                selectedTables[tableName] = sqlQuery;

                // Display the SQL query in the TextBox
                textBox.Text = sqlQuery;
            }
        }


        private List<string> GetColumnNamesAndTypesForTable(string tableName, bool isSourceDatabase)
        {
            List<string> columnNamesAndTypes = new List<string>();

            // Determine the connection string based on the database source
            string connectionString = isSourceDatabase
                ? $"Data Source={sourceHost};Initial Catalog={selectedSourceDatabase};Integrated Security=True;MultipleActiveResultSets=True"
                : $"Data Source={targetHost};Initial Catalog={selectedTargetDatabase};Integrated Security=True;MultipleActiveResultSets=True";
            // Replace 'username' and 'password' with actual values if needed

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand($"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", sqlConnection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();
                            string dataType = reader["DATA_TYPE"].ToString();
                            string characterMaximumLength = reader["CHARACTER_MAXIMUM_LENGTH"].ToString();
                            string columnAndType;

                            // Include the character maximum length if available
                            if (!string.IsNullOrEmpty(characterMaximumLength))
                            {
                                columnAndType = $"{columnName} {dataType}({characterMaximumLength})";
                            }
                            else
                            {
                                columnAndType = $"{columnName} {dataType}";
                            }

                            columnNamesAndTypes.Add(columnAndType);
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
            if (sourceNode.Tag is string sourceTableName)
            {
                foreach (TreeNode targetNode in targetNodes)
                {
                    if (targetNode.Tag is string targetTableName && sourceTableName == targetTableName)
                    {
                        return targetNode;
                    }

                    TreeNode matchingChildNode = FindMatchingTableNode(sourceNode, targetNode.Nodes);
                    if (matchingChildNode != null)
                    {
                        return matchingChildNode;
                    }
                }
            }

            return null;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Get the selected table names from the dictionaries
            string sourceTableName = selectedSourceTables.Keys.FirstOrDefault();
            string targetTableName = selectedTargetTables.Keys.FirstOrDefault();

            if (!string.IsNullOrEmpty(sourceTableName) && !string.IsNullOrEmpty(targetTableName))
            {
                // Generate the ALTER TABLE SQL statement
                string alterTableSql = GenerateAlterTableSql(sourceTableName, targetTableName);

                // Show the ALTER TABLE SQL in AlterTableCompaireForm
                using (AlterTableCompaireForm alterTableCompareForm = new AlterTableCompaireForm())
                {
                    alterTableCompareForm.SetAlterTableSql(alterTableSql); // Pass the SQL statement
                    alterTableCompareForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select tables to compare.");
            }
        }


        private string GenerateAlterTableSql(string sourceTableName, string targetTableName)
        {
            // Get the column names and data types for the source and target tables
            List<string> sourceColumnsAndTypes = GetColumnNamesAndTypesForTable(selectedSourceDatabase, sourceTableName);
            List<string> targetColumnsAndTypes = GetColumnNamesAndTypesForTable(selectedTargetDatabase, targetTableName);

            // Find missing columns in the target table
            List<string> missingColumns = new List<string>();
            foreach (string sourceColumnAndType in sourceColumnsAndTypes)
            {
                // Check if the source column exists in the target columns
                if (!targetColumnsAndTypes.Contains(sourceColumnAndType))
                {
                    missingColumns.Add(sourceColumnAndType);
                }
            }

            // Generate the ALTER TABLE SQL statement
            if (missingColumns.Count > 0)
            {
                string alterTableSql = $"ALTER TABLE {targetTableName}\n";

                foreach (string missingColumn in missingColumns)
                {
                    alterTableSql += $" ADD {missingColumn},\n";
                }

                // Remove the trailing comma and newline
                alterTableSql = alterTableSql.TrimEnd(',', '\n');

                return alterTableSql;
            }
            else
            {
                return "No missing columns found.";
            }
        }

        private List<string> GetColumnNamesAndTypesForTable(string databaseName, string tableName)
        {
            List<string> columnNamesAndTypes = new List<string>();

            string connectionString = $"Data Source={sourceHost};Initial Catalog={databaseName};Integrated Security=True;MultipleActiveResultSets=True";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand($"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", sqlConnection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();
                            string dataType = reader["DATA_TYPE"].ToString();
                            string characterMaximumLength = reader["CHARACTER_MAXIMUM_LENGTH"].ToString();
                            string columnAndType;

                            // Include the character maximum length if available
                            if (!string.IsNullOrEmpty(characterMaximumLength))
                            {
                                columnAndType = $"{columnName} {dataType}({characterMaximumLength})";
                            }
                            else
                            {
                                columnAndType = $"{columnName} {dataType}";
                            }

                            columnNamesAndTypes.Add(columnAndType);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception gracefully, e.g., log it or show an error message.
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            return columnNamesAndTypes;
        }

        public void ExecuteAlterTableSql(string alterTableSql)
        {
            try
            {
                // Create a SqlConnection to the target database where you want to execute the ALTER TABLE query
                string targetConnectionString = $"Data Source={targetHost};Initial Catalog={selectedTargetDatabase};Integrated Security=True;MultipleActiveResultSets=True";
                using (SqlConnection targetConnection = new SqlConnection(targetConnectionString))
                {
                    targetConnection.Open();

                    // Create a SqlCommand with the ALTER TABLE SQL statement
                    using (SqlCommand command = new SqlCommand(alterTableSql, targetConnection))
                    {
                        // Execute the SQL command
                        command.ExecuteNonQuery();
                        MessageBox.Show("ALTER TABLE query executed successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during execution
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // The rest of your code remains the same.
    }
}
