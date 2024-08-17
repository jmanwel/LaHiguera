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
            return _ctxt.EstadosCiviles.OrderByDescending(o => o.Id).ToList();
        }

        public EstadoCivil getById(int id)
        {
            var estado_civil = _ctxt.EstadosCiviles.Find(id);
            if (estado_civil == null)
            {
                Console.WriteLine("Registro no encontrado");
            }            
            return estado_civil;
        }

        public List<EstadoCivil> getAllButId(int id)
        {
            return _ctxt.EstadosCiviles.Where(o => o.Id != id).OrderByDescending(o => o.Id).ToList();
        }

    }
}
