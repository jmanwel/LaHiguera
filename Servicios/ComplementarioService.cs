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

    }
}
