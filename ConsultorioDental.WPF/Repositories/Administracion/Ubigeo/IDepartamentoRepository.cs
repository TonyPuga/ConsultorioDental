using ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;

namespace ConsultorioDental.WPF.Repositories.Administracion.Ubigeo;

public interface IDepartamentoRepository
{
    IEnumerable<DepartamentoModel> ListarDepartamentoTodo();
}
