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
    public partial class checkout : Form
    {
        public checkout()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;

        private void button12_Click(object sender, EventArgs e)
        {
            int itemid = Convert.ToInt32(textBox15.Text);

            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();
            String q = "select * from inventory where id = " + itemid;
            cmd = new SqlCommand(q, con);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {


                string itemname = dr.GetString(1);

                textBox1.Text = itemname;

                textBox17.Text = dr.GetInt32(2).ToString();

                textBox16.Text = dr.GetInt32(3).ToString();

                //textBox23.Text = dr.GetString(4);
                //textBox36.Text = dr.GetString(5);




            }
            else
            {
                MessageBox.Show("RECORD NOT FOUND");
            }
            con.Close();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            int amntreq = Convert.ToInt32(textBox19.Text);
            int curentprice = Convert.ToInt32(textBox16.Text);

            if (amntreq > 0)
            {
                int totprice = curentprice * amntreq;
                textBox18.Text = totprice.ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            inventoryreport invrep = new inventoryreport();
            invrep.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            

            int amontavailable = Convert.ToInt32(textBox17.Text);
            int amontrequired = Convert.ToInt32(textBox19.Text);

            if (amontrequired < amontavailable)
            {
                int n = dataGridView3.Rows.Add();

                dataGridView3.Rows[n].Cells[0].Value = textBox15.Text;
                dataGridView3.Rows[n].Cells[1].Value = textBox1.Text;
                dataGridView3.Rows[n].Cells[2].Value = textBox19.Text;
                dataGridView3.Rows[n].Cells[3].Value = textBox18.Text;
            }
            else
            {
                MessageBox.Show("Sorry but that amount is not present in stock \nAmont Present: " + amontavailable);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int sum=0;
            for (int i = 0; i <= dataGridView3.Rows.Count - 1; i++)
            {
               

                sum += Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value);

            }

            textBox11.Text = sum.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tot = Convert.ToInt32(textBox11.Text);
            int given = Convert.ToInt32(textBox12.Text);

           
                int change = given - tot;
            

            textBox13.Text = change.ToString();
            textBox14.Text = given.ToString();

            
        }

        private void button11_Click(object sender, EventArgs e)
        {



            // int id = Convert.ToInt32(textBox2.Text);
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();

            string cname = textBox10.Text;
            DateTime now = DateTime.Now;
            string date = now.ToString();

            int tot = Convert.ToInt32(textBox11.Text);

            string selected = comboBox2.SelectedItem.ToString();






            string q = "insert into transactions values ('" + cname + "','" + date + "','" + tot + "','" + selected + "')";



            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Transaction Proceeded Succesfully");





        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;


            DataGridViewRow selectedrow = dataGridView3.Rows[index];
            textBox15.Text = selectedrow.Cells[0].Value.ToString();
            textBox1.Text = selectedrow.Cells[1].Value.ToString();
            textBox19.Text = selectedrow.Cells[2].Value.ToString();
            textBox18.Text = selectedrow.Cells[3].Value.ToString();

            textBox17.Text = "";
            textBox16.Text = "";



        }

       
    }
}
