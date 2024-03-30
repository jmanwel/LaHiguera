using Entidades.Models;


namespace Servicios
{
    public interface IPediatriaService
    {
        public void create(Pediatria pediatria);

        public List<Pediatria> getAllPediatryForAPatient(int id_patient);

        public Pediatria getPediatryForAPatient(int id);

        public void edit(Pediatria pediatria);

    }
}