using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLider
{
    public partial class Menus : Form
    {
        public Menus()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Usuario frmUsuario = new Usuario();
            frmUsuario.ShowDialog();
        }

        private void btnParticipante_Click(object sender, EventArgs e)
        {
            Participante frmParticipante = new Participante();
            frmParticipante.ShowDialog();
        }

        private void btnDocente_Click(object sender, EventArgs e)
        {
            Docente frmDocente = new Docente();
            frmDocente.ShowDialog();
        }

        private void btnEvento_Click(object sender, EventArgs e)
        {
            Evento frmEvento = new Evento();
            frmEvento.ShowDialog();
        }

        private void btnCetificado_Click(object sender, EventArgs e)
        {
            Certificado frmCertificado = new Certificado();
            frmCertificado.ShowDialog();
        }

        private void btnAsigDocEv_Click(object sender, EventArgs e)
        {
            DocenteEvento frmDocenteEvento = new DocenteEvento();
            frmDocenteEvento.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
