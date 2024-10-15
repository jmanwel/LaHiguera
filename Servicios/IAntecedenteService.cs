using Entidades.Models;


namespace Servicios
{
    public interface IAntecedenteService
    {
        List<Antecedente> getAllAntecedentForAPatient(int id_patient);
        void create(Antecedente antecedente);
        public Antecedente getAntecedent(int id_antecedent);

        void editAntecedent(Antecedente antecedente);

        Task<AntecedenteView?> getAntecedentLabels(int id_patient);

    }
}