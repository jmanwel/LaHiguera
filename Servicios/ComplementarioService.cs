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
            complementario.FechaCreacion = DateTime.Now;
            complementario.ParajeResidencia = complementario.ParajeResidencia?.ToUpper() ?? "";            
            complementario.Ocupacion = complementario.Ocupacion?.ToUpper() ?? "";
            complementario.Notas = complementario.Notas?.ToUpper() ?? "";
            complementario.Id = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            _ctxt.Complementarios.Add(complementario);
            _ctxt.SaveChanges();
        }

        public Complementario getComplementaryData(int id_patient)
        {
            //This method returns Complementario objects for a patient            
            var complementario = _ctxt.Complementarios.Where(o => o.PacienteId == id_patient).ToList();
            if (complementario.Count() > 0)
            {
                return complementario[0];            
            }
            return null;
        }

        public void editComplementary(Complementario complementario)
        {
            //This method updates Complementario objects in DDBB
            var updated_complementary = _ctxt.Complementarios.Find(complementario.Id);
            if (updated_complementary is null) { Console.WriteLine("Datos no encontrados"); }
            else
            {
                updated_complementary.ParajeResidencia = complementario.ParajeResidencia?.ToUpper() ?? "";
                updated_complementary.EstadoCivilId = complementario.EstadoCivilId;
                updated_complementary.SabeLeer = complementario.SabeLeer;
                updated_complementary.EscolaridadId = complementario.EscolaridadId;
                updated_complementary.EscolaridadCompleta = complementario.EscolaridadCompleta;
                updated_complementary.Ocupacion = complementario.Ocupacion?.ToUpper() ?? "";
                updated_complementary.Notas = complementario.Notas?.ToUpper() ?? "";
                updated_complementary.LastUpdated = DateTime.Now;
                _ctxt.SaveChanges();
            }
        }

    }
}
