namespace Entidades.Models;

public class Complementario
{
    public int Id { get; set; }

    public int? PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    public string? ParajeResidencia { get; set; }

    public int? EstadoCivilId { get; set; }

    public EstadoCivil? EstadoCivil { get; set; }

    public int? SabeLeer { get; set; }

    public int? EscolaridadId { get; set; }
    public Escolaridad? Escolaridad { get; set; }

    public int? EscolaridadCompleta { get; set; }

    public string? Ocupacion { get; set; }

    public string? Notas { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? LastUpdated { get; set; }

}
