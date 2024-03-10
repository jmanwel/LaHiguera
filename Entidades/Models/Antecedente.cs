using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class Antecedente
{
    public int Id { get; set; }

    public int? PacienteId { get; set; }

    public string? Sedentarismo { get; set; }

    public string? Alcohol { get; set; }

    public string? Drogas { get; set; }

    public string? Tabaco { get; set; }

    public string? Alergias { get; set; }

    public string? Dbt { get; set; }

    public string? Hta { get; set; }

    public string? Displemia { get; set; }

    public string? Obesidad { get; set; }

    public string? Chagas { get; set; }

    public string? Hidatidosis { get; set; }

    public string? Tbc { get; set; }

    public string? Cancer { get; set; }

    public string? Quirurgicos { get; set; }

    public int? RiesgoNut { get; set; }

    public string? RiesgoSoc { get; set; }

    public int? Personales { get; set; }

    public int? Familiares { get; set; }

    public int? Hospitalizaciones { get; set; }

    public int? AntPerinatales { get; set; }

    public int? Vacunacion { get; set; }

    public int? Medicacion { get; set; }

    public string? Notas { get; set; }

    public string? FechaCreacion { get; set; }
}
