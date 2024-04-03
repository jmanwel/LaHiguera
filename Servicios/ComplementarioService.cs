using Entidades.Models;

namespace Servicios
{
    public class ComplementarioService: IComplementarioService
    {
        public LahigueraContext _ctxt { get; set; }
        public ComplementarioService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }

        public void create(Complementario complementario)
        {
            //This method persist Complementario objects in DDBB
            complementario.FechaCreacion = DateTime.Today.ToString("d").ToString();
            _ctxt.Complementarios.Add(complementario);
            _ctxt.SaveChanges();
        }


        //public bool hasComplementary(int id_patient)
        //{
        //    if (_ctxt.Complementarios.Where(o => o.PacienteId == id_patient).ToList().Count > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public List<Complementario> getComplementaryData(int id_patient)
        {
            //This method returns Complementario objects for a patient
            //var id = _ctxt.Complementarios.Where(o => o.PacienteId == id_patient).ToList()[0].Id;
            //return _ctxt.Complementarios.Find(id);
            return _ctxt.Complementarios.Where(o => o.PacienteId == id_patient).ToList();
        }

        public void editComplementary(Complementario complementario)
        {
            //This method updates Complementario objects in DDBB
            var updated_complementary = _ctxt.Complementarios.Find(complementario.Id);
            if (updated_complementary is null) { Console.WriteLine("Datos no encontrados"); }
            else
            {
                updated_complementary.LugarNac = complementario.LugarNac;
                updated_complementary.ParajeResidencia = complementario.ParajeResidencia;
                updated_complementary.Etnia = complementario.Etnia;
                updated_complementary.EstadoCivil = complementario.EstadoCivil;
                updated_complementary.SabeLeer = complementario.SabeLeer;
                updated_complementary.Escolaridad = complementario.Escolaridad;
                updated_complementary.Ocupacion = complementario.Ocupacion;
                updated_complementary.AnoIngreso = complementario.AnoIngreso;
                updated_complementary.Notas = complementario.Notas;
                _ctxt.SaveChanges();
            }
        }

    }
}
