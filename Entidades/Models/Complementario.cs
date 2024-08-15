namespace Entidades.Models;

public class Complementario
{
    public int Id { get; set; }

    public int? PacienteId { get; set; }

    public virtual Paciente Paciente { get; set; }

    public string? ParajeResidencia { get; set; }

    public int? EstadoCivilId { get; set; }

    public virtual EstadoCivil? EstadoCivil { get; set; }

    public int? SabeLeer { get; set; }

    public int? EscolaridadId { get; set; }
    public virtual Escolaridad? Escolaridad { get; set; }

    public int? EscolaridadCompleta { get; set; }

    public string? Ocupacion { get; set; }

    public string? Notas { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public DateOnly? LastUpdated { get; set; }

}
