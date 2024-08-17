
using Entidades.Models;

namespace Servicios
{
    public class EtniaService : IEtniaService
    {
        public LahigueraContext _ctxt { get; set; }
        public EtniaService(LahigueraContext ctx)
        {

            _ctxt = ctx;
        }
        public List<Etnia> getAll()
        {
            return _ctxt.Etnias.OrderByDescending(o => o.Id).ToList();

        }

        public Etnia getById(int id)
        {
            var etnia = _ctxt.Etnias.Find(id);
            if (etnia == null)
            {
                Console.WriteLine("Registro no encontrado");
            }
            return etnia;
        }

        public List<Etnia> getAllButId(int id)
        {
            return _ctxt.Etnias.Where(o => o.Id != id).OrderByDescending(o => o.Id).ToList();
        }
    }
}
