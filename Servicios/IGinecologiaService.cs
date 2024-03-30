using Entidades.Models;


namespace Servicios
{
    public interface IGinecologiaService
    {
        public void create(Ginecologia ginecologia);

        public List<Ginecologia> getAllGinecologyForAPatient(int id_patient);

        public Ginecologia getGinecology(int id);

        public void edit(Ginecologia ginecologia);
    }
}