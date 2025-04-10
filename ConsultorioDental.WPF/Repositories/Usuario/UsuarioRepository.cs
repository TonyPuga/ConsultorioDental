    using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Security;

namespace ConsultorioDental.WPF.Repositories.Usuario;

public class UsuarioRepository : RepositoryBase, IUsuarioRepository
{
    bool IUsuarioRepository.IniciarSesion(string login, SecureString password)
    {
        bool validUser;
        using (var connection = GetConnection())
        using (var command = new SqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "[Maestros].[IniciarSesion_Usuario_SP]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Login", SqlDbType.VarChar).Value = login;
            
            IntPtr passwordBSTR = Marshal.SecureStringToBSTR(password);
            string passwordString = Marshal.PtrToStringBSTR(passwordBSTR);
            try
            {
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = passwordString;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            finally
            {
                // Clean up the unmanaged string
                Marshal.ZeroFreeBSTR(passwordBSTR);
            }
        }
        return validUser;
    }
}
