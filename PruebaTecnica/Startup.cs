using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PruebaTecnica.Modelo;

namespace PruebaTecnica
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    try
                    {
                        Conexion.ConexionDB db = new Conexion.ConexionDB();
                        List<Cliente> listClientes = new List<Cliente>();

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
                                    cliente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
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
                });
            });
        }
    }
}
