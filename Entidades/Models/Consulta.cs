namespace Entidades.Models;

public class Consulta
{
    public int Id { get; set; }

    public int PacienteId { get; set; }

    public virtual Paciente Paciente { get; set; }

    public DateOnly? FechaAtencion { get; set; }

    public string? MotivoConsulta { get; set; }

    public int? EdadConsulta { get; set; }

    public string? DiagnosticoConsulta { get; set; }

    public string? Observacion { get; set; }

    public string? EvalNutric { get; set; }
    
    public string? EvalSoc { get; set; }

    public DateOnly? Fum { get; set; }

    public string? MacActual { get; set; }

    public DateOnly? FechaMac { get; set; }

    public string? ExamenFisico { get; set; }

    public string? Ta { get; set; }

    public decimal? Peso { get; set; }

    public decimal? Talla { get; set; }

    public decimal? Imc { get; set; }

    public int? CircCintura { get; set; }

    public int? CircCadera { get; set; }

    public int? Icc { get; set; }

    public int? Saturacion { get; set; }

    public decimal? Temperatura { get; set; }

    public int? Glicemia { get; set; }

    public string? AgudezaDer {get; set; }

    public string? AgudezaIzq { get; set; }

    public int? Ecografia { get; set; }

    public string? ObservacionEco { get; set; }

    public int? Ecg { get; set; }

    public string? ObservacionEcg { get; set; }

    public int? Radiografia { get; set; }

    public string? ObservacionRadiografia { get; set; }

    public int? Laboratorio { get; set; }

    public string? ObservacionLab {  get; set; }

    public string? EstudiosComp { get; set; }

    public string? Tratamiento { get; set; }

    public int? DerivacionAguda { get; set; }

    public int? DerivacionProg { get; set; }

    public string? ObservacionDeriv { get; set; }

    public decimal? PercentilPeso { get; set; }

    public decimal? PzPeso { get; set; }

    public decimal? PercentilTalla {  get; set; }

    public decimal? PzTalla { get; set; }

    public decimal? PercentilImc { get; set; }

    public decimal? PzImc { get; set; }

    public decimal? Pc { get; set; }

    public decimal? PercentilPc { get; set; }

    public decimal? PzPc { get; set; }

    public int? Gestas { get; set; }

    public int? Para { get; set; }

    public int? Cesareas { get; set; }

    public int? Abortos { get; set; }

    public int? Irs { get; set; }

    public int? Menarca { get; set; }

    public string? RitmoMenst { get; set; }

    public int? Menopausia { get; set; }

    public int? TomaPap { get; set; }

    public string? ResultadoPap { get; set; }

    public string? Colposcopia { get; set; }

    public int? FrecuenciaCardiaca { get; set; }

    public int? FrecuenciaRespiratoria { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? LastUpdated { get; set; }
}
