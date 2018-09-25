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

namespace aaaaa
{
    public partial class editcorrector : Form
    {
        public editcorrector(string id)
        {
            InitializeComponent();
            textBox1.Text = id;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = double.Parse(nump.Text);
            double y = double.Parse(numw.Text);
            double h = (y * 100) / x;
            wrong.Text = h.ToString();


        }

        private void editcorrector_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            //  SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
            string sql = " select ratio from corrector WHERE id_corrector=" + int.Parse(textBox1.Text) + " ";
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");
                //  SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ID2L8K2\SQLEXPRESS;Intial Catalog=glal;Integrated Security=True");
                string sql = " select ratio from corrector WHERE id_corrector = " + int.Parse(textBox1.Text) + "";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                string y = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
               // double yy = float.Parse(y);
                try
                {
                double x = double.Parse(wrong.Text) +double.Parse(y);
                    all.Text = x.ToString();
                    string command = "update corrector set ratio =" + double.Parse(all.Text) + "WHERE id_corrector=" + int.Parse(textBox1.Text) + "";

                    SqlCommand cmdd = new SqlCommand(command, con);
                    cmdd.ExecuteNonQuery();
                    con.Close();
                   
                
               
                MessageBox.Show("Done !");
                this.Close();
            }
          catch 
            {
               
              
           double x = double.Parse(wrong.Text);
                all.Text = x.ToString();
                string command = "update corrector set ratio =" + double.Parse(all.Text) + "WHERE id_corrector=" + int.Parse(textBox1.Text) + "";

                SqlCommand cmdd = new SqlCommand(command, con);
                cmdd.ExecuteNonQuery();
                con.Close();



                MessageBox.Show("Done !");
                this.Close();
            }

                /*   SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");
                   //  SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ID2L8K2\SQLEXPRESS;Intial Catalog=glal;Integrated Security=True");
                   //  string sql = " insert ratio from corrector WHERE id_corrector = " + float.Parse(textBox1.Text) + "";
                   con.Open();
                   string command = "update corrector set ratio =" + float.Parse(all.Text) + "WHERE id_corrector=" + int.Parse(textBox1.Text) + "";

                   SqlCommand cmd = new SqlCommand(command, con);
                   cmd.ExecuteNonQuery();
                   con.Close();
                   MessageBox.Show("Done !");
                   this.Close();
               }*/

            
        }
    }
}