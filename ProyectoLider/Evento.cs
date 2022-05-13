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
    public partial class Evento : Form
    {
        public Evento()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=JOS-V-PC\\SERVER;database=Proyecto_Lider;integrated security=true");


        public void llenar_tabla()
        {
            string consulta = "Select id_evento, Departamentos.nombre AS DEPTO, codevento, evento, modalidad, cargahoraria,  desdefecha, hastafecha, estado from Eventos inner join Departamentos ON Eventos.id_departamento = Departamentos.id_departamento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
        }

        public void limpiar_campos()
        {
            txtIdEvento.Clear();
            txtCodEvento.Clear();
            txtEvento.Clear();
            txtModalidad.Clear();
            txtCargaHoraria.Clear();                        
            datetpStart.ResetText();
            datetpEnd.ResetText();
            rbActivo.ResetText();
            rbNOactivo.ResetText();            
            cmbxDepartamento.ResetText();
            txtBuscar.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "INSERT INTO Eventos VALUES (" + Convert.ToInt32(cmbxDepartamento.SelectedValue) + ", '" + txtCodEvento.Text + "', '" + txtEvento.Text + "', '" + txtModalidad.Text + "', " + txtCargaHoraria.Text + ",  '" + datetpStart.Text + "', '" + datetpEnd.Text + "', " + Convert.ToInt32(cmbEstados.SelectedIndex) + ") ";
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
            string consulta = "update Eventos set id_departamento=" + Convert.ToInt32(cmbxDepartamento.SelectedValue) + ", codevento='" + txtCodEvento.Text + "', evento='" + txtEvento.Text + "', modalidad='" + txtModalidad.Text + "', cargahoraria='" + txtCargaHoraria.Text + "',  desdefecha='" + datetpStart.Text + "', hastafecha='" + datetpEnd.Text + "', estado=" + Convert.ToInt32(cmbEstados.SelectedIndex) + " WHERE id_evento=" + txtIdEvento.Text + "";
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
            string consulta = "delete from Eventos where id_evento=" + txtIdEvento.Text + "";
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
            string consulta = "Select id_evento, Departamentos.nombre AS DEPTO, codevento, evento, modalidad, cargahoraria,  desdefecha, hastafecha, estado from Eventos inner join Departamentos ON Eventos.id_departamento = Departamentos.id_departamento where id_evento=" + txtBuscar.Text + "";
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

        private void Evento_Load(object sender, EventArgs e)
        {
            conexion.Open();          
            string consulta = "Select id_evento, Departamentos.nombre AS DEPTO, codevento, evento, modalidad, cargahoraria,  desdefecha, hastafecha, estado from Eventos inner join Departamentos ON Eventos.id_departamento = Departamentos.id_departamento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
            conexion.Close();
            ListarDepartamentos();
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int indice = cmbEstados.SelectedIndex + 1;
            //String Estado = cmbEstados.Items[indice].ToString();


            txtIdEvento.Text = DGV1.CurrentRow.Cells[0].Value.ToString();
            cmbxDepartamento.Text = DGV1.CurrentRow.Cells[1].Value.ToString();
            txtCodEvento.Text = DGV1.CurrentRow.Cells[2].Value.ToString();
            txtEvento.Text = DGV1.CurrentRow.Cells[3].Value.ToString();
            txtModalidad.Text = DGV1.CurrentRow.Cells[4].Value.ToString();
            txtCargaHoraria.Text = DGV1.CurrentRow.Cells[5].Value.ToString();
            datetpStart.Text = DGV1.CurrentRow.Cells[6].Value.ToString();
            datetpEnd.Text = DGV1.CurrentRow.Cells[7].Value.ToString();
            cmbEstados.Text = DGV1.CurrentRow.Cells[8].Value.ToString();
            //txtNcuenta.Text = DGV1.CurrentRow.Cells[8].Value.ToString();

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
