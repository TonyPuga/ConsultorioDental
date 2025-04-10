namespace ConsultorioDental.WPF.Models;

public abstract class EntityModel
{
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string UsuarioCreador { get; set; }
    public DateTime FechaModificacion { get; set; }
    public string UsuarioModificador { get; set; }        
    public String HostModificador { get; set; }
    public String AppModificador { get; set; }
}
