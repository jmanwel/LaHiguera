using Entidades.Models;

namespace Servicios
{
    public interface IEtniaService
    {
        List<Etnia> getAll();

        public Etnia getById(int id);

        public List<Etnia> getAllButId(int id);

    }
}
