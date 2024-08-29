import sys, sqlite3

PATH = ""

db1 = "../Entidades/lahiguera.db"
db2 = f"{PATH}DB_PC_2\\lahiguera.db"

fields_consulta = ('ID', 'paciente_id', 'fecha_atencion', 'motivo_consulta', 'edad_consulta', 'frecuencia_cardiaca', 'frecuencia_respiratoria', 'diagnostico_consulta', 'observacion', 'eval_nutric', 'eval_soc', 'fum', 'mac_actual', 'fecha_mac', 'fecha_creacion', 'examen_fisico', 'ta', 'peso', 'talla', 'imc', 'circ_cintura', 'circ_cadera', 'icc', 'saturacion', 'temperatura', 'glicemia', 'agudeza_der', 'agudeza_izq', 'ecografia', 'observacion_eco', 'ecg', 'observacion_ecg', 'radiografia', 'observacion_radiografia', 'laboratorio', 'observacion_lab', 'estudios_comp', 'tratamiento', 'derivacion_aguda', 'derivacion_prog', 'observacion_deriv', 'percentil_peso', 'pz_peso', 'percentil_talla', 'pz_talla', 'percentil_imc', 'pz_imc', 'pc', 'percentil_pc', 'pz_pc', 'gestas', 'para', 'cesareas', 'abortos', 'irs', 'menarca', 'ritmo_menst', 'menopausia', 'toma_pap', 'resultado_pap', 'colposcopia', 'last_update')
fields_antecedentes = ('ID', 'paciente_id', 'sedentarismo', 'alcohol', 'drogas', 'tabaco', 'alergias', 'dbt', 'hta', 'dislipemia', 'obesidad', 'chagas', 'hidatidosis', 'tbc', 'cancer', 'quirurgicos', 'riesgo_nut', 'riesgo_soc', 'personales', 'familiares', 'hospitalizaciones', 'ant_perinatales', 'vacunacion_id', 'medicacion', 'notas', 'fecha_creacion', 'last_update')
fields_complementarios = ('ID', 'paciente_id', 'paraje_residencia', 'estado_civil_id', 'sabe_leer', 'escolaridad_id', 'escolaridad_completa', 'ocupacion', 'notas', 'fecha_creacion', 'last_update')
fields_paciente = ('ID', 'nombre', 'apellido', 'dni', 'fecha_nac', 'sexo', 'paraje_atencion', 'flg_activo', 'fecha_alta', 'lugar_nac', 'etnia_id', 'ano_ingreso', 'last_update')

LIST_TABLE = [{"table_name": "consulta", "table_fields":fields_consulta},
              {"table_name": "antecedentes", "table_fields":fields_antecedentes},
              {"table_name": "complementarios", "table_fields":fields_complementarios},
              {"table_name": "paciente", "table_fields":fields_paciente}]

cona = sqlite3.connect(db1)
conb = sqlite3.connect(db2)
cursor_a = cona.cursor()
cursor_b = conb.cursor()


def check_tables_are_equal(t1, t2) ->int:
    if t1 == t2:
        return 0
    return 1


def insert_row_in_table(cursor, con, name, fields, str_question, values) -> dict:
    cursor.execute(f"INSERT INTO { name } { fields } VALUES ({ str_question });", values)
    con.commit()
    if cursor.rowcount == 1:
        return { "result": 0, "msg": "Row inserted succesfully" }
    return { "result": 1, "msg": "Something went wrong" }


def update_row_in_table(cursor, con, name, fields, id, values) -> dict:
    cursor.execute(f"UPDATE { name } SET { fields } WHERE ID = { id };", values)
    con.commit()
    if cursor.rowcount == 1:
        return { "result": 0, "msg": "Row updated succesfully" }
    return { "result": 1, "msg": "Something went wrong" }


def fetch_all_rows_in_table(cursor, fields, name):
    return cursor.execute(f"SELECT { fields } FROM { name };").fetchall()


for i in LIST_TABLE:
    print(f"WORKING WITH TABLE { i['table_name'] }...")
    select = str( [ f"{x}" for x in i['table_fields'] ] ).replace("[","").replace("]","").replace("'","")
    print("PRE-CHECK")
    db1_table_precheck = fetch_all_rows_in_table(cursor_a, select, i['table_name'])
    db2_table_precheck = fetch_all_rows_in_table(cursor_b, select, i['table_name'])
    if check_tables_are_equal(db1_table_precheck, db2_table_precheck) == 0:
        print("Both tables, have the same data, nothing to do here.")
    else:
        print("work with tables")
        
        list_question = str("?,"*len( i['table_fields']) )[:-1]
        l = str( [ f"{x}=?" for x in i['table_fields'] ] ).replace("[","").replace("]","").replace("'","")
        table_fields = str( i['table_fields'] ).replace("'", "")
        try:
            for h in db1_table_precheck:
                tuple_values_a = tuple( [value for value in h] )
                query_table_db2 = cursor_b.execute(f"SELECT { select } FROM { i['table_name'] } WHERE ID = { h[0] };").fetchall()
                if len(query_table_db2) == 0:
                    print("Insert row in db_b table")
                    insert_row_in_table(cursor_b, conb, i['table_name'], table_fields, list_question, tuple_values_a)
                else:
                    resb = query_table_db2[0]
                if h != resb:
                    if h[-1] < resb[-1]:
                        print("Updating row in db_a with db_b values")               
                        tuple_values_b = tuple( [value for value in resb] )
                        update_row_in_table(cursor_a, cona, i['table_name'], l, h[0], tuple_values_b)
            print("SWITCHING DB")
            print("CLEANUP")
            tuple_values_a = ""
            tuple_values_b = ""
            for k in db2_table_precheck:
                tuple_values_b = tuple( [value for value in k] )
                query_table_db1 = cursor_a.execute(f"SELECT { select } FROM { i['table_name'] } WHERE ID = { k[0] };").fetchall()
                if len(query_table_db1) == 0:
                    print("Inserting row in db_a table")
                    insert_row_in_table(cursor_a, cona, i['table_name'], table_fields, list_question, tuple_values_a)
                else:
                    resa_2 = query_table_db1[0]
                if k != resa_2:
                    if k[-1] < resa_2[-1]:
                        print("Updating row in db_b with db_a values")               
                        tuple_values_a = tuple( [field for field in resa_2] )
                        update_row_in_table(cursor_b, conb, i['table_name'], l, k[0], tuple_values_a)
            print("POST CHECK")
            db1_table_postcheck = fetch_all_rows_in_table(cursor_a, select, i['table_name'])
            db2_table_postcheck = fetch_all_rows_in_table(cursor_b, select, i['table_name'])
            if check_tables_are_equal(db1_table_postcheck, db2_table_postcheck) == 0:
                print(f"Merge table: { i['table_name'] } Successful!\n")
            else:
                print(f"ERROR!: Merge table: { i['table_name'] } Failed")
        except sqlite3.OperationalError as e:
            print(f"ERROR!: Merge Failed => { e }")
    print("===================================================\n")

print("Closing connections")
cona.close()
conb.close()