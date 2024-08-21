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
            return _ctxt.Escolaridades.OrderByDescending(o => o.Id).ToList();
        }

        public Escolaridad getById(int id)
        {
            var escolaridad = _ctxt.Escolaridades.Find(id);
            if (escolaridad == null)
            {
                Console.WriteLine("Registro ESCOLARIDAD no encontrado");
            }
            return escolaridad;
        }

        public List<Escolaridad> getAllButId(int id)
        {
            return _ctxt.Escolaridades.Where(o => o.Id != id).ToList();
        }
    }
}
