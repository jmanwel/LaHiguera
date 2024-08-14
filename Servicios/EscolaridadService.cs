using Entidades.Models;

namespace Servicios
{
    public class EscolaridadService : IEscolaridadService
    {
        private LahigueraContext _ctxt { get; set; }
        public EscolaridadService(LahigueraContext ctx) 
        {
            _ctxt = ctx;  
        }
        public List<Escolaridad> getAll()
        {
            return _ctxt.Escolaridades.ToList();
        }
    }
}
