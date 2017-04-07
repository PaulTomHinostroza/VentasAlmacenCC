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
    public partial class VentanaCargos : Form
    {
        private clsCargo _CargoSeleccionado;

        public clsCargo CargoSeleccionado
        {
            get { return _CargoSeleccionado; }
            set { _CargoSeleccionado = value; }
        }


        private List<clsCargo> _CargoEncontrado = new List<clsCargo>();

        public List<clsCargo> CargoEncontrado
        {
            get { return _CargoEncontrado; }
            set { _CargoEncontrado = value; }
        }


        public VentanaCargos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroCargo x;
            x = new RegistroCargo();
            x.ShowDialog();
        }

        private void VentanaCargos_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CargoSeleccionado.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsCargo ELEMENTO in clsCargo.Listar_Cargos())
            {

                CargoEncontrado.Add(ELEMENTO);
                lstvDatos.Items.Add(contador.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreCar);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionCar);
                if (contador % 2 == 0)
                {
                    lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                }

                contador = contador + 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir", "Ventana de los  Cargos", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
