import sqlite3
from datetime import datetime, timedelta

dbsource = input("Ingrese la ubicacion de la base de datos de origen: ")
if dbsource == "":
    dbsource = "../Entidades/lahiguera.db"

connection = sqlite3.connect(dbsource)
cursor = connection.cursor()

print("DB opened database successfully")
print('Task 1: Changing name field name "displemia" for "dislipemia" in table antecedentes...')

try:
    cursor.execute("ALTER TABLE antecedentes RENAME COLUMN displemia TO dislipemia;")
    connection.commit()
    print("Task 1: Successful")
except:
    print("Task 1: Failed")

print('Task 2.1: Adding new field "last_update" in tables...')

try:
    cursor.execute("ALTER TABLE antecedentes ADD COLUMN last_update DATETIME;")
    cursor.execute("ALTER TABLE complementarios ADD COLUMN last_update DATETIME;")
    cursor.execute("ALTER TABLE consulta ADD COLUMN last_update DATETIME;")
    cursor.execute("ALTER TABLE ginecologia ADD COLUMN last_update DATETIME;")
    cursor.execute("ALTER TABLE historia ADD COLUMN last_update DATETIME;")
    cursor.execute("ALTER TABLE paciente ADD COLUMN last_update DATETIME;")
    cursor.execute("ALTER TABLE pediatria ADD COLUMN last_update DATETIME;")
    connection.commit()
    print("Task 2.1: Successful")
except:
    print("Task 2.1: Failed")


print('Task 2.2: TBD if we must populate historic last_update fields and if we need to perform some operation with the patients IDs...')

try:
    cursor.execute("UPDATE antecedentes SET last_update = fecha_creacion;")
    cursor.execute("UPDATE complementarios SET last_update = fecha_creacion;")
    cursor.execute("UPDATE consulta SET last_update = fecha_creacion;")
    cursor.execute("UPDATE ginecologia SET last_update = fecha_creacion;")
    cursor.execute("UPDATE historia SET last_update = fecha_creacion;")
    cursor.execute("UPDATE pediatria SET last_update = fecha_creacion;")
    connection.commit()
    print("Task 2.2: Successful")
except:
    print("Task 2.2: Failed")

print('Task 3.1: BKP tables for standardization...')

try:
    cursor.execute("CREATE TABLE antecedentes_bkp AS SELECT * FROM antecedentes;")
    cursor.execute("CREATE TABLE complementarios_bkp AS SELECT * FROM complementarios;")
    cursor.execute("CREATE TABLE consulta_bkp AS SELECT * FROM consulta;")
    cursor.execute("CREATE TABLE ginecologia_bkp AS SELECT * FROM ginecologia;")
    cursor.execute("CREATE TABLE historia_bkp AS SELECT * FROM historia;")
    cursor.execute("CREATE TABLE paciente_bkp AS SELECT * FROM paciente;")
    cursor.execute("CREATE TABLE pediatria_bkp AS SELECT * FROM pediatria;")
    connection.commit()
    print("Task 3.1: Successful")
except:
    print("Task 3.1: Failed")

print('Task 3.2: Deleting old tables...')

try:
    cursor.execute("DROP TABLE antecedentes;")
    cursor.execute("DROP TABLE complementarios;")
    cursor.execute("DROP TABLE consulta;")
    cursor.execute("DROP TABLE ginecologia;")
    cursor.execute("DROP TABLE historia;")
    cursor.execute("DROP TABLE paciente;")
    cursor.execute("DROP TABLE pediatria;")
    connection.commit()
    print("Task 3.2: Successful")
except:
    print("Task 3.2: Failed")

print('Task 3.3: Creating new tables...')

try:
    cursor.execute("CREATE TABLE estados_civiles (ID INTEGER PRIMARY KEY AUTOINCREMENT, estado_civil TEXT );")
    cursor.execute("CREATE TABLE escolaridades (ID INTEGER PRIMARY KEY AUTOINCREMENT, escolaridad TEXT );")
    cursor.execute("CREATE TABLE vacunaciones (ID INTEGER PRIMARY KEY AUTOINCREMENT, vacunacion TEXT );")
    cursor.execute("CREATE TABLE etnias (ID INTEGER PRIMARY KEY AUTOINCREMENT, etnia TEXT );")
    cursor.execute("CREATE TABLE enfermedades_familiares (ID INTEGER PRIMARY KEY AUTOINCREMENT, enfermedad_familiar TEXT );")

    cursor.execute("CREATE TABLE antecedentes_enfermedades_familiares (ID INTEGER PRIMARY KEY AUTOINCREMENT, antecedente_id INTEGER, enfermedad_familiar_id INTEGER );")

    # Tabla temporal
    cursor.execute("CREATE TABLE tmp_fechas ( ID INTEGER PRIMARY KEY AUTOINCREMENT, fecha DATETIME, paciente_id INTEGER );")
    
    cursor.execute("CREATE TABLE complementarios (ID INTEGER PRIMARY KEY AUTOINCREMENT, paciente_id INTEGER, paraje_residencia TEXT, estado_civil_id INTEGER, sabe_leer INTEGER, escolaridad_id INTEGER, escolaridad_completa INTEGER, ocupacion TEXT, notas TEXT, fecha_creacion DATETIME, last_update DATETIME );")
    cursor.execute("CREATE TABLE antecedentes ( ID INTEGER PRIMARY KEY AUTOINCREMENT, paciente_id INTEGER, sedentarismo INTEGER, alcohol INTEGER, drogas INTEGER, tabaco INTEGER, alergias INTEGER, dbt INTEGER, hta INTEGER, dislipemia INTEGER, obesidad INTEGER, chagas INTEGER, hidatidosis INTEGER, tbc INTEGER, cancer INTEGER, quirurgicos INTEGER, riesgo_nut INTEGER, riesgo_soc INTEGER, personales INTEGER, familiares INTEGER, hospitalizaciones INTEGER, ant_perinatales INTEGER, vacunacion_id INTEGER, medicacion INTEGER, notas TEXT, fecha_creacion DATETIME, last_update DATETIME );")
    cursor.execute("CREATE TABLE consulta ( ID INTEGER PRIMARY KEY AUTOINCREMENT, paciente_id INTEGER, fecha_atencion DATE, motivo_consulta TEXT, edad_consulta INTEGER, diagnostico_consulta TEXT, observacion TEXT, eval_nutric TEXT, eval_soc TEXT, fum DATE, mac_actual TEXT, fecha_mac TEXT, fecha_creacion DATETIME, last_update DATETIME, examen_fisico TEXT, ta TEXT, peso REAL, talla REAL, imc REAL, circ_cintura INTEGER, circ_cadera INTEGER, icc INTEGER, saturacion INTEGER, temperatura REAL, glicemia INTEGER, agudeza_der TEXT, agudeza_izq TEXT, ecografia INTEGER, observacion_eco TEXT, ecg INTEGER, observacion_ecg TEXT, radiografia INTEGER, observacion_radiografia TEXT, laboratorio INTEGER, observacion_lab TEXT, estudios_comp TEXT, diagnostico TEXT, tratamiento TEXT, derivacion_aguda INTEGER, derivacion_prog INTEGER, observacion_deriv TEXT, percentil_peso REAL, pz_peso REAL, percentil_talla REAL, pz_talla REAL, percentil_imc REAL, pz_imc REAL, pc REAL, percentil_pc REAL, pz_pc REAL, gestas INTEGER, para INTEGER, cesareas INTEGER, abortos INTEGER, irs INTEGER, menarca INTEGER, ritmo_menst TEXT, menopausia INTEGER, toma_pap INTEGER, resultado_pap TEXT, colposcopia INTEGER );")
    cursor.execute("CREATE TABLE paciente ( ID INTEGER PRIMARY KEY AUTOINCREMENT, nombre TEXT, apellido TEXT, dni INTEGER, fecha_nac DATE, sexo TEXT, paraje_atencion TEXT, flg_activo INTEGER, fecha_alta DATETIME, lugar_nac TEXT, etnia_id INTEGER, ano_ingreso INTEGER );")
    connection.commit()
    print("Task 3.3: Successful")
except:
    print("Task 3.3: Failed")

print('Task 3.4: Seeding new static tables...')

try:
    print("Seeding estados_civiles...")
    cursor.execute("INSERT INTO estados_civiles (estado_civil) VALUES ('SOLTERO');")
    cursor.execute("INSERT INTO estados_civiles (estado_civil) VALUES ('CASADO');")
    cursor.execute("INSERT INTO estados_civiles (estado_civil) VALUES ('UNION ESTABLE');")
    cursor.execute("INSERT INTO estados_civiles (estado_civil) VALUES ('VIUDO');")
    cursor.execute("INSERT INTO estados_civiles (estado_civil) VALUES ('SEPARADO');")
    cursor.execute("INSERT INTO estados_civiles (estado_civil) VALUES ('OTRO');")
    print("Seeding escolaridades...")
    cursor.execute("INSERT INTO escolaridades (escolaridad) VALUES ('NINGUNA');")
    cursor.execute("INSERT INTO escolaridades (escolaridad) VALUES ('JARDIN INFANTES');")
    cursor.execute("INSERT INTO escolaridades (escolaridad) VALUES ('PRIMARIA');")
    cursor.execute("INSERT INTO escolaridades (escolaridad) VALUES ('SECUNDARIA');")
    cursor.execute("INSERT INTO escolaridades (escolaridad) VALUES ('TERCIARIA');")
    cursor.execute("INSERT INTO escolaridades (escolaridad) VALUES ('UNIVERSITARIA');")
    print("Seeding vacunaciones...")
    cursor.execute("INSERT INTO vacunaciones (vacunacion) VALUES ('COMPLETA');")
    cursor.execute("INSERT INTO vacunaciones (vacunacion) VALUES ('INCOMPLETA');")
    cursor.execute("INSERT INTO vacunaciones (vacunacion) VALUES ('DESCONOCE');")
    print("Seeding etnias...")
    cursor.execute("INSERT INTO etnias (etnia) VALUES ('QUOM');")
    cursor.execute("INSERT INTO etnias (etnia) VALUES ('WICHI');")
    cursor.execute("INSERT INTO etnias (etnia) VALUES ('CRIOLLA');")
    cursor.execute("INSERT INTO etnias (etnia) VALUES ('OTRA');")
    print("Seeding enfermedades_familiares...")
    cursor.execute("INSERT INTO enfermedades_familiares (enfermedad_familiar) VALUES ('DIABETES');")
    cursor.execute("INSERT INTO enfermedades_familiares (enfermedad_familiar) VALUES ('HIPERTENSION');")
    cursor.execute("INSERT INTO enfermedades_familiares (enfermedad_familiar) VALUES ('CHAGAS');")
    cursor.execute("INSERT INTO enfermedades_familiares (enfermedad_familiar) VALUES ('HIDATISODIS');")
    cursor.execute("INSERT INTO enfermedades_familiares (enfermedad_familiar) VALUES ('TUBERCULOSIS');")
    cursor.execute("INSERT INTO enfermedades_familiares (enfermedad_familiar) VALUES ('OTROS');")
    connection.commit()
    print("Task 3.4: Successful")
except:
    print("Task 3.4: Failed")

print('Task 3.5: Migrating data from old tables to new ones...')

print("Task 3.5.1: Migrating paciente...")
try:
    querypaciente = "INSERT INTO paciente ( ID, nombre, apellido, dni, fecha_nac, sexo, paraje_atencion, flg_activo, fecha_alta, lugar_nac, etnia_id, ano_ingreso ) "
    querypaciente += "SELECT pb.ID, "
    querypaciente += "pb.nombre, "
    querypaciente += "pb.apellido, "
    querypaciente += "pb.dni, "
    querypaciente += "pb.fecha_nac, "
    querypaciente += "pb.sexo, "
    querypaciente += "pb.paraje_atencion, "
    querypaciente += "flg_activo, "
    querypaciente += "pb.fecha_alta, "
    querypaciente += "cb.lugar_nac, "
    querypaciente += "CASE "
    querypaciente += "	WHEN UPPER(cb.etnia)='QUOM' THEN 1 "
    querypaciente += "	WHEN UPPER(cb.etnia)='WICHI' THEN 2 "
    querypaciente += "	WHEN UPPER(cb.etnia)='CRIOLLA' THEN 3 "
    querypaciente += "	WHEN UPPER(cb.etnia)='CRIOLLO' THEN 3 "
    querypaciente += "	WHEN UPPER(cb.etnia)='OTRA' THEN 4 "
    querypaciente += "	WHEN UPPER(cb.etnia)='OTRO' THEN 4 "
    querypaciente += "	ELSE NULL "
    querypaciente += "END AS etnia, "
    querypaciente += "cb.ano_ingreso "
    querypaciente += "FROM paciente_bkp AS pb "
    querypaciente += "LEFT JOIN complementarios_bkp AS cb ON cb.paciente_id=pb.ID;"
    cursor.execute(querypaciente)
    connection.commit()
    print("Task 3.5.1: Successful")
except:
    print("Task 3.5.1: Failed")

print("Task 3.5.2: Migrating antecedentes...")
try:
    queryantecedentes = "INSERT INTO antecedentes ( ID, paciente_id, sedentarismo, alcohol, drogas, tabaco, alergias, dbt, hta, dislipemia, obesidad, chagas, hidatidosis, tbc, cancer, quirurgicos, riesgo_nut, riesgo_soc, personales, familiares, hospitalizaciones, ant_perinatales, vacunacion_id, medicacion, notas, fecha_creacion, last_update) "
    queryantecedentes += "SELECT "
    queryantecedentes += "ab.ID, "
    queryantecedentes += "ab.paciente_id, "
    queryantecedentes += "ab.sedentarismo, "
    queryantecedentes += "ab.alcohol, "
    queryantecedentes += "ab.drogas, "
    queryantecedentes += "ab.tabaco, "
    queryantecedentes += "ab.alergias, "
    queryantecedentes += "ab.dbt, "
    queryantecedentes += "ab.hta, "
    queryantecedentes += "ab.dislipemia, "
    queryantecedentes += "ab.obesidad, "
    queryantecedentes += "ab.chagas, "
    queryantecedentes += "ab.hidatidosis, "
    queryantecedentes += "ab.tbc, "
    queryantecedentes += "ab.cancer, "
    queryantecedentes += "ab.quirurgicos, "
    queryantecedentes += "ab.riesgo_nut, "
    queryantecedentes += "ab.riesgo_soc, "
    queryantecedentes += "ab.personales, "
    queryantecedentes += "ab.familiares, "
    queryantecedentes += "ab.hospitalizaciones, "
    queryantecedentes += "ab.ant_perinatales, "
    queryantecedentes += "3 AS vacunacion_id, "
    queryantecedentes += "ab.medicacion, "
    queryantecedentes += "ab.notas, "
    queryantecedentes += "ab.fecha_creacion, "
    queryantecedentes += "ab.last_update "
    queryantecedentes += "FROM antecedentes_bkp AS ab;"
    cursor.execute(queryantecedentes)
    connection.commit()
    print("Task 3.5.2: Successful")
except:
    print("Task 3.5.2: Failed")

print("Seeding tmp_fechas...")
try:
    # obtengo el rango de fechas a considerar
    fecha_inicial = datetime.strptime('2024-01-01', '%Y-%m-%d')
    fecha_actual = datetime.today()
    # Obtengo los ids de los pacientes
    cursor.execute('SELECT ID FROM paciente;')
    pacientes_ids = cursor.fetchall()


    # Iterar sobre cada día desde la fecha inicial hasta hoy
    fecha_actual_iterativa = fecha_inicial
    while fecha_actual_iterativa <= fecha_actual:
        for paciente_id in pacientes_ids:

            # Insertar la fecha en la tabla
            cursor.execute('''
            INSERT INTO tmp_fechas (fecha, paciente_id) VALUES (?, ?)
            ''', (fecha_actual_iterativa.strftime('%Y-%m-%d')+' 00:00:00', paciente_id[0]))
        
        # Incrementar la fecha en un día
        fecha_actual_iterativa += timedelta(days=1)

    # Guardar los cambios y cerrar la conexión
    print("Task 3.5.3: Migrating consulta...")
    queryconsultas = "INSERT INTO consulta ( paciente_id, fecha_atencion, motivo_consulta, edad_consulta, diagnostico_consulta, observacion, eval_nutric, eval_soc, fum, mac_actual, fecha_mac, fecha_creacion, last_update, examen_fisico, ta, peso, talla, imc, circ_cintura, circ_cadera, icc, saturacion, temperatura, glicemia, agudeza_der, agudeza_izq, ecografia, observacion_eco, ecg, observacion_ecg, radiografia, observacion_radiografia, laboratorio, observacion_lab, estudios_comp, diagnostico, tratamiento, derivacion_aguda, derivacion_prog, observacion_deriv, percentil_peso, pz_peso, percentil_talla, pz_talla, percentil_imc, pz_imc, pc, percentil_pc, pz_pc, gestas, para, cesareas, abortos, irs, menarca, ritmo_menst, menopausia, toma_pap, resultado_pap, colposcopia ) "
    queryconsultas += "SELECT "
    queryconsultas += "tf.paciente_id, "
    queryconsultas += "CASE "
    queryconsultas += "    WHEN cb.fecha_atencion IS NOT NULL THEN cb.fecha_atencion "
    queryconsultas += "    ELSE tf.fecha "
    queryconsultas += "END AS fecha_atencion, "
    queryconsultas += "cb.motivo_consulta, "
    queryconsultas += "cb.edad_consulta, "
    queryconsultas += "cb.diagnostico_consulta, "
    queryconsultas += "cb.observacion, "
    queryconsultas += "cb.eval_nutric, "
    queryconsultas += "cb.eval_soc, "
    queryconsultas += "cb.fum, "
    queryconsultas += "cb.mac_actual, "
    queryconsultas += "cb.fecha_mac, "
    queryconsultas += "CASE "
    queryconsultas += "    WHEN cb.fecha_creacion IS NOT NULL THEN cb.fecha_creacion "
    queryconsultas += "    ELSE tf.fecha "
    queryconsultas += "END AS fecha_creacion, "
    queryconsultas += "cb.last_update, "
    queryconsultas += "hb.examen_fisico, "
    queryconsultas += "hb.ta, "
    queryconsultas += "CASE "
    queryconsultas += "    WHEN pb.peso IS NOT NULL THEN pb.peso "
    queryconsultas += "    WHEN hb.peso IS NOT NULL THEN hb.peso "
    queryconsultas += "    ELSE NULL "
    queryconsultas += "END as peso, "
    queryconsultas += "CASE "
    queryconsultas += "    WHEN pb.talla IS NOT NULL THEN pb.talla "
    queryconsultas += "    WHEN hb.talla IS NOT NULL THEN hb.talla "
    queryconsultas += "    ELSE NULL "
    queryconsultas += "END as talla, "
    queryconsultas += "CASE "
    queryconsultas += "    WHEN pb.imc IS NOT NULL THEN pb.imc "
    queryconsultas += "    WHEN hb.imc IS NOT NULL THEN hb.imc "
    queryconsultas += "    ELSE NULL "
    queryconsultas += "END as imc, "
    queryconsultas += "hb.circ_cintura, "
    queryconsultas += "hb.circ_cadera, "
    queryconsultas += "hb.icc, "
    queryconsultas += "hb.saturacion, "
    queryconsultas += "hb.temperatura, "
    queryconsultas += "hb.glicemia, "
    queryconsultas += "hb.agudeza_der, "
    queryconsultas += "hb.agudeza_izq, "
    queryconsultas += "hb.ecografia, "
    queryconsultas += "hb.observacion_eco, "
    queryconsultas += "hb.ecg, "
    queryconsultas += "hb.observacion_ecg, "
    queryconsultas += "hb.radiografia, "
    queryconsultas += "hb.observacion_radiografia, "
    queryconsultas += "hb.laboratorio, "
    queryconsultas += "hb.observacion_lab, "
    queryconsultas += "hb.estudios_comp, "
    queryconsultas += "hb.diagnostico, "
    queryconsultas += "hb.tratamiento, "
    queryconsultas += "hb.derivacion_aguda, "
    queryconsultas += "hb.derivacion_prog, "
    queryconsultas += "hb.observacion_deriv, "
    queryconsultas += "pb.percentil_peso, "
    queryconsultas += "pb.pz_peso, "
    queryconsultas += "pb.percentil_talla, "
    queryconsultas += "pb.pz_talla, "
    queryconsultas += "pb.percentil_imc, "
    queryconsultas += "pb.pz_imc, "
    queryconsultas += "pb.pc, "
    queryconsultas += "pb.percentil_pc, "
    queryconsultas += "pb.pz_pc, "
    queryconsultas += "gb.gestas, "
    queryconsultas += "gb.para, "
    queryconsultas += "gb.cesareas, "
    queryconsultas += "gb.abortos, "
    queryconsultas += "gb.irs, "
    queryconsultas += "gb.menarca, "
    queryconsultas += "gb.ritmo_menst, "
    queryconsultas += "gb.menopausia, "
    queryconsultas += "gb.toma_pap, "
    queryconsultas += "gb.resultado_pap, "
    queryconsultas += "gb.colposcopia "

    queryconsultas += "FROM tmp_fechas AS tf  "
    queryconsultas += "LEFT JOIN consulta_bkp AS cb ON cb.paciente_id=tf.paciente_id AND cb.fecha_creacion=tf.fecha "
    queryconsultas += "LEFT JOIN historia_bkp AS hb ON hb.paciente_id=tf.paciente_id AND  hb.fecha_creacion=tf.fecha "
    queryconsultas += "LEFT JOIN pediatria_bkp AS pb ON pb.paciente_id=tf.paciente_id AND pb.fecha_creacion=tf.fecha "
    queryconsultas += "LEFT JOIN ginecologia_bkp AS gb ON gb.paciente_id=tf.paciente_id AND gb.fecha_creacion=tf.fecha "

    queryconsultas += "WHERE cb.paciente_id IS NOT NULL "
    queryconsultas += "OR hb.paciente_id IS NOT NULL "
    queryconsultas += "OR pb.paciente_id IS NOT NULL "
    queryconsultas += "OR gb.paciente_id IS NOT NULL "

    cursor.execute(queryconsultas)
    connection.commit()
    print("Task 3.5.3: Successful")
except:
    print("Task 3.5.3: Failed")

print('Task 3.6: Deleting temp tables...')

try:
    cursor.execute("DROP TABLE tmp_fechas;")
    connection.commit()
    print("Task 3.6: Successful")
except:
    print("Task 3.6: Failed")

connection.close()

print("Connection closed")
print("ALL DONE!")