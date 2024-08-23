import sqlite3
from datetime import datetime

dbsource = input("Ingrese la ubicacion de la base de datos de origen: ")
if dbsource == "":
    dbsource = "../Entidades/lahiguera.db"

connection = sqlite3.connect(dbsource)
cursor = connection.cursor()

print("DB opened database successfully")
print('Task 1: Adding new fields to tables...')

try:
    cursor.execute("ALTER TABLE consulta ADD COLUMN frecuencia_cardiaca INTEGER;")
    cursor.execute("ALTER TABLE consulta ADD COLUMN frecuencia_respiratoria INTEGER;")
    cursor.execute("ALTER TABLE paciente ADD COLUMN fecha_creacion DATETIME;")
    cursor.execute("ALTER TABLE paciente ADD COLUMN last_update DATETIME;")
    connection.commit()
    print("Task 1: "+"\033[1;30;42m"+" Successful "+'\033[0;m')
except:
    print("Task 1: "+"\033[1;37;41m"+" Failed "+'\033[0;m')

print('Task 2: updating new dates fields in paciente...')

try:
    # Obtenemos la fecha y hora actual en el formato correcto
    fecha_actual = datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')[:-3]

    cursor.execute("UPDATE paciente SET fecha_creacion = ?, last_update = ?;", (fecha_actual, fecha_actual))
    connection.commit()
    print("Task 2: "+"\033[1;30;42m"+" Successful "+'\033[0;m')
except:
    print("Task 2: "+"\033[1;37;41m"+" Failed "+'\033[0;m')

connection.close()

print("Connection closed")
print("\033[1;30;42m"+" ALL DONE! "+'\033[0;m')