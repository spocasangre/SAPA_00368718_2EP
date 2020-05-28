using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace HugoApp_2EP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            poblarControles();
        }
        
        private void poblarControles()
        {
            // Actualizar ComboBox
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "password";
            comboBox1.DisplayMember = "userName";
            comboBox1.DataSource = AppUserDAO.getLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // string query = $"SELECT u.password from APPUSER u WHERE u.userName = '{comboBox1.SelectedValue}'";
          //  var dt = Conexion.realizarConsulta(query);
          //  var dr = dt.Rows[0].ToString();

            
            
           if (Encriptador.CompararMD5(textBox1.Text, comboBox1.SelectedValue.ToString()))
           {
                AppUser u = (AppUser) comboBox1.SelectedItem;
                
                MessageBox.Show("¡Bienvenido!",
                        "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (u.userType == true)
                {
                    frmPrincipal ventana = new frmPrincipal(u);
                    ventana.Show();
                    this.Hide();
                }
                else
                {
                    frmNormalUser ven = new frmNormalUser(u);
                    ven.Show();
                    this.Hide();
                }
           }
            else
               MessageBox.Show("¡Contraseña incorrecta!", "Hugo App",
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        private void labelContra_Click(object sender, EventArgs e)
        {
            ChangePassword unaVentana = new ChangePassword();
           unaVentana.ShowDialog();
            this.Hide();
        }
    }
}