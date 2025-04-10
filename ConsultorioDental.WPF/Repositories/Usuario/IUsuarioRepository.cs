using System.Security;

namespace ConsultorioDental.WPF.Repositories.Usuario;
public interface IUsuarioRepository
{
    bool IniciarSesion(string login, SecureString password);
}
