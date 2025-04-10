namespace ConsultorioDental.WPF.Models;

public class ApoderadoModel : PersonaModel
{
    public int IdApoderado { get; set; }
    public required TipoParentescoModel TipoParentesco { get; set; }
}
