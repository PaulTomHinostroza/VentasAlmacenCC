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
    public partial class RegistroAlmacen : Form
    {
        public RegistroAlmacen()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                clsAlmacen nuevoAlmacen;
                nuevoAlmacen = new clsAlmacen(txtDireccion.Text, txtTelefono.Text);
                nuevoAlmacen.InsertarAlmacen();
                MessageBox.Show("Almacen Registrado");
            }
            catch (Exception ErrorRegAl)
            {

                MessageBox.Show(ErrorRegAl.Message);
            }
            
        }

        private void RegistroAlmacen_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir", "Registro de ALmacen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
