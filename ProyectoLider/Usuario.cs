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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=JOS-V-PC\\SERVER;database=Proyecto_Lider;integrated security=true");

        public void llenar_tabla()
        {
            //string consulta = "select * from Usuarios";
            string consulta = "select id_usuario, usuario, CONVERT(varchar(MAX), DECRYPTBYPASSPHRASE('password', contrasena)) AS DESENCRIPTADO from Usuarios";
          SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
        }

        public void limpiar_campos()
        {           
            txtUsuario.Clear();
            txtPassword.Clear();
            txtBuscar.Clear();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "INSERT INTO Usuarios VALUES ('" + txtUsuario.Text + "', ENCRYPTBYPASSPHRASE('password','" + txtPassword.Text + "') ) ";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro adicionado Correctamente.....");
            llenar_tabla();
            limpiar_campos();
            conexion.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "update Usuarios set usuario='" + txtUsuario.Text + "', contrasena= ENCRYPTBYPASSPHRASE('password','" + txtPassword.Text + "') WHERE id_usuario=" + txtBuscar.Text + "";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            int cantidad;
            cantidad = comando.ExecuteNonQuery();
            if (cantidad > 0)
            {
                MessageBox.Show("Registro Modificado Satisfactoriamente....");
            }
            llenar_tabla();
            limpiar_campos();
            conexion.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "delete from Usuarios where id_usuario=" + txtBuscar.Text + "";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro eliminado correctamente....");
            llenar_tabla();
            limpiar_campos();
            conexion.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "select id_usuario, usuario, CONVERT(varchar(MAX), DECRYPTBYPASSPHRASE('password', contrasena)) AS DESENCRIPTADO from Usuarios where id_usuario=" + txtBuscar.Text + "";            
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
            conexion.Close();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            llenar_tabla();
            limpiar_campos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "select id_usuario, usuario, CONVERT(varchar(MAX), DECRYPTBYPASSPHRASE('password', contrasena)) AS DESENCRIPTADO from Usuarios";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
            conexion.Close();
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBuscar.Text = DGV1.CurrentRow.Cells[0].Value.ToString();
            txtUsuario.Text = DGV1.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = DGV1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
