using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Intuit.Ipp.Data;

namespace Práctica_6
{
    public partial class CFactura : Form
    {
        private IQueryable queryable;
        private IQueryable pro;
        private int advance = 0;
        public CFactura()
        {
            InitializeComponent();
        }

        private void CFactura_Load(object sender, EventArgs e)
        {
            tabControl1.Size = this.Size;
            DatosVentasDataContext db = new DatosVentasDataContext();
            queryable = from v in db.Catalogo select v;
            var fact = from p in db.Factura select p;
            foreach (FacturaC producto in fact)
            {
                cbCodigo.Items.AddRange(new object[] { producto.Codigo });
            }
            pro = from q in db.Producto select q;
            foreach (Catalogo producto1 in queryable)
            {
                selectProducto.Items.AddRange(new object[] { producto1.Nombre });
            }
        }

        private void CFactura_SizeChanged(object sender, EventArgs e)
        {
            tabControl1.Width = this.Width;
            tabControl1.Height = this.Height;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                object n = cbCodigo.SelectedItem;
                double suma = 0;
                int nn = Convert.ToInt32(n);
                DatosVentasDataContext db = new DatosVentasDataContext();
                var user = from us in db.Factura where us.Codigo == nn select us;
                var pro = from p in db.Producto
                          join q in db.Factura on p.Fk_Codigo equals q.Codigo
                          where p.Fk_Codigo == nn
                          select p;
                foreach (Producto producto in pro)
                {
                    suma += producto.Precio;
                }
                foreach (FacturaC factura in user)
                {
                    tbMostrarCliente.Text = "Nombre: " + factura.Cliente + " - " + " Fecha de la compra: " + factura.Fecha;
                }
                dataGridViewViusualizar.DataSource = pro;
                tbTotal.Text = suma.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
        }

        private void dataGridViewNueva_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewComboBoxCell combo = dataGridViewNueva.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
            /*string msg = String.Format("Editing Cell at ({0}, {1})", e.ColumnIndex, e.RowIndex);
            MessageBox.Show(msg);*/
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            advance = 0;
            DatosVentasDataContext db = new DatosVentasDataContext();
            FacturaC factura = new FacturaC();
            try
            {
                factura.Cliente = tbNombreCliente.Text;
                //MessageBox.Show(factura.Cliente);
                factura.Codigo = Convert.ToInt32(tbCodigoFac.Text);
                //MessageBox.Show(factura.Codigo.ToString());
                factura.Fecha = dateTimePicker1.Value.ToString();
                //MessageBox.Show(factura.Fecha);
                db.Factura.InsertOnSubmit(factura);
                db.SubmitChanges();
                //MessageBox.Show("Datos ingresados en la tabla factura");
                int j = 0;
                bool cont = false;
                foreach (Catalogo producto1 in queryable)
                {
                    while (advance < dataGridViewNueva.Rows.Count - 1)
                    {
                        if (producto1.Nombre == dataGridViewNueva.Rows[advance].Cells[0].Value.ToString())
                        {
                            Producto producto = new Producto
                            {
                                Codigo = producto1.Codigo,
                                Nombre = producto1.Nombre,
                                Precio = producto1.Precio,
                                Cantidad = Convert.ToInt32(dataGridViewNueva.Rows[advance].Cells[1].Value),
                                Fk_Codigo = Convert.ToInt32(tbCodigoFac.Text)
                            };
                            db.Producto.InsertOnSubmit(producto);
                            db.SubmitChanges();
                            j++;
                            if (j == dataGridViewNueva.Rows.Count - 1)
                            {
                                cont = true;
                                break;
                            }
                            break;
                        }
                        advance++;
                    }
                    advance = 0;
                    if (cont == true)
                    {
                        break;
                    }
                }
                //MessageBox.Show("Datos ingresados en la tabla producto");
                Actualizar();
                dataGridViewNueva.Rows.Clear();
                /*if (dataGridViewNueva.Rows[advance].Cells[0].Selected)
                {
                    MessageBox.Show(dataGridViewNueva.Rows[advance].Cells[0].Value.ToString());
                    advance++;
                }
                else
                {
                    MessageBox.Show("Elija el siguiente producto");
                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema. Revise los datos e inténtelo nuevamente");
            }
        }

        private void Actualizar()
        {
            try
            {
                DatosVentasDataContext db = new DatosVentasDataContext();
                queryable = from v in db.Catalogo select v;
                var fact = from p in db.Factura select p;
                cbCodigo.Items.Clear();
                foreach (FacturaC producto in fact)
                {
                    cbCodigo.Items.AddRange(new object[] { producto.Codigo });
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
            /*pro = from q in db.Producto select q;
            foreach (Catalogo producto1 in queryable)
            {
                selectProducto.Items.AddRange(new object[] { producto1.Nombre });
            }*/
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void CFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = (Form1)ActiveForm;
            form1.facturasToolStripMenuItem.Enabled = true;
            form1.facturasToolStripMenuItem.Checked = false;
        }
    }
}