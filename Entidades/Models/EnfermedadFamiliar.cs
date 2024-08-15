namespace Entidades.Models
{
    public class EnfermedadFamiliar
    {
        public int Id { get; set; }

        public string Enfermedad { get; set; }

        public virtual ICollection<Antecedente> Antecedentes { get; } = new List<Antecedente>();

    }
}
