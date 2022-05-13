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
    public partial class Participante : Form
    {
        public Participante()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=JOS-V-PC\\SERVER;database=Proyecto_Lider;integrated security=true");

        public void llenar_tabla()
        {
            //string consulta = "select * from Participantes";
            string consulta = "Select id_participante, Departamentos.nombre AS DEPTO, codparticipante, Participantes.nombre, apellido, ci, gradoacademico, correo, telefono, fechanac, profesion, foto from Participantes inner join Departamentos ON Participantes.id_departamento = Departamentos.id_departamento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
        }

        public void limpiar_campos()
        {
            txtIdParticipante.Clear();
            txtCodParticipante.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCI.Clear();
            txtGradoAcad.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtprofesion.Clear();
            dateFechaNac.ResetText();
            cmbxDepartamento.ResetText();
            txtBuscar.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //ListarDepartamentos();
            //int var;
            //var = Convert.ToInt32(cmbxDepartamento.SelectedValue);
            //txtBuscar.Text = cmbxDepartamento.ValueMember ;
            
            conexion.Open();
            string consulta = "INSERT INTO Participantes VALUES ("+ Convert.ToInt32(cmbxDepartamento.SelectedValue) + ", '" + txtCodParticipante.Text + "', '" + txtNombres.Text + "', '" + txtApellidos.Text + "', " + txtCI.Text + ", '" + txtGradoAcad.Text + "', '" + txtCorreo.Text + "', " + txtTelefono.Text + ", '" + dateFechaNac.Text + "', '" + txtprofesion.Text + "', 'default.jpg') ";
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
            string consulta = "update Participantes set id_departamento=" + Convert.ToInt32(cmbxDepartamento.SelectedValue) + ", codparticipante='" + txtCodParticipante.Text + "', nombre='" + txtNombres.Text + "', apellido='" + txtApellidos.Text + "', ci=" + txtCI.Text + ", gradoacademico='" + txtGradoAcad.Text + "', correo='" + txtCorreo.Text + "', telefono=" + txtTelefono.Text + " , fechanac='" + dateFechaNac.Text + "', profesion='" + txtprofesion.Text + "', foto='default1.jpg' WHERE id_participante=" + txtIdParticipante.Text + "";            
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
            string consulta = "delete from Participantes where id_participante=" + txtIdParticipante.Text + "";
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
            string consulta = "Select id_participante, Departamentos.nombre AS DEPTO, codparticipante, Participantes.nombre, apellido, ci, gradoacademico, correo, telefono, fechanac, profesion, foto from Participantes inner join Departamentos ON Participantes.id_departamento = Departamentos.id_departamento where id_participante=" + txtBuscar.Text + "";
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

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdParticipante.Text = DGV1.CurrentRow.Cells[0].Value.ToString();
            cmbxDepartamento.Text = DGV1.CurrentRow.Cells[1].Value.ToString();
            txtCodParticipante.Text = DGV1.CurrentRow.Cells[2].Value.ToString();
            txtNombres.Text = DGV1.CurrentRow.Cells[3].Value.ToString();
            txtApellidos.Text = DGV1.CurrentRow.Cells[4].Value.ToString();
            txtCI.Text = DGV1.CurrentRow.Cells[5].Value.ToString();
            txtGradoAcad.Text = DGV1.CurrentRow.Cells[6].Value.ToString();
            txtCorreo.Text = DGV1.CurrentRow.Cells[7].Value.ToString();
            txtTelefono.Text = DGV1.CurrentRow.Cells[8].Value.ToString();
            dateFechaNac.Text = DGV1.CurrentRow.Cells[9].Value.ToString();
            txtprofesion.Text = DGV1.CurrentRow.Cells[10].Value.ToString();
            //.Text = DGV1.CurrentRow.Cells[2].Value.ToString();
        }

        private void Participante_Load(object sender, EventArgs e)
        {
            conexion.Open();
            //string consulta = "select * from Participantes";
            string consulta = "Select id_participante, Departamentos.nombre AS DEPTO, codparticipante, Participantes.nombre, apellido, ci, gradoacademico, correo, telefono, fechanac, profesion, foto from Participantes inner join Departamentos ON Participantes.id_departamento = Departamentos.id_departamento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
            conexion.Close();
            ListarDepartamentos();
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

        private void cmbxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int id_dep = Convert.ToInt32(cmbxDepartamento.SelectedValue);
            //txtBuscar.Text = cmbxDepartamento.SelectedValue.ToString();
        }
        /*public void ListarDepartamentos()
{
   SqlCommand comando = new SqlCommand("SELECT id_departamento, nombre FROM Departamentos", conexion);
   conexion.Open();            
   SqlDataReader registro = comando.ExecuteReader();
   while (registro.Read()) {
       cmbxDepartamento.Items.Add(registro["nombre"].ToString());
       cmbxDepartamento.ValueMember = registro["id_departamento"].ToString();

   }
   conexion.Close();

}*/

        /* public DataTable ListarDepartamentos() {           
             conexion.Open();
             SqlCommand comando = new SqlCommand();
             SqlDataAdapter LeerFilas;
             DataTable Tabla = new DataTable();
             comando.CommandText = "ListarDepartamentos";
             comando.CommandType = CommandType.StoredProcedure;
             LeerFilas = comando.ExecuteReader;
             Tabla.Load(LeerFilas);
             LeerFilas.Close();
             conexion.Close();
             return Tabla;
         }*/
    }
}
