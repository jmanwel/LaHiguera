using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class Antecedente
{
    public int Id { get; set; }

    public int? PacienteId { get; set; }

    public int? Sedentarismo { get; set; }

    public int? Alcohol { get; set; }

    public int? Drogas { get; set; }

    public int? Tabaco { get; set; }

    public int? Alergias { get; set; }

    public int? Dbt { get; set; }

    public int? Hta { get; set; }

    public int? Displemia { get; set; }

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

    public int? Vacunacion { get; set; }

    public int? Medicacion { get; set; }

    public string? Notas { get; set; }

    public string? FechaCreacion { get; set; }
}
