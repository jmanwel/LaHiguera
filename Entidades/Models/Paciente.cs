namespace Entidades.Models;

public class Paciente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = "";

    public string Apellido { get; set; } = "";

    public string? Dni { get; set; }

    public DateOnly FechaNac { get; set; }

    public string Sexo { get; set; } = "";

    public string ParajeAtencion { get; set; } = "";

    public int FlgActivo { get; set; } = 1;

    public string? LugarNac { get; set; }

    public int? EtniaId { get; set; }

    public Etnia? Etnia { get; set; }

    public List<Antecedente> Antecedentes { get; } = [];

    public List<Complementario> Complementarios { get; } = [];

    public List<Consulta> Consultas { get; } = [];

    public DateTime AnoIngreso { get; set; }

    public DateOnly? FechaAlta { get; set; }

}
