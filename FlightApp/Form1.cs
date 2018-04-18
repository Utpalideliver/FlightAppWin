using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FlightApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\utpal\.jenkins\workspace\Build_Generate_WIth_UnitTesting\FlightEXE\FlightApp\FlightApp.accdb");
       public bool DoLogin(String username_text, String password_text)
        {
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from [login]", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows[0]["username"].ToString() == username_text && ds.Tables[0].Rows[0]["password"].ToString() == password_text)
            {
                Booking book = new Booking();
                this.Hide();
                book.Show();
                con.Close();
                return true;
            }
            else
            {
                MessageBox.Show("Wrong Credential!!");
                con.Close();
                return false;
            }
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //con.Open();
            //OleDbDataAdapter da = new OleDbDataAdapter("Select * from [login]", con);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //if (ds.Tables[0].Rows[0]["username"].ToString() == txtUser.Text && ds.Tables[0].Rows[0]["password"].ToString() == txtPass.Text)
            //{
            //    Booking book = new Booking();
            //    this.Hide();
            //    book.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Wrong Credential!!");
            //}
            //con.Close();
            string user, pass;
            user = txtUser.Text;
            pass = txtPass.Text;
            DoLogin(user, pass);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            

        }

        private void txtUser_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip8 = new ToolTip();
            toolTip8.SetToolTip(this.txtUser, "Enter User Name");
        }

        private void txtPass_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip8 = new ToolTip();
            toolTip8.SetToolTip(this.txtPass, "Enter Password");
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip8 = new ToolTip();
            toolTip8.SetToolTip(this.btnLogin, "Click Login button");
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip8 = new ToolTip();
            toolTip8.SetToolTip(this.btnClose, "Click Close button");
        }
    }
}
