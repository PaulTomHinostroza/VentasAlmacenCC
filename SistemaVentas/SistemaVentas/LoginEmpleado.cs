using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class LoginEmpleado : Form
    {
        public LoginEmpleado()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            clsLogin MiUsuario = clsLogin.Validar(txtUsuario.Text, txtClave.Text);
            if (MiUsuario == null)
            {
                MessageBox.Show("El usuario y/o contraseña es incorrecto.");
            }
            else
            {
                mdlVariables.MiUsuarioConectado = MiUsuario;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir", "Ventana de Login", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
