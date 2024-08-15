namespace Entidades.Models
{
    public class AntecedenteEnfermedadFamiliar
    {
        public int Id { get; set; }

        public int AntecedenteId { get; set; }
        public virtual Antecedente Antecedente { get; set; }

        public int EnfermedadFamiliarId { get; set; }
        public virtual EnfermedadFamiliar EnfermedadFamiliar { get; set; }
    }
}
