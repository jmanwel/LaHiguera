using Entidades.Models;

namespace Servicios
{
    public class ConsultaService: IConsultaService
    {
        public LahigueraContext _ctxt { get; set; }
        public ConsultaService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }

        public List<Consulta> getAllConsultationFromIdPatient(int id_patient) { 
            // This Method returns all consultation availables for a patient
            return _ctxt.Consulta.Where(o => o.PacienteId == id_patient).OrderByDescending(o => o.FechaAtencion).ToList();
        }

        public void create(Consulta consulta)
        {
            //This method persists Consulta objects in DDBB
            try {
                consulta.FechaCreacion = @DateTime.Today;
                _ctxt.Consulta.Add(consulta);
                _ctxt.SaveChanges();
                Console.WriteLine("Consulta creada OK!");
            }
            catch (Exception e) { 
                Console.WriteLine(e.ToString());
            }

        }
    }
}
