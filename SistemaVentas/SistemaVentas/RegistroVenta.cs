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
    public partial class RegistroVenta : Form
    {
        public RegistroVenta()
        {
            InitializeComponent();
        }

 
        private int _IdProd;

        public int IdProd
        {
            get { return _IdProd; }
            set { _IdProd = value; }
        }

        private void RegistroVenta_Load(object sender, EventArgs e)
        {
            lblIGV.Visible = false;
            txtIgv.Visible = false;
             
        }

        private void btnBusqueda_Click_1(object sender, EventArgs e)
        {
            VentanaCliente x;
            x = new VentanaCliente();
            x.ShowDialog();

            if (x.ClienteSeleccionado == null)
            {
                MessageBox.Show("La búsqueda fue cancelada");
            }
            else
            {
                txtDatos.Text = x.ClienteSeleccionado.NombresCli;
                txtDocIdentidad.Text = x.ClienteSeleccionado.DNICli;
                
            }
            

        }


        private void btnBusquedaProducto_Click_1(object sender, EventArgs e)
        {
            nudCantidad.Value = 0;
            VentanaProductos x;
            x = new VentanaProductos();
            x.ShowDialog();

            if (x.ProductoSeleccionado == null)
            {
                MessageBox.Show("La búsqueda fue cancelada");
            }
            else
            {
                txtMarca.Text = x.ProductoSeleccionado.MarcaProd;
                txtDescripcion.Text = x.ProductoSeleccionado.NombreProd;
                IdProd = x.ProductoSeleccionado.IdProducto;


                cmbMedida.Items.Clear();
                foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProducto(x.ProductoSeleccionado.IdProducto))
                {                    
                    cmbMedida.Items.Add(ELEMENTO.NombreMedida);
                }
            }
        }

        private void rbnBoleta_CheckedChanged(object sender, EventArgs e)
        {
            lblIGV.Visible = true;
            txtIgv.Visible = true;

            if (rbnFactura.Checked == true)
            {
                lblTipo.Text = "FACTURA";
            }
            else
            {
                if (rbnGuia.Checked==true)
                {
                    lblTipo.Text = "GUIA DE REMISION";
                }
                else
                {
                    lblTipo.Text = "BOLETA DE VENTA";    
                }
                
            }
        }

        private void rbnGuia_CheckedChanged(object sender, EventArgs e)
        {
            lblIGV.Visible = false;
            txtIgv.Visible = false;

            if (rbnFactura.Checked == true)
            {
                lblTipo.Text = "FACTURA";
            }
            else
            {
                if (rbnGuia.Checked == true)
                {
                    lblTipo.Text = "GUIA DE REMISION";
                }
                else
                {
                    lblTipo.Text = "BOLETA DE VENTA";
                }

            }
        }

        private void cmbMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProductoMedida(IdProd,cmbMedida.SelectedItem.ToString()))
                {

                    txtPVenta.Text = ELEMENTO.Precio.ToString();
                    
                }        
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double valorVenta,subtotal,igv,total;
            subtotal=0;
            total=0;
            igv=0;
            Boolean repetido;
            int index;
            valorVenta = Convert.ToDouble(nudCantidad.Value) * Convert.ToDouble(txtPVenta.Text);
            index = 0;
            repetido = false;

            if (lstvDatos.Items.Count==0)
            {
                lstvDatos.Items.Add((nudCantidad.Value).ToString());
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(cmbMedida.SelectedItem.ToString());
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(txtDescripcion.Text + " " + txtMarca.Text);
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(txtPVenta.Text);
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(valorVenta.ToString("0.00"));
            }
            else
            {
                
                for (int i = 0; i < lstvDatos.Items.Count; i++)
                {
                    if (lstvDatos.Items[i].SubItems[1].Text == cmbMedida.SelectedItem.ToString() && lstvDatos.Items[i].SubItems[2].Text == txtDescripcion.Text + " " + txtMarca.Text)
                    {
                        index = i;
                        repetido = true;
                    }

                }

                if (repetido==true)
                {
                    lstvDatos.Items[index].Text = (Convert.ToDecimal(lstvDatos.Items[index].Text) + nudCantidad.Value).ToString();
                    lstvDatos.Items[index].SubItems[4].Text = (Convert.ToDouble(lstvDatos.Items[index].SubItems[4].Text) + valorVenta).ToString("0.00");
                }
                else
                {
                    lstvDatos.Items.Add((nudCantidad.Value).ToString());
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(cmbMedida.SelectedItem.ToString());
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(txtDescripcion.Text + " " + txtMarca.Text);
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(txtPVenta.Text);
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(valorVenta.ToString("0.00"));
                }
            }

            for (int i = 0; i < lstvDatos.Items.Count; i++)
            {
                total = total + Convert.ToDouble(lstvDatos.Items[i].SubItems[4].Text);
            }

            subtotal = total / 1.18;
            igv = subtotal * 0.18;

            txtSubTotal.Text = subtotal.ToString("0.00");
            txtIGV2.Text = igv.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");

        }

        private void rbnFactura_CheckedChanged(object sender, EventArgs e)
        {
            lblIGV.Visible = true;
            txtIgv.Visible = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir", "Registro de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            double total, subtotal, igv;
            total = 0;
            subtotal = 0;
            igv = 0;
            total = Convert.ToDouble(txtTotal.Text) - Convert.ToDouble(lstvDatos.SelectedItems[0].SubItems[4].Text);
            subtotal = total / 1.18;
            igv = subtotal * 0.18;
            lstvDatos.SelectedItems[0].Remove();
            txtSubTotal.Text = subtotal.ToString("0.00");
            txtIGV2.Text = igv.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");          
        }

        



    }
}
