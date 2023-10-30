using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

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

			label1.Text = sourceHost;
			label2.Text = targetHost;
			label12.Text = selectedSourceDatabase + ".dbo";
			label4.Text = selectedTargetDatabase + ".dbo";

			TreeNode sourceNode = new TreeNode("Source Database: " + selectedSourceDatabase);
			TreeNode targetNode = new TreeNode("Target Database: " + selectedTargetDatabase);



			List<TreeNode> sourceTables = GetTablesForDatabase(selectedSourceDatabase, "Source", sourceHost);
			List<TreeNode> targetTables = GetTablesForDatabase(selectedTargetDatabase, "Target", targetHost);
			List<TreeNode> sourceProcedures = GetProceduresForDatabase(selectedSourceDatabase, "Source", sourceHost);
			List<TreeNode> targetProcedures = GetProceduresForDatabase(selectedTargetDatabase, "Target", targetHost);


			sourceNode.Nodes.AddRange(sourceTables.ToArray());
			targetNode.Nodes.AddRange(targetTables.ToArray());

			sourceNode.Nodes.AddRange(sourceProcedures.ToArray());
			targetNode.Nodes.AddRange(targetProcedures.ToArray());

			treeView1.Nodes.Add(sourceNode);
			treeView2.Nodes.Add(targetNode);


			// Expand the nodes with matching table names
			ExpandMatchingTableNodes(sourceNode, targetNode);

			sourceNode.Expand();
			targetNode.Expand();
		}

		private void ExpandMatchingTableNodes(TreeNode sourceNode, TreeNode targetNode)
		{
			foreach (TreeNode sourceTableNode in sourceNode.Nodes)
			{
				if (sourceTableNode.Tag is string sourceTableName)
				{
					foreach (TreeNode targetTableNode in targetNode.Nodes)
					{
						if (targetTableNode.Tag is string targetTableName && sourceTableName == targetTableName)
						{
							sourceTableNode.Expand();
							targetTableNode.Expand();
						}
					}
				}
			}
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

            if (selectedNode.Tag is string procedureName)
            {
                // It's a stored procedure node
                string procedureCode = GetStoredProcedureCode(procedureName, selectedSourceDatabase);
                textBox1.Text = procedureCode;

                // Find the matching stored procedure node in the target tree and set its code in textBox2
                TreeNode matchingNode = FindMatchingStoredProcedureNode(selectedNode, treeView2.Nodes);
                if (matchingNode != null)
                {
                    string matchingProcedureName = matchingNode.Tag as string;
                    string matchingProcedureCode = GetStoredProcedureCode(matchingProcedureName, selectedTargetDatabase);
                    textBox2.Text = matchingProcedureCode;
                }
                else
                {
                    textBox2.Clear();
                }
            }
            else if (selectedNode.Tag is string tableName)
            {
                // It's a table node
                LoadTableSqlQuery(selectedNode, textBox1, selectedSourceTables, true); // Pass true for source database

                // Find the corresponding table in the target tree and set its SQL query in textBox2
                TreeNode matchingNode = FindMatchingTableNode(selectedNode, treeView2.Nodes);
                if (matchingNode != null)
                {
                    LoadTableSqlQuery(matchingNode, textBox2, selectedTargetTables, false); // Pass false for target database
                }
                else
                {
                    textBox2.Clear();
                }
            }
            else
            {
                // Handle other node types as needed
            }
        }



		private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
		{
			//TreeNode selectedNode = e.Node;
			//// For target tables
			//LoadTableSqlQuery(selectedNode, textBox2, selectedTargetTables, false); // Pass false for target database

			//// Find the corresponding table in the target tree and set its SQL query in textBox2
			//TreeNode matchingNode = FindMatchingTableNode(selectedNode, treeView1.Nodes);
			//if (matchingNode != null)
			//{
			//	// For target tables
			//	LoadTableSqlQuery(selectedNode, textBox1, selectedTargetTables, true); // Pass false for target database

			//}

			//else
			//{
			//	textBox1.Clear();
			//}

			//if (selectedNode.Tag is string procedureName)
			//{
			//	// Fetch the stored procedure code and display it in a text box
			//	string procedureCode = GetStoredProcedureCode(procedureName, selectedTargetDatabase);
			//	textBox2.Text = procedureCode;
			//}

		}

		private string GetStoredProcedureCode(string procedureName, string databaseName)
        {
            string connectionString = $"Data Source={sourceHost};Initial Catalog={databaseName};Integrated Security=True;MultipleActiveResultSets=True";
            string query = $"SELECT definition FROM {databaseName}.sys.sql_modules WHERE object_id = OBJECT_ID('{procedureName}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }

            return "Stored procedure not found or empty.";
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
        private TreeNode FindMatchingStoredProcedureNode(TreeNode sourceNode, TreeNodeCollection targetNodes)
        {
            if (sourceNode.Tag is string sourceProcedureName)
            {
                foreach (TreeNode targetNode in targetNodes)
                {
                    if (targetNode.Tag is string targetProcedureName && sourceProcedureName == targetProcedureName)
                    {
                        return targetNode;
                    }

                    TreeNode matchingChildNode = FindMatchingStoredProcedureNode(sourceNode, targetNode.Nodes);
                    if (matchingChildNode != null)
                    {
                        return matchingChildNode;
                    }
                }
            }

            return null;
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









		private List<TreeNode> GetProceduresForDatabase(string databaseName, string prefix, string con)
		{

			List<TreeNode> procedureNodes = new List<TreeNode>();

			// Replace the host name in the connection string with "DESKTOP-UKUD1D5"
			string connectionString = $"Data Source={con};Initial Catalog={databaseName};Integrated Security=True;MultipleActiveResultSets=True";
			// Replace 'username' and 'password' with actual values if needed

			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				try
				{
					sqlConnection.Open();
					SqlCommand proceduresCommand = new SqlCommand($"SELECT name FROM {databaseName}.sys.procedures", sqlConnection);
					using (SqlDataReader reader = proceduresCommand.ExecuteReader()) // Use 'using' here
					{
						while (reader.Read())
						{
							string procedureName = reader["name"].ToString();
							TreeNode procedureNode = new TreeNode(prefix + " Procedure: " + procedureName);
							procedureNode.Tag = procedureName; // Store table name in the tag



							procedureNodes.Add(procedureNode);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error: {ex.Message}");
				}
			}

			return procedureNodes;
		}






        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView2.SelectedNode != null)
            {
                TreeNode selectedNode1 = treeView1.SelectedNode;
                TreeNode selectedNode2 = treeView2.SelectedNode;

                if (selectedNode1.Tag is string sourceObjectName && selectedNode2.Tag is string targetObjectName)
                {
                    string selectedConnectionName1 = selectedSourceDatabase;
                    string selectedConnectionName2 = selectedTargetDatabase;

                    // Check if the selected object is a table or a stored procedure
                    if (selectedNode1.Text.StartsWith("Source Table"))
                    {
                        // Generate the ALTER TABLE SQL statement for tables
                        string alterTableSql = GenerateAlterTableSql(sourceObjectName, targetObjectName);

                        if (!string.IsNullOrEmpty(alterTableSql))
                        {
                            // Show the ALTER TABLE SQL in AlterTableCompareForm
                            using (AlterTableCompaireForm alterTableCompareForm = new AlterTableCompaireForm(selectedSourceDatabase, selectedTargetDatabase))
                            {
                                alterTableCompareForm.SetAlterTableSql(alterTableSql); // Pass the SQL statement
                                alterTableCompareForm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No differences found in tables.");
                        }
                    }
                    else if (selectedNode1.Text.StartsWith("Source Procedure"))
                    {
                        // Generate the UPDATE PROCEDURE SQL statement for stored procedures
                        string updateProcedureSql = GenerateUpdateProcedureSql(sourceObjectName, targetObjectName);

                        if (!string.IsNullOrEmpty(updateProcedureSql))
                        {
                            // Show the UPDATE PROCEDURE SQL in UpdateProcedureCompareForm
                            using (UpdateProcedureCompareForm updateProcedureCompareForm = new UpdateProcedureCompareForm(selectedSourceDatabase, selectedTargetDatabase))
                            {
                                updateProcedureCompareForm.SetUpdateProcedureSql(updateProcedureSql); // Pass the SQL statement
                                updateProcedureCompareForm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No differences found in stored procedures.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select tables or stored procedures to compare.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select valid objects to compare.");
                }
            }
            else
            {
                MessageBox.Show("Please select objects to compare.");
            }
        }


        private string GenerateAlterTableSql(string sourceTableName, string targetTableName)
		{
			// Get the column names and data types for the source and target tables
			List<string> sourceColumnsAndTypes = GetColumnNamesAndTypesForTable(selectedSourceDatabase, sourceTableName);
			List<string> targetColumnsAndTypes = GetColumnNamesAndTypesForTable(selectedTargetDatabase, targetTableName);

			// Find missing columns in the target table
			List<string> missingColumnsInTarget = sourceColumnsAndTypes.Except(targetColumnsAndTypes).ToList();
			List<string> missingColumnsInSource = targetColumnsAndTypes.Except(sourceColumnsAndTypes).ToList();

			// Generate the ALTER TABLE SQL statement
			string alterTableSql = "";

			if (missingColumnsInTarget.Count > 0)
			{
				// Add columns to the target table
				alterTableSql = $"ALTER TABLE [{targetTableName}]\n";
				foreach (string missingColumn in missingColumnsInTarget)
				{
					alterTableSql += $" ADD {missingColumn},";
				}

				// Remove the trailing comma
				alterTableSql = alterTableSql.TrimEnd(',') + ";";
			}

			if (missingColumnsInSource.Count > 0)
			{
				// Remove columns from the target table
				if (!string.IsNullOrEmpty(alterTableSql))
				{
					alterTableSql += "\n"; // Add a newline if we already added columns.
				}
				else
				{
					alterTableSql = $"ALTER TABLE {targetTableName}\n";
				}

				foreach (string missingColumn in missingColumnsInSource)
				{
					string columnName = missingColumn.Split(' ')[0]; // Extract the column name
					alterTableSql += $" DROP COLUMN {columnName},";
				}

				// Remove the trailing comma
				alterTableSql = alterTableSql.TrimEnd(',') + ";";
			}

			if (string.IsNullOrEmpty(alterTableSql))
			{
				alterTableSql = "No missing columns found.";
			}

			return alterTableSql;
		}



        private string GenerateUpdateProcedureSql(string sourceProcedureName, string targetProcedureName)
        {
            // Fetch the stored procedure code from both databases
            string sourceProcedureCode = GetStoredProcedureCode(sourceProcedureName, selectedSourceDatabase);
            string targetProcedureCode = GetStoredProcedureCode(targetProcedureName, selectedTargetDatabase);

            // Compare the source and target procedure code to check for differences
            if (sourceProcedureCode != targetProcedureCode)
            {
                // If differences exist, generate the UPDATE PROCEDURE SQL statement
                return $"UPDATE PROCEDURE {targetProcedureName} AS\n{sourceProcedureCode}";
            }
            else
            {
                return string.Empty; // No differences found
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
        public void ExecuteUpdateProcedureSql(string updateProcedureSql)
        {
            try
            {
                // Create a SqlConnection to the target database where you want to execute the UPDATE PROCEDURE SQL statement
                string targetConnectionString = $"Data Source={targetHost};Initial Catalog={selectedTargetDatabase};Integrated Security=True;MultipleActiveResultSets=True";
                using (SqlConnection targetConnection = new SqlConnection(targetConnectionString))
                {
                    targetConnection.Open();

                    // Create a SqlCommand with the UPDATE PROCEDURE SQL statement
                    using (SqlCommand command = new SqlCommand(updateProcedureSql, targetConnection))
                    {
                        // Execute the SQL command
                        command.ExecuteNonQuery();
                        MessageBox.Show("UPDATE PROCEDURE SQL executed successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during execution
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
