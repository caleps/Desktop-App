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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
