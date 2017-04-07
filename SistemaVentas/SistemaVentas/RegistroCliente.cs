﻿using System;
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
    public partial class RegistroCliente : Form
    {
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                clsCliente nuevocliente;
                if (rbnMasculino.Checked == true)
                {
                    nuevocliente = new clsCliente(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                    'M');
                }
                else
                {
                    nuevocliente = new clsCliente(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                    'F');
                }

                nuevocliente.TelefonoCli = txtTelefono.Text;
                nuevocliente.RUCCli = txtRUC.Text;
                nuevocliente.EmailCli = txtEmail.Text;
                nuevocliente.InsertarCliente();
                MessageBox.Show("Cliente Registrado");
            }
            catch (Exception ErrorRegCli)
            {
                MessageBox.Show(ErrorRegCli.Message);
                
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir", "Registro Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Close();
            }
        }

        private void RegistroCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
