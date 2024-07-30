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
    public partial class frmlibro : Form
    {
        private frmlibro _Libro;
        private ModoFormulario _modo;
        public frmlibro()
        {
            InitializeComponent();
            _Libro= new frmlibro();
            _modo = ModoFormulario.Nuevo;
        }

        private void setClientToControls()
        {
            if (_Libro.Codigo != 0)
            {
                txtCodigo.Text = _Libro.Codigo.ToString();
                txttitulo.Text = _Libro.titulo;
                txtautor.Text = _Libro.Autor;
                txtcategoria.Text = _Libro.Categorias;
                txtIBSN.Text = _Libro.ISbn;
                txtaño.Text = _Libro.año;
                txtEditoria.Text = _Libro.Editoria;
                txtCodigo.ReadOnly = true;
                setReadOnly();
               
            }
        }

        private void setReadOnly()
        {
            if (_modo == ModoFormulario.Consultar || _modo == ModoFormulario.Eliminar)
            {
                txtCodigo.ReadOnly = true;
                txttitulo.ReadOnly = true;
                txtautor.ReadOnly = true;
                txtcategoria.ReadOnly = true;
                txtIBSN.ReadOnly = true;
                txtaño.ReadOnly = true;
                txtEditoria.ReadOnly = true;
                if (_modo == ModoFormulario.Consultar)
                {
                    btncorfirma.Visible = false;
                }
            }
        }

        public frmlibro libro
        {
            get => _Libro;
            set
            {
                _Libro = value;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btncorfirma_Click(object sender, EventArgs e)
        {

            this._Libro = new Libro(
                int.Parse(txtCodigo.Text),
                txttitulo.Text,
                txtautor.Text,
                txtcategoria.Text,
                txtIBSN.Text,
                txtaño.Text,
                txtEditoria.Text
            );
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}