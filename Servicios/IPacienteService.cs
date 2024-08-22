using Entidades.Models;


namespace Servicios
{
    public interface IPacienteService
    {
        List<Paciente> getAllPatients();
        List<Paciente> getAllInactivePatients();
        int create(Paciente paciente);
        void setActivate(int id_patient);
        void setDeactivate(int id_patient);
        Paciente getPatient(int id_patient);
        void editPatient(Paciente paciente);
        public bool checkPatient(String dni);
    }
}