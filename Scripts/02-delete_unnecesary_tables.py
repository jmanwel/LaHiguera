import sqlite3

dbsource = input("Ingrese la ubicacion de la base de datos de origen: ")
if dbsource == "":
    dbsource = "../Entidades/lahiguera.db"

connection = sqlite3.connect(dbsource)
cursor = connection.cursor()

print("DB opened database successfully")
print('Task 1: Deletting unused tables...')

try:
    cursor.execute("DROP TABLE antecedentes_bkp;")
    cursor.execute("DROP TABLE complementarios_bkp;")
    cursor.execute("DROP TABLE consulta_bkp;")
    cursor.execute("DROP TABLE ginecologia_bkp;")
    cursor.execute("DROP TABLE historia_bkp;")
    cursor.execute("DROP TABLE paciente_bkp;")
    cursor.execute("DROP TABLE pediatria_bkp;")
    connection.commit()
    print("Task 1: Successful")
except:
    print("Task 1: Failed")

connection.close()

print("Connection closed")
print("ALL DONE!")
