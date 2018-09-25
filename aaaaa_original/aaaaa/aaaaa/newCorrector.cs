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
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
            con.Open();

            string command = "insert into corrector(id_corrector,name,salary,total_salary,certificate,address,phone1,phone2)values(" + int.Parse(id.Text) + "," + "'" + name.Text + "'" + "," + int.Parse(sa.Text) + "," + int.Parse(to_sa.Text) + "," + "'" + cert.Text + "','" + add.Text + "','" + ph1.Text + "','" + ph2.Text + "')";
            
            SqlCommand cmd = new SqlCommand(command, con);

            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Done !");

            
            this.Visible = false;
            this.Close();
        }
    }
}
