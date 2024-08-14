namespace Entidades.Models
{
    public class EnfermedadFamiliar
    {
        public int Id { get; set; }

        public string Enfermedad { get; set; }

        public List<Antecedente> Antecedentes { get; } = [];

    }
}
