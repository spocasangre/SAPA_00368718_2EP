using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HugoApp_2EP
{
    public partial class frmNormalUser : Form
    {
        private AppUser usuario;
        public frmNormalUser(AppUser pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
        }

        private void frmNormalUser_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text =
                "Bienvenido " + usuario.fullName + " [" + (usuario.userType ? "Administrador" : "Usuario") + "]";

            actualizarControles();
        }

        public void actualizarControles()
        {
            List<AppUser> lista = AppUserDAO.getListaP(usuario.idUser);
            List<Order> listO = OrderDAO.getOListP(usuario.idUser);
            List<Address> listA = AddressDAO.getPList(usuario.idUser);
            List<Business> listaB = BusinessDAO.getBList();
            List<Product> listaP = ProductDAO.getPList(Convert.ToInt32(comboBox2.SelectedValue));
            
            comboBox3.DataSource = null;
            comboBox3.ValueMember = "idProduct";
            comboBox3.DisplayMember = "name";
            comboBox3.DataSource = listaP;

            comboBox1.DataSource = null;
            comboBox1.ValueMember = "idUser";
            comboBox1.DisplayMember = "userName";
            comboBox1.DataSource = lista;
            
            comboBox2.DataSource = null;
            comboBox2.ValueMember = "idBusiness";
            comboBox2.DisplayMember = "name";
            comboBox2.DataSource = listaB;

            comboBox5.DataSource = null;
            comboBox5.ValueMember = "idOrder";
            comboBox5.DisplayMember = "idProduct";
            comboBox5.DataSource = listO;
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listO;

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listA;
        }


        private void tabPage2_Enter(object sender, EventArgs e)
        {
            actualizarControles();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length >= 5)
                {
                    AddressDAO.createAddress(usuario.idUser, textBox1.Text);
                    MessageBox.Show("¡Direccion agregada exitosamente!", 
                        "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    textBox1.Clear();
                    actualizarControles();
                }
                else
                {
                    MessageBox.Show("Favor digite una direccion (longitud minima, 5 caracteres)", 
                        "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("No fue posible registrar la nueva direccion", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDAO.crearOrder(DateTime.Now, Convert.ToInt32(comboBox3.SelectedValue.ToString()), 
                    Convert.ToInt32(comboBox4.SelectedValue.ToString()));
                MessageBox.Show("¡Orden agregada exitosamente!", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarControles();
            }
            catch (Exception exp)
            {
                MessageBox.Show("No fue posible registrar la orden", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Product> listaP = ProductDAO.getPList(Convert.ToInt32(comboBox2.SelectedValue));
            comboBox3.DataSource = null;
            comboBox3.ValueMember = "idProduct";
            comboBox3.DisplayMember = "name";
            comboBox3.DataSource = listaP;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Address> listA = AddressDAO.getPList(usuario.idUser);
            comboBox4.DataSource = null;
            comboBox4.ValueMember = "idAddres";
            comboBox4.DisplayMember = "address";
            comboBox4.DataSource = listA;
            
        }

        private void frmNormalUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDAO.eliminarOrden(Convert.ToInt32(comboBox5.SelectedValue));
                MessageBox.Show("¡Orden ELIMINADA exitosamente!", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarControles();
            }
            catch (Exception exp)
            {
                MessageBox.Show("No fue posible eliminar la orden", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}