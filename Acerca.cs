using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Práctica_6
{
    public partial class Acerca : Form
    {
        public Acerca()
        {
            InitializeComponent();
        }

        private void Acerca_Load(object sender, EventArgs e)
        {
            label1.Text = Application.CompanyName;
            label2.Text = "Versión: " +  Application.ProductVersion;
            label3.Text = "Copyrigth © Microsof 2019";
            label4.Text = "Microsoft";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Acerca_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = (Form1)ActiveForm;
            form1.acercaDeToolStripMenuItem.Checked = false;
            form1.acercaDeToolStripMenuItem.Enabled = true;
        }
    }
}
