using Entidades.Models;

namespace Servicios
{
    public class EstadoCivilService : IEstadoCivilService
    {
        private LahigueraContext _ctxt { get; set; }
        public EstadoCivilService(LahigueraContext ctx)
        {
            _ctxt = ctx;
        }
        public List<EstadoCivil> getAll()
        {
            return _ctxt.EstadosCiviles.ToList();
        }
    }
}
