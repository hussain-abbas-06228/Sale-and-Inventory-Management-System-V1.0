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
    public partial class Form1 : Form
    {


        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");
            con.Open();


            string username = textBox1.Text;
            string pass = textBox2.Text;

            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);


            string q = "select * from users where usename = '" + username + "' AND  password = '" + pass + "'  AND  post = '" + selected + "'";
            cmd = new SqlCommand(q, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if (selected.Contains(value: "Admin"))
                {
                    mainscreen mainsc = new mainscreen();
                    mainsc.Visible = true;
                    this.Visible = false;


                }



                if (selected.Contains(value: "Sales Person"))
                {
                    salespersondash salepdash = new salespersondash();
                    salepdash.Visible = true;
                    this.Visible = false;
                }


                if (selected.Contains(value: "Sales Manager"))
                {
                    salesmanagerdash salemdash = new salesmanagerdash();
                    salemdash.Visible = true;
                    this.Visible = false;
                }

                if (selected.Contains(value: "Inventory Manager"))
                {
                    inventorymanagerdash invmdash = new inventorymanagerdash();
                    invmdash.Visible = true;
                    this.Visible = false;
                }



            }
            else
            {
                MessageBox.Show("Incorrect name or password");
            }

            con.Close();



            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginpasswordinfo log = new loginpasswordinfo();
            log.Visible = true;
        }
    }
}
