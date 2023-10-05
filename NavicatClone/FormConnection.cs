using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavicatClone
{
    public partial class FormConnection : Form

    {
        public string ConnectionName { get; private set; }
        public string Host { get; private set; }
        public string InitialDatabase { get; private set; }
        public string AuthenticationType { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public FormConnection()
        {
            InitializeComponent();
            AuthenticationComboBox.Items.Add("Windows Authentication");
            AuthenticationComboBox.Items.Add("SQL Authentication");
            AuthenticationComboBox.SelectedIndex = 0;
        }



        private void connect_ok_Click(object sender, EventArgs e)
        {
            if(AuthenticationComboBox.SelectedItem.ToString() == "Windows Authentication")
            {
                if (string.IsNullOrEmpty(ConnectionNameTextBox.Text) ||
                string.IsNullOrEmpty(HostTextBox.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Don't proceed if any field is empty
                }
                // If all required fields are filled, proceed with the connection setup
                ConnectionName = ConnectionNameTextBox.Text;
                Host = HostTextBox.Text;
                AuthenticationType = AuthenticationComboBox.SelectedItem.ToString();

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (AuthenticationComboBox.SelectedItem.ToString() == "SQL Authentication")
                {
                    // Check if any of the required fields are empty
                    if (string.IsNullOrEmpty(ConnectionNameTextBox.Text) ||
                        string.IsNullOrEmpty(HostTextBox.Text) ||
                        string.IsNullOrEmpty(InitialDatabaseTextBox.Text) ||
                        string.IsNullOrEmpty(UsernameTextBox.Text) ||
                        string.IsNullOrEmpty(PasswordTextBox.Text))
                    {
                        MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Don't proceed if any field is empty
                    }

                    // If all required fields are filled, proceed with the connection setup
                    ConnectionName = ConnectionNameTextBox.Text;
                    Host = HostTextBox.Text;
                    InitialDatabase = InitialDatabaseTextBox.Text;
                    AuthenticationType = AuthenticationComboBox.SelectedItem.ToString();
                    Username = UsernameTextBox.Text;
                    Password = PasswordTextBox.Text;

                    this.DialogResult = DialogResult.OK;
                }
            }
          


        }


        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AuthenticationComboBox_SelectedIndexChange(object sender, EventArgs e)
        {
            string selectedAuthentication = AuthenticationComboBox.SelectedItem.ToString();

            if (selectedAuthentication == "Windows Authentication")
            {
                label8.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                InitialDatabaseTextBox.Visible = false;
                UsernameTextBox.Visible = false;
                PasswordTextBox.Visible = false;
            }
            else
            {
                label8.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                InitialDatabaseTextBox.Visible = true;
                UsernameTextBox.Visible = true;
                PasswordTextBox.Visible = true;
            }
        }
    }
}
