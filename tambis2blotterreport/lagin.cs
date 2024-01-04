using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tambis2blotterreport
{
    public partial class lagin : Form
    {
        public lagin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "admin" && txtPass.Text == "berondo")
            {
               HOME db = new HOME();
                this.Hide();
                db.Show();
            }
            else
            {
                MessageBox.Show("The username or password you entered is incorrect, try again !");
                txtUser.Clear();
                txtPass.Clear();
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}
