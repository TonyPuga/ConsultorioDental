using ConsultorioDental.WPF.Models.AdministracionModels.TipoModels;

namespace ConsultorioDental.WPF.Repositories.Administracion.Tipo;

public interface ITipoRepository
{
    IEnumerable<TipoModel>ListarTipoPorSupertipoId(int idSuperTipo);
}
