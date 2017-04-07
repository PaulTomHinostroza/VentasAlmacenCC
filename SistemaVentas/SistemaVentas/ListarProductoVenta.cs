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
    public partial class ListarProductoVenta : Form
    {
        
        public ListarProductoVenta()
        {
            InitializeComponent();
        }

        private void ListarProductoVenta_Load(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length>3)
            {
               
                lstvDatos.Items.Clear();
                int contador = 0;
                foreach (clsProducto elemento in clsProducto.Listar_Todos())
                {
                    lstvDatos.Items.Add(contador.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(elemento.IdProducto.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(elemento.NombreProd);
                    lstvDatos.Items[contador - 1].SubItems.Add(elemento.DescripcionProd);
                    contador++;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir", "Listado Producto Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                Close();
            }
        }
            

    }
}
