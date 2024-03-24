using Entidades.Models;


namespace Servicios
{
    public interface IComplementarioService
    {
        bool hasComplementary(int id_patient);

        void create(Complementario complementario);

        List<Complementario> getComplementaryData(int id_patient);

        void editComplementary(Complementario complementario);
    }
}