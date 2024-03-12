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

        public void setDeactivate(int id_patient)
        {
            Console.WriteLine("-----------------");
            Console.WriteLine(id_patient);
            //This method set the field FlgActivo to 0
            var deactivate_patient = _ctxt.Pacientes.Find(id_patient);
            if (deactivate_patient is null)
            {
                Console.WriteLine("Patient not found");
            }
            else
            {
                deactivate_patient.FlgActivo = 0;
                _ctxt.SaveChanges();
            }
            
        }

    }
}
