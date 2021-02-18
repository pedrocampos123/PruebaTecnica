using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dao;
using Conexion;
using System.Data.SqlClient;

namespace ApiPruebaTecnica.Controllers
{
    public class ClienteController : ApiController
    {
        Conexion.ConexionDB db = new Conexion.ConexionDB();

        // GET: api/Cliente
        public IEnumerable<Cliente> Get()
        {
            List<Cliente> listClientes = new List<Cliente>();
            try
            {

                string sql = "SELECT * FROM Cliente";

                using (SqlCommand command = new SqlCommand(sql, db.conexion()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente();
                            cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                            cliente.Nombres = Convert.ToString(reader["Nombres"]);
                            cliente.Apellidos = Convert.ToString(reader["Apellidos"]);
                            cliente.FechaNacimiento = Convert.ToString(reader["FechaNacimiento"]);
                            cliente.Direccion = Convert.ToString(reader["Direccion"]);
                            cliente.Telefono = Convert.ToString(reader["Telefono"]);
                            cliente.Email = Convert.ToString(reader["Email"]);
                            cliente.Edad = Convert.ToInt32(reader["Edad"]);
                            cliente.Genero = Convert.ToString(reader["Genero"]);

                            listClientes.Add(cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return listClientes;
        }

        // GET: api/Cliente/5
        public Cliente Get(int id)
        {
            Cliente cliente = new Cliente();
            try
            {

                string sql = "SELECT * FROM Cliente WHERE IdCliente='" + id + "'";

                using (SqlCommand command = new SqlCommand(sql, db.conexion()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                            cliente.Nombres = Convert.ToString(reader["Nombres"]);
                            cliente.Apellidos = Convert.ToString(reader["Apellidos"]);
                            cliente.FechaNacimiento = Convert.ToString(reader["FechaNacimiento"]);
                            cliente.Direccion = Convert.ToString(reader["Direccion"]);
                            cliente.Telefono = Convert.ToString(reader["Telefono"]);
                            cliente.Email = Convert.ToString(reader["Email"]);
                            cliente.Edad = Convert.ToInt32(reader["Edad"]);
                            cliente.Genero = Convert.ToString(reader["Genero"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return cliente;
        }

        //INSERT
        // POST: api/Cliente
        public string Post([FromBody] Cliente cliente)
        {
            string code = "";
            try
            {
                string sql = "insert into Cliente values('" + cliente.Nombres + "', " +
                    "'" + cliente.Apellidos + "', '" + cliente.FechaNacimiento + "', " +
                    "'" + cliente.Direccion + "', '" + cliente.Telefono + "', " +
                    "'" + cliente.Email + "', " + cliente.Edad + ", '" + cliente.Genero + "')";

                using (SqlCommand command = new SqlCommand(sql, db.conexion()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        code = Request.CreateResponse(HttpStatusCode.OK, "").RequestMessage.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return code = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "").RequestMessage.ToString();
            }

            return code;
        }

        //UPDATE
        // PUT: api/Cliente/5
        public string Put(int id, [FromBody] Cliente cliente)
        {
            string code = "";
            try
            {
                string sql = "UPDATE Cliente SET Nombres = '" + cliente.Nombres + "', " +
                    "Apellidos = '" + cliente.Apellidos + "', " +
                    "FechaNacimiento = '" + cliente.FechaNacimiento + "'," +
                    " Direccion = '" + cliente.Direccion + "', Telefono = '" + cliente.Telefono + "'," +
                    " Email = '" + cliente.Email + "', Edad = " + cliente.Edad + ", " +
                    "Genero = '" + cliente.Genero + "' " +
                    "WHERE IdCliente = " + cliente.IdCliente + "";

                using (SqlCommand command = new SqlCommand(sql, db.conexion()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        code = Request.CreateResponse(HttpStatusCode.OK, "").RequestMessage.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return code = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "").RequestMessage.ToString();
            }

            return code;
        }

        // DELETE: api/Cliente/5
        public string Delete(int id)
        {
            string code = "";
            try
            {
                string sql = "DELETE FROM Cliente WHERE IdCliente=" + id + "";

                using (SqlCommand command = new SqlCommand(sql, db.conexion()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        code = Request.CreateResponse(HttpStatusCode.OK, "").StatusCode.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return code = Request.CreateResponse(HttpStatusCode.InternalServerError, "").StatusCode.ToString();
            }

            return code;
        }
    }
}
