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
    public partial class frmUsuario : Form
    {
        private frmUsuario _Usuario;
        private ModoFormulario _modo;
        public frmUsuario()
        {
            InitializeComponent();
            _Usuario = new frmUsuario();
            _modo = ModoFormulario.Nuevo;
        }
        private void setClientToControls()
        {
            if (_Usuario.Codigo != 0)
            {
                txtcodigo.Text = _Usuario.codigo.ToString();
                txtnombre.Text = _Usuario.nombre;
                txtapellido.Text = _Usuario.apellido;
                txtEmail.Text = _Usuario.Email;
                txtTelefono.Text = _Usuario.Telefono;
                txtDireccion.Text = _Usuario.Direccion;
                txtRegistro.Text = _Usuario.Registro;
                txtcodigo.ReadOnly = true;
                setReadOnly();

            }
        }
        private void setReadOnly()
        {
            if (_modo == ModoFormulario.Consultar || _modo == ModoFormulario.Eliminar)
            {
                txtcodigo.ReadOnly = true;
                txtnombre.ReadOnly = true;
                txtapellido.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtRegistro.ReadOnly = true;
                if (_modo == ModoFormulario.Consultar)
                {
                    btnConfirma.Visible = false;
                }
            }
        }

        public frmUsuario Usuario
        {
            get => _Usuario;
            set
            {
                _Usuario = value;
                setClientToControls();
            }
        }

        public ModoFormulario Modo
        {
            get => _modo;
            set
            {
                switch (value)
                {
                    case ModoFormulario.Modificar:
                    case ModoFormulario.Eliminar:
                    case ModoFormulario.Consultar:
                        setClientToControls();
                        break;
                    case ModoFormulario.Nuevo:
                        break;
                }
                _modo = value;
            }
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            this._Usuario = new Usuario(
                int.Parse(txtcodigo.Text),
                txtnombre.Text,
                txtapellido.Text,
                txtEmail.Text,
                txtTelefono.Text,
                txtDireccion.Text,
                txtRegistro.Text
            );
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
