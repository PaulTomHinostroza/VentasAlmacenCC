using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    public class clsLogin
    {
        public string NombresEmp { get; set; }
        public string DNIEmp { get; set; }
        public char TipoEmp { get; set; }

        public clsLogin(string parNombresEmp,
                        string parDNIEmp,
                       char parTipoEmp)
        {
            NombresEmp = parNombresEmp;
            DNIEmp = parDNIEmp;
            TipoEmp = parTipoEmp;
        }


        public static clsLogin Validar(string parNombresEmp,
                                        string parDNIEmp)
        {
            clsLogin UsuarioRetornado = null;
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Usuario_Validacion", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parNombres_Emp", parNombresEmp);
            cmd.Parameters.AddWithValue("@parDNI_Emp", parDNIEmp);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                UsuarioRetornado = new clsLogin(contenedor["Nombres_Emp"].ToString(),
                                                 contenedor["DNI_Emp"].ToString(),
                                                 Convert.ToChar(contenedor["Tipo_Emp"].ToString()));
            }
            conexion.Close();
            return UsuarioRetornado;
        }
    }
}