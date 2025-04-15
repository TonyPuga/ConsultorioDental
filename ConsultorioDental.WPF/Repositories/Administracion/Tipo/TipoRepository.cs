using ConsultorioDental.WPF.Models.AdministracionModels.TipoModels;
using ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsultorioDental.WPF.Repositories.Administracion.Tipo;

internal class TipoRepository:RepositoryBase, ITipoRepository
{
    public IEnumerable<TipoModel> ListarTipoPorSupertipoId(int idSuperTipo)
    {
        using (var connection = GetConnection())
        using (var command = new SqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "[Maestros].[Tipo_ListarPorSuperTipo_SP]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IdSuperTipo", SqlDbType.Int).Value = idSuperTipo;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TipoModel tipo;

                    try
                    {
                        tipo = new TipoModel
                        {
                            IdTipo = reader.GetInt32(0),
                            IdSuperTipo = reader.GetInt32(1),
                            Descripcion = reader.GetString(2),
                            DescripcionCorta = reader.GetString(3),
                            Codigo_Tipo = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Longitud_Tipo = reader.IsDBNull(5) ? null : (int)reader.GetByte(5)
                        };
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new InvalidOperationException("Error de base de datos al listar tipos", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("Error al procesar la operación", ex); // Excepción específica
                    }

                    yield return tipo;
                }
            }
        }
    }
}    
