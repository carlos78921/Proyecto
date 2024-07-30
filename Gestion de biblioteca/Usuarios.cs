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
    public partial class frmUsuarios : Form
    {
        private List<frmUsuarios> _Usuarios;
        private frmUsuarios _UsuarioSeleccionada;
        public frmUsuarios()
        {
            InitializeComponent();
            bindingUsuarios.DataSource = _Usuarios;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                _UsuarioSeleccionada = (frmUsuarios)dataGridView1.SelectedRows[0].DataBoundItem;
            }
        }
        private void btndetalle_Click(object sender, EventArgs e)
        {
            if (_UsuarioSeleccionada != null)
            {
                frmlibros mostrarForm = new frmlibros();
                mostrarForm._Modo = ModoFormulario.Consultar;
                mostrarForm._Usuarios = _UsuarioSeleccionada;
                mostrarForm.ShowDialog();
                mostrarForm.Dispose();
                mostrarForm = null;
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (_UsuarioSeleccionada != null)
            {
                frmUsuario editarForm = new frmUsuario();
                editarForm.Modo = ModoFormulario.Modificar;
                editarForm.Usuario = _UsuarioSeleccionada;
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            frmUsuario nuevoUsuario = new frmUsuario();
            nuevoUsuario.Modo = ModoFormulario.Nuevo;
            nuevoUsuario.Dispose();
            nuevoUsuario = null;
        }
    }
}
