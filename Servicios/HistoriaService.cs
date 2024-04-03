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
            history.FechaCreacion = DateTime.Today;
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
                history_updated.CircCintura = history.CircCintura;
                history_updated.CircCadera = history.CircCadera;
                history_updated.Ecg = history.Ecg;
                history_updated.ObservacionEcg = history.ObservacionEcg;
                history_updated.Ecografia = history.Ecografia;
                history_updated.ObservacionEco = history.ObservacionEco;
                history_updated.AgudezaDer = history.AgudezaDer;
                history_updated.AgudezaIzq = history.AgudezaIzq;
                history_updated.DerivacionAguda = history.DerivacionAguda;
                history_updated.DerivacionProg = history.DerivacionProg;
                history_updated.ObservacionDeriv = history.ObservacionDeriv;
                history_updated.EstudiosComp = history.EstudiosComp;
                history_updated.Diagnostico = history.Diagnostico;
                history_updated.ExamenFisico = history.ExamenFisico;
                history_updated.Glicemia = history.Glicemia;
                history_updated.Imc = history.Imc;
                history_updated.Laboratorio = history.Laboratorio;
                history_updated.ObservacionLab = history.ObservacionLab;
                history_updated.Radiografia = history.Radiografia;
                history_updated.ObservacionRadiografia = history.ObservacionRadiografia;
                history_updated.Peso = history.Peso;
                history_updated.Ta = history.Ta;
                history_updated.Talla = history.Talla;
                history_updated.Saturacion = history.Saturacion;
                history_updated.Tratamiento = history.Tratamiento;
                _ctxt.SaveChanges();
            }
        }
    }
}
