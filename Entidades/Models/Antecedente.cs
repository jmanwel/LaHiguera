namespace Entidades.Models;

public class Antecedente
{
    public int Id { get; set; }

    public int? PacienteId { get; set; }

    public Paciente? Paciente { get; set; }

    public int? Sedentarismo { get; set; }

    public int? Alcohol { get; set; }

    public int? Drogas { get; set; }

    public int? Tabaco { get; set; }

    public int? Alergias { get; set; }

    public int? Dbt { get; set; }

    public int? Hta { get; set; }

    public int? Dislipemia { get; set; }

    public int? Obesidad { get; set; }

    public int? Chagas { get; set; }

    public int? Hidatidosis { get; set; }

    public int? Tbc { get; set; }

    public int? Cancer { get; set; }

    public int? Quirurgicos { get; set; }

    public int? RiesgoNut { get; set; }

    public int? RiesgoSoc { get; set; }

    public int? Personales { get; set; }

    public int? Familiares { get; set; }

    public int? Hospitalizaciones { get; set; }

    public int? AntPerinatales { get; set; }

    public int? VacunacionId { get; set; }

    public Vacunacion? Vacunacion { get; set; }

    public int? Medicacion { get; set; }

    public string? Notas { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? LastUpdated { get; set; }

}
