using ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;

namespace ConsultorioDental.WPF.Repositories.Administracion.Ubigeo;

public interface IDistritoRepository
{
    IEnumerable<DistritoModel> ListarDistritoTodo(int idprovincia);
}
