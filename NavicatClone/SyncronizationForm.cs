using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

//DESKTOP-ADDF7PF\MSSQL

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
			string selectedConnectionName1 = SelectedSourceConnection;
			string selectedConnectionName2 = SelectedTargetConnection;

			ConnectionDetails selectedConnection1 = connections.Find(c => c.ConnectionName == selectedConnectionName1);
			ConnectionDetails selectedConnection2 = connections.Find(c => c.ConnectionName == selectedConnectionName2);

			if (selectedConnection1 == null || selectedConnection2 == null)
			{
				MessageBox.Show("Connection details not found for the selected database.");
				return;
			}

			// Pass host information to the CompaireForm
			string sourceHost = selectedConnection1.Host;
			string targetHost = selectedConnection2.Host;
			MessageBox.Show($"Source Host - {sourceHost}\nTarget Host - {targetHost}", "Host Information");



			// Open the CompaireForm with the selected source and target databases and host information.
			using (CompaireForm compaireForm = new CompaireForm(selectedSourceDatabase, selectedTargetDatabase, sourceHost, targetHost))
			{
				compaireForm.ShowDialog();
			}
		}
	}
}
