
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
            return _ctxt.Etnias.ToList();

        }
    }
}
