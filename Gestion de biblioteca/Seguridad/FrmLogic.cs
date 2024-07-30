using BibliotecaLib.Controladores.Seguridad;
using BibliotecaLib.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_biblioteca.Seguridad
{
    public partial class FrmLogic : Form
    {
        public frmUsuario UsuarioSesion { get; set; }

        private frmUsuarios usuarioController;
        public FrmLogic()
        {
            InitializeComponent();
            usuarioController = new frmUsuarios();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            UsuarioSesion = usuarioController.Login(txtUsuario.Text, txtContraseña.Text);
            if (UsuarioSesion != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
