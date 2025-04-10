using ConsultorioDental.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioDental.WPF.Repositories.Persona
{
    public interface IPersonaRepository
    {
        PersonaModel InsertarPersona(PersonaModel persona);
        void ActualizarPersona(PersonaModel persona);
        PersonaModel ObtenerPersonaPorId(int id);
        IEnumerable<PersonaModel> ListarPersonaTodo();
        IEnumerable<PersonaModel> ListarPersonaFiltadoPaginado();
    }
}
