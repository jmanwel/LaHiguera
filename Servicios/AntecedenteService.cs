using Entidades.Models;

namespace Servicios
{
    public class AntecedenteService: IAntecedenteService
    {
        public LahigueraContext _ctxt { get; set; }
        public AntecedenteService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }
        

        public List<Antecedente> getAllAntecedentForAPatient(int id_patient) {
            // This Method returns all antecedent for a patient
            return _ctxt.Antecedentes.Where(o => o.PacienteId == id_patient).OrderByDescending(o =>o.FechaCreacion).ToList();
        }

        public void create(Antecedente antecedente)
        {
            //This method persists Antecedent objects in DDBB
            antecedente.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            antecedente.Notas = antecedente.Notas?.ToUpper() ?? "";
            antecedente.Id = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            _ctxt.Antecedentes.Add(antecedente);
            _ctxt.SaveChanges();
        }
       
        public Antecedente getAntecedent(int id_antecedent)
        {
            //This method retrieves Antecedent objects by Id
            var antecedent = _ctxt.Antecedentes.Find(id_antecedent);
            if (antecedent == null)
            {
                Console.WriteLine("Registro no encontrado");
            }
            return antecedent;
        }

        public void editAntecedent(Antecedente antecedente)
        {
            //This method updates Antecedente objects in DDBB
            var updated_antecedent = _ctxt.Antecedentes.Find(antecedente.Id);
            if (updated_antecedent is null) { Console.WriteLine("Antecedente no encontrado"); }
            else
            {
                updated_antecedent.Sedentarismo = antecedente.Sedentarismo;
                updated_antecedent.Notas = antecedente.Notas?.ToUpper() ?? "";
                updated_antecedent.Alcohol = antecedente.Alcohol;
                updated_antecedent.Alergias = antecedente.Alergias;
                updated_antecedent.AntPerinatales = antecedente.AntPerinatales;
                updated_antecedent.Cancer = antecedente.Cancer;
                updated_antecedent.Chagas = antecedente.Chagas;
                updated_antecedent.Dbt = antecedente.Dbt;
                updated_antecedent.Dislipemia = antecedente.Dislipemia;
                updated_antecedent.Drogas = antecedente.Drogas;
                updated_antecedent.Tbc = antecedente.Tbc;
                updated_antecedent.Tabaco = antecedente.Tabaco;
                updated_antecedent.VacunacionId = antecedente.VacunacionId;
                updated_antecedent.Medicacion = antecedente.Medicacion;
                updated_antecedent.Hidatidosis = antecedente.Hidatidosis;
                updated_antecedent.Hospitalizaciones = antecedente.Hospitalizaciones;
                updated_antecedent.Hta = antecedente.Hta;
                updated_antecedent.RiesgoNut = antecedente.RiesgoNut;
                updated_antecedent.RiesgoSoc = antecedente.RiesgoSoc;
                updated_antecedent.Familiares = antecedente.Familiares;
                updated_antecedent.Quirurgicos = antecedente.Quirurgicos;
                updated_antecedent.Obesidad = antecedente.Obesidad;
                updated_antecedent.LastUpdated = DateOnly.FromDateTime(DateTime.Now);
                _ctxt.SaveChanges();
            }
        }

    }
}
