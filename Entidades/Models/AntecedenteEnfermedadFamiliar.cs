namespace Entidades.Models
{
    public class AntecedenteEnfermedadFamiliar
    {
        public int Id { get; set; }

        public int AntecedenteId { get; set; }
        public Antecedente Antecedente { get; set; }

        public int EnfermedadFamiliarId { get; set; }
        public EnfermedadFamiliar EnfermedadFamiliar { get; set; }
    }
}
