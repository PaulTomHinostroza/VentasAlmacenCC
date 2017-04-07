﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class clsAlmacen
    {
        private int _CodigoAlmacen;
        private string _Direccion;
        private string _Telefono;

        public clsAlmacen(string parDireccion, string parTelefono)
        {
            Direccion = parDireccion;
            Telefono = parTelefono;
        }

        public int CodigoAlmacen
        {
            get { return _CodigoAlmacen; }
            set { _CodigoAlmacen = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("La direccion del almacen no debe quedar vacio");
                }
                else if (value.Length > 80)
                {
                    throw new Exception("La direccion del almacen no puede contener mas de 80 caracteres");
                }
                else
                {
                    _Direccion = value.ToUpper();
                }
            }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El telefono del almacen no debe quedar vacio");
                }
                else if (value.Length !=9)
                {
                    throw new Exception("EL telefono del almacen debe contener mas de 9 caracteres");
                }
                else
                {
                    _Telefono = value.ToUpper();
                }
            }
        }

        public void InsertarAlmacen()
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Almacen_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parDireccion", Direccion);
            cmd.Parameters.AddWithValue("@parTelefono", Telefono);
            conexion.Open();
            cmd.ExecuteReader();
            conexion.Close();
        }
        public static List<clsAlmacen> ListarAlmacen()
        {
            List<clsAlmacen> x = new List<clsAlmacen>();
            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand comando;
            comando = new SqlCommand("usp_Almacen_Listar_Todos", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = comando.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsAlmacen MiObjeto;
                MiObjeto = new clsAlmacen(contenedor["Direccion"].ToString(),                                            
                                            contenedor["Telefono"].ToString());                                            

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }
    }
}
