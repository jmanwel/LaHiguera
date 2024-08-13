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
            complementario.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            complementario.LugarNac = complementario.LugarNac?.ToUpper() ?? "";
            complementario.ParajeResidencia = complementario.ParajeResidencia?.ToUpper() ?? "";
            complementario.Etnia = complementario.Etnia?.ToUpper() ?? "";
            complementario.EstadoCivil = complementario.EstadoCivil?.ToUpper() ?? "";
            complementario.Escolaridad = complementario.Escolaridad?.ToUpper() ?? "";
            complementario.Ocupacion = complementario.Ocupacion?.ToUpper() ?? "";
            complementario.Notas = complementario.Notas?.ToUpper() ?? "";
            complementario.Id = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
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
            return _ctxt.Complementarios.Where(o => o.PacienteId == id_patient).ToList();
        }

        public void editComplementary(Complementario complementario)
        {
            //This method updates Complementario objects in DDBB
            var updated_complementary = _ctxt.Complementarios.Find(complementario.Id);
            if (updated_complementary is null) { Console.WriteLine("Datos no encontrados"); }
            else
            {
                updated_complementary.LugarNac = complementario.LugarNac?.ToUpper() ?? "";
                updated_complementary.ParajeResidencia = complementario.ParajeResidencia?.ToUpper() ?? "";
                updated_complementary.Etnia = complementario.Etnia?.ToUpper() ?? "";
                updated_complementary.EstadoCivil = complementario.EstadoCivil?.ToUpper() ?? "";
                updated_complementary.SabeLeer = complementario.SabeLeer;
                updated_complementary.Escolaridad = complementario.Escolaridad?.ToUpper() ?? "";
                updated_complementary.Ocupacion = complementario.Ocupacion?.ToUpper() ?? "";
                updated_complementary.AnoIngreso = complementario.AnoIngreso;
                updated_complementary.Notas = complementario.Notas?.ToUpper() ?? "";
                updated_complementary.LastUpdated = DateOnly.FromDateTime(DateTime.Now);
                _ctxt.SaveChanges();
            }
        }

    }
}
