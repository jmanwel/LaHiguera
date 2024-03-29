using Entidades.Models;


namespace Servicios
{
    public interface IHistoriaService
    {

        public List<Historia> getAllHistoryForAPatient(int id_patient);

        public void create(Historia history);

        public Historia getHistory(int id_history);

        public void edit(Historia history);
    }
}