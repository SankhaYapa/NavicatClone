
using System.Data.SqlClient;

namespace NavicatClone
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

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
                        // Connection is now open, you can perform database operations here

                        // Don't forget to close the connection when done
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle connection errors here
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }
    }
}