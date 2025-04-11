namespace ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;

public class DistritoModel : EntityModel
{
    public int IdDistrito { get; set; }
    public int IdDepartamento { get; set; }
    public int IdProvincia { get; set; }
    public required string NombreDistrito { get; set; }
    public required string CodigoDepartamento { get; set; }
    public required string CodigoProvincia { get; set; }
    public required string CodigoDistrito { get; set; }
}
