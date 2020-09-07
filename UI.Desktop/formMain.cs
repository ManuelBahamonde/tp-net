using Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace UI.Desktop {
    public partial class formMain : Form {
        public formMain() {
            InitializeComponent();

        }

        private void mnuSalir_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void formMain_shown(object sender, EventArgs e) {
            formLogin appLogin = new formLogin();
            if(appLogin.ShowDialog() != DialogResult.OK) {
                this.Dispose();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) {
            Usuarios appUsuarios = new Usuarios();
            appUsuarios.ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e) {
            Especialidades appEspecialidades = new Especialidades();
            appEspecialidades.ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes appPlanes = new Planes();
            appPlanes.ShowDialog();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones appComisiones = new Comisiones();
            appComisiones.ShowDialog();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas appPersonas = new Personas();
            appPersonas.ShowDialog();
        }
    }
}
