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
            complementario.FechaCreacion = DateTime.Today.ToString("d").ToString();
            _ctxt.Complementarios.Add(complementario);
            _ctxt.SaveChanges();
        }

        public bool hasComplementary(int id_patient)
        {
            if(_ctxt.Complementarios.Find(id_patient) != null)
            {
                return true;
            }
            return false;
        }

        public Complementario getComplementaryData(int id_patient)
        {
            return _ctxt.Complementarios.Find(id_patient);
        }

        public void editComplementary(Complementario complementario)
        {
            //This method updates Antecedente objects in DDBB
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
