namespace ConsultorioDental.WPF.Models
{
    public class PersonaModel: EntityModel
    {
        public int IdPersona { get; set; }
        public required int TipoDOI { get; set; }
        public required string NumeroDOI { get; set; }
        public required string Nombres { get; set; }
        public required string ApellidoPaterno { get; set; }
        public required string ApellidoMaterno { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public required DireccionModel Direccion { get; set; }
    }
}