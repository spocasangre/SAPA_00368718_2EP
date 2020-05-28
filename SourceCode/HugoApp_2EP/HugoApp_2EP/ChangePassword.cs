using System;
using System.Windows.Forms;

namespace HugoApp_2EP
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "password";
            comboBox1.DisplayMember = "userName";
            comboBox1.DataSource = AppUserDAO.getLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool actualIgual = Encriptador.CompararMD5(textBox1.Text, comboBox1.SelectedValue.ToString());
            bool nuevaIgual = textBox2.Text.Equals(textBox3.Text);
            bool nuevaValida = textBox2.Text.Length > 0;

            if (actualIgual && nuevaIgual && nuevaValida)
            {
                try
                {
                    AppUserDAO.actualizarContra(comboBox1.Text, Encriptador.CrearMD5(textBox2.Text));
                    
                    MessageBox.Show("¡Contraseña actualizada exitosamente!", 
                        "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Contraseña no actualizada! Favor intente mas tarde.", 
                        "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("¡¡Favor verifique que los datos sean correctos!", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}