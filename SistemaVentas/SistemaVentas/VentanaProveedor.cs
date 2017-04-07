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
    public partial class VentanaProveedor : Form
    {


        private clsProveedor _ProveedorSeleccionado;

        public clsProveedor ProveedorSeleccionado
        {
            get { return _ProveedorSeleccionado; }
            set { _ProveedorSeleccionado = value; }
        }



        private List<clsProveedor> _ProveedorEncontrado = new List<clsProveedor>();

        public List<clsProveedor> ProveedorEncontrado
        {
            get { return _ProveedorEncontrado; }
            set { _ProveedorEncontrado = value; }
        }

        
        public VentanaProveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroProveedor x;
            x = new RegistroProveedor();
            x.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text.Length >= 3)
            {
                ProveedorEncontrado.Clear();
                lstvDatos.Items.Clear();
                int contador = 1;
                foreach (clsProveedor ELEMENTO in clsProveedor.Buscar_PorNombres(txtNombres.Text))
                {
                    ProveedorEncontrado.Add(ELEMENTO);
                    lstvDatos.Items.Add(contador.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreProv);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionProv);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoProv);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailProv);
                    if (contador % 2 == 0)
                    {
                        lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                    }
                    contador = contador + 1;
                }
            }
        }

        private void VentanaProveedor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProveedorEncontrado.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsProveedor ELEMENTO in clsProveedor.ListarProveedores())
            {

                ProveedorEncontrado.Add(ELEMENTO);
                lstvDatos.Items.Add(contador.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreProv);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionProv);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoProv);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailProv);
                if (contador % 2 == 0)
                {
                    lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                }

                contador = contador + 1;
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir", "Ventana del Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
