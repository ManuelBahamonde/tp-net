using Business.Entities;
using Business.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop {
    public partial class Comisiones : Form {
        public Comisiones() {
            InitializeComponent();
            generarColumnas();
        }

        private void generarColumnas() {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "Id";
            this.dgvPlanes.Columns.Add(colId);

            DataGridViewTextBoxColumn colAnio = new DataGridViewTextBoxColumn();
            colId.Name = "anio";
            colId.HeaderText = "Año especialidad";
            colId.DataPropertyName = "AnioEspecialidad";
            this.dgvPlanes.Columns.Add(colAnio);

            DataGridViewTextBoxColumn colIdPlan = new DataGridViewTextBoxColumn();
            colId.Name = "idPlan";
            colId.HeaderText = "ID Plan";
            colId.DataPropertyName = "IdPlan";
            this.dgvPlanes.Columns.Add(colIdPlan);

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
            colId.Name = "descripcion";
            colId.HeaderText = "Descripcion";
            colId.DataPropertyName = "Descripcion";
            this.dgvPlanes.Columns.Add(colDescripcion);
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            ComisionDesktop iuComisiones = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            iuComisiones.ShowDialog();
            listar();
        }

        private void listar() {
            ComisionesLogic comLogic = new ComisionesLogic();
            dgvPlanes.DataSource = null;
            try {
                dgvPlanes.DataSource = comLogic.getAll();
            }catch(Exception exc) {
                DialogResult result = MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (dgvPlanes.GetCellCount(DataGridViewElementStates.Selected) > 0) {
                int idComSelected = ((Comision)dgvPlanes.SelectedRows[0].DataBoundItem).Id;
                ComisionDesktop iuComisiones = new ComisionDesktop(idComSelected, ApplicationForm.ModoForm.Modificacion);
                iuComisiones.ShowDialog();
                listar();
            }
            else {
                MessageBox.Show("Debe seleccionar la fila a modificar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (dgvPlanes.GetCellCount(DataGridViewElementStates.Selected) > 0) {
                int idComSelected = ((Comision)dgvPlanes.SelectedRows[0].DataBoundItem).Id;
                ComisionDesktop iuComisiones = new ComisionDesktop(idComSelected, ApplicationForm.ModoForm.Baja);
                iuComisiones.ShowDialog();
                listar();
            }
            else {
                MessageBox.Show("Debe seleccionar la fila a eliminar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e) {
            listar();
        }

        private void Comisiones_Load(object sender, EventArgs e) {
            listar();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
