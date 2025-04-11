namespace ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;

public class ProvinciaModel : EntityModel
{
    public int IdProvincia { get; set; }
    public int IdDepartamento { get; set; }
    public required string NombreProvincia { get; set; }
    public required string CodigoDepartamento { get; set; }
    public required string CodigoProvincia { get; set; }
}
