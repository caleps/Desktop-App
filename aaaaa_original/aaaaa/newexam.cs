using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aaaaa
{
    public partial class newexam : Form
    {


        public newexam(string id)
        {
            InitializeComponent();
            textBox2.Text = id;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            //  SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
            con.Open();
            // string MyString = CStr(dateTimePicker1.Value.Date);
            string command = "insert into paper(id_paper,exam_date,date_of_enterring,date_of_delivering,price_p,num_p,co_per,groups)values('" + textBox1.Text + "','" + dateTimePicker1.Value.Date.ToString("yyyyMMdd") + "','" + dateTimePicker2.Value.Date.ToString("yyyyMMdd") + "','" + dateTimePicker3.Value.Date.ToString("yyyyMMdd") + "'," + double.Parse(price_p.Text) + "," + double.Parse(num_p.Text) + "," + double.Parse(co_per.Text) + ",'" + textBox4.Text + "')";

            SqlCommand cmd = new SqlCommand(command, con);

            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Done !");


            //  this.Visible = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }






        private void newexam_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            // SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
            string sql = " select name,id_corrector from corrector where var=1 ";
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
            try
            {
                string x = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();

                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

                // SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
                string command = "insert into corrector_paper(id_corrector,id_paper)values( " + int.Parse(x) + ",'" + textBox1.Text + "')";

                con.Open();
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.ExecuteNonQuery();
                //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                con.Close();
                string commandd = "insert into teacher_paper(id_paper,id_teacher)values( '" + textBox1.Text + "'," + int.Parse(textBox2.Text) + ")";

                con.Open();
                SqlCommand cmdd = new SqlCommand(commandd, con);
                cmdd.ExecuteNonQuery();
                //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                con.Close();


                MessageBox.Show("Done !");

            }
            catch
            {
                MessageBox.Show("Add at least one marker at first !");
                this.Visible = false;
              //  string x = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                newCorrector frm = new newCorrector();
                frm.ShowDialog();
                this.Close();
                this.Visible = true;
            }


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }



        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

                //  SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
                con.Open();
                double price = double.Parse(price_p.Text);
                double x = double.Parse(num_p.Text);
                double per = double.Parse(co_per.Text);
                double c = price * x;
                double y = (per * c) / 100;
                double v = c - y;
                money.Text = v.ToString();
                co_money.Text = y.ToString();
                string command = "update paper set money ='" + double.Parse(money.Text) + "',co_money='" + double.Parse(co_money.Text) + "' WHERE id_paper= '" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(command, con);

                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Done !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");
        string imagloc;
        SqlCommand cmd;
        private void button5_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                imagloc = openFileDialog.FileName.ToString();
                pictureBox1.ImageLocation = imagloc;
                bb.Text = openFileDialog.FileName.ToString(); 
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

            byte[] images = null;

            FileStream st = new FileStream(imagloc, FileMode.Open, FileAccess.Read);
            BinaryReader bra = new BinaryReader(st);
            images = bra.ReadBytes((int)st.Length);
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            //  SqlConnection con = new SqlConnection(Properties.Settings.Default.constr);
            con.Open();

            string command = "update paper set photo=@images , path='" + bb.Text + "' ";

            cmd = new SqlCommand(command, con);
            cmd.Parameters.Add(new SqlParameter("@images", images));

            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Done !");
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

                con.Open();
                string command = "select name,id_corrector from corrector WHERE name like '%" + textBox3.Text + "%'";
                string commandd = "select name,id_corrector from corrector WHERE id_corrector like '%" + textBox3.Text + "%'";

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

     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "enter name or id")
            {
                textBox3.Text = "0";
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }




    }
}