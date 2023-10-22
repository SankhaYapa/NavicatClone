using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace NavicatClone
{
	public partial class Form1 : Form
	{
		private List<ConnectionDetails> connections = new List<ConnectionDetails>();

		public Form1(string connectionString)
		{
			InitializeComponent();
			// Load the appsettings.json configuration
			if (!string.IsNullOrEmpty(connectionString))
			{
				// The connection string is provided, attempt to establish the connection
				SqlConnection sqlConnection = new SqlConnection(connectionString);

				try
				{
					sqlConnection.Open();

					// You can proceed with your database operations here
					// For example, you can populate the TreeView with database information

					// Create a TreeNode for the connectionName as the root node
					TreeNode connectionNode = new TreeNode("Connected Database");

					// Fetch the list of databases
					SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", sqlConnection);
					SqlDataReader reader = command.ExecuteReader();

					// Add the connectionNode as a child node in the TreeView
					treeView1.Nodes.Add(connectionNode);

					// Add retrieved database names as child nodes to the connectionNode
					while (reader.Read())
					{
						string dbName = reader["name"].ToString();

						// Create a new TreeNode for the database name
						TreeNode dbNode = new TreeNode(dbName);

						// Add the database node to the connectionNode
						connectionNode.Nodes.Add(dbNode);

						// You can also add further child nodes or details here if needed
					}

					reader.Close();
				}
				catch (Exception ex)
				{
					// Handle connection errors here
					MessageBox.Show($"Error: {ex.Message}");
				}
				finally
				{
					// Don't forget to close the connection when done
					sqlConnection.Close();
				}
			}

		}


		private void ConnectButton_Click(object sender, EventArgs e)
		{
			using (FormConnection connectionForm = new FormConnection())
			{
				if (connectionForm.ShowDialog() == DialogResult.OK)
				{
					// Retrieve the connection details from the connectionForm instance
					ConnectionDetails connectionDetails = new ConnectionDetails
					{
						ConnectionName = connectionForm.ConnectionName,
						Host = connectionForm.Host,
						InitialDatabase = connectionForm.InitialDatabase,
						AuthenticationType = connectionForm.AuthenticationType,
						Username = connectionForm.Username,
						Password = connectionForm.Password
					};

					// Add the connection details to the list
					connections.Add(connectionDetails);

					// Build the connection string based on the user's input
					string connectionString = "";

					if (connectionDetails.AuthenticationType == "Windows Authentication")
					{
						// Windows Authentication
						connectionString = $"Data Source={connectionDetails.Host};Initial Catalog={connectionDetails.InitialDatabase};Integrated Security=True";
					}
					else
					{
						// SQL Server Authentication
						connectionString = $"Data Source={connectionDetails.Host};Initial Catalog={connectionDetails.InitialDatabase};User ID={connectionDetails.Username};Password={connectionDetails.Password}";
					}

					// Establish a database connection
					SqlConnection sqlConnection = new SqlConnection(connectionString);

					try
					{
						sqlConnection.Open();

						// Create a TreeNode for the connectionName as the root node
						TreeNode connectionNode = new TreeNode(connectionDetails.ConnectionName);


						// Fetch the list of databases
						SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", sqlConnection);
						SqlDataReader reader = command.ExecuteReader();

						// Add the connectionNode as a child node in the TreeView
						treeView1.Nodes.Add(connectionNode);

						// Add retrieved database names as child nodes to the connectionNode
						while (reader.Read())
						{
							string dbName = reader["name"].ToString();

							// Create a new TreeNode for the database name
							TreeNode dbNode = new TreeNode(dbName);

							// Add the database node to the connectionNode
							connectionNode.Nodes.Add(dbNode);

							// You can also add further child nodes or details here if needed
						}

						reader.Close();
					}
					catch (Exception ex)
					{
						// Handle connection errors here
						MessageBox.Show($"Error: {ex.Message}");
					}
					finally
					{
						// Don't forget to close the connection when done
						sqlConnection.Close();
					}
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (SyncronizationForm synchronizeForm = new SyncronizationForm(connections))
			{
				if (synchronizeForm.ShowDialog() == DialogResult.OK)
				{
					// Handle synchronization here using the selected source and target connections
					string sourceConnectionName = synchronizeForm.SelectedSourceConnection;
					string targetConnectionName = synchronizeForm.SelectedTargetConnection;


					// You can use the selected connection names to perform synchronization tasks
				}
			}
		}

	}

	// Define a class to represent connection details
	public class ConnectionDetails
	{
		public string ConnectionName { get; set; }
		public string Host { get; set; }
		public string InitialDatabase { get; set; }
		public string AuthenticationType { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}
}