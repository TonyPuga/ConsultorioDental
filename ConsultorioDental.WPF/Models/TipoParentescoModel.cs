namespace ConsultorioDental.WPF.Models;

public class TipoParentescoModel : EntityModel
{
    public int IdTipoParentesco { get; set; }    
    public required string Descripcion { get; set; }
}
