using Entidades.Models;

namespace Servicios
{
    public interface IEscolaridadService
    {
        List<Escolaridad> getAll();

        public Escolaridad getById(int id);

        public List<Escolaridad> getAllButId(int id);

    }
}
