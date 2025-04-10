namespace ConsultorioDental.WPF.Models
{
    public class UsuarioModel : EntityModel
    {
        public int IdUsuario { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
    }
}
