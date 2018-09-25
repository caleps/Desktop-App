using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aaaaa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            this.Visible = false;

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Visible = false;
                main_frm frm = new main_frm();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                progressBar1.Value++;
                label2.Text = progressBar1.Value.ToString() + "%";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
