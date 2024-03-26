using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Models;

public partial class LahigueraContext : DbContext
{
    public LahigueraContext()
    {
    }

    public LahigueraContext(DbContextOptions<LahigueraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Antecedente> Antecedentes { get; set; }

    public virtual DbSet<AppLog> AppLogs { get; set; }

    public virtual DbSet<Complementario> Complementarios { get; set; }

    public virtual DbSet<Consulta> Consulta { get; set; }

    public virtual DbSet<Ginecologium> Ginecologia { get; set; }

    public virtual DbSet<Historium> Historia { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Pediatrium> Pediatria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("DataSource=C:\\Data\\Voluntariado\\LaHiguera\\Entidades\\lahiguera.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Antecedente>(entity =>
        {
            entity.ToTable("antecedentes");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Alcohol)
                .HasColumnType("INTEGER")
                .HasColumnName("alcohol");
            entity.Property(e => e.Alergias)
                .HasColumnType("INTEGER")
                .HasColumnName("alergias");
            entity.Property(e => e.AntPerinatales).HasColumnName("ant_perinatales");
            entity.Property(e => e.Cancer)
                .HasColumnType("INTEGER")
                .HasColumnName("cancer");
            entity.Property(e => e.Chagas)
                .HasColumnType("INTEGER")
                .HasColumnName("chagas");
            entity.Property(e => e.Dbt)
                .HasColumnType("INTEGER")
                .HasColumnName("dbt");
            entity.Property(e => e.Displemia)
                .HasColumnType("INTEGER")
                .HasColumnName("displemia");
            entity.Property(e => e.Drogas)
                .HasColumnType("INTEGER")
                .HasColumnName("drogas");
            entity.Property(e => e.Familiares).HasColumnName("familiares");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Hidatidosis)
                .HasColumnType("INTEGER")
                .HasColumnName("hidatidosis");
            entity.Property(e => e.Hospitalizaciones).HasColumnName("hospitalizaciones");
            entity.Property(e => e.Hta)
                .HasColumnType("INTEGER")
                .HasColumnName("hta");
            entity.Property(e => e.Medicacion).HasColumnName("medicacion");
            entity.Property(e => e.Notas).HasColumnName("notas");
            entity.Property(e => e.Obesidad)
                .HasColumnType("INTEGER")
                .HasColumnName("obesidad");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Personales).HasColumnName("personales");
            entity.Property(e => e.Quirurgicos)
                .HasColumnType("INTEGER")
                .HasColumnName("quirurgicos");
            entity.Property(e => e.RiesgoNut).HasColumnName("riesgo_nut");
            entity.Property(e => e.RiesgoSoc)
                .HasColumnType("INTEGER")
                .HasColumnName("riesgo_soc");
            entity.Property(e => e.Sedentarismo)
                .HasColumnType("INTEGER")
                .HasColumnName("sedentarismo");
            entity.Property(e => e.Tabaco)
                .HasColumnType("INTEGER")
                .HasColumnName("tabaco");
            entity.Property(e => e.Tbc)
                .HasColumnType("INTEGER")
                .HasColumnName("tbc");
            entity.Property(e => e.Vacunacion).HasColumnName("vacunacion");
        });

        modelBuilder.Entity<AppLog>(entity =>
        {
            entity.ToTable("app_log");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Timestamp)
                .HasColumnType("DATETIME")
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<Complementario>(entity =>
        {
            entity.ToTable("complementarios");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AnoIngreso).HasColumnName("ano_ingreso");
            entity.Property(e => e.Escolaridad).HasColumnName("escolaridad");
            entity.Property(e => e.EstadoCivil).HasColumnName("estado_civil");
            entity.Property(e => e.Etnia).HasColumnName("etnia");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.LugarNac).HasColumnName("lugar_nac");
            entity.Property(e => e.Notas).HasColumnName("notas");
            entity.Property(e => e.Ocupacion).HasColumnName("ocupacion");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.ParajeResidencia).HasColumnName("paraje_residencia");
            entity.Property(e => e.SabeLeer)
                .HasColumnType("INTEGER")
                .HasColumnName("sabe_leer");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.ToTable("consulta");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiagnosticoConsulta).HasColumnName("diagnostico_consulta");
            entity.Property(e => e.EdadConsulta)
                .HasColumnType("INTEGER")
                .HasColumnName("edad_consulta");
            entity.Property(e => e.EvalNutric).HasColumnName("eval_nutric");
            entity.Property(e => e.EvalSoc).HasColumnName("eval_soc");
            entity.Property(e => e.FechaAtencion)
                .HasColumnType("DATE")
                .HasColumnName("fecha_atencion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaMac).HasColumnName("fecha_mac");
            entity.Property(e => e.Fum)
                .HasColumnType("DATE")
                .HasColumnName("fum");
            entity.Property(e => e.MacActual).HasColumnName("mac_actual");
            entity.Property(e => e.MotivoConsulta).HasColumnName("motivo_consulta");
            entity.Property(e => e.Observacion).HasColumnName("observacion");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
        });

        modelBuilder.Entity<Ginecologium>(entity =>
        {
            entity.ToTable("ginecologia");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Abortos).HasColumnName("abortos");
            entity.Property(e => e.Cesareas).HasColumnName("cesareas");
            entity.Property(e => e.Colposcopia).HasColumnName("colposcopia");
            entity.Property(e => e.EstudiosComp).HasColumnName("estudios_comp");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Gestas).HasColumnName("gestas");
            entity.Property(e => e.Irs).HasColumnName("irs");
            entity.Property(e => e.Menarca).HasColumnName("menarca");
            entity.Property(e => e.Menopausia).HasColumnName("menopausia");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Para).HasColumnName("para");
            entity.Property(e => e.ResultadoPap).HasColumnName("resultado_pap");
            entity.Property(e => e.RitmoMenst).HasColumnName("ritmo_menst");
            entity.Property(e => e.TomaPap).HasColumnName("toma_pap");
        });

        modelBuilder.Entity<Historium>(entity =>
        {
            entity.ToTable("historia");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AgudezaDer).HasColumnName("agudeza_der");
            entity.Property(e => e.AgudezaIzq).HasColumnName("agudeza_izq");
            entity.Property(e => e.CircCadera).HasColumnName("circ_cadera");
            entity.Property(e => e.CircCintura).HasColumnName("circ_cintura");
            entity.Property(e => e.DerivacionAguda).HasColumnName("derivacion_aguda");
            entity.Property(e => e.DerivacionProg).HasColumnName("derivacion_prog");
            entity.Property(e => e.Diagnostico).HasColumnName("diagnostico");
            entity.Property(e => e.Ecg).HasColumnName("ecg");
            entity.Property(e => e.Ecografia).HasColumnName("ecografia");
            entity.Property(e => e.EstudiosComp).HasColumnName("estudios_comp");
            entity.Property(e => e.ExamenFisico).HasColumnName("examen_fisico");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Glicemia).HasColumnName("glicemia");
            entity.Property(e => e.Icc).HasColumnName("icc");
            entity.Property(e => e.Imc).HasColumnName("imc");
            entity.Property(e => e.Laboratorio).HasColumnName("laboratorio");
            entity.Property(e => e.ObservacionDeriv).HasColumnName("observacion_deriv");
            entity.Property(e => e.ObservacionEcg).HasColumnName("observacion_ecg");
            entity.Property(e => e.ObservacionEco).HasColumnName("observacion_eco");
            entity.Property(e => e.ObservacionLab).HasColumnName("observacion_lab");
            entity.Property(e => e.ObservacionRadiografia).HasColumnName("observacion_radiografia");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.Radiografia).HasColumnName("radiografia");
            entity.Property(e => e.Saturacion).HasColumnName("saturacion");
            entity.Property(e => e.Ta).HasColumnName("ta");
            entity.Property(e => e.Talla).HasColumnName("talla");
            entity.Property(e => e.Temperatura).HasColumnName("temperatura");
            entity.Property(e => e.Tratamiento).HasColumnName("tratamiento");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.ToTable("paciente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido).HasColumnName("apellido");
            entity.Property(e => e.Dni).HasColumnName("dni");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_alta");
            entity.Property(e => e.FechaNac)
                .HasColumnType("DATE")
                .HasColumnName("fecha_nac");
            entity.Property(e => e.FlgActivo).HasColumnName("flg_activo");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.ParajeAtencion).HasColumnName("paraje_atencion");
            entity.Property(e => e.Sexo).HasColumnName("sexo");
        });

        modelBuilder.Entity<Pediatrium>(entity =>
        {
            entity.ToTable("pediatria");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AgudezaDer).HasColumnName("agudeza_der");
            entity.Property(e => e.AgudezaIzq).HasColumnName("agudeza_izq");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Imc).HasColumnName("imc");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Pc).HasColumnName("pc");
            entity.Property(e => e.PercentilImc).HasColumnName("percentil_imc");
            entity.Property(e => e.PercentilPc).HasColumnName("percentil_pc");
            entity.Property(e => e.PercentilPeso).HasColumnName("percentil_peso");
            entity.Property(e => e.PercentilTalla).HasColumnName("percentil_talla");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.PzImc).HasColumnName("pz_imc");
            entity.Property(e => e.PzPc).HasColumnName("pz_pc");
            entity.Property(e => e.PzPeso).HasColumnName("pz_peso");
            entity.Property(e => e.PzTalla).HasColumnName("pz_talla");
            entity.Property(e => e.Talla).HasColumnName("talla");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
