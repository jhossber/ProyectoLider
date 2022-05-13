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
    public partial class Docente : Form
    {
        public Docente()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=JOS-V-PC\\SERVER;database=Proyecto_Lider;integrated security=true");


        public void llenar_tabla()
        {
            string consulta = "Select id_docente, Departamentos.nombre AS DEPTO, coddocente, ci, Docentes.nombre, apellido,  gradoacademico, profesion, nrocuentabanco, correo, celular from Docentes inner join Departamentos ON Docentes.id_departamento = Departamentos.id_departamento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
        }

        public void limpiar_campos()
        {
            txtIdDocente.Clear();
            txtCodDocente.Clear();
            txtCI.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();            
            txtGradoAcad.Clear();
            txtprofesion.Clear();
            txtNcuenta.Clear();
            txtCorreo.Clear();
            txtCelular.Clear();
            cmbxDepartamento.ResetText();
            txtBuscar.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "INSERT INTO Docentes VALUES (" + Convert.ToInt32(cmbxDepartamento.SelectedValue) + ", '" + txtCodDocente.Text + "', " + txtCI.Text + ", '" + txtNombres.Text + "', '" + txtApellidos.Text + "',  '" + txtGradoAcad.Text + "', '" + txtprofesion.Text + "', " + txtNcuenta.Text + ", '" + txtCorreo.Text + "',  '" + txtCelular.Text + "') ";
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
            string consulta = "update Docentes set id_departamento=" + Convert.ToInt32(cmbxDepartamento.SelectedValue) + ", coddocente='" + txtCodDocente.Text + "', ci=" + txtCI.Text + ", nombre='" + txtNombres.Text + "', apellido='" + txtApellidos.Text + "',  gradoacademico='" + txtGradoAcad.Text + "', profesion='" + txtprofesion.Text + "', nrocuentabanco=" + txtNcuenta.Text + " , correo='" + txtCorreo.Text + "',  celular='" + txtCelular.Text + "' WHERE id_docente=" + txtIdDocente.Text + "";
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
            string consulta = "delete from Docentes where id_docente=" + txtIdDocente.Text + "";
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
            string consulta = "Select id_docente, Departamentos.nombre AS DEPTO, coddocente, ci, Docentes.nombre, apellido,  gradoacademico, profesion, nrocuentabanco, correo, celular from Docentes inner join Departamentos ON Docentes.id_departamento = Departamentos.id_departamento where id_docente=" + txtBuscar.Text + "";
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

        private void Docente_Load(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "Select id_docente, Departamentos.nombre AS DEPTO, coddocente, ci, Docentes.nombre, apellido,  gradoacademico, profesion, nrocuentabanco, correo, celular from Docentes inner join Departamentos ON Docentes.id_departamento = Departamentos.id_departamento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
            conexion.Close();
            ListarDepartamentos();
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdDocente.Text = DGV1.CurrentRow.Cells[0].Value.ToString();
            cmbxDepartamento.Text = DGV1.CurrentRow.Cells[1].Value.ToString();
            txtCodDocente.Text = DGV1.CurrentRow.Cells[2].Value.ToString();
            txtCI.Text = DGV1.CurrentRow.Cells[3].Value.ToString();
            txtNombres.Text = DGV1.CurrentRow.Cells[4].Value.ToString();
            txtApellidos.Text = DGV1.CurrentRow.Cells[5].Value.ToString(); 
            txtGradoAcad.Text = DGV1.CurrentRow.Cells[6].Value.ToString();
            txtprofesion.Text = DGV1.CurrentRow.Cells[7].Value.ToString();
            txtNcuenta.Text = DGV1.CurrentRow.Cells[8].Value.ToString();
            txtCorreo.Text = DGV1.CurrentRow.Cells[9].Value.ToString();
            txtCelular.Text = DGV1.CurrentRow.Cells[10].Value.ToString();
            
            
        }

        public void ListarDepartamentos()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT id_departamento, nombre FROM Departamentos", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            cmbxDepartamento.DataSource = tabla;
            cmbxDepartamento.ValueMember = "id_departamento";
            cmbxDepartamento.DisplayMember = "nombre";
            conexion.Close();

        }
    }
}
