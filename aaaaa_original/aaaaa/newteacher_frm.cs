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
    public partial class newteacher_frm : Form
    {
        public newteacher_frm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

                //   SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
                con.Open();

                if (radioButton1.Checked)
                {

                    string command = "insert into teacher (id_teacher,name_teacher,phone1,phone2,address,subject,primare)values(" + int.Parse(id.Text) + "," + "'" + name.Text + "'" + "," + "'" + ph1.Text + "'" + "," + "'" + ph2.Text + "'" + "," + "'" + add.Text + "'" + "," + "'" + sub.Text + "'" + ",'" + textBox1.Text + "' )";

                    SqlCommand cmd = new SqlCommand(command, con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Done !");

                    this.Visible = false;
                    this.Close();
                }

                if (radioButton2.Checked)
                {

                    string command = "insert into teacher (id_teacher,name_teacher,phone1,phone2,address,subject,preparatory)values(" + int.Parse(id.Text) + "," + "'" + name.Text + "'" + "," + "'" + ph1.Text + "'" + "," + "'" + ph2.Text + "'" + "," + "'" + add.Text + "'" + "," + "'" + sub.Text + "'" + ",'" + textBox1.Text + "' )";

                    SqlCommand cmd = new SqlCommand(command, con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Done !");

                    this.Visible = false;
                    this.Close();
                }

                if (radioButton3.Checked)
                {

                    string command = "insert into teacher (id_teacher,name_teacher,phone1,phone2,address,subject,secondry)values(" + int.Parse(id.Text) + "," + "'" + name.Text + "'" + "," + "'" + ph1.Text + "'" + "," + "'" + ph2.Text + "'" + "," + "'" + add.Text + "'" + "," + "'" + sub.Text + "'" + ",'" + textBox1.Text + "' )";

                    SqlCommand cmd = new SqlCommand(command, con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Done !");

                    this.Visible = false;
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("you entered NOThing !");

                this.Visible = false;
                this.Close();
            }






        }

        private void newteacher_frm_Load(object sender, EventArgs e)
        {

        }




        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            //SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
            con.Open();
            string command = "select max (id_teacher) from teacher";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void sub_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}
