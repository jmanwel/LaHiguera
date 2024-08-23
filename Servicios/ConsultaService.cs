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
                consulta.FechaCreacion = DateTime.Now;
                //Paso a uppercase los campos de texto antes de guardarlo
                consulta.MotivoConsulta = consulta.MotivoConsulta.ToUpper();
                consulta.DiagnosticoConsulta = consulta.DiagnosticoConsulta?.ToUpper() ?? "";
                consulta.Observacion = consulta.Observacion?.ToUpper() ?? "";
                consulta.EvalNutric = consulta.EvalNutric?.ToUpper() ?? "";
                consulta.EvalSoc = consulta.EvalSoc.ToUpper();
                consulta.Colposcopia = consulta.Colposcopia?.ToUpper() ?? "";
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
                edited_consultation.LastUpdated= DateTime.Now;
                edited_consultation.ExamenFisico = consulta.ExamenFisico;
                edited_consultation.Ta = consulta.Ta;
                edited_consultation.Peso = consulta.Peso;
                edited_consultation.Talla = consulta.Talla;
                edited_consultation.Imc = consulta.Imc;
                edited_consultation.CircCintura = consulta.CircCintura;
                edited_consultation.CircCadera = consulta.CircCadera;
                edited_consultation.Icc = consulta.Icc;
                edited_consultation.Saturacion = consulta.Saturacion;
                edited_consultation.Temperatura = consulta.Temperatura;
                edited_consultation.Glicemia = consulta.Glicemia;
                edited_consultation.AgudezaDer = consulta.AgudezaDer;
                edited_consultation.AgudezaIzq = consulta.AgudezaIzq;
                edited_consultation.Ecografia = consulta.Ecografia;
                edited_consultation.ObservacionEco = consulta.ObservacionEco;
                edited_consultation.Ecg = consulta.Ecg;
                edited_consultation.ObservacionEcg = consulta.ObservacionEcg;
                edited_consultation.Radiografia = consulta.Radiografia;
                edited_consultation.ObservacionRadiografia = consulta.ObservacionRadiografia;
                edited_consultation.Laboratorio = consulta.Laboratorio;
                edited_consultation.ObservacionLab = consulta.ObservacionLab;
                edited_consultation.EstudiosComp = consulta.EstudiosComp;             
                edited_consultation.Tratamiento = consulta.Tratamiento;
                edited_consultation.DerivacionAguda = consulta.DerivacionAguda;
                edited_consultation.DerivacionProg = consulta.DerivacionProg;
                edited_consultation.ObservacionDeriv = consulta.ObservacionDeriv;
                edited_consultation.PercentilPeso = consulta.PercentilPeso;
                edited_consultation.PzPeso = consulta.PzPeso;
                edited_consultation.PercentilTalla = consulta.PercentilTalla;
                edited_consultation.PzTalla = consulta.PzTalla;
                edited_consultation.PercentilImc = consulta.PercentilImc;
                edited_consultation.PzImc = consulta.PzImc;
                edited_consultation.Pc = consulta.Pc;
                edited_consultation.PercentilPc = consulta.PercentilPc;
                edited_consultation.PzPc = consulta.PzPc;
                edited_consultation.Gestas = consulta.Gestas;
                edited_consultation.Para = consulta.Para;
                edited_consultation.Cesareas = consulta.Cesareas;
                edited_consultation.Abortos = consulta.Abortos;
                edited_consultation.Irs = consulta.Irs;
                edited_consultation.Menarca = consulta.Menarca;
                edited_consultation.RitmoMenst = consulta.RitmoMenst;
                edited_consultation.Menopausia = consulta.Menopausia;
                edited_consultation.TomaPap = consulta.TomaPap;
                edited_consultation.ResultadoPap = consulta.ResultadoPap;
                edited_consultation.Colposcopia = consulta.Colposcopia?.ToUpper() ?? "";

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
