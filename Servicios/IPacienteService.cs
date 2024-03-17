using Entidades.Models;


namespace Servicios
{
    public interface IPacienteService
    {
        List<Paciente> getAllPatients();
        void create(Paciente paciente);
        void setDeactivate(int id_patient);
        Paciente getPatient(int id_patient);
        void editPatient(Paciente paciente);
    }
}