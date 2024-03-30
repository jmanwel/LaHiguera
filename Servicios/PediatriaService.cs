using Entidades.Models;

namespace Servicios
{
    public class PediatriaService : IPediatriaService
    {
        public LahigueraContext _ctxt { get; set; }
        public PediatriaService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }

        public void create(Pediatria pediatria)
        {
            //This method persists Pediatry objects in DDBB
            pediatria.FechaCreacion = DateTime.Today;
            _ctxt.Pediatria.Add(pediatria);
            _ctxt.SaveChanges();
        }

        public List<Pediatria> getAllPediatryForAPatient(int id_patient)
        {
            // This Method returns all antecedent for a patient
            return _ctxt.Pediatria.Where(o => o.PacienteId == id_patient).OrderByDescending(o => o.FechaCreacion).ToList();
        }

        public Pediatria getPediatryForAPatient(int id)
        {
            // This Method returns all antecedent for a patient
            return _ctxt.Pediatria.Find(id);
        }

        public void edit(Pediatria pediatria)
        {
            //This method updates Pediatry objects in DDBB
            var pediatria_updated = _ctxt.Pediatria.Find(pediatria.Id);
            if (pediatria_updated == null)
            {
                Console.WriteLine("Registro no encontrado!");
            }
            else
            {
                pediatria_updated.PacienteId = pediatria.PacienteId;
                pediatria_updated.Peso = pediatria.Peso;
                pediatria_updated.PercentilPeso = pediatria.PercentilPeso;
                pediatria_updated.PzPeso = pediatria.PzPeso;
                pediatria_updated.Talla = pediatria.Talla;
                pediatria_updated.PercentilTalla = pediatria.PercentilTalla;
                pediatria_updated.PzTalla = pediatria.PzTalla;
                pediatria_updated.Imc = pediatria.Imc;
                pediatria_updated.PercentilImc = pediatria.PercentilImc;
                pediatria_updated.PzImc = pediatria.PzImc;
                pediatria_updated.Pc = pediatria.Pc;
                pediatria_updated.PercentilPc = pediatria.PercentilPc;
                pediatria_updated.PzPc = pediatria.PzPc;
                pediatria_updated.AgudezaDer = pediatria.AgudezaDer;
                pediatria_updated.AgudezaIzq = pediatria.AgudezaIzq;
                _ctxt.SaveChanges();
            }
        }

    }
}
