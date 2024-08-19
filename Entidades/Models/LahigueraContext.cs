using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

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

    public virtual DbSet<Complementario> Complementarios { get; set; }

    public virtual DbSet<Consulta> Consulta { get; set; }

    public virtual DbSet<EnfermedadFamiliar> EnfermedadesFamiliares { get; set; }

    public virtual DbSet<Etnia> Etnias { get; set; }

    public virtual DbSet<EstadoCivil> EstadosCiviles { get; set; }

    public virtual DbSet<Escolaridad> Escolaridades { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Vacunacion> Vacunaciones { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.Load();
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        if(connectionString == null){
            throw new InvalidOperationException("Connection string not found");
        }else{
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseLazyLoadingProxies().UseSqlite(connectionString);
             }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Antecedente>(entity =>
        {
            entity.ToTable("antecedentes");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Alcohol)
                .HasColumnType("INTEGER")
                .HasColumnName("alcohol");
            entity.Property(e => e.Alergias)
                .HasColumnType("INTEGER")
                .HasColumnName("alergias");
            entity.Property(e => e.AntPerinatales)
                .HasColumnType("INTEGER")
                .HasColumnName("ant_perinatales");
            entity.Property(e => e.Cancer)
                .HasColumnType("INTEGER")
                .HasColumnName("cancer");
            entity.Property(e => e.Chagas)
                .HasColumnType("INTEGER")
                .HasColumnName("chagas");
            entity.Property(e => e.Dbt)
                .HasColumnType("INTEGER")
                .HasColumnName("dbt");
            entity.Property(e => e.Dislipemia)
                .HasColumnType("INTEGER")
                .HasColumnName("dislipemia");
            entity.Property(e => e.Drogas)
                .HasColumnType("INTEGER")
                .HasColumnName("drogas");
            entity.Property(e => e.Familiares)
                .HasColumnType("INTEGER")
                .HasColumnName("familiares");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.LastUpdated)
                .HasColumnType("DATETIME")
                .HasColumnName("last_update");
            entity.Property(e => e.Hidatidosis)
                .HasColumnType("INTEGER")
                .HasColumnName("hidatidosis");
            entity.Property(e => e.Hospitalizaciones)
                .HasColumnType("INTEGER")
                .HasColumnName("hospitalizaciones");
            entity.Property(e => e.Hta)
                .HasColumnType("INTEGER")
                .HasColumnName("hta");
            entity.Property(e => e.Medicacion)
                .HasColumnType("INTEGER")
                .HasColumnName("medicacion");
            entity.Property(e => e.Notas)
                .HasColumnName("notas");
            entity.Property(e => e.Obesidad)
                .HasColumnType("INTEGER")
                .HasColumnName("obesidad");
            entity.Property(e => e.PacienteId)
                .HasColumnName("paciente_id");
            entity.Property(e => e.Personales)
                .HasColumnType("INTEGER")
                .HasColumnName("personales");
            entity.Property(e => e.Quirurgicos)
                .HasColumnType("INTEGER")
                .HasColumnName("quirurgicos");
            entity.Property(e => e.RiesgoNut)
                .HasColumnType("INTEGER")
                .HasColumnName("riesgo_nut");
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
            entity.Property(e => e.VacunacionId)
                .HasColumnName("vacunacion_id");
            entity.HasMany(e => e.EnfermedadesFamiliares)
                .WithMany(e => e.Antecedentes)
                .UsingEntity<AntecedenteEnfermedadFamiliar>();
        });

        modelBuilder.Entity<AntecedenteEnfermedadFamiliar>(entity =>
        {
            entity.ToTable("antecedentes_enfermedades_familiares");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AntecedenteId)
                .HasColumnType("INTEGER")
                .HasColumnName("antecedente_id");
            entity.Property(e => e.EnfermedadFamiliarId)
                .HasColumnType("INTEGER")
                .HasColumnName("enfermedad_familiar_id");
        });

        modelBuilder.Entity<Complementario>(entity =>
        {
            entity.ToTable("complementarios");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.EscolaridadId)
                .HasColumnType("INTEGER")
                .HasColumnName("escolaridad_id");
            entity.Property(e => e.EstadoCivilId)
                .HasColumnType("INTEGER")
                .HasColumnName("estado_civil_id");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.LastUpdated)
                .HasColumnType("DATETIME")
                .HasColumnName("last_update");
            entity.Property(e => e.Notas)
                .HasColumnName("notas");
            entity.Property(e => e.Ocupacion)
                .HasColumnName("ocupacion");
            entity.Property(e => e.PacienteId)
                .HasColumnName("paciente_id");
            entity.Property(e => e.ParajeResidencia)
                .HasColumnName("paraje_residencia");
            entity.Property(e => e.SabeLeer)
                .HasColumnType("INTEGER")
                .HasColumnName("sabe_leer");
            entity.Property(e => e.EscolaridadCompleta)
                .HasColumnType("INTEGER")
                .HasColumnName("escolaridad_completa");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.ToTable("consulta");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.DiagnosticoConsulta)
                .HasColumnName("diagnostico_consulta");
            entity.Property(e => e.EdadConsulta)
                .HasColumnType("INTEGER")
                .HasColumnName("edad_consulta");
            entity.Property(e => e.EvalNutric)
                .HasColumnName("eval_nutric");
            entity.Property(e => e.EvalSoc)
                .HasColumnName("eval_soc");
            entity.Property(e => e.FechaAtencion)
                .HasColumnType("DATE")
                .HasColumnName("fecha_atencion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.LastUpdated)
                .HasColumnType("DATETIME")
                .HasColumnName("last_update");
            entity.Property(e => e.FechaMac)
                .HasColumnType("DATE")
                .HasColumnName("fecha_mac");
            entity.Property(e => e.Fum)
                .HasColumnType("DATE")
                .HasColumnName("fum");
            entity.Property(e => e.MacActual)
                .HasColumnName("mac_actual");
            entity.Property(e => e.MotivoConsulta)
                .HasColumnName("motivo_consulta");
            entity.Property(e => e.Observacion)
                .HasColumnName("observacion");
            entity.Property(e => e.PacienteId)
                .HasColumnType("INTEGER")
                .HasColumnName("paciente_id");
            entity.Property(e => e.ExamenFisico)
                .HasColumnName("examen_fisico");
            entity.Property(e => e.Ta)
                .HasColumnName("ta");
            entity.Property(e => e.Peso)
                .HasColumnType("DECIMAL")
                .HasColumnName("peso");
            entity.Property(e => e.Talla)
                .HasColumnType("DECIMAL")
                .HasColumnName("talla");
            entity.Property(e => e.Imc)
                .HasColumnType("DECIMAL")
                .HasColumnName("imc");
            entity.Property(e => e.CircCintura)
                .HasColumnType("INTEGER")
                .HasColumnName("circ_cintura");
            entity.Property(e => e.CircCadera)
                .HasColumnType("INTEGER")
                .HasColumnName("circ_cadera");
            entity.Property(e => e.Icc)
                .HasColumnType("INTEGER")
                .HasColumnName("icc");
            entity.Property(e => e.Saturacion)
                .HasColumnType("INTEGER")
                .HasColumnName("saturacion");
            entity.Property(e => e.Temperatura)
                .HasColumnType("DECIMAL")
                .HasColumnName("temperatura");
            entity.Property(e => e.Glicemia)
                .HasColumnType("INTEGER")
                .HasColumnName("glicemia");
            entity.Property(e => e.AgudezaDer)
                .HasColumnName("agudeza_der");
            entity.Property(e => e.AgudezaIzq)
                .HasColumnName("agudeza_izq");
            entity.Property(e => e.Ecografia)
                .HasColumnType("INTEGER")
                .HasColumnName("ecografia");
            entity.Property(e => e.ObservacionEco)
                .HasColumnName("observacion_eco");
            entity.Property(e => e.Ecg)
                .HasColumnType("INTEGER")
                .HasColumnName("ecg");
            entity.Property(e => e.ObservacionEcg)
                .HasColumnName("observacion_ecg");
            entity.Property(e => e.Radiografia)
                .HasColumnType("INTEGER")
                .HasColumnName("radiografia");
            entity.Property(e => e.ObservacionRadiografia)
                .HasColumnName("observacion_radiografia");
            entity.Property(e => e.Laboratorio)
                .HasColumnType("INTEGER")
                .HasColumnName("laboratorio");
            entity.Property(e => e.EstudiosComp)
                .HasColumnName("estudios_comp");            
            entity.Property(e => e.Tratamiento)
                .HasColumnName("tratamiento");
            entity.Property(e => e.DerivacionAguda)
                .HasColumnType("INTEGER")
                .HasColumnName("derivacion_aguda");
            entity.Property(e => e.DerivacionProg)
                .HasColumnType("INTEGER")
                .HasColumnName("derivacion_prog");
            entity.Property(e => e.ObservacionDeriv)
                .HasColumnName("observacion_deriv");
            entity.Property(e => e.PercentilPeso)
                .HasColumnType("DECIMAL")
                .HasColumnName("percentil_peso");
            entity.Property(e => e.PzPeso)
                .HasColumnType("DECIMAL")
                .HasColumnName("pz_peso");
            entity.Property(e => e.PercentilTalla)
                .HasColumnType("DECIMAL")
                .HasColumnName("percentil_talla");
            entity.Property(e => e.PzTalla)
                .HasColumnType("DECIMAL")
                .HasColumnName("pz_talla");
            entity.Property(e => e.PercentilImc)
                .HasColumnType("DECIMAL")
                .HasColumnName("percentil_imc");
            entity.Property(e => e.PzImc)
                .HasColumnType("DECIMAL")
                .HasColumnName("pz_imc");
            entity.Property(e => e.Pc)
                .HasColumnType("DECIMAL")
                .HasColumnName("pc");
            entity.Property(e => e.PzPc)
                .HasColumnType("DECIMAL")
                .HasColumnName("pz_pc");
            entity.Property(e => e.Gestas)
                .HasColumnType("INTEGER")
                .HasColumnName("gestas");
            entity.Property(e => e.Para)
                .HasColumnType("INTEGER")
                .HasColumnName("para");
            entity.Property(e => e.Cesareas)
                .HasColumnType("INTEGER")
                .HasColumnName("cesareas");
            entity.Property(e => e.Abortos)
                .HasColumnType("INTEGER")
                .HasColumnName("abortos");
            entity.Property(e => e.Irs)
                .HasColumnType("INTEGER")
                .HasColumnName("irs");
            entity.Property(e => e.Menarca)
                .HasColumnType("INTEGER")
                .HasColumnName("menarca");
            entity.Property(e => e.RitmoMenst)
                .HasColumnName("ritmo_menst");
            entity.Property(e => e.Menopausia)
                .HasColumnType("INTEGER")
                .HasColumnName("menopausia");
            entity.Property(e => e.TomaPap)
                .HasColumnType("INTEGER")
                .HasColumnName("toma_pap");
            entity.Property(e => e.ResultadoPap)
                .HasColumnName("resultado_pap");
            entity.Property(e => e.Colposcopia)
                .HasColumnType("INTEGER")
                .HasColumnName("colposcopia");
            entity.Property(e => e.ObservacionLab)
                .HasColumnName("observacion_lab");
            entity.Property(e => e.PercentilPc)
                .HasColumnType("DECIMAL")
                .HasColumnName("percentil_pc");
        });

        modelBuilder.Entity<EnfermedadFamiliar>(entity =>
        {
            entity.ToTable("enfermedades_familiares");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Enfermedad)
                .HasColumnName("enfermedad_familiar");
        });

        modelBuilder.Entity<Escolaridad>(entity =>
        {
            entity.ToTable("escolaridades");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasColumnName("escolaridad");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.ToTable("estados_civiles");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasColumnName("estado_civil");
        });

        modelBuilder.Entity<Etnia>(entity =>
        {
            entity.ToTable("etnias");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasColumnName("etnia");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.ToTable("paciente");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni)
                .HasColumnName("dni");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_alta");
            entity.Property(e => e.FechaNac)
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_nac");
            entity.Property(e => e.FlgActivo)
                .HasColumnType("INTEGER")
                .HasColumnName("flg_activo");
            entity.Property(e => e.Nombre)
                .HasColumnName("nombre");
            entity.Property(e => e.ParajeAtencion)
                .HasColumnName("paraje_atencion");
            entity.Property(e => e.Sexo)
                .HasColumnName("sexo");
            entity.Property(e => e.AnoIngreso)
                .HasColumnType("DATE")
                .HasColumnName("ano_ingreso");
            entity.Property(e => e.EtniaId)
                .HasColumnName("etnia_id");
            entity.Property(e => e.LugarNac)
                .HasColumnName("lugar_nac");
        });

        modelBuilder.Entity<Vacunacion>(entity =>
        {
            entity.ToTable("vacunaciones");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
              .HasColumnName("vacunacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
