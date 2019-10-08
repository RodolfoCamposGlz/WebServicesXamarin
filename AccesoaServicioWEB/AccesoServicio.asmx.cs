using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace AccesoaServicioWEB
{
    /// <summary>
    /// Summary description for AccesoServicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AccesoServicio : System.Web.Services.WebService
    {

        [WebMethod]
        public bool GuardarSQLServer(string nombre, string domicilio, string correo, string edad, double saldo)
        {
            SqlConnection Conexion= new SqlConnection("Data Source=RODOLFO\\SQLEXPRESS;"+ "Initial Catalog =Informacion;"+"User ID=sa; Password=hola123");
            SqlCommand Insertar = new SqlCommand("INSERT INTO Datos (nombre,domicilio, correo, edad, saldo) VALUES('"+nombre+"','"+domicilio+"','"+
            correo+"','"+edad+"','"+saldo+"')",Conexion);
            try
            {
                Conexion.Open();
                Insertar.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch(Exception ex)
            {
                Conexion.Close();
                return false;
            }
        }
        [WebMethod]
        public DataSet BuscarSQLServer(int folio)
        {
            SqlConnection Conexion= new SqlConnection("Data Source=RODOLFO\\SQLEXPRESS;"+ "Initial Catalog =Informacion;"+"User ID=sa; Password=hola123");
            SqlDataAdapter Buscar= new SqlDataAdapter ("SELECT * FROM Datos WHERE Folio='"+folio+ "'",Conexion);
            DataSet Conjunto= new DataSet();

            try
            {
                Conexion.Open();
                Buscar.Fill(Conjunto,"Datos");
                Conexion.Close();
                return Conjunto;
            }
            catch(Exception ex)
            {
                Conexion.Close();
                return Conjunto;
            }
        }
        }
    }

