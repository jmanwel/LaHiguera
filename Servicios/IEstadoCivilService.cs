using Entidades.Models;

namespace Servicios
{
    public interface IEstadoCivilService
    {
        List<EstadoCivil> getAll();

        EstadoCivil getById(int id);

        List<EstadoCivil> getAllButId(int id);

    }
}
