using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NavicatClone
{
    public partial class SyncronizationForm : Form
    {
        private List<ConnectionDetails> connections;

        public string SelectedSourceConnection
        {
            get { return sourceComboBox.SelectedItem as string; }
        }

        public string SelectedTargetConnection
        {
            get { return targetComboBox.SelectedItem as string; }
        }

        public SyncronizationForm(List<ConnectionDetails> connections)
        {
            InitializeComponent();
            this.connections = connections;
            PopulateComboBoxes();
            sourceComboBox.SelectedIndexChanged += SourceComboBox_SelectedIndexChanged;
            targetComboBox.SelectedIndexChanged += TargetComboBox_SelectedIndexChanged;
        }

        private void PopulateComboBoxes()
        {
            foreach (var connection in connections)
            {
                sourceComboBox.Items.Add(connection.ConnectionName);
                targetComboBox.Items.Add(connection.ConnectionName);
            }
        }

        private void SourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceDatabaseComboBox.Items.Clear();
            string selectedConnectionName = SelectedSourceConnection;

            if (string.IsNullOrEmpty(selectedConnectionName))
            {
                return;
            }

            connectionName.Text = selectedConnectionName;
            ConnectionDetails selectedConnection = connections.Find(c => c.ConnectionName == selectedConnectionName);

            if (selectedConnection == null)
            {
                return;
            }

            string connectionString = "";

            if (selectedConnection.AuthenticationType == "Windows Authentication")
            {
                connectionString = $"Data Source={selectedConnection.Host};Initial Catalog=master;Integrated Security=True";
                HostLabel.Text = selectedConnection.Host;
                label25.Text = selectedConnection.AuthenticationType;

            }
            else
            {
                connectionString = $"Data Source={selectedConnection.Host};Initial Catalog=master;User ID={selectedConnection.Username};Password={selectedConnection.Password}";
                HostLabel.Text = selectedConnection.Host;
                label25.Text = selectedConnection.AuthenticationType;
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string dbName = reader["name"].ToString();
                        sourceDatabaseComboBox.Items.Add(dbName);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void TargetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetDatabaseComboBox.Items.Clear();
            string selectedConnectionName = SelectedTargetConnection;

            if (string.IsNullOrEmpty(selectedConnectionName))
            {
                return;
            }

            connectionTName.Text = selectedConnectionName;
            ConnectionDetails selectedConnection = connections.Find(c => c.ConnectionName == selectedConnectionName);

            if (selectedConnection == null)
            {
                return;
            }

            string connectionString = "";

            if (selectedConnection.AuthenticationType == "Windows Authentication")
            {
                connectionString = $"Data Source={selectedConnection.Host};Initial Catalog=master;Integrated Security=True";
                label26.Text = selectedConnection.Host;
                label27.Text = selectedConnection.AuthenticationType;

            }
            else
            {
                connectionString = $"Data Source={selectedConnection.Host};Initial Catalog=master;User ID={selectedConnection.Username};Password={selectedConnection.Password}";
                label26.Text = selectedConnection.Host;
                label27.Text = selectedConnection.AuthenticationType;
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string dbName = reader["name"].ToString();
                        targetDatabaseComboBox.Items.Add(dbName);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

 


        private string GetSelectedSourceDatabase()
        {
            return sourceDatabaseComboBox.SelectedItem as string;
        }

        private string GetSelectedTargetDatabase()
        {
            return targetDatabaseComboBox.SelectedItem as string;
        }

        private void Compaire_btn_Click(object sender, EventArgs e)
        {
            string selectedSourceDatabase = GetSelectedSourceDatabase();
            string selectedTargetDatabase = GetSelectedTargetDatabase();

            if (string.IsNullOrEmpty(selectedSourceDatabase) || string.IsNullOrEmpty(selectedTargetDatabase))
            {
                MessageBox.Show("Please select source and target databases.");
                return;
            }

            using (CompaireForm compaireForm = new CompaireForm(selectedSourceDatabase, selectedTargetDatabase))
            {
                compaireForm.ShowDialog();
            }
        }

    }
}
