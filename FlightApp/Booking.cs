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
    public partial class Booking : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\utpal\.jenkins\workspace\Build_Generate_WIth_UnitTesting\FlightEXE\FlightApp\FlightApp.accdb");
        public Booking()
        {
            InitializeComponent();
            initCombo();
        }

        private void initCombo()
        {
            dTPicker.Text = Convert.ToString(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            panelBook.Visible = false;
        }
        //DateTime selectDate;
        public bool FlightSearch()
        {
            if (cmbFrom.Text == cmbTo.Text)
            {
                MessageBox.Show("Both cities are same!!!!");
                return false;
            }
            else
            {
                if (cmbTicket.Text == "")
                {
                    MessageBox.Show("Select atleast One Ticket!!!!");
                    return false;
                }
                else
                {
                    this.timer1.Start();
                    panelBook.Visible = true;
                    txtFrom1.Text = cmbFrom.Text;
                    txtTo1.Text = cmbTo.Text;
                    textBox4.Text = cmbFrom.Text;
                    textBox3.Text = cmbTo.Text;
                    textBox9.Text = cmbFrom.Text;
                    textBox8.Text = cmbTo.Text;
                    txtDate1.Text = Convert.ToString(dTPicker.Text);
                    textBox2.Text = Convert.ToString(dTPicker.Text);
                    textBox7.Text = Convert.ToString(dTPicker.Text);
                    cmbFrom.Items.Clear();
                    con.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Price, F1001 from Search_Flight", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    //Price
                    txtPrice1.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    int a = Convert.ToInt32(txtPrice1.Text) * Convert.ToInt32(cmbTicket.Text);
                    txtPrice1.Text = Convert.ToString(a);
                    //Price
                    textBox5.Text = ds.Tables[0].Rows[1]["Price"].ToString();
                    int b = Convert.ToInt32(textBox5.Text) * Convert.ToInt32(cmbTicket.Text);
                    textBox5.Text = Convert.ToString(b);
                    //Price
                    textBox10.Text = ds.Tables[0].Rows[2]["Price"].ToString();
                    int c = Convert.ToInt32(textBox10.Text) * Convert.ToInt32(cmbTicket.Text);
                    textBox10.Text = Convert.ToString(c);
                    //Flight
                    txtFlight1.Text = ds.Tables[0].Rows[0]["F1001"].ToString();
                    //Flight
                    textBox1.Text = ds.Tables[0].Rows[1]["F1001"].ToString();
                    //Flight
                    textBox6.Text = ds.Tables[0].Rows[2]["F1001"].ToString();
                    con.Close();
                    progressBar1.Visible = false;
                    return true;
                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (cmbFrom.Text == cmbTo.Text)
            //{
            //    MessageBox.Show("Both cities are same!!!!");
            //}
            //else
            //{
            //    if (cmbTicket.Text == "")
            //    {
            //        MessageBox.Show("Select atleast One Ticket!!!!");
            //    }
            //    else
            //    {
            //        this.timer1.Start();
            //        panelBook.Visible = true;
            //        txtFrom1.Text = cmbFrom.Text;
            //        txtTo1.Text = cmbTo.Text;
            //        textBox4.Text = cmbFrom.Text;
            //        textBox3.Text = cmbTo.Text;
            //        textBox9.Text = cmbFrom.Text;
            //        textBox8.Text = cmbTo.Text;
            //        txtDate1.Text = Convert.ToString(dTPicker.Text);
            //        textBox2.Text = Convert.ToString(dTPicker.Text);
            //        textBox7.Text = Convert.ToString(dTPicker.Text);
            //        cmbFrom.Items.Clear();
            //        con.Open();
            //        OleDbDataAdapter da = new OleDbDataAdapter("Select Price, F1001 from Search_Flight", con);
            //        DataSet ds = new DataSet();
            //        da.Fill(ds);
            //        //Price
            //        txtPrice1.Text = ds.Tables[0].Rows[0]["Price"].ToString();
            //        int a = Convert.ToInt32(txtPrice1.Text) * Convert.ToInt32(cmbTicket.Text);
            //        txtPrice1.Text = Convert.ToString(a);
            //        //Price
            //        textBox5.Text = ds.Tables[0].Rows[1]["Price"].ToString();
            //        int b = Convert.ToInt32(textBox5.Text) * Convert.ToInt32(cmbTicket.Text);
            //        textBox5.Text = Convert.ToString(b);
            //        //Price
            //        textBox10.Text = ds.Tables[0].Rows[2]["Price"].ToString();
            //        int c = Convert.ToInt32(textBox10.Text) * Convert.ToInt32(cmbTicket.Text);
            //        textBox10.Text = Convert.ToString(c);
            //        //Flight
            //        txtFlight1.Text = ds.Tables[0].Rows[0]["F1001"].ToString();
            //        //Flight
            //        textBox1.Text = ds.Tables[0].Rows[1]["F1001"].ToString();
            //        //Flight
            //        textBox6.Text = ds.Tables[0].Rows[2]["F1001"].ToString();
            //        con.Close();
            //    }

            //}
            //progressBar1.Visible = false;
            FlightSearch();
        }
       
        private void btnReset_Click(object sender, EventArgs e)
        {
            initCombo();
            progressBar1.Visible = false;
        }

        public bool BookSearch(string oneway_text, string order_num, string from_city, string to_city, string ddate, string flight_num)
        {
           
            con.Open();
            if(con.State == ConnectionState.Open)
            {
                string command = "insert into Order_Booking values('" + oneway_text + "', '" + from_city + "', '" + to_city + "', '" + ddate + "', '" + flight_num + "', '" + order_num + "') ";
                OleDbCommand cmdd = new OleDbCommand(command, con);
                cmdd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            else
            {
                MessageBox.Show("Unable to book the order!!!!!!Error");
                return false;
            }
            
        }

        private void btnBook_Click(object sender, EventArgs e)
        {

            
            if ((radioButton1.Checked == false) && (radioButton2.Checked == false) && (radioButton3.Checked == false))
            {
                MessageBox.Show("Select atleast one available Flight!!!!");
            }
            else
            {
                if (oneway.Checked == true)
                {
                    if (radioButton1.Checked == true)
                    {
                        string oneway_text, order_num, from_city, to_city, ddate, flight_num;
                        Random rand1 = new Random();
                        int num1 = rand1.Next(1, 5000);
                        int num2 = rand1.Next(1, 50);
                        int a = num1 + num2;
                        order_num = Convert.ToString(a);
                        oneway_text = oneway.Text;
                        from_city = txtFrom1.Text;
                        to_city = txtTo1.Text;
                        ddate = txtDate1.Text;
                        flight_num = txtFlight1.Text;
                        BookSearch(oneway_text, order_num, from_city, to_city, ddate, flight_num);
                        MessageBox.Show("Flight has been booked with Order# " + a);
                        radioButton1.Checked = false;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        string oneway_text, order_num, from_city, to_city, ddate, flight_num;
                        Random rand1 = new Random();
                        int num1 = rand1.Next(1, 5000);
                        int num2 = rand1.Next(1, 50);
                        int a = num1 + num2;
                        order_num = Convert.ToString(a);
                        oneway_text = oneway.Text;
                        from_city = textBox4.Text;
                        to_city = textBox3.Text;
                        ddate = textBox2.Text;
                        flight_num = textBox1.Text;
                        BookSearch(oneway_text, order_num, from_city, to_city, ddate, flight_num);
                        MessageBox.Show("Flight has been booked with Order# " + a);
                        radioButton2.Checked = false;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        string oneway_text, order_num, from_city, to_city, ddate, flight_num;
                        Random rand1 = new Random();
                        int num1 = rand1.Next(1, 5000);
                        int num2 = rand1.Next(1, 50);
                        int a = num1 + num2;
                        order_num = Convert.ToString(a);
                        oneway_text = oneway.Text;
                        from_city = textBox9.Text;
                        to_city = textBox8.Text;
                        ddate = textBox7.Text;
                        flight_num = textBox6.Text;
                        BookSearch(oneway_text, order_num, from_city, to_city, ddate, flight_num);
                        MessageBox.Show("Flight has been booked with Order# " + a);
                        radioButton3.Checked = false;
                    }
                }
                else if (round.Checked == true)
                {
                    //round trip code
                }
            }

            

            
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
            toolTip1.SetToolTip(this.cmbFrom, "Select Source City");
        }

        private void cmbTo_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip2 = new ToolTip();
            toolTip2.SetToolTip(this.cmbTo, "Select Destination City");
        }

        private void dTPicker_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip3 = new ToolTip();
            toolTip3.SetToolTip(this.dTPicker, "Current Date");
        }

        private void cmbClass_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip4 = new ToolTip();
            toolTip4.SetToolTip(this.cmbClass, "Select Class");
        }

        private void cmbTicket_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip5 = new ToolTip();
            toolTip5.SetToolTip(this.cmbTicket, "Select Ticket");
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip6 = new ToolTip();
            toolTip6.SetToolTip(this.button1, "Click Find Flight button");
        }

        private void btnReset_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip7 = new ToolTip();
            toolTip7.SetToolTip(this.btnReset, "Click Reset button");
        }

        private void btnBook_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip8 = new ToolTip();
            toolTip8.SetToolTip(this.btnBook, "Click Book button");
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            
        }

        private void cmbFrom_Click(object sender, EventArgs e)
        {
            int RowCount,i;
            cmbFrom.Items.Clear();
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select FromCity from Flight_Detail", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            RowCount = ds.Tables[0].Rows.Count;
            for(i=0;i<=RowCount-1;i++)
            {
                cmbFrom.Items.Add(ds.Tables[0].Rows[i]["FromCity"].ToString());
                cmbFrom.ValueMember = ds.Tables[0].Rows[i]["FromCity"].ToString();
                cmbFrom.DisplayMember = ds.Tables[0].Rows[i]["FromCity"].ToString();
            }
            con.Close();
        }



        private void cmbTo_Click(object sender, EventArgs e)
        {
            int RowCount, i;
            cmbTo.Items.Clear();
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select ToCity from Flight_Detail", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            RowCount = ds.Tables[0].Rows.Count;
            for (i = 0; i <= RowCount - 1; i++)
            {
                cmbTo.Items.Add(ds.Tables[0].Rows[i]["ToCity"].ToString());
                cmbTo.ValueMember = ds.Tables[0].Rows[i]["ToCity"].ToString();
                cmbTo.DisplayMember = ds.Tables[0].Rows[i]["ToCity"].ToString();
            }
            con.Close();
        }

        private void cmbClass_Click(object sender, EventArgs e)
        {
            int RowCount, i;
            cmbClass.Items.Clear();
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select Class from Flight_Detail", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            RowCount = ds.Tables[0].Rows.Count;
            for (i = 0; i <= RowCount - 1; i++)
            {
                cmbClass.Items.Add(ds.Tables[0].Rows[i]["Class"].ToString());
                cmbClass.ValueMember = ds.Tables[0].Rows[i]["Class"].ToString();
                cmbClass.DisplayMember = ds.Tables[0].Rows[i]["Class"].ToString();
            }
            con.Close();
        }

        private void cmbTicket_Click(object sender, EventArgs e)
        {
            int RowCount, i;
            cmbTicket.Items.Clear();
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select Ticket from Flight_Detail", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            RowCount = ds.Tables[0].Rows.Count;
            for (i = 0; i <= RowCount - 1; i++)
            {
                cmbTicket.Items.Add(ds.Tables[0].Rows[i]["Ticket"].ToString());
                cmbTicket.ValueMember = ds.Tables[0].Rows[i]["Ticket"].ToString();
                cmbTicket.DisplayMember = ds.Tables[0].Rows[i]["Ticket"].ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
 }

