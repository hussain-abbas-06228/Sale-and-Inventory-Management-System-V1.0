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
    public partial class inventoryreport : Form
    {

        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;


        public inventoryreport()
        {
            InitializeComponent();



            display();


        }

        private void display()
        {
            con = new SqlConnection(@"Data Source=LAB1PC14\SQL2012;Initial Catalog=sims;User ID=sa;Password=sa9");

            con.Open();
            String q = "select * from inventory";
            cmd = new SqlCommand(q, con);

            dr = cmd.ExecuteReader();


            DataTable table = new DataTable();
            table.Load(dr);
            dataGridView1.DataSource = table;
            con.Close();
        }
    }
}
