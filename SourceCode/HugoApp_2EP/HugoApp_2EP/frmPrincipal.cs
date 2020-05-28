using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HugoApp_2EP
{
    public partial class frmPrincipal : Form
    {

        private AppUser usuario;

        public frmPrincipal(AppUser pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text =
                "Bienvenido " + usuario.fullName + " [" + (usuario.userType ? "Administrador" : "Usuario") + "]";

            if (usuario.userType)
            {
                // Los administradores si tienen acceso a esta informacion
                actualizarControles();
            }
            else
            {
                // Los usuarios NO administradores no tienen permiso de acceder a estas pestanas
                tabControl1.TabPages[1].Parent = null;
                tabControl1.TabPages[1].Parent = null;
                tabControl1.TabPages[1].Parent = null;
            }
        }

        private void actualizarControles()
        {
            // Realizar consulta a la base de datos
            List<AppUser> lista = AppUserDAO.getLista();
            List<Business> listaB = BusinessDAO.getBList();
            List<Product> listaP = ProductDAO.getPList(Convert.ToInt32(comboBox3.SelectedValue));
            List<Product> listaPP = ProductDAO.getPList(Convert.ToInt32(comboBox4.SelectedValue));

            List<Order> listaO = OrderDAO.getOList();

            // Tabla (data grid view)
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            // Menu desplegable (combo box)
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "password";
            comboBox1.DisplayMember = "userName";
            comboBox1.DataSource = lista;

            comboBox2.DataSource = null;
            comboBox2.ValueMember = "name";
            comboBox2.DisplayMember = "name";
            comboBox2.DataSource = listaB;

            comboBox3.DataSource = null;
            comboBox3.ValueMember = "idBusiness";
            comboBox3.DisplayMember = "name";
            comboBox3.DataSource = listaB;

            comboBox4.DataSource = null;
            comboBox4.ValueMember = "idBusiness";
            comboBox4.DisplayMember = "name";
            comboBox4.DataSource = listaB;
            
            comboBox5.DataSource = null;
            comboBox5.ValueMember = "idProduct";
            comboBox5.DisplayMember = "name";
            comboBox5.DataSource = listaPP;

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listaB;

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = listaP;

            dataGridView4.DataSource = null;
            dataGridView4.DataSource = listaO;

        }

        public void loadByItem()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar al usuario " + comboBox1.Text + "?", 
                "Hugo App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppUserDAO.eliminar(comboBox1.Text);
                
                MessageBox.Show("¡Usuario eliminado exitosamente!", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                actualizarControles();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length >= 7 &&  textBox1.Text.Length >= 16)
                {
                    AppUserDAO.crearNuevo(textBox1.Text,textBox2.Text);
                    
                    MessageBox.Show("¡Usuario agregado exitosamente! Valores por defecto: " +
                                    "contrasena igual a usuario, no admin", 
                        "Clase GUI 06", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    textBox1.Clear();
                    textBox2.Clear();
                    actualizarControles();
                }
                else
                    MessageBox.Show("Favor digite un usuario (longitud minima, 7 caracteres)", 
                        "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario que ha digitado, no se encuentra disponible.", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text.Length >= 16)
                {
                    BusinessDAO.crearBusiness(textBox3.Text, textBox4.Text);
                    MessageBox.Show("¡Negocio agregado exitosamente!", 
                        "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    textBox3.Clear();
                    textBox4.Clear();
                    actualizarControles();
                }
                else
                {
                    MessageBox.Show("Favor digite una descripcion (longitud minima, 25 caracteres)", 
                        "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("No fue posible registrar el nuevo negocio", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("¿Seguro que desea eliminar el negocio " + comboBox2.Text + "?", 
                "Hugo App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BusinessDAO.eliminar(comboBox2.Text);
                
                MessageBox.Show("¡Negocio eliminado exitosamente!", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                actualizarControles();
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text.Length >= 4)
                {
                    ProductDAO.crearProduct(Convert.ToInt32(comboBox3.SelectedValue), textBox5.Text);
                    MessageBox.Show("¡Producto agregado exitosamente!", 
                        "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    textBox5.Clear();
                    actualizarControles();
                }
                else
                {
                    MessageBox.Show("Favor digite un nombre (longitud minima, 25 caracteres)", 
                        "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("No fue posible registrar el nuevo negocio", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            
            List<Product> listaPP = ProductDAO.getPList(Convert.ToInt32(comboBox4.SelectedValue));
            comboBox5.DataSource = null;
            comboBox5.ValueMember = "idProduct";
            comboBox5.DisplayMember = "name";
            comboBox5.DataSource = listaPP;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar este producto " + comboBox5.Text + "?", 
                "Hugo App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProductDAO.eliminar(Convert.ToInt32(comboBox5.SelectedValue.ToString()), Convert.ToInt32(comboBox4.SelectedValue.ToString()));
                
                MessageBox.Show("¡Negocio eliminado exitosamente!", 
                    "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                actualizarControles();
            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
    }
