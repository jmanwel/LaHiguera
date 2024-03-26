using Entidades.Models;


namespace Servicios
{
    public interface IConsultaService
    {
        List<Consulta> getAllConsultationFromIdPatient(int id_patient);
        void create(Consulta consulta);

    }
}