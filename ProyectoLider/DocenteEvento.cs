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
    public partial class DocenteEvento : Form
    {
        public DocenteEvento()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=JOS-V-PC\\SERVER;database=Proyecto_Lider;integrated security=true");


        public void llenar_tabla()
        {
            string consulta = "select id_docente_eventos, Concat(Docentes.ci, ' - ',  Docentes.nombre, ' ', Docentes.apellido) AS Docente, Concat(Eventos.evento, ' - ',  Eventos.modalidad, ' ', Eventos.cargahoraria) AS Eventos from DocenteEventos inner join Docentes on Docentes.id_docente = DocenteEventos.id_docente inner join Eventos on Eventos.id_evento = DocenteEventos.id_evento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
        }

        public void limpiar_campos()
        {
            txtIdDocenteEvento.Clear();            
            cmbxDocentes.ResetText();
            cmbxEvento.ResetText();
            txtBuscar.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "INSERT INTO DocenteEventos VALUES (" + Convert.ToInt32(cmbxDocentes.SelectedValue) + ", " + Convert.ToInt32(cmbxEvento.SelectedValue) + ") ";
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
            string consulta = "update DocenteEventos set id_docente=" + Convert.ToInt32(cmbxDocentes.SelectedValue) + ", id_evento=" + Convert.ToInt32(cmbxEvento.SelectedValue) + " WHERE id_docente_eventos=" + txtIdDocenteEvento.Text + "";
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
            string consulta = "delete from DocenteEventos where id_docente_eventos=" + txtIdDocenteEvento.Text + "";
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
            string consulta = "select id_docente_eventos, Concat(Docentes.ci, ' - ',  Docentes.nombre, ' ', Docentes.apellido) AS Docente, Concat(Eventos.evento, ' - ',  Eventos.modalidad, ' ', Eventos.cargahoraria) AS Eventos from DocenteEventos inner join Docentes on Docentes.id_docente = DocenteEventos.id_docente inner join Eventos on Eventos.id_evento = DocenteEventos.id_evento where id_docente_eventos=" + txtBuscar.Text + "";
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
            txtIdDocenteEvento.Text = DGV1.CurrentRow.Cells[0].Value.ToString();
            cmbxDocentes.Text = DGV1.CurrentRow.Cells[1].Value.ToString();
            cmbxEvento.Text = DGV1.CurrentRow.Cells[2].Value.ToString();
        }

        private void DocenteEvento_Load(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "select id_docente_eventos, Concat(Docentes.ci, ' - ',  Docentes.nombre, ' ', Docentes.apellido) AS Docente, Concat(Eventos.evento, ' - ',  Eventos.modalidad, ' ', Eventos.cargahoraria) AS Eventos from DocenteEventos inner join Docentes on Docentes.id_docente = DocenteEventos.id_docente inner join Eventos on Eventos.id_evento = DocenteEventos.id_evento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
            conexion.Close();
            ListarDocentes();
            ListarEventos();
        }

        public void ListarDocentes()
        {
            conexion.Open();
            string consulta = "select id_docente, Concat(ci, ' - ',  nombre, ' ', apellido) AS Docente from Docentes";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            cmbxDocentes.DataSource = tabla;
            cmbxDocentes.ValueMember = "id_docente";
            cmbxDocentes.DisplayMember = "Docente";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in tabla.Rows)
            {
                coleccion.Add(Convert.ToString(row["Docente"]));
            }
            cmbxDocentes.AutoCompleteCustomSource = coleccion;
            cmbxDocentes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbxDocentes.AutoCompleteSource = AutoCompleteSource.CustomSource;

            conexion.Close();

        }

        public void ListarEventos()
        {
            conexion.Open();
            string consulta = "select id_evento, Concat(evento, ' - ', modalidad, ' ', cargahoraria) AS Evento from Eventos";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            cmbxEvento.DataSource = tabla;
            cmbxEvento.ValueMember = "id_evento";
            cmbxEvento.DisplayMember = "Evento";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in tabla.Rows)
            {
                coleccion.Add(Convert.ToString(row["Evento"]));
            }
            cmbxEvento.AutoCompleteCustomSource = coleccion;
            cmbxEvento.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbxEvento.AutoCompleteSource = AutoCompleteSource.CustomSource;

            conexion.Close();

        }
    }
}
