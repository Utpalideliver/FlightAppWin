using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public bool dologin(String user, String password)
        {
            if (txtUser.Text == user && txtPass.Text == password)
            {
                Booking book = new Booking();
                this.Hide();
                book.Show();
                return true;
            }
            else
            {
                MessageBox.Show("Wrong Credential!!");
                return false;

            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user_text, pass_text;
            user_text = "admin";
            pass_text = "admin";
            dologin(user_text, pass_text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
