using Entidades.Models;

namespace Servicios
{
    public class HistoriaService: IHistoriaService
    {
        public LahigueraContext _ctxt { get; set; }
        public HistoriaService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }

        public List<Historia> getAllHistoryForAPatient(int id_patient) {
            // This Method returns all history for a patient
            return _ctxt.Historia.Where(o => o.PacienteId == id_patient).OrderByDescending(o =>o.FechaCreacion).ToList();
        }

        public void create(Historia history)
        {
            //This method persists History objects in DDBB
            if (history.CircCintura >0 && history.CircCadera > 0)
            {
                history.Icc = history.CircCintura / history.CircCadera;
            }else
            {
                history.Icc = 0;
            }
            history.ExamenFisico = history.ExamenFisico?.ToUpper() ?? "";
            history.Ta = history.Ta?.ToUpper() ?? "";
            history.AgudezaDer = history.AgudezaDer?.ToUpper() ?? "";
            history.AgudezaIzq = history.AgudezaIzq?.ToUpper() ?? "";
            history.ObservacionEco = history.ObservacionEco?.ToUpper() ?? "";
            history.ObservacionEcg = history.ObservacionEcg?.ToUpper() ?? "";
            history.ObservacionRadiografia = history.ObservacionRadiografia?.ToUpper() ?? "";
            history.ObservacionLab = history.ObservacionLab?.ToUpper() ?? "";
            history.EstudiosComp = history.EstudiosComp?.ToUpper() ?? "";
            history.Diagnostico = history.Diagnostico.ToUpper();
            history.Tratamiento = history.Tratamiento?.ToUpper() ?? "";
            history.ObservacionDeriv = history.ObservacionDeriv?.ToUpper() ?? "";

            history.Talla = (double?)Convert.ToDecimal(history.Talla);
            history.Temperatura = (double?)Convert.ToDecimal(history.Temperatura);
            history.Peso = (double?)Convert.ToDecimal(history.Peso);
            history.Imc = (double?)Convert.ToDecimal(history.Imc);
            history.FechaCreacion = DateTime.Today;
            history.Id = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            _ctxt.Historia.Add(history);
            _ctxt.SaveChanges();
        }
       
        public Historia getHistory(int id_history)
        {
            //This method retrieves History objects by Id
            var history = _ctxt.Historia.Find(id_history);
            if (history == null)
            {
                Console.WriteLine("Registro no encontrado");
            }
            return history;
        }

        public void edit(Historia history)
        {
            //This method update History objects in DDBB
            var history_updated = _ctxt.Historia.Find(history.Id);
            if (history_updated == null)
            {
                Console.WriteLine("Registro no encontrado");
            }
            else
            {
                if (history_updated.CircCintura > 0 && history_updated.CircCadera > 0)
                {
                    history_updated.Icc = history_updated.CircCintura / history_updated.CircCadera;
                }
                else
                {
                    history_updated.Icc = 0;
                }
                history_updated.Temperatura = (double?)Convert.ToDecimal(history.Temperatura);
                history_updated.CircCintura = history.CircCintura;
                history_updated.CircCadera = history.CircCadera;
                history_updated.Ecg = history.Ecg;
                history_updated.ObservacionEcg = history.ObservacionEcg?.ToUpper() ?? "";
                history_updated.Ecografia = history.Ecografia;
                history_updated.ObservacionEco = history.ObservacionEco?.ToUpper() ?? "";
                history_updated.AgudezaDer = history.AgudezaDer?.ToUpper() ?? "";
                history_updated.AgudezaIzq = history.AgudezaIzq?.ToUpper() ?? "";
                history_updated.DerivacionAguda = history.DerivacionAguda;
                history_updated.DerivacionProg = history.DerivacionProg;
                history_updated.ObservacionDeriv = history.ObservacionDeriv?.ToUpper() ?? "";
                history_updated.EstudiosComp = history.EstudiosComp?.ToUpper() ?? "";
                history_updated.Diagnostico = history.Diagnostico.ToUpper();
                history_updated.ExamenFisico = history.ExamenFisico?.ToUpper() ?? "";
                history_updated.Glicemia = history.Glicemia;
                history_updated.Imc = (double?)Convert.ToDecimal(history.Imc);
                history_updated.Laboratorio = history.Laboratorio;
                history_updated.ObservacionLab = history.ObservacionLab?.ToUpper() ?? "";
                history_updated.Radiografia = history.Radiografia;
                history_updated.ObservacionRadiografia = history.ObservacionRadiografia?.ToUpper() ?? "";
                history_updated.Peso = (double?)Convert.ToDecimal(history.Peso);
                history_updated.Ta = history.Ta?.ToUpper() ?? "";
                history_updated.Talla = (double?)Convert.ToDecimal(history.Talla);
                history_updated.Saturacion = history.Saturacion;
                history_updated.Tratamiento = history.Tratamiento?.ToUpper() ?? "";
                history_updated.LastUpdated = DateTime.Today;
                _ctxt.SaveChanges();
            }
        }
    }
}
