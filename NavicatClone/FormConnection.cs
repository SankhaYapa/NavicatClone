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
            ConnectionName = ConnectionNameTextBox.Text;
            Host = HostTextBox.Text;
            // InitialDatabase = InitialDatabaseTextBox.Text;
            AuthenticationType = AuthenticationComboBox.SelectedItem.ToString();
            // Username = UsernameTextBox.Text;
            // Password = PasswordTextBox.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void AuthenticationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAuthentication = AuthenticationComboBox.SelectedItem.ToString();

            // Check if the selected authentication type is "Windows Authentication"
            if (selectedAuthentication == "Windows Authentication")
            {
                // Hide the labels and input fields
                label5.Visible = false;
                label6.Visible = false;
                UsernameTextBox.Visible = false;
                PasswordTextBox.Visible = false;
                label3.Visible = false;
                InitialDatabaseTextBox.Visible = false;
            }
            else
            {
                // Show the labels and input fields for SQL Authentication
                label5.Visible = true;
                label6.Visible = true;
                UsernameTextBox.Visible = true;
                PasswordTextBox.Visible = true;
                label3.Visible = true;
                InitialDatabaseTextBox.Visible = true;
            }
        }


    }
}
