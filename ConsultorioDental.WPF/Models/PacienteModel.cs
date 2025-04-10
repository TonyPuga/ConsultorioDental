namespace ConsultorioDental.WPF.Models;

public class PacienteModel : PersonaModel
{
    public int IdPaciente { get; set; }
    public ApoderadoModel? Apoderado { get; set; }    
}
