using ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace ConsultorioDental.WPF.Repositories.Administracion.Ubigeo;

public class DepartamentoRepository : RepositoryBase, IDepartamentoRepository
{
    public IEnumerable<DepartamentoModel> ListarDepartamentoTodo()
    {
        using (var connection = GetConnection())
        using (var command = new SqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "[Maestros].[Departamento_ListarTodo_SP]";
            command.CommandType = CommandType.StoredProcedure;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    DepartamentoModel departamento;

                    try
                    {
                        departamento = new DepartamentoModel
                        {
                            IdDepartamento = reader.GetInt32(0),
                            NombreDepartamento = reader.GetString(1),
                            CodigoDepartamento = reader.GetString(2)
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

                    yield return departamento;
                }
            }
        }
    }
}