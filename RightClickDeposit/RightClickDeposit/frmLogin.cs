using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace org.swordapp.client.windows
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        public string GetUsername()
        {
            return txtUsername.Text;
        }

        public void SetUsername(string username)
        {
            txtUsername.Text = username;
        }

        public string GetPassword()
        {
            return txtPassword.Text;
        }

        public void SetPassword(string password)
        {
            txtPassword.Text = password;
        }
    }
}
