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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
            initCombo();
        }

        private void initCombo()
        {
            cmbFrom.SelectedIndex = 0;
            cmbTo.SelectedIndex = 0;
            cmbClass.SelectedIndex = 0;
            cmbTicket.SelectedIndex = 0;
            dTPicker.Text = Convert.ToString(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            panelBook.Visible = false;
        }
        //DateTime selectDate;
        private void button1_Click(object sender, EventArgs e)
        {
            if(cmbFrom.Text == cmbTo.Text)
            {
                MessageBox.Show("Both cities are same!!!!");
            }
            else
            {
                this.timer1.Start();
                progressBar1.Visible = false;

                panelBook.Visible = true;
                textBox2.Text = cmbFrom.Text;
                textBox3.Text = cmbTo.Text;
                txtDate.Text = Convert.ToString(dTPicker.Text);
                
            }
            
        }
       
        private void btnReset_Click(object sender, EventArgs e)
        {
            initCombo();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            var s = new Random(1000);
            int a =s.Next(1000, 9999);
            MessageBox.Show("Flight has been booked with Order# " + a);
        }

        private void Booking_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            this.Hide();
            Login l1 =new Login();l1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            this.progressBar1.Increment(1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void cmbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbFrom_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.cmbFrom, "Enter Source City");
        }
    }
}
