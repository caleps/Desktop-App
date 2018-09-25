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
    public partial class teacher_frm : Form
    {
        public teacher_frm()
        {
            InitializeComponent();
        }

        private void teacher_frm_Load(object sender, EventArgs e)
        {
            try
            {
                // SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");
                //  SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ID2L8K2\SQLEXPRESS;Intial Catalog=glal;Integrated Security=True");
                string sql = " select * from teacher ";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            newteacher_frm frm = new newteacher_frm();
            frm.ShowDialog();
            this.Close();
            this.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                string x = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                exam frm = new exam(x);
                frm.ShowDialog();
                this.Close();
                this.Visible = true;
            }
            catch
            {
                MessageBox.Show("Add teacher first !");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

                // SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);

                con.Open();
                string x = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                string command = "delete from teacher where id_teacher=" + int.Parse(x) + "";
                string command1 = "delete from teacher_paper where id_teacher=" + int.Parse(x) + "";
              //  string command1 = "update teacher_paper where id_teacher=" + int.Parse(x) + "set id_teacher=0";
                SqlCommand cmd = new SqlCommand(command, con);
                SqlCommand cmd1 = new SqlCommand(command1, con);
                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("your details are deleted !");
                this.Close();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

                con.Open();
                string command = "select * from teacher where name_teacher like '%" + textBox1.Text + "%'";
                string commandd = "select * from teacher where id_teacher like '%" + textBox1.Text + "%'";

                SqlCommand cmd = new SqlCommand(command, con);
                SqlCommand cmdd = new SqlCommand(commandd, con);

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                SqlDataAdapter adptt = new SqlDataAdapter(cmdd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                adptt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch { MessageBox.Show("An Error Ocured !"); }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "enter name or id")
            {
                textBox1.Text = "0";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Visible = false;
       allexams frm = new allexams();
            frm.ShowDialog();
            // this.Close();
            this.Visible = true;
        }




    }
}
