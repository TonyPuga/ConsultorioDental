using ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsultorioDental.WPF.Repositories.Administracion.Ubigeo;

public class ProvinciaRepository : RepositoryBase, IProvinciaRepository
{
    public IEnumerable<ProvinciaModel> ListarProvinciaTodo(int idDepartamento)
    {
        using (var connection = GetConnection())
        using (var command = new SqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "[Maestros].[Provincia_ListarTodo_SP]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = idDepartamento;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProvinciaModel provincia;

                    try
                    {
                        provincia = new ProvinciaModel
                        {
                            IdProvincia = reader.GetInt32(0),
                            IdDepartamento = reader.GetInt32(1),
                            NombreProvincia = reader.GetString(2),
                            CodigoDepartamento = reader.GetString(3),
                            CodigoProvincia = reader.GetString(4)
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

                    yield return provincia;
                }
            }
        }
    }
}