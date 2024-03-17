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
            return _ctxt.Antecedentes.Where(o => o.PacienteId == id_patient).ToList();
        }

        public void create(Antecedente antecedente)
        {
            //This method persists Antecedent objects in DDBB
            antecedente.FechaCreacion = DateTime.Today.ToString("d");
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

        //public void editAntecedent(Antecedente antecedente)
        //{
        //    //This method updates Antecedente objects in DDBB
        //    var updated_antecedent = _ctxt.Antecedente.Find(antecedente.Id);
        //    if (updated_patient is null) { Console.WriteLine("Antecedente no encontrado"); }
        //    else
        //    {
        //        _ctxt.SaveChanges();
        //    }
        //    _ctxt.SaveChanges();
        //}

    }
}
