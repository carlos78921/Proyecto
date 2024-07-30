using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_biblioteca
{
    public partial class frmlibros : Form
    {
        private List<frmlibros> _Libros;
        private frmlibros _LibroSeleccionada;
        public frmlibros()
        {
            InitializeComponent();
            bindingLibros.DataSource = _Libros;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                _LibroSeleccionada = (frmlibros)dataGridView1.SelectedRows[0].DataBoundItem;
            }
        }

        private void btnDetalle_Click_1(object sender, EventArgs e)
        {
            if (_LibroSeleccionada != null)
            {
                frmlibros mostrarForm = new frmlibros();
                mostrarForm._Modo = ModoFormulario.Consultar;
                mostrarForm._Libros = _LibroSeleccionada;
                mostrarForm.ShowDialog();
                mostrarForm.Dispose();
                mostrarForm = null;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmlibro nuevaLibro = new frmlibro();
            nuevaLibro.Modo = ModoFormulario.Nuevo;
            nuevaLibro.Dispose();
            nuevaLibro = null;
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            if (_LibroSeleccionada != null)
            {
                frmlibro eliminarForm = new frmlibro();
                eliminarForm.Modo = ModoFormulario.Eliminar;
                eliminarForm.libro = _LibroSeleccionada;
            }
        }
    }
}
