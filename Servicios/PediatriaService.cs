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
            pediatria.Peso = (double?)Convert.ToDecimal(pediatria.Peso);
            pediatria.PercentilPeso = (double?)Convert.ToDecimal(pediatria.PercentilPeso);
            pediatria.PzPeso = (double?)Convert.ToDecimal(pediatria.PzPeso);
            pediatria.Talla = (double?)Convert.ToDecimal(pediatria.Talla);
            pediatria.PercentilTalla = (double?)Convert.ToDecimal(pediatria.PercentilTalla);
            pediatria.PzTalla = (double?)Convert.ToDecimal(pediatria.PzTalla);
            pediatria.Imc = (double?)Convert.ToDecimal(pediatria.Imc);
            pediatria.PercentilImc = (double?)Convert.ToDecimal(pediatria.PercentilImc);
            pediatria.PzImc = (double?)Convert.ToDecimal(pediatria.PzImc);
            pediatria.Pc = (double?)Convert.ToDecimal(pediatria.Pc);
            pediatria.PercentilPc = (double?)Convert.ToDecimal(pediatria.PercentilPc);
            pediatria.PzPc = (double?)Convert.ToDecimal(pediatria.PzPc);
            pediatria.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            pediatria.AgudezaDer = pediatria.AgudezaDer?.ToUpper() ?? "";
            pediatria.AgudezaIzq = pediatria.AgudezaIzq?.ToUpper() ?? "";
            pediatria.Id = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            _ctxt.Pediatria.Add(pediatria);
            _ctxt.SaveChanges();
        }

        public List<Pediatria> getAllPediatryForAPatient(int id_patient)
        {
            // This Method returns all pediatry for a patient
            return _ctxt.Pediatria.Where(o => o.PacienteId == id_patient).OrderByDescending(o => o.FechaCreacion).ToList();
        }

        public Pediatria getPediatryForAPatient(int id)
        {
            // This Method returns a pediatry object for a patient
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
                pediatria_updated.Peso = (double?)Convert.ToDecimal(pediatria.Peso);
                pediatria_updated.PercentilPeso = (double?)Convert.ToDecimal(pediatria.PercentilPeso);
                pediatria_updated.PzPeso = (double?)Convert.ToDecimal(pediatria.PzPeso);
                pediatria_updated.Talla = (double?)Convert.ToDecimal(pediatria.Talla);
                pediatria_updated.PercentilTalla = (double?)Convert.ToDecimal(pediatria.PercentilTalla);
                pediatria_updated.PzTalla = (double?)Convert.ToDecimal(pediatria.PzTalla);
                pediatria_updated.Imc = (double?)Convert.ToDecimal(pediatria.Imc);
                pediatria_updated.PercentilImc = (double?)Convert.ToDecimal(pediatria.PercentilImc);
                pediatria_updated.PzImc = (double?)Convert.ToDecimal(pediatria.PzImc);
                pediatria_updated.Pc = (double?)Convert.ToDecimal(pediatria.Pc);
                pediatria_updated.PercentilPc = (double?)Convert.ToDecimal(pediatria.PercentilPc);
                pediatria_updated.PzPc = (double?)Convert.ToDecimal(pediatria.PzPc);
                pediatria_updated.AgudezaDer = pediatria.AgudezaDer?.ToUpper() ?? "";
                pediatria_updated.AgudezaIzq = pediatria.AgudezaIzq?.ToUpper() ?? "";
                pediatria_updated.LastUpdated = DateOnly.FromDateTime(DateTime.Now);
                _ctxt.SaveChanges();
            }
        }

    }
}
