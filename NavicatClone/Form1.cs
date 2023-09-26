using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NavicatClone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            using (FormConnection connectionForm = new FormConnection())
            {
                if (connectionForm.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve the connection details from the connectionForm instance
                    string connectionName = connectionForm.ConnectionName;
                    string host = connectionForm.Host;
                    string initialDatabase = connectionForm.InitialDatabase;
                    string authenticationType = connectionForm.AuthenticationType;
                    string username = connectionForm.Username;
                    string password = connectionForm.Password;

                    // Build the connection string based on the user's input
                    string connectionString = "";

                    if (authenticationType == "Windows Authentication")
                    {
                        // Windows Authentication
                        connectionString = $"Data Source={host};Initial Catalog={initialDatabase};Integrated Security=True";
                    }
                    else
                    {
                        // SQL Server Authentication
                        connectionString = $"Data Source={host};Initial Catalog={initialDatabase};User ID={username};Password={password}";
                    }

                    // Establish a database connection
                    SqlConnection sqlConnection = new SqlConnection(connectionString);

                    try
                    {
                        sqlConnection.Open();

                        // Fetch the list of databases
                        SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", sqlConnection);
                        SqlDataReader reader = command.ExecuteReader();

                        // Clear existing nodes in your TreeView
                        treeView1.Nodes.Clear();

                        // Add a root node to the TreeView (optional)
                        TreeNode rootNode = new TreeNode("Databases");
                        treeView1.Nodes.Add(rootNode);

                        // Add retrieved database names as child nodes to the root node or directly to the TreeView
                        while (reader.Read())
                        {
                            string dbName = reader["name"].ToString();

                            // Create a new TreeNode for the database name
                            TreeNode dbNode = new TreeNode(dbName);

                            // Add the database node to the root node or directly to the TreeView
                            treeView1.Nodes.Add(dbNode); // Or rootNode.Nodes.Add(dbNode) if you want to add it under a root node

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

        }
    }
}