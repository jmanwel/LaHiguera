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


connection.close()

print("Connection closed")
print("ALL DONE!")
