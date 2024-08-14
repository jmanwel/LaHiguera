using Entidades.Models;

namespace Servicios
{
    public class VacunacionService : IVacunacionService
    {
        private LahigueraContext _ctxt { get; set; }
        public VacunacionService(LahigueraContext ctx)
        {
            _ctxt = ctx;
        }
        public List<Vacunacion> getAll()
        {
            return _ctxt.Vacunaciones.ToList();
        }
    }
}
