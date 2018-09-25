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
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
            con.Open();
            if (radioButton1.Checked)
            {
                string command = "insert into teacher (id_teacher,name_teacher,phone1,phone2,address,subject,stage)values(" + int.Parse(id.Text) + "," + "'" + name.Text + "'" + "," + "'" + ph1.Text + "'" + "," + "'" + ph2.Text + "'" + "," + "'" + add.Text + "'" + "," + "'" + sub.Text + "'" + ",  'primary' )";

                SqlCommand cmd = new SqlCommand(command, con);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done !");

                this.Visible = false;
                this.Close();
            }
            if (radioButton2.Checked)
            {
                string command = "insert into teacher (id_teacher,name_teacher,phone1,phone2,address,subject,stage)values(" + int.Parse(id.Text) + "," + "'" + name.Text + "'" + "," + "'" + ph1.Text + "'" + "," + "'" + ph2.Text + "'" + "," + "'" + add.Text + "'" + "," + "'" + sub.Text + "'" + ",'Preparatory ')";

                SqlCommand cmd = new SqlCommand(command, con);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done !");

                this.Visible = false;
                this.Close();
            }
            if (radioButton3.Checked)
            {
                string command = "insert into teacher (id_teacher,name_teacher,phone1,phone2,address,subject,stage)values(" + int.Parse(id.Text) + "," + "'" + name.Text + "'" + "," + "'" + ph1.Text + "'" + "," + "'" + ph2.Text + "'" + "," + "'" + add.Text + "'" + "," + "'" + sub.Text + "'" + ",'secondary ')";

                SqlCommand cmd = new SqlCommand(command, con);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done !");

                this.Visible = false;
                this.Close();
            }

            
        }

        private void newteacher_frm_Load(object sender, EventArgs e)
        {

        }
        

              private void button2_Click_1(object sender, EventArgs e)
        {
            int x = 0, y = 0, z = 0;
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                if (radioButton1.Checked) x = 1;
                if (radioButton2.Checked) y = 1;
                if (radioButton3.Checked) z = 1;
                string mina = comboBox1.SelectedValue + "," + x + "," + y + "," + z;

                if (listBox1.Items.IndexOf(mina) < 0)
                    listBox1.Items.Add(comboBox1.SelectedValue + "," + x + "," + y + "," + z);
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);

        }
    }
}
