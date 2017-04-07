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
    public partial class VentanaAlmacen : Form
    {
        private clsAlmacen _AlmacenSeleccionado;

        public clsAlmacen AlmacenSeleccionado
        {
            get { return _AlmacenSeleccionado; }
            set { _AlmacenSeleccionado = value; }
        }



        private List<clsAlmacen> _AlmacenEncontrado = new List<clsAlmacen>();

        public List<clsAlmacen> AlmacenEncontrado
        {
            get { return _AlmacenEncontrado; }
            set { _AlmacenEncontrado = value; }
        }


        public VentanaAlmacen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroAlmacen x;
            x = new RegistroAlmacen();
            x.ShowDialog();
        }

        private void VentanaAlmacen_Load(object sender, EventArgs e)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlmacenEncontrado.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsAlmacen ELEMENTO in clsAlmacen.ListarAlmacen())
            {

                AlmacenEncontrado.Add(ELEMENTO);
                lstvDatos.Items.Add(contador.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Direccion);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Telefono);
                if (contador % 2 == 0)
                {
                    lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                }

                contador = contador + 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir", "Ventana del Almacen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
