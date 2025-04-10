using ConsultorioDental.WPF.Models;

namespace ConsultorioDental.WPF.Repositories.Apoderado;

public interface IApoderadoRepository
{
    ApoderadoModel InsertarApoderado(ApoderadoModel apoderado);
    void ActualizarApoderado(ApoderadoModel apoderado);
    ApoderadoModel ObtenerApoderadoPorId(int id);
    IEnumerable<ApoderadoModel> ListarApoderadoTodo();
    IEnumerable<ApoderadoModel> ListarApoderadoFiltadoPaginado();
}