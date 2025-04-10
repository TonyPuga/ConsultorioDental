using ConsultorioDental.WPF.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsultorioDental.WPF.Repositories.Apoderado;

public class ApoderadoRepository : RepositoryBase, IApoderadoRepository
{
    public void ActualizarApoderado(ApoderadoModel apoderado)
    {
        try
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "[Maestros].[Apoderado_Actualizar_SP]";
                command.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros de entrada
                command.Parameters.AddWithValue("@IdApoderado", apoderado.IdApoderado);
                command.Parameters.AddWithValue("@IdPersona", apoderado.IdPersona);
                command.Parameters.AddWithValue("@IdTipoParentesco", apoderado.TipoParentesco);
                command.Parameters.AddWithValue("@UsuarioCreacion", apoderado.UsuarioCreador);
                command.Parameters.AddWithValue("@HostModificacion", apoderado.HostModificador);
                command.Parameters.AddWithValue("@AppModificacion", apoderado.AppModificador);
                                
                // Abrir la conexión y ejecutar el comando
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error al procesar la operación", ex); // Excepción específica
        }
    }

    public ApoderadoModel InsertarApoderado(ApoderadoModel apoderado)
    {        
        try
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "[Maestros].[Apoderado_Insertar_SP]";
                command.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros de entrada
                command.Parameters.AddWithValue("@IdPersona", apoderado.IdPersona);
                command.Parameters.AddWithValue("@IdTipoParentesco", apoderado.TipoParentesco);                
                command.Parameters.AddWithValue("@UsuarioCreacion", apoderado.UsuarioCreador);
                command.Parameters.AddWithValue("@HostModificacion", apoderado.HostModificador);
                command.Parameters.AddWithValue("@AppModificacion", apoderado.AppModificador);

                // Agregar el parámetro de salida
                var outputParam = new SqlParameter("@IdApoderado", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                // Abrir la conexión y ejecutar el comando
                connection.Open();
                command.ExecuteNonQuery();

                // Obtener el valor del parámetro de salida
                apoderado.IdApoderado = (int)outputParam.Value;
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error al procesar la operación", ex); // Excepción específica
        }

        return apoderado;
    }

    public IEnumerable<ApoderadoModel> ListarApoderadoFiltadoPaginado()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ApoderadoModel> ListarApoderadoTodo()
    {
        throw new NotImplementedException();
    }

    public ApoderadoModel ObtenerApoderadoPorId(int id)
    {
        throw new NotImplementedException();
    }
}
