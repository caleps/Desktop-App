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
    public partial class allexams : Form
    {
        public allexams()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void se_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

                con.Open();
                string command = "select * from paper where id_paper like '%" + textBox2.Text + "%'";
                // string commandd = "select * from teacher where id_teacher like '%" + textBox1.Text + "%'";

                SqlCommand cmd = new SqlCommand(command, con);
                //SqlCommand cmdd = new SqlCommand(commandd, con);

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                //SqlDataAdapter adptt = new SqlDataAdapter(cmdd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                //adptt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch { MessageBox.Show("An Error Ocured !"); }
        
        }

        private void allexams_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            //  SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
            //   string sql = " select id_paper from teacher_paper WHERE id_teacher="+int .Parse(textBox1.Text)+" ";
            string command = "SELECT*from paper"; 
            con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            //SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);

            con.Open();
            string x = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            string command1 = "delete from teacher_paper  where id_paper='" + x + "'";
            string command = "delete from corrector_paper where id_paper='" + x + "'";
            string command2 = "delete from paper  where id_paper='" + x + "'";
            SqlCommand cmd = new SqlCommand(command, con);
            SqlCommand cmd1 = new SqlCommand(command1, con);
            SqlCommand cmd2 = new SqlCommand(command2, con);
            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("your details are deleted !");
            this.Close();
            this.Visible = true;


        }
    }
}
