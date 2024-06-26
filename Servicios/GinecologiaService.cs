using Entidades.Models;

namespace Servicios
{
    public class GinecologiaService : IGinecologiaService
    {
        public LahigueraContext _ctxt { get; set; }
        public GinecologiaService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }

        public void create(Ginecologia ginecologia)
        {
            //This method persists Ginecology objects in DDBB
            ginecologia.FechaCreacion = DateTime.Today;
            ginecologia.RitmoMenst = ginecologia.RitmoMenst?.ToUpper() ?? "";
            ginecologia.ResultadoPap = ginecologia.ResultadoPap?.ToUpper() ?? "";
            ginecologia.EstudiosComp = ginecologia.EstudiosComp?.ToUpper() ?? "";
            ginecologia.Id = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            _ctxt.Ginecologia.Add(ginecologia);
            _ctxt.SaveChanges();
        }

        public List<Ginecologia> getAllGinecologyForAPatient(int id_patient)
        {
            // This Method returns all ginecology for a patient
            return _ctxt.Ginecologia.Where(o => o.PacienteId == id_patient).OrderByDescending(o => o.FechaCreacion).ToList();
        }

        public Ginecologia getGinecology(int id)
        {
            // This Method returns a ginecology object
            return _ctxt.Ginecologia.Find(id);
        }

        public void edit(Ginecologia ginecologia)
        {
            //This method updates ginecology objects in DDBB
            var ginecologia_updated = _ctxt.Ginecologia.Find(ginecologia.Id);
            if (ginecologia_updated == null)
            {
                Console.WriteLine("Registro no encontrado!");
            }
            else
            {
                ginecologia_updated.PacienteId = ginecologia.PacienteId;
                ginecologia_updated.Gestas = ginecologia.Gestas;
                ginecologia_updated.Para = ginecologia.Para;
                ginecologia_updated.Cesareas = ginecologia.Cesareas;
                ginecologia_updated.Abortos = ginecologia.Abortos;
                ginecologia_updated.Irs = ginecologia.Irs;
                ginecologia_updated.Menarca = ginecologia.Menarca;
                ginecologia_updated.RitmoMenst = ginecologia.RitmoMenst?.ToUpper() ?? "";
                ginecologia_updated.Menopausia = ginecologia.Menopausia;
                ginecologia_updated.TomaPap = ginecologia.TomaPap;
                ginecologia_updated.ResultadoPap = ginecologia.ResultadoPap?.ToUpper() ?? "";
                ginecologia_updated.Colposcopia = ginecologia.Colposcopia;
                ginecologia_updated.EstudiosComp = ginecologia.EstudiosComp?.ToUpper() ?? "";
                ginecologia_updated.LastUpdated = DateTime.Today;
                _ctxt.SaveChanges();
            }
        }

    }
}
