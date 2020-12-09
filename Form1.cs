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
    public partial class Form1 : Form
    {
        public string passwd;
        public string Username
        {
            get
            {
                return userName.Text;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            userName.Text = login.tbUser.Text;
            passwd = login.tbPasswd.Text;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Activate();
            this.Close();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CFactura factura = new CFactura();
            factura.MdiParent = this;
            factura.Show();;
            facturasToolStripMenuItem.Checked = true;
            facturasToolStripMenuItem.Enabled = false;
        }

        private void catálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CCatalogo catalogo = new CCatalogo();
            catalogo.MdiParent = this;
            catalogo.Show();
            catálogoToolStripMenuItem.Checked = true;
            catálogoToolStripMenuItem.Enabled = false;
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswd changePasswd = new ChangePasswd();
            changePasswd.MdiParent = this;
            changePasswd.Show();
            cambiarContraseñaToolStripMenuItem.Checked = true;
            cambiarContraseñaToolStripMenuItem.Enabled = false;
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
            cascadaToolStripMenuItem.Checked = true;
            horizontalToolStripMenuItem.Checked = false;
            verticalToolStripMenuItem.Checked = false;
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
            cascadaToolStripMenuItem.Checked = false;
            horizontalToolStripMenuItem.Checked = true;
            verticalToolStripMenuItem.Checked = false;
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
            cascadaToolStripMenuItem.Checked = false;
            horizontalToolStripMenuItem.Checked = false;
            verticalToolStripMenuItem.Checked = true;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca acerca = new Acerca();
            acerca.MdiParent = this;
            acerca.Show();
            acercaDeToolStripMenuItem.Checked = true;
            acercaDeToolStripMenuItem.Enabled = false;
        }
    }
}
