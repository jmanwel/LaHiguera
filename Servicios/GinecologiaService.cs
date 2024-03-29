using Entidades.Models;

namespace Servicios
{
    public class GinecologiaService : IGinecologiaService
    {
        public LahigueraContext _ctxt { get; set; }
        public GinecologiaService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }

        

    }
}
