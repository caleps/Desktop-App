using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
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
    public partial class main_frm : Form
    {
        public main_frm()
        {
            InitializeComponent();
        }

        private void tech_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            teacher_frm frm = new teacher_frm();
            frm.ShowDialog();
            // this.Close();
            this.Visible = true;
        }

        private void cor_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            correctors frm = new correctors();
            frm.ShowDialog();
            // this.Close();
            this.Visible = true;
        }



        private void main_frm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*this.Visible = false;
            Form2 frm = new Form2();
            frm.ShowDialog();
            // this.Close();
            this.Visible = true;
            */
            SqlConnection con = new SqlConnection(@"Server = DESKTOP-ID2L8K2\SQLEXPRESS; Database = glal; Trusted_Connection = True");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;
            string comand = "SELECT * FROM paper,corrector_paper,corrector,teacher,teacher_paper";
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
                    MessageBox.Show("Exported Successfully");
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
            Server dbserver=new Server(new ServerConnection (@"Server = DESKTOP-ID2L8K2\SQLEXPRESS"));
            Backup dbbackup =new Backup(){Action=BackupActionType.Database,Database="glal"};
            dbbackup.Devices.AddDevice(@"C:\Data\Northwind.bak", DeviceType.File);
            dbbackup.Initialize = true;
            dbbackup.PercentComplete+=DbB

        }
    }
}
