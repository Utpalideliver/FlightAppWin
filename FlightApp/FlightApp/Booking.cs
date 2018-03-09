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
            dTPicker.MinDate = DateTime.Now;
            dTPicker.Value = DateTime.Now;
            panelBook.Visible = false;
        }
        //DateTime selectDate;
        private void button1_Click(object sender, EventArgs e)
        {
            panelBook.Visible = true;
            txtDate.Text = Convert.ToString(dTPicker.Value);
            
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
            Application.Exit();
        }
    }
}
