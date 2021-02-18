using System;
using System.Data.SqlClient;

namespace Conexion
{
    public class ConexionDB
    {
        public SqlConnection conexion()
        {
            try
            {
                SqlConnection conexionDataBase = new SqlConnection("server=DESKTOP-PKM08QI\\MSSQLSERVER19; database=PruebaTecnica; integrated security = true");
                conexionDataBase.Open();

                return conexionDataBase;
            }
            catch (Exception ex)
            {
                return new SqlConnection();
            }
        }
    }
}
