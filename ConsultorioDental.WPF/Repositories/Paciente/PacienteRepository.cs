using ConsultorioDental.WPF.Models;

namespace ConsultorioDental.WPF.Repositories.Paciente;

public class PacienteRepository : RepositoryBase, IPacienteRepository
{
    public void ActualizarPaciente(PacienteModel paciente)
    {
        throw new NotImplementedException();
    }
    
    public PacienteModel InsertarPaciente(PacienteModel paciente)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PacienteModel> ListarPacienteTodo()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PacienteModel> ListarPacienteFiltadoPaginado()
    {
        throw new NotImplementedException();
    }

    public PacienteModel ObtenerPacientePorId(int id)
    {
        throw new NotImplementedException();
    }
}
