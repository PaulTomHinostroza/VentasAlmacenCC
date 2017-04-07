using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class clsProveedor
    {
        private string _NombreProv;
        private string _DireccionProv;
        private string _TelefonoProv;
        private string _EmailProv;

        public clsProveedor(string parNombreProv, string parDireccionProv,string parTelefonoProv)

        {
            NombreProv = parNombreProv;
            DireccionProv = parDireccionProv;
            TelefonoProv = parTelefonoProv;
        
        }

        public clsProveedor(string parNombreProv, string parDireccionProv, string parTelefonoProv,string parEmailProv)
        {
            NombreProv = parNombreProv;
            DireccionProv = parDireccionProv;
            TelefonoProv = parTelefonoProv;
            EmailProv = parEmailProv;

        }
        public string NombreProv
        {
            get { return _NombreProv; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El nombre del proveedor no debe quedar vacío.");
                }
                else if (value.Length > 25)
                {
                    throw new Exception("El nombre del Proveedor no debe tener mas de 25 caracteres");
                }
                else
                {
                    _NombreProv = value.ToUpper();
                }
            }
        }
        public string DireccionProv
        {
            get { return _DireccionProv; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("La direccion  del Proveedor no debe quedar en blanco");
                }
                else if (value.Length > 80)
                {
                    throw new Exception("La direccion del Proveedor no debe contener mas de 80");
                }
                else
                {
                    _DireccionProv = value.ToUpper();
                }
            }
        }

        public string TelefonoProv
        {
            get { return _TelefonoProv; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El  Telefono del Proveedor no debe quedar vacio");
                }
                else if (value.Length != 9)
                {
                    throw new Exception(" El  Telefono del Proveedor ndebe contener  9 caracteres");
                }
                else
                {
                    _TelefonoProv = value;
                }
            }
        }

        public string EmailProv
        {
            get { return _EmailProv; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El  correo electornico del Proveedor no bede quedar vacio");
                }
                else if (value.Length > 30)
                {
                    throw new Exception(" El  correo electornico del Proveedor no debe contener mas de 30 caracteres");
                }
                else
                {
                    _EmailProv = value;
                }
            }
        }

        public void InsertarProveedor()
        {
            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand comando1;
            comando1 = new SqlCommand("usp_Proveedor_Insertar", conexion);
            comando1.CommandType = System.Data.CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("@parNombre_Prov", NombreProv);
            comando1.Parameters.AddWithValue("@parDireccion_Prov", DireccionProv);
            comando1.Parameters.AddWithValue("@parTelefono_Prov", TelefonoProv);
            if (string.IsNullOrEmpty(EmailProv))
            {
                comando1.Parameters.AddWithValue("@parEmail_Prov", DBNull.Value);
            }
            else
            {
                comando1.Parameters.AddWithValue("@parEmail_Prov", EmailProv);
            }

            conexion.Open();
            comando1.ExecuteNonQuery();
            conexion.Close();

        }

        public static List<clsProveedor> Buscar_PorNombres(string parametroNombres)
        {
            List<clsProveedor> x = new List<clsProveedor>();

            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand comando1;
            comando1 = new SqlCommand("usp_Proveedor_Buscar_PorNombres", conexion);
            comando1.CommandType = System.Data.CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("@parNombre_Prov", parametroNombres);            
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = comando1.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsProveedor MiObjeto;
                MiObjeto = new clsProveedor(contenedor["Nombre_Prov"].ToString(),
                                            contenedor["Direccion_Prov"].ToString(),
                                            contenedor["Telefono_Prov"].ToString(), 
                                            contenedor["Email_Prov"].ToString());                                                                    

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }
        public static List<clsProveedor> ListarProveedores()
        {
            List<clsProveedor> x = new List<clsProveedor>();
            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand comando;
            comando = new SqlCommand("usp_Proveedor_Listar_Todos", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = comando.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsProveedor MiObjeto;
                MiObjeto = new clsProveedor(contenedor["Nombre_Prov"].ToString(),
                                            contenedor["Direccion_Prov"].ToString(),
                                            contenedor["Telefono_Prov"].ToString(), 
                                            contenedor["Email_Prov"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }
    }
}
