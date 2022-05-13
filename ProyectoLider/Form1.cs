using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace ProyectoLider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=JOS-V-PC\\SERVER;database=Proyecto_Lider;integrated security=true");

        public void limpiar_campos()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
        }

        /*
        Autor : Jose Bernal Yujra Charca
        Fecha : 03-05-2022
        Descripcion : Login con Tres intentos
        */
        int contador = 3;
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            conexion.Open();

            string consulta = "select * from Usuarios where usuario='" + txtUsuario.Text + "' AND CONVERT(varchar(MAX), DECRYPTBYPASSPHRASE('password', contrasena))='" + txtPassword.Text + "'";            
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.HasRows == true)
            {
                MessageBox.Show("Bienvenido al Sistema.... ");
                //Menu frmMenu = new ProyectoLider.Menu();
                Menus frmMenu = new ProyectoLider.Menus();
                this.Hide();
                frmMenu.Show();
            }
            else
            {
                contador--;
                MessageBox.Show("Usuario y Contrasena Incorrectos. Te quedá " + contador + " intentos");
                limpiar_campos();
                if (contador == 0)
                {
                    MessageBox.Show("LLegó al máximo de intentos");
                    Close();
                }
            }
            conexion.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
