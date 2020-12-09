using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Práctica_6
{
    public partial class ChangePasswd : Form
    {
        public MySqlConnection connection;
        public MySqlCommand command;
        public MySqlDataAdapter adapter;
        public ChangePasswd()
        {
            InitializeComponent();
        }

        private void ChangePasswd_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbPasswdActual.Text == string.Empty || tbNewPasswd.Text == string.Empty || tbConNewPasswd.Text == string.Empty)
                {
                    MessageBox.Show("Por favor revise que los campos no estén vacíos");
                }
                else
                {
                    Form1 form1 = (Form1)ActiveForm;
                    if (form1.passwd == tbPasswdActual.Text)
                    {
                        if (tbConNewPasswd.Text == tbNewPasswd.Text)
                        {
                            try
                            {
                                string server = "localhost";
                                string User = "root";
                                string pass = "root";
                                string bd = "bd_login";
                                string cadenaConectar = "Database=" + bd + "; Data Source=" + server + "; User Id=" + User + "; Password=" + pass;
                                connection = new MySqlConnection(cadenaConectar);
                                connection.Open();
                                //MessageBox.Show(form1.Username);
                                string comando = "UPDATE tb_login set clave='" + tbConNewPasswd.Text + "'" + "where usuario='" + form1.Username + "';";
                                command = new MySqlCommand(comando, connection);
                                command.ExecuteNonQuery();
                                MessageBox.Show("La contraseña se ha actualizado exitosamente");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas son diferentes");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Revise su contraseña actual");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
        }

        private void ChangePasswd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = (Form1)ActiveForm;
            form1.cambiarContraseñaToolStripMenuItem.Enabled = true;
            form1.cambiarContraseñaToolStripMenuItem.Checked = false;
        }
    }
}
