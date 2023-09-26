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

                    //Use the connection details as needed
                    // For example, you can establish a database connection here
                    // Example: SqlConnection sqlConnection = new SqlConnection(connectionString);
                }
            }
        }
    }
}