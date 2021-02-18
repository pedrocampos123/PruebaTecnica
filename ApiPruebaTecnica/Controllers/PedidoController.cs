using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dao;

namespace ApiPruebaTecnica.Controllers
{
    public class PedidoController : ApiController
    {
        Conexion.ConexionDB db = new Conexion.ConexionDB();

        // GET: api/Pedido
        public IEnumerable<Pedido> Get()
        {
            List<Pedido> listPedido = new List<Pedido>();
            try
            {

                string sql = "SELECT * FROM Pedido";

                using (SqlCommand command = new SqlCommand(sql, db.conexion()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido();
                            pedido.IdPedido = Convert.ToInt32(reader["IdPedido"]);
                            pedido.ISBN = Convert.ToInt32(reader["ISBN"]);
                            pedido.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                            pedido.FechaPedido = Convert.ToString(reader["FechaPedido"]);

                            listPedido.Add(pedido);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return listPedido;
        }

        // GET: api/Pedido/5
        public Pedido Get(int id)
        {
            Pedido pedido = new Pedido();
            try
            {

                string sql = "SELECT * FROM Pedido WHERE IdPedido='" + id + "'";

                using (SqlCommand command = new SqlCommand(sql, db.conexion()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pedido.IdPedido = Convert.ToInt32(reader["IdPedido"]);
                            pedido.ISBN = Convert.ToInt32(reader["ISBN"]);
                            pedido.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                            pedido.FechaPedido = Convert.ToString(reader["FechaPedido"]);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return pedido;
        }

        // POST: api/Pedido
        public string Post([FromBody] Pedido pedido)
        {
            string code = "";
            try
            {
                string sql = "insert into Pedido values('" + pedido.ISBN + "', " +
                    "'" + pedido.IdCliente + "', '" + pedido.FechaPedido + "')";

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
                return ex.Message;
            }

            return code;
        }

        // PUT: api/Pedido/5
        public string Put(int id, [FromBody] Pedido pedido)
        {
            string code = "";
            try
            {
                string sql = "UPDATE Pedido SET ISBN=" + pedido.ISBN + ", IdCliente=" + pedido.IdCliente + "," +
                    " FechaPedido=" + pedido.FechaPedido + " WHERE IdPedido=" + pedido.IdPedido + "";

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
                return ex.Message;
            }

            return code;
        }

        // DELETE: api/Pedido/5
        public string Delete(int id)
        {
            string code = "";
            try
            {
                string sql = "DELETE FROM Pedido WHERE IdPedido=" + id + "";

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
                return ex.Message;
            }

            return code;
        }
    }
}
