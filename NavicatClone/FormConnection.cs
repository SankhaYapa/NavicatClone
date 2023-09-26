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
            AuthenticationComboBox.SelectedIndex = 0;
        }

        private void FormConnection_Load(object sender, EventArgs e)
        {

        }

        private void connect_ok_Click(object sender, EventArgs e)
        {
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
