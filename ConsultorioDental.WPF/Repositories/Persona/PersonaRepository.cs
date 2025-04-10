using ConsultorioDental.WPF.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsultorioDental.WPF.Repositories.Persona;

public class PersonaRepository : RepositoryBase, IPersonaRepository
{
    public void ActualizarPersona(PersonaModel persona)
    {
        try
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "[Maestros].[Persona_Actualizar_SP]";
                command.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros de entrada
                command.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
                command.Parameters.AddWithValue("@IdDireccion", persona.Direccion.IdDireccion);
                command.Parameters.AddWithValue("@IdTipoDOI", persona.TipoDOI);
                command.Parameters.AddWithValue("@DOI", persona.NumeroDOI);
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
                command.Parameters.AddWithValue("@ApellidoPaterno", persona.ApellidoPaterno);
                command.Parameters.AddWithValue("@ApellidoMaterno", persona.ApellidoMaterno);
                command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                command.Parameters.AddWithValue("@Telefono", persona.Telefono);
                command.Parameters.AddWithValue("@Email", persona.CorreoElectronico);
                command.Parameters.AddWithValue("@UsuarioModificacion", persona.UsuarioModificador);
                command.Parameters.AddWithValue("@HostModificacion", persona.HostModificador);
                command.Parameters.AddWithValue("@AppModificacion", persona.AppModificador);

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

    public PersonaModel InsertarPersona(PersonaModel persona)
    {
        try
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "[Maestros].[Persona_Insertar_SP]";
                command.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros de entrada
                command.Parameters.AddWithValue("@IdDireccion", persona.Direccion.IdDireccion);
                command.Parameters.AddWithValue("@IdTipoDOI", persona.TipoDOI);
                command.Parameters.AddWithValue("@DOI", persona.NumeroDOI);
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
                command.Parameters.AddWithValue("@ApellidoPaterno", persona.ApellidoPaterno);
                command.Parameters.AddWithValue("@ApellidoMaterno", persona.ApellidoMaterno);
                command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                command.Parameters.AddWithValue("@Telefono", persona.Telefono);
                command.Parameters.AddWithValue("@Email", persona.CorreoElectronico);
                command.Parameters.AddWithValue("@UsuarioCreacion", persona.UsuarioCreador);
                command.Parameters.AddWithValue("@HostModificacion", persona.HostModificador);
                command.Parameters.AddWithValue("@AppModificacion", persona.AppModificador);

                // Agregar el parámetro de salida
                var outputParam = new SqlParameter("@IdPersona", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                // Abrir la conexión y ejecutar el comando
                connection.Open();
                command.ExecuteNonQuery();

                // Obtener el valor del parámetro de salida
                persona.IdPersona = (int)outputParam.Value;
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error al procesar la operación", ex); // Excepción específica
        }

        return persona;
    }

    public IEnumerable<PersonaModel> ListarPersonaFiltadoPaginado()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PersonaModel> ListarPersonaTodo()
    {
        throw new NotImplementedException();
    }

    public PersonaModel ObtenerPersonaPorId(int id)
    {
        throw new NotImplementedException();
    }
}
