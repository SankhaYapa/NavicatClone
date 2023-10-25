using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Xml.Linq;

namespace NavicatClone
{
    public partial class Form1 : Form
    {
        // Define a list to store connection details
        private List<ConnectionDetails> connections = new List<ConnectionDetails>();

        public Form1()
        {
            InitializeComponent();
            LoadConnectionsFromFile();
            PopulateTreeView();

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
                    SaveConnectionsToFile();
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

                        // Add the connectionNode as a child node in the TreeView
                        treeView1.Nodes.Add(connectionNode);

                        // Fetch the list of databases
                        // Fetch the list of databases
                        // Fetch the list of databases
                        // Fetch the list of databases
                        SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", sqlConnection);
                        SqlDataReader reader = command.ExecuteReader();

                        // Add retrieved database names as child nodes to the connectionNode
                        while (reader.Read())
                        {
                            string dbName = reader["name"].ToString();

                            // Create a new TreeNode for the database name
                            TreeNode dbNode = new TreeNode(dbName);

                            // Add "Tables," "Views," and "Functions" nodes as child nodes to the database node
                            TreeNode tablesNode = new TreeNode("Tables");

                            dbNode.Nodes.Add(tablesNode); // Add "Tables" node to the database node

                            // Fetch table names for the current database using a new connection
                            using (SqlConnection tablesConnection = new SqlConnection(connectionString))
                            {
                                tablesConnection.Open();
                                SqlCommand tablesCommand = new SqlCommand($"SELECT name FROM {dbName}.sys.tables", tablesConnection);
                                SqlDataReader tablesReader = tablesCommand.ExecuteReader();

                                // Add retrieved table names as child nodes to the "Tables" node
                                while (tablesReader.Read())
                                {
                                    string tableName = tablesReader["name"].ToString();
                                    TreeNode tableNode = new TreeNode(tableName);
                                    tablesNode.Nodes.Add(tableNode);  // Add table node to "Tables" node
                                }

                                tablesReader.Close(); // Close the tablesReader
                                TreeNode procedureNode = new TreeNode("storedProcedure");
                                dbNode.Nodes.Add(procedureNode);
                                PopulateStoredProcedures(procedureNode, connectionDetails, dbName);
                            }

                            // Add the database node to the connectionNode
                            connectionNode.Nodes.Add(dbNode);
                        }

                        reader.Close(); // Close the reader when done with all iterations


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
        private void PopulateTreeView()
        {
            treeView1.Nodes.Clear(); // Clear existing nodes

            foreach (var connectionDetails in connections)
            {
                TreeNode connectionNode = new TreeNode(connectionDetails.ConnectionName);
                treeView1.Nodes.Add(connectionNode);

                // Add child nodes for databases and their tables
                PopulateDatabases(connectionNode, connectionDetails);
            }
        }


        
        private void PopulateDatabases(TreeNode connectionNode, ConnectionDetails connectionDetails)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionDetails.ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string dbName = reader["name"].ToString();
                        TreeNode dbNode = new TreeNode(dbName);
                        connectionNode.Nodes.Add(dbNode);

                        // Add tables under the database node
                        PopulateTables(dbNode, connectionDetails, dbName);
                    }
                }
                catch (Exception ex)
                {
                    // Handle connection errors here
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void PopulateTables(TreeNode dbNode, ConnectionDetails connectionDetails, string dbName)
        {
            using (SqlConnection tablesConnection = new SqlConnection(connectionDetails.ConnectionString))
            {
                tablesConnection.Open();
                SqlCommand tablesCommand = new SqlCommand($"SELECT name FROM {dbName}.sys.tables", tablesConnection);
                SqlDataReader tablesReader = tablesCommand.ExecuteReader();

                while (tablesReader.Read())
                {
                    string tableName = tablesReader["name"].ToString();
                    TreeNode tableNode = new TreeNode(tableName);
                    dbNode.Nodes.Add(tableNode);
                }

                TreeNode procedureNode = new TreeNode("storedProcedure");
                dbNode.Nodes.Add(procedureNode);
                PopulateStoredProcedures(procedureNode, connectionDetails, dbName);
            }
        }

        private void PopulateStoredProcedures(TreeNode dbNode, ConnectionDetails connectionDetails, string dbName)
        {
            using (SqlConnection procedureConnection = new SqlConnection(connectionDetails.ConnectionString))
            {
                procedureConnection.Open();
                SqlCommand proceduresCommand = new SqlCommand($"SELECT name FROM {dbName}.sys.procedures", procedureConnection);
                SqlDataReader procedureReader = proceduresCommand.ExecuteReader();

                while (procedureReader.Read())
                {
                    string procedureName = procedureReader["name"].ToString();
                    TreeNode procedureNode = new TreeNode(procedureName);
                    dbNode.Nodes.Add(procedureNode);
                }
            }
        }




        private void SaveConnectionsToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(connections);
                string filePath = "./connections.json";
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void LoadConnectionsFromFile()
        {
            try
            {
                string filePath = "./connections.json";

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    connections = JsonConvert.DeserializeObject<List<ConnectionDetails>>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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

        private void Form1_Load(object sender, EventArgs e)
        {

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

        public string ConnectionString
        {
            get
            {
                if (AuthenticationType == "Windows Authentication")
                {
                    return $"Data Source={Host};Initial Catalog={InitialDatabase};Integrated Security=True";
                }
                else
                {
                    return $"Data Source={Host};Initial Catalog={InitialDatabase};User ID={Username};Password={Password}";
                }
            }
        }
    }
}

