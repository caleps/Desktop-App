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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Done ");
            this.Close();
            this.Visible = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;
            string comand = "SELECT * FROM paper";
           
            cmd = new SqlCommand(comand, con);
           
            con.Open();

            da = new SqlDataAdapter(cmd);
           
            ds = new DataSet();
           

            da.Fill(ds);
         

            SaveFileDialog op = new SaveFileDialog();
           
            op.Filter = "Excel Files (*.xls) | *.xls";
            
            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ds.WriteXml(op.FileName);
                    MessageBox.Show("Exported Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error !!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;
            string comand = "SELECT * FROM teacher";

            cmd = new SqlCommand(comand, con);

            con.Open();

            da = new SqlDataAdapter(cmd);

            ds = new DataSet();


            da.Fill(ds);


            SaveFileDialog op = new SaveFileDialog();

            op.Filter = "Excel Files (*.xls) | *.xls";

            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ds.WriteXml(op.FileName);
                    MessageBox.Show("Exported Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error !!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;
            string comand = "SELECT * FROM corrector";

            cmd = new SqlCommand(comand, con);

            con.Open();

            da = new SqlDataAdapter(cmd);

            ds = new DataSet();


            da.Fill(ds);


            SaveFileDialog op = new SaveFileDialog();

            op.Filter = "Excel Files (*.xls) | *.xls";

            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ds.WriteXml(op.FileName);
                    MessageBox.Show("Exported Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error !!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;
            string comand = "SELECT * FROM corrector_paper";

            cmd = new SqlCommand(comand, con);

            con.Open();

            da = new SqlDataAdapter(cmd);


            ds = new DataSet();

            da.Fill(ds);


            SaveFileDialog op = new SaveFileDialog();

            op.Filter = "Excel Files (*.xls) | *.xls";

            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ds.WriteXml(op.FileName);
                    MessageBox.Show("Exported Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error !!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;
            string comand = "SELECT * FROM teacher_paper";

            cmd = new SqlCommand(comand, con);

            con.Open();

            da = new SqlDataAdapter(cmd);

            ds = new DataSet();


            da.Fill(ds);


            SaveFileDialog op = new SaveFileDialog();

            op.Filter = "Excel Files (*.xls) | *.xls";

            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ds.WriteXml(op.FileName);
                    MessageBox.Show("Exported Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error !!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
          
        }
    }
}
