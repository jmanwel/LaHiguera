using Entidades.Models;

namespace Servicios
{
    public class PacienteService: IPacienteService
    {
        public LahigueraContext _ctxt { get; set; }
        public PacienteService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }

        public List<Paciente> getAllPatients() { 
            return _ctxt.Pacientes.ToList();
        }

        public void create(Paciente paciente)
        {
            _ctxt.Pacientes.Add(paciente);
            _ctxt.SaveChanges();
        }

    }
}
