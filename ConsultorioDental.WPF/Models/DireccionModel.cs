namespace ConsultorioDental.WPF.Models;

public class DireccionModel : EntityModel
{
    public int IdDireccion { get; set; }
    public int IdDepartamento { get; set; }
    public int IdProvincia { get; set; }
    public string Direccion { get; set; } = string.Empty;
    public string Referencia { get; set; } = string.Empty;
}
