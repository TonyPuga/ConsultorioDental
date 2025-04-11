namespace ConsultorioDental.WPF.Models.AdministracionModels.TipoModels
{
    public class TipoModel : EntityModel
    {
        public int IdTipo { get; set; }
        public int IdSuperTipo { get; set; }
        public required string Descripcion { get; set; }
        public string? DescripcionCorta { get; set; }
        public string? Codigo_Tipo { get; set; }
        public int? Longitud_Tipo { get; set; }
    }
}
