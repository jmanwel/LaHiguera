using Entidades.Models;

namespace Servicios
{
    public class PediatriaService : IPediatriaService
    {
        public LahigueraContext _ctxt { get; set; }
        public PediatriaService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }

        

    }
}
