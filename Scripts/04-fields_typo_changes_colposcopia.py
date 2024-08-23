import sqlite3

dbsource = input("Ingrese la ubicacion de la base de datos de origen: ")
if dbsource == "":
    dbsource = "../Entidades/lahiguera.db"

connection = sqlite3.connect(dbsource)
cursor = connection.cursor()

print("DB opened database successfully")
print('Task 1: Creating new tables...')

try:
    cursor.execute("CREATE TABLE consulta_new ( ID INTEGER PRIMARY KEY AUTOINCREMENT, paciente_id INTEGER, fecha_atencion DATE, motivo_consulta TEXT, edad_consulta INTEGER, diagnostico_consulta TEXT, observacion TEXT, eval_nutric TEXT, eval_soc TEXT, fum DATE, mac_actual TEXT, fecha_mac TEXT, fecha_creacion DATETIME, last_update DATETIME, examen_fisico TEXT, ta TEXT, peso REAL, talla REAL, imc REAL, circ_cintura INTEGER, circ_cadera INTEGER, icc INTEGER, saturacion INTEGER, temperatura REAL, glicemia INTEGER, agudeza_der TEXT, agudeza_izq TEXT, ecografia INTEGER, observacion_eco TEXT, ecg INTEGER, observacion_ecg TEXT, radiografia INTEGER, observacion_radiografia TEXT, laboratorio INTEGER, observacion_lab TEXT, estudios_comp TEXT, diagnostico TEXT, tratamiento TEXT, derivacion_aguda INTEGER, derivacion_prog INTEGER, observacion_deriv TEXT, percentil_peso REAL, pz_peso REAL, percentil_talla REAL, pz_talla REAL, percentil_imc REAL, pz_imc REAL, pc REAL, percentil_pc REAL, pz_pc REAL, gestas INTEGER, para INTEGER, cesareas INTEGER, abortos INTEGER, irs INTEGER, menarca INTEGER, ritmo_menst TEXT, menopausia INTEGER, toma_pap INTEGER, resultado_pap TEXT, colposcopia TEXT );")
    connection.commit()
    print("Task 1: Successful")
except:
    print("Task 1: Failed")


print('Task 2: Copying data from old table to new table...')

try:
    queryInsertConsultaNew = "INSERT INTO consulta_new ( "
    queryInsertConsultaNew += " ID, "
    queryInsertConsultaNew += " paciente_id, "
    queryInsertConsultaNew += " fecha_atencion, "
    queryInsertConsultaNew += " motivo_consulta, "
    queryInsertConsultaNew += " edad_consulta, "
    queryInsertConsultaNew += " diagnostico_consulta, "
    queryInsertConsultaNew += " observacion, "
    queryInsertConsultaNew += " eval_nutric, "
    queryInsertConsultaNew += " eval_soc, "
    queryInsertConsultaNew += " fum, "
    queryInsertConsultaNew += " mac_actual, "
    queryInsertConsultaNew += " fecha_mac, "
    queryInsertConsultaNew += " fecha_creacion, "
    queryInsertConsultaNew += " last_update, "
    queryInsertConsultaNew += " examen_fisico, "
    queryInsertConsultaNew += " ta, "
    queryInsertConsultaNew += " peso, "
    queryInsertConsultaNew += " talla, "
    queryInsertConsultaNew += " imc, "
    queryInsertConsultaNew += " circ_cintura, "
    queryInsertConsultaNew += " circ_cadera, "
    queryInsertConsultaNew += " icc, "
    queryInsertConsultaNew += " saturacion, "
    queryInsertConsultaNew += " temperatura, "
    queryInsertConsultaNew += " glicemia, "
    queryInsertConsultaNew += " agudeza_der, "
    queryInsertConsultaNew += " agudeza_izq, "
    queryInsertConsultaNew += " ecografia, "
    queryInsertConsultaNew += " observacion_eco, "
    queryInsertConsultaNew += " ecg, "
    queryInsertConsultaNew += " observacion_ecg, "
    queryInsertConsultaNew += " radiografia, "
    queryInsertConsultaNew += " observacion_radiografia, "
    queryInsertConsultaNew += " laboratorio, "
    queryInsertConsultaNew += " observacion_lab, "
    queryInsertConsultaNew += " estudios_comp, "
    queryInsertConsultaNew += " diagnostico, "
    queryInsertConsultaNew += " tratamiento, "
    queryInsertConsultaNew += " derivacion_aguda, "
    queryInsertConsultaNew += " derivacion_prog, "
    queryInsertConsultaNew += " observacion_deriv, "
    queryInsertConsultaNew += " percentil_peso, "
    queryInsertConsultaNew += " pz_peso, "
    queryInsertConsultaNew += " percentil_talla, "
    queryInsertConsultaNew += " pz_talla, "
    queryInsertConsultaNew += " percentil_imc, "
    queryInsertConsultaNew += " pz_imc, "
    queryInsertConsultaNew += " pc, "
    queryInsertConsultaNew += " percentil_pc, "
    queryInsertConsultaNew += " pz_pc, "
    queryInsertConsultaNew += " gestas, "
    queryInsertConsultaNew += " para, "
    queryInsertConsultaNew += " cesareas, "
    queryInsertConsultaNew += " abortos, "
    queryInsertConsultaNew += " irs, "
    queryInsertConsultaNew += " menarca, "
    queryInsertConsultaNew += " ritmo_menst, "
    queryInsertConsultaNew += " menopausia, "
    queryInsertConsultaNew += " toma_pap, "
    queryInsertConsultaNew += " resultado_pap, "
    queryInsertConsultaNew += " colposcopia  "
    queryInsertConsultaNew += ") "
    queryInsertConsultaNew += "SELECT ID, "
    queryInsertConsultaNew += "paciente_id, "
    queryInsertConsultaNew += "fecha_atencion, "
    queryInsertConsultaNew += "motivo_consulta, "
    queryInsertConsultaNew += "edad_consulta, "
    queryInsertConsultaNew += "diagnostico_consulta, "
    queryInsertConsultaNew += "observacion, "
    queryInsertConsultaNew += "eval_nutric, "
    queryInsertConsultaNew += "eval_soc, "
    queryInsertConsultaNew += "fum, "
    queryInsertConsultaNew += "mac_actual, "
    queryInsertConsultaNew += "fecha_mac, "
    queryInsertConsultaNew += "fecha_creacion, "
    queryInsertConsultaNew += "last_update, "
    queryInsertConsultaNew += "examen_fisico, "
    queryInsertConsultaNew += "ta, "
    queryInsertConsultaNew += "peso, "
    queryInsertConsultaNew += "talla, "
    queryInsertConsultaNew += "imc, "
    queryInsertConsultaNew += "circ_cintura, "
    queryInsertConsultaNew += "circ_cadera, "
    queryInsertConsultaNew += "icc, "
    queryInsertConsultaNew += "saturacion, "
    queryInsertConsultaNew += "temperatura, "
    queryInsertConsultaNew += "glicemia, "
    queryInsertConsultaNew += "agudeza_der, "
    queryInsertConsultaNew += "agudeza_izq, "
    queryInsertConsultaNew += "ecografia, "
    queryInsertConsultaNew += "observacion_eco, "
    queryInsertConsultaNew += "ecg, "
    queryInsertConsultaNew += "observacion_ecg, "
    queryInsertConsultaNew += "radiografia, "
    queryInsertConsultaNew += "observacion_radiografia, "
    queryInsertConsultaNew += "laboratorio, "
    queryInsertConsultaNew += "observacion_lab, "
    queryInsertConsultaNew += "estudios_comp, "
    queryInsertConsultaNew += "diagnostico, "
    queryInsertConsultaNew += "tratamiento, "
    queryInsertConsultaNew += "derivacion_aguda, "
    queryInsertConsultaNew += "derivacion_prog, "
    queryInsertConsultaNew += "observacion_deriv, "
    queryInsertConsultaNew += "percentil_peso, "
    queryInsertConsultaNew += "pz_peso, "
    queryInsertConsultaNew += "percentil_talla, "
    queryInsertConsultaNew += "pz_talla, "
    queryInsertConsultaNew += "percentil_imc, "
    queryInsertConsultaNew += "pz_imc, "
    queryInsertConsultaNew += "pc, "
    queryInsertConsultaNew += "percentil_pc, "
    queryInsertConsultaNew += "pz_pc, "
    queryInsertConsultaNew += "gestas, "
    queryInsertConsultaNew += "para, "
    queryInsertConsultaNew += "cesareas, "
    queryInsertConsultaNew += "abortos, "
    queryInsertConsultaNew += "irs, "
    queryInsertConsultaNew += "menarca, "
    queryInsertConsultaNew += "ritmo_menst, "
    queryInsertConsultaNew += "menopausia, "
    queryInsertConsultaNew += "toma_pap, "
    queryInsertConsultaNew += "resultado_pap, "
    queryInsertConsultaNew += "CASE "
    queryInsertConsultaNew += "    WHEN (colposcopia)=1 THEN 'SI' "
    queryInsertConsultaNew += "    WHEN (colposcopia)=0 THEN 'NO' "
    queryInsertConsultaNew += "    ELSE NULL "
    queryInsertConsultaNew += "END AS colposcopia "
    queryInsertConsultaNew += "FROM consulta;"

    cursor.execute(queryInsertConsultaNew)
    connection.commit()
    print("Task 2: Successful")
except:
    print("Task 2: Failed")

print('Task 3: Deleting old table...')

try:
    cursor.execute("DROP TABLE consulta;")
    connection.commit()
    print("Task 3: Successful")
except:
    print("Task 3: Failed")

print('Task 4: Renaming new table...')

try:
    cursor.execute("ALTER TABLE consulta_new RENAME TO consulta;")
    connection.commit()
    print("Task 4: Successful")
except:
    print("Task 4: Failed")

connection.close()

print("Connection closed")
print("ALL DONE!")