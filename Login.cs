using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Práctica_6
{
    public partial class Login : Form
    {
        private int bandera = 0;
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet data = new DataSet();
                bool c = false;
                data.Locale = CultureInfo.InvariantCulture;
                FillDataSet(data);
                DataTable user = data.Tables["tb_login"];
                IEnumerable<DataRow> query = from tb_login in user.AsEnumerable() select tb_login;
                foreach (DataRow row in query)
                {
                    if (tbUser.Text != row.Field<string>("usuario") || tbPasswd.Text != row.Field<string>("clave"))
                    {
                        c = false;
                    }
                    else
                    {
                        c = true;
                        bandera = 1;
                        this.Close();
                        break;
                    }
                }
                if (c == false)
                {
                    MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void FillDataSet(DataSet data)
        {
            MySqlConnection connection = new MySqlConnection();
            try
            {
                string server = "localhost";
                string User = "root";
                string pass = "root";
                string bd = "bd_login";
                string cadenaConectar = "Database=" + bd + "; Data Source=" + server + "; User Id=" + User + "; Password=" + pass;
                connection.ConnectionString = cadenaConectar;
                connection.Open();
                string cons = "SELECT * FROM tb_login";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cons, connection);
                adapter.Fill(data, "tb_login");
            }
            catch (MySqlException E)
            {
                MessageBox.Show(E.Message);
            }
            finally
            {
                connection.Close();
            }
            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bandera == 1)
            {

            }
            else
            {
                Application.Exit();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
