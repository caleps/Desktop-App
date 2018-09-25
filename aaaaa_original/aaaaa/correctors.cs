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
    
    public partial class correctors : Form
    {
        public correctors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            newCorrector frm = new newCorrector();
            frm.ShowDialog();
        this.Close();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                string x = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                editcorrector frm = new editcorrector(x);
                frm.ShowDialog();
                // this.Close();
                this.Visible = true;
            }
            catch { MessageBox.Show("All Deleted !"); }
        }

        private void correctors_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            //  SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
            string sql = " select * from corrector where var =1";
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //int b = 0;
        private void button3_Click(object sender, EventArgs e)
        {
           
            
            try
            {
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

                // SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
                // search();
                con.Open();
                string x = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
               // string command = "delete from corrector where id_corrector=" + int.Parse(x) + "";
                //string command1 = "delete from corrector_paper where id_corrector=" + int.Parse(x) + "";
                string command1 = "  UPDATE TOP (1)  corrector set var=-1  where id_corrector=" + int.Parse(x) + "";
              
               // SqlCommand cmd = new SqlCommand(command, con);
                SqlCommand cmd1 = new SqlCommand(command1, con);
                cmd1.ExecuteNonQuery();

                //cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("your details are deleted !");
                this.Close();
                this.Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            search();
        }
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "enter name or id")
            {
                textBox1.Text = "0";
            }
        }
        private void search()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

                con.Open();
                string command = "select * from corrector where name like '%" + textBox1.Text + "%'";
                string commandd = "select * from corrector where id_corrector like '%" + textBox1.Text + "%'";

                SqlCommand cmd = new SqlCommand(command, con);
                SqlCommand cmdd = new SqlCommand(commandd, con);

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                SqlDataAdapter adptt = new SqlDataAdapter(cmdd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                adptt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch { MessageBox.Show("An Error Occured !"); }
        }
        public string command { get; set; }
    }
}
