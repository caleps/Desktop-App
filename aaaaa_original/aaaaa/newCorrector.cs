using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace aaaaa
{
    public partial class newCorrector : Form
    {
        public newCorrector()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

                // SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
                con.Open();

                string command = "insert into corrector(id_corrector,name,certificate,address,phone1,phone2,var)values(" + int.Parse(id.Text) + "," + "'" + name.Text + "'" + "," + "'" + cert.Text + "','" + add.Text + "','" + ph1.Text + "','" + ph2.Text + "',"+1+")";

                SqlCommand cmd = new SqlCommand(command, con);

                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Done !");


                this.Visible = false;
                this.Close();
            }
            catch
            {
                MessageBox.Show("you entered NOThing !");

                this.Visible = false;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            //SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
            con.Open();
            string command = "select max (id_corrector) from corrector";
            SqlCommand cmd = new SqlCommand(command, con);

            //if (newid == null) newid = "0";
            try
            {
                string newid = cmd.ExecuteScalar().ToString();
                id.Text = (int.Parse(newid) + 1) + "";

            }
            catch { id.Text = "1"; }
            con.Close();

        }

        private void newCorrector_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void sa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
