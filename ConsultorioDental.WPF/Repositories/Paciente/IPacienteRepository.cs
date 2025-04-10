using ConsultorioDental.WPF.Models;

namespace ConsultorioDental.WPF.Repositories.Paciente
{
    public interface IPacienteRepository
    {
        PacienteModel InsertarPaciente(PacienteModel paciente);
        void ActualizarPaciente(PacienteModel paciente);
        PacienteModel ObtenerPacientePorId(int id);
        IEnumerable<PacienteModel> ListarPacienteTodo();
        IEnumerable<PacienteModel> ListarPacienteFiltadoPaginado();
    }
}
