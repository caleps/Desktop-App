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
            // this.Close();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            editcorrector frm = new editcorrector();
            frm.ShowDialog();
            // this.Close();
            this.Visible = true;
        }
    }
}
