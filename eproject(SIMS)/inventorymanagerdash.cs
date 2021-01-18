using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eproject_SIMS_
{
    public partial class inventorymanagerdash : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;

        public inventorymanagerdash()
        {
            InitializeComponent();
            displayinfo();
            displayinv();
            displaytransactions();
            displayrecieved();
            displaysent();
        }

        private void displaysent()
        {
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");

            con.Open();
            String q = "select * from messages where Sender = 'Inventory Manager' ";
            cmd = new SqlCommand(q, con);

            dr = cmd.ExecuteReader();


            DataTable table = new DataTable();
            table.Load(dr);
            dataGridView6.DataSource = table;
            con.Close();
        }

        private void displayrecieved()
        {
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");

            con.Open();
            String q = "select * from messages where Recepient = 'Inventory Manager' ";
            cmd = new SqlCommand(q, con);

            dr = cmd.ExecuteReader();


            DataTable table = new DataTable();
            table.Load(dr);
            dataGridView5.DataSource = table;
            con.Close();
        }

        private void displaytransactions()
        {
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");

            con.Open();
            String q = "select * from transactions";
            cmd = new SqlCommand(q, con);

            dr = cmd.ExecuteReader();


            DataTable table = new DataTable();
            table.Load(dr);
            dataGridView4.DataSource = table;
            con.Close();
        }

        private void displayinv()
        {
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");

            con.Open();
            String q = "select * from inventory";
            cmd = new SqlCommand(q, con);

            dr = cmd.ExecuteReader();


            DataTable table = new DataTable();
            table.Load(dr);
            dataGridView2.DataSource = table;
            con.Close();
        }

        private void displayinfo()
        {
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");

            con.Open();
            String q = "select * from users where post='Inventory Manager'";




            cmd = new SqlCommand(q, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr.GetString(1);
                textBox2.Text = dr.GetString(2);
                textBox3.Text = dr.GetString(3);
                textBox4.Text = dr.GetString(4);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f1 = new Form1();
            f1.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            inventoryreport invrep = new inventoryreport();
            invrep.Visible = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            salesreport salrep = new salesreport();
            salrep.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayinfo();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            displayinv();
        }

        private void button8_Click(object sender, EventArgs e)
        {


            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();

            //int id = Convert.ToInt32(textBox6.Text);
            string itemname = textBox7.Text;
            int itemqty = Convert.ToInt32(textBox8.Text);
            string itemcategory = textBox23.Text;
            int itemprice = Convert.ToInt32(textBox9.Text);

            string itemunit = textBox5.Text;


            string q = "insert into inventory values ('" + itemname + "','" + itemqty + "','" + itemprice + "','" + itemcategory + "','" + itemunit + "')";
            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Item Is Added Succesfully");

        }

        private void button6_Click(object sender, EventArgs e)
        {

            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();

            int itemid = Convert.ToInt32(textBox6.Text);
            string itemname = textBox7.Text;
            int itemqty = Convert.ToInt32(textBox8.Text);
            string itemcategory = textBox23.Text;
            int itemprice = Convert.ToInt32(textBox9.Text);

            string itemunit = textBox5.Text;






            String q = "update inventory set name = '" + itemname + "' ,quantity =  '" + itemqty + "',price = '" + itemprice + "',category = '" + itemcategory + "',measuringunit = '" + itemunit + "' where id=" + itemid;
            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("DATA UPDATED");
            con.Close();


        }

        private void button9_Click(object sender, EventArgs e)
        {

            int itemid = Convert.ToInt32(textBox6.Text);
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();
            String q = "select * from inventory where id = " + itemid;
            cmd = new SqlCommand(q, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox7.Text = dr.GetString(1);


                textBox8.Text = dr.GetInt32(2).ToString();

                textBox9.Text = dr.GetInt32(3).ToString();

                textBox23.Text = dr.GetString(4);
                textBox5.Text = dr.GetString(5);
            }
            else
            {
                MessageBox.Show("RECORD NOT FOUND");
            }
            con.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            int itemid = Convert.ToInt32(textBox6.Text);
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();
            String q = "delete from inventory where id =" + itemid;
            cmd = new SqlCommand(q, con);
            MessageBox.Show("RECORD DELETED");
            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void button16_Click(object sender, EventArgs e)
        {
            displaytransactions();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();

            string id = textBox20.Text;

            String q = "DELETE FROM transactions WHERE id = " + id;
            cmd = new SqlCommand(q, con);
            MessageBox.Show("This Transaction was Deleted");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();

            String q = "delete from transactions";
            cmd = new SqlCommand(q, con);
            MessageBox.Show("All Transactions Deleted");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;


            DataGridViewRow selectedrow = dataGridView4.Rows[index];
            textBox20.Text = selectedrow.Cells[0].Value.ToString();
            textBox21.Text = selectedrow.Cells[1].Value.ToString();
            textBox22.Text = selectedrow.Cells[2].Value.ToString();
            textBox11.Text = selectedrow.Cells[3].Value.ToString();
            textBox10.Text = selectedrow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displayrecieved();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            displaysent();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox25.Text);


            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();
            String q = "select * from messages where id = " + id;
            cmd = new SqlCommand(q, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox26.Text = dr.GetString(2);
                textBox27.Text = dr.GetString(3);
                textBox28.Text = dr.GetString(4);
            }
            else
            {
                MessageBox.Show("RECORD NOT FOUND");
            }
            con.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox32.Text);


            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();
            String q = "select * from messages where id = " + id;
            cmd = new SqlCommand(q, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox31.Text = dr.GetString(1);
                textBox30.Text = dr.GetString(3);
                textBox29.Text = dr.GetString(4);
            }
            else
            {
                MessageBox.Show("RECORD NOT FOUND");
            }
            con.Close();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string recepient = comboBox3.Text;
            string date = dateTimePicker1.Text;
            string message = textBox33.Text;




            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();




            string q = "insert into messages values ('" + recepient + "','" + "Inventory Manager" + "','" + date + "','" + message + "')";
            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Message Sent Succesfully");
        }
    }
}
