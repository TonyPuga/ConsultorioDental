using ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsultorioDental.WPF.Repositories.Administracion.Ubigeo
{
    public class DistritoRepository : RepositoryBase, IDistritoRepository
    {
        public IEnumerable<DistritoModel> ListarDistritoTodo(int idprovincia)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "[Maestros].[Distrito_ListarTodo_SP]";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@IdProvincia", SqlDbType.Int).Value = idprovincia;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DistritoModel distrito;

                        try
                        {
                            distrito = new DistritoModel
                            {
                                IdDistrito = reader.GetInt32(0),
                                IdDepartamento = reader.GetInt32(1),
                                IdProvincia = reader.GetInt32(2),
                                NombreDistrito = reader.GetString(3),
                                CodigoDepartamento = reader.GetString(4),
                                CodigoProvincia = reader.GetString(5),
                                CodigoDistrito = reader.GetString(6)
                            };
                        }
                        catch (SqlException sqlEx)
                        {
                            throw new InvalidOperationException("Error de base de datos al listar departamentos", sqlEx);
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException("Error al procesar la operación", ex); // Excepción específica
                        }

                        yield return distrito;
                    }
                }
            }
        }
    }
}