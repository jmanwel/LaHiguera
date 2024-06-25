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
                //Paso a uppercase los campos de texto antes de guardarlo
                consulta.MotivoConsulta = consulta.MotivoConsulta.ToUpper();
                consulta.DiagnosticoConsulta = consulta.DiagnosticoConsulta?.ToUpper() ?? "";
                consulta.Observacion = consulta.Observacion?.ToUpper() ?? "";
                consulta.EvalNutric = consulta.EvalNutric?.ToUpper() ?? "";
                consulta.EvalSoc = consulta.EvalSoc.ToUpper();
                consulta.MacActual = consulta.MacActual?.ToUpper() ?? "";
                consulta.Id = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                _ctxt.Consulta.Add(consulta);
                _ctxt.SaveChanges();
                Console.WriteLine("Consulta creada OK!");
            }
            catch (Exception e) { 
                Console.WriteLine(e.ToString());
            }
        }

        public Consulta getConsultation(int id_consultation)
        {
            // This Method returns a consultation object
            return _ctxt.Consulta.Find(id_consultation);
        }

        public void edit(Consulta consulta)
        {
            //This method update Consulta objects in DDBB
            try
            {
                var edited_consultation = _ctxt.Consulta.Find(consulta.Id);
                edited_consultation.EvalSoc = consulta.EvalSoc.ToUpper();
                edited_consultation.FechaMac = consulta.FechaMac;
                edited_consultation.EdadConsulta = consulta.EdadConsulta;
                edited_consultation.Observacion = consulta.Observacion?.ToUpper() ?? "";
                edited_consultation.DiagnosticoConsulta = consulta.DiagnosticoConsulta?.ToUpper() ?? "";
                edited_consultation.MotivoConsulta = consulta.MotivoConsulta.ToUpper();
                edited_consultation.EvalNutric = consulta.EvalNutric?.ToUpper() ?? "";
                edited_consultation.FechaAtencion = consulta.FechaAtencion;
                edited_consultation.Fum = consulta.Fum;
                edited_consultation.MacActual = consulta.MacActual?.ToUpper() ?? "";
                edited_consultation.PacienteId = consulta.PacienteId;
                _ctxt.SaveChanges();
                Console.WriteLine("Consulta modificada OK!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
