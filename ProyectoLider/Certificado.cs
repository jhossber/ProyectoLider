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
    public partial class Certificado : Form
    {
        public Certificado()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=JOS-V-PC\\SERVER;database=Proyecto_Lider;integrated security=true");


        public void llenar_tabla()
        {
            //string consulta = "Select id_curso_evento, Concat(Docentes.ci, ' - ', Docentes.nombre, ' ', Docentes.apellido) AS Docente , CONCAT(Participantes.ci, ' - ', Participantes.nombre, ' ', Participantes.nombre ) AS Participante, nota, fechaevento, imagen, codigoqr, imagenqr from CursoEventos inner join DocenteEventos ON DocenteEventos.id_docente_eventos = CursoEventos.id_docente_eventos inner join Participantes ON Participantes.id_participante = CursoEventos.id_participante inner join Docentes ON Docentes.id_docente = DocenteEventos.id_docente";
            string consulta = "Select id_curso_evento, Concat(Docentes.ci, ' - ',  Docentes.nombre, ' ', Docentes.apellido, ' --- ', Eventos.evento) AS DocenteImparte , CONCAT(Participantes.ci, ' - ', Participantes.nombre, ' ', Participantes.apellido ) AS Participante, nota, fechaevento, imagen, codigoqr, imagenqr from CursoEventos inner join DocenteEventos ON DocenteEventos.id_docente_eventos = CursoEventos.id_docente_eventos inner join Participantes ON Participantes.id_participante = CursoEventos.id_participante inner join Docentes ON Docentes.id_docente = DocenteEventos.id_docente inner join Eventos ON Eventos.id_evento = DocenteEventos.id_evento";
            //string consulta = "Select id_curso_evento, CursoEventos.id_docente_eventos , CONCAT(Participantes.ci, ' - ', Participantes.nombre, ' ', Participantes.apellido ) AS Participante, nota, fechaevento, imagen, codigoqr, imagenqr from CursoEventos inner join DocenteEventos ON DocenteEventos.id_docente_eventos = CursoEventos.id_docente_eventos inner join Participantes ON Participantes.id_participante = CursoEventos.id_participante inner join Docentes ON Docentes.id_docente = DocenteEventos.id_docente inner join Eventos ON Eventos.id_evento = DocenteEventos.id_evento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
        }

        public void limpiar_campos()
        {
            txtIdCertificado.Clear();
            txtNota.Clear();
            dateFevento.ResetText();
            txtCodQR.Clear();
            cmbxDocentes.ResetText();
            cmbxParticipante.ResetText();
            // txtModalidad.Clear();

            txtBuscar.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "INSERT INTO CursoEventos VALUES (" + Convert.ToInt32(cmbxDocentes.SelectedValue) + ", " + Convert.ToInt32(cmbxParticipante.SelectedValue) + ", " + txtNota.Text + ", '" + dateFevento.Text + "', 'ima.jp', 'codigo aqui', 'imagenqr aqui') ";
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
            string consulta = "update CursoEventos set id_docente_eventos=" + Convert.ToInt32(cmbxDocentes.SelectedValue) + ", id_participante=" + Convert.ToInt32(cmbxParticipante.SelectedValue) + ", nota='" + txtNota.Text + "', fechaevento='" + dateFevento.Text + "', imagen='ima update.jpg', codigoqr='codigo qr .gif',  imagenqr='ima qr jos' WHERE id_curso_evento=" + txtIdCertificado.Text + "";
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
            string consulta = "delete from CursoEventos where id_curso_evento=" + txtIdCertificado.Text + "";
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
            string consulta = "Select id_curso_evento, Concat(Docentes.ci, ' - ',  Docentes.nombre, ' ', Docentes.apellido, ' --- ', Eventos.evento) AS DocenteImparte , CONCAT(Participantes.ci, ' - ', Participantes.nombre, ' ', Participantes.apellido ) AS Participante, nota, fechaevento, imagen, codigoqr, imagenqr from CursoEventos inner join DocenteEventos ON DocenteEventos.id_docente_eventos = CursoEventos.id_docente_eventos inner join Participantes ON Participantes.id_participante = CursoEventos.id_participante inner join Docentes ON Docentes.id_docente = DocenteEventos.id_docente inner join Eventos ON Eventos.id_evento = DocenteEventos.id_evento where id_curso_evento=" + txtBuscar.Text + "";
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
            txtIdCertificado.Text = DGV1.CurrentRow.Cells[0].Value.ToString();
            cmbxDocentes.Text = DGV1.CurrentRow.Cells[1].Value.ToString();
            cmbxParticipante.Text = DGV1.CurrentRow.Cells[2].Value.ToString();
            txtNota.Text = DGV1.CurrentRow.Cells[3].Value.ToString();
            dateFevento.Text = DGV1.CurrentRow.Cells[4].Value.ToString();
            //txtCodQR.Text = DGV1.CurrentRow.Cells[4].Value.ToString();
            //txtCargaHoraria.Text = DGV1.CurrentRow.Cells[5].Value.ToString();
            //datetpStart.Text = DGV1.CurrentRow.Cells[6].Value.ToString();
            //datetpEnd.Text = DGV1.CurrentRow.Cells[7].Value.ToString();
        }

        private void Certificado_Load(object sender, EventArgs e)
        {
            conexion.Open();
            ////////string consulta = "Select id_curso_evento, Concat(Docentes.ci, ' - ', CursoEventos.id_docente_eventos, ' - ',  Docentes.nombre, ' ', Docentes.apellido, ' --- ', Eventos.evento) AS DocenteImparte , CONCAT(Participantes.ci, ' - ', Participantes.nombre, ' ', Participantes.apellido ) AS Participante, nota, fechaevento, imagen, codigoqr, imagenqr from CursoEventos inner join DocenteEventos ON DocenteEventos.id_docente_eventos = CursoEventos.id_docente_eventos inner join Participantes ON Participantes.id_participante = CursoEventos.id_participante inner join Docentes ON Docentes.id_docente = DocenteEventos.id_docente inner join Eventos ON Eventos.id_evento = DocenteEventos.id_evento";
            //string consulta = "Select id_evento, Departamentos.nombre AS DEPTO, codevento, evento, modalidad, cargahoraria,  desdefecha, hastafecha, estado from Eventos inner join Departamentos ON Eventos.id_departamento = Departamentos.id_departamento";
            //string consulta = "Select id_curso_evento, CursoEventos.id_docente_eventos , CONCAT(Participantes.ci, ' - ', Participantes.nombre, ' ', Participantes.apellido ) AS Participante, nota, fechaevento, imagen, codigoqr, imagenqr from CursoEventos inner join DocenteEventos ON DocenteEventos.id_docente_eventos = CursoEventos.id_docente_eventos inner join Participantes ON Participantes.id_participante = CursoEventos.id_participante inner join Docentes ON Docentes.id_docente = DocenteEventos.id_docente inner join Eventos ON Eventos.id_evento = DocenteEventos.id_evento";
            string consulta = "Select id_curso_evento, Concat(Docentes.ci, ' - ',  Docentes.nombre, ' ', Docentes.apellido, ' --- ', Eventos.evento) AS DocenteImparte , CONCAT(Participantes.ci, ' - ', Participantes.nombre, ' ', Participantes.apellido ) AS Participante, nota, fechaevento, imagen, codigoqr, imagenqr from CursoEventos inner join DocenteEventos ON DocenteEventos.id_docente_eventos = CursoEventos.id_docente_eventos inner join Participantes ON Participantes.id_participante = CursoEventos.id_participante inner join Docentes ON Docentes.id_docente = DocenteEventos.id_docente inner join Eventos ON Eventos.id_evento = DocenteEventos.id_evento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGV1.DataSource = dt;
            conexion.Close();
            ListarDocentesEventos();
            ListarParticipantes();
        }

        public void ListarDocentesEventos()
        {
            conexion.Open();
            string consulta = "Select id_docente_eventos, Concat(Docentes.ci, ' - ', Docentes.nombre, ' ', Docentes.apellido, ' --- ', Eventos.evento ) AS ImpartidoDocente from DocenteEventos inner join Docentes ON Docentes.id_docente = DocenteEventos.id_docente inner join Eventos ON Eventos.id_evento = DocenteEventos.id_evento";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            cmbxDocentes.DataSource = tabla;
            cmbxDocentes.ValueMember = "id_docente_eventos";
            cmbxDocentes.DisplayMember = "ImpartidoDocente";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach(DataRow row in tabla.Rows)
            {
                coleccion.Add(Convert.ToString(row["ImpartidoDocente"]));
            }
            cmbxDocentes.AutoCompleteCustomSource = coleccion;
            cmbxDocentes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbxDocentes.AutoCompleteSource = AutoCompleteSource.CustomSource;

            conexion.Close();

        }

        public void ListarParticipantes()
        {
            conexion.Open();
            string consulta = "Select id_participante, CONCAT(Participantes.ci, ' - ', Participantes.nombre, ' ', Participantes.apellido ) AS DatosParticipante  from Participantes";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            cmbxParticipante.DataSource = tabla;
            cmbxParticipante.ValueMember = "id_participante";
            cmbxParticipante.DisplayMember = "DatosParticipante";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in tabla.Rows)
            {
                coleccion.Add(Convert.ToString(row["DatosParticipante"]));
            }
            cmbxParticipante.AutoCompleteCustomSource = coleccion;
            cmbxParticipante.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbxParticipante.AutoCompleteSource = AutoCompleteSource.CustomSource;

            conexion.Close();

        }

   
    }
}
