namespace ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;

public class DepartamentoModel : EntityModel
{
    public int IdDepartamento { get; set; }
    public required string NombreDepartamento { get; set; }
    public required string CodigoDepartamento { get; set; }
}
