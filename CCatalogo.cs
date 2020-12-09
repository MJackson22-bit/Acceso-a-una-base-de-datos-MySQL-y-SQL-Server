using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Práctica_6
{
    public partial class CCatalogo : Form
    {
        public CCatalogo()
        {
            InitializeComponent();
        }

        private void CCatalogo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bd_ventasDataSet.Catalogo' Puede moverla o quitarla según sea necesario.
            this.catalogoTableAdapter.Fill(this.bd_ventasDataSet.Catalogo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bd_ventasDataSet.HasChanges())
                {
                    sqlDataAdapter1.Update(bd_ventasDataSet);
                    MessageBox.Show("origen de datos actualizados");
                }
                else
                {
                    MessageBox.Show("Aún no hay cambios para guardar");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
        }

        private void CCatalogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (bd_ventasDataSet.HasChanges())
                {
                    DialogResult dialog = MessageBox.Show("¿Desea guardar los cambios?", "Adevertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dialog.Equals(DialogResult.OK))
                    {
                        sqlDataAdapter1.Update(bd_ventasDataSet);
                        MessageBox.Show("Origen de datos actualizados");
                    }
                    else
                    {
                        MessageBox.Show("Los datos no han sido guardados");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
            Form1 form1 = (Form1)ActiveForm;
            form1.catálogoToolStripMenuItem.Enabled = true;
            form1.catálogoToolStripMenuItem.Checked = false;
        }
    }
}
