using HuellitasPaginaWEB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HuellitasPaginaWEB.Data
{
    public class PerritoRepository
    {
        private readonly string _connectionString;

        public PerritoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("HuellitasDB") ?? 
                throw new ArgumentNullException(nameof(_connectionString), 
                    "Connection string 'HuellitasDB' not found");
        }

        public List<Perrito> ObtenerTodos()
        {
            var perritos = new List<Perrito>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    const string query = "SELECT Id, Nombre, FotoUrl, Estado, FechaRegistro, Descripcion FROM Perritos";

                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var perrito = new Perrito
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                FotoUrl = reader.IsDBNull(reader.GetOrdinal("FotoUrl")) 
                                    ? null 
                                    : reader.GetString(reader.GetOrdinal("FotoUrl")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado")),
                                FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaRegistro"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("FechaRegistro")),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("Descripcion"))
                            };

                            perritos.Add(perrito);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Loggear el error (considera usar ILogger)
                throw new ApplicationException("Error al acceder a la base de datos", ex);
            }

            return perritos;
        }
    }
}