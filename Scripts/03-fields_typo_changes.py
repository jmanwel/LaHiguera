import sqlite3

dbsource = input("Ingrese la ubicacion de la base de datos de origen: ")
if dbsource == "":
    dbsource = "../Entidades/lahiguera.db"

connection = sqlite3.connect(dbsource)
cursor = connection.cursor()

print("DB opened database successfully")
print('Task 1: Creating new tables...')

try:
    cursor.execute("CREATE TABLE 'paciente_new' ( ID INTEGER PRIMARY KEY AUTOINCREMENT, nombre TEXT, apellido TEXT, dni INTEGER, fecha_nac DATE, sexo TEXT, paraje_atencion TEXT, flg_activo INTEGER, fecha_alta DATE, lugar_nac TEXT, etnia_id INTEGER, ano_ingreso INTEGER );")
    connection.commit()
    print("Task 1: Successful")
except:
    print("Task 1: Failed")

print('Task 2: Copying data from old table to new table...')

try:
    cursor.execute("INSERT INTO paciente_new (ID, nombre, apellido, dni, fecha_nac, sexo, paraje_atencion, flg_activo, fecha_alta, lugar_nac, etnia_id, ano_ingreso) SELECT ID, nombre, apellido, dni, fecha_nac, sexo, paraje_atencion, flg_activo, DATE(fecha_alta), lugar_nac, etnia_id, ano_ingreso FROM paciente;")
    connection.commit()
    print("Task 2: Successful")
except:
    print("Task 2: Failed")

print('Task 3: Deleting old table...')

try:
    cursor.execute("DROP TABLE paciente;")
    connection.commit()
    print("Task 3: Successful")
except:
    print("Task 3: Failed")

print('Task 4: Renaming new table...')

try:
    cursor.execute("ALTER TABLE paciente_new RENAME TO paciente;")
    connection.commit()
    print("Task 4: Successful")
except:
    print("Task 4: Failed")

print('Task 5: Changing dates formats in tables...')

try:
    print("Updating antecedentes.fecha_creacion...")
    queryantecedentesfcreacion = "UPDATE antecedentes "
    queryantecedentesfcreacion += "SET fecha_creacion = "
    queryantecedentesfcreacion += "    substr(substr(fecha_creacion,instr(fecha_creacion,'/')+1), instr(substr(fecha_creacion,instr(fecha_creacion,'/')+1),'/')+1) || '-' ||  "
    queryantecedentesfcreacion += "    SUBSTR('00' || TRIM(SUBSTR(fecha_creacion, INSTR(fecha_creacion, '/') + 1, INSTR(SUBSTR(fecha_creacion, INSTR(fecha_creacion, '/') + 1), '/') - 1)), -2) || '-' ||  "
    queryantecedentesfcreacion += "    SUBSTR('00' || TRIM(SUBSTR(fecha_creacion, 1, INSTR(fecha_creacion, '/') - 1)), -2) || ' 00:00:00.000000' "
    queryantecedentesfcreacion += "WHERE fecha_creacion LIKE '%/%/%';"

    cursor.execute(queryantecedentesfcreacion)

    print("Updating antecedentes.last_update...")
    queryantecedenteslupdate = "UPDATE antecedentes "
    queryantecedenteslupdate += "SET last_update = "
    queryantecedenteslupdate += "    substr(substr(last_update,instr(last_update,'/')+1), instr(substr(last_update,instr(last_update,'/')+1),'/')+1) || '-' ||  "
    queryantecedenteslupdate += "    SUBSTR('00' || TRIM(SUBSTR(last_update, INSTR(last_update, '/') + 1, INSTR(SUBSTR(last_update, INSTR(last_update, '/') + 1), '/') - 1)), -2) || '-' ||  "
    queryantecedenteslupdate += "    SUBSTR('00' || TRIM(SUBSTR(last_update, 1, INSTR(last_update, '/') - 1)), -2) || ' 00:00:00.000000' "
    queryantecedenteslupdate += "WHERE last_update LIKE '%/%/%';"

    cursor.execute(queryantecedenteslupdate)

    print("Updating consulta.fecha_atencion...")
    queryconsultafatencion = "UPDATE consulta "
    queryconsultafatencion += "SET fecha_atencion = substr(fecha_atencion,1,instr(fecha_atencion,' ')-1) "
    queryconsultafatencion += "WHERE length(fecha_atencion)>10;"

    cursor.execute(queryconsultafatencion)

    connection.commit()
    print("Task 5: Successful")
except:
    print("Task 5: Failed")


connection.close()

print("Connection closed")
print("ALL DONE!")
