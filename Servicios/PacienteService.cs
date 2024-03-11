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
            // This Method returns all patients active
            return _ctxt.Pacientes.Where(o => o.FlgActivo == 1).ToList();
        }

        public void create(Paciente paciente)
        {
            //This method persists Patients objects in DDBB
            _ctxt.Pacientes.Add(paciente);
            _ctxt.SaveChanges();
        }

    }
}
