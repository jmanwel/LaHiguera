BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "paciente" (
	"ID"	INTEGER,
	"nombre"	TEXT,
	"apellido"	TEXT,
	"dni"	INTEGER,
	"fecha_nac"	DATE,
	"sexo"	TEXT,
	"paraje_atencion"	TEXT,
	"flg_activo"	INTEGER,
	"fecha_alta"	DATETIME,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "antecedentes" (
	"ID"	INTEGER,
	"paciente_id"	INTEGER,
	"sedentarismo"	INTEGER,
	"alcohol"	INTEGER,
	"drogas"	INTEGER,
	"tabaco"	INTEGER,
	"alergias"	INTEGER,
	"dbt"	INTEGER,
	"hta"	INTEGER,
	"displemia"	INTEGER,
	"obesidad"	INTEGER,
	"chagas"	INTEGER,
	"hidatidosis"	INTEGER,
	"tbc"	INTEGER,
	"cancer"	INTEGER,
	"quirurgicos"	INTEGER,
	"riesgo_nut"	INTEGER,
	"riesgo_soc"	INTEGER,
	"personales"	INTEGER,
	"familiares"	INTEGER,
	"hospitalizaciones"	INTEGER,
	"ant_perinatales"	INTEGER,
	"vacunacion"	INTEGER,
	"medicacion"	INTEGER,
	"notas"	TEXT,
	"fecha_creacion"	DATETIME,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "app_log" (
	"ID"	INTEGER,
	"timestamp"	DATETIME,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "complementarios" (
	"ID"	INTEGER,
	"paciente_id"	INTEGER,
	"lugar_nac"	TEXT,
	"paraje_residencia"	TEXT,
	"etnia"	TEXT,
	"estado_civil"	TEXT,
	"sabe_leer"	INTEGER,
	"escolaridad"	TEXT,
	"ocupacion"	TEXT,
	"ano_ingreso"	INTEGER,
	"notas"	TEXT,
	"fecha_creacion"	DATETIME,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "ginecologia" (
	"ID"	INTEGER,
	"paciente_id"	INTEGER,
	"gestas"	INTEGER,
	"para"	INTEGER,
	"cesareas"	INTEGER,
	"abortos"	INTEGER,
	"irs"	INTEGER,
	"menarca"	INTEGER,
	"ritmo_menst"	TEXT,
	"menopausia"	INTEGER,
	"toma_pap"	INTEGER,
	"resultado_pap"	TEXT,
	"colposcopia"	INTEGER,
	"estudios_comp"	TEXT,
	"fecha_creacion"	DATETIME,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "historia" (
	"ID"	INTEGER,
	"paciente_id"	INTEGER,
	"examen_fisico"	TEXT,
	"ta"	TEXT,
	"peso"	INTEGER,
	"talla"	INTEGER,
	"imc"	INTEGER,
	"circ_cintura"	INTEGER,
	"circ_cadera"	INTEGER,
	"icc"	INTEGER,
	"saturacion"	INTEGER,
	"temperatura"	INTEGER,
	"glicemia"	INTEGER,
	"agudeza_der"	TEXT,
	"agudeza_izq"	TEXT,
	"ecografia"	INTEGER,
	"observacion_eco"	TEXT,
	"ecg"	INTEGER,
	"observacion_ecg"	TEXT,
	"radiografia"	INTEGER,
	"observacion_radiografia"	TEXT,
	"laboratorio"	INTEGER,
	"observacion_lab"	TEXT,
	"estudios_comp"	TEXT,
	"diagnostico"	TEXT,
	"tratamiento"	TEXT,
	"derivacion_aguda"	INTEGER,
	"derivacion_prog"	INTEGER,
	"observacion_deriv"	TEXT,
	"fecha_creacion"	datetime,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "pediatria" (
	"ID"	INTEGER,
	"paciente_id"	INTEGER,
	"peso"	REAL,
	"percentil_peso"	REAL,
	"pz_peso"	REAL,
	"talla"	REAL,
	"percentil_talla"	REAL,
	"pz_talla"	REAL,
	"imc"	REAL,
	"percentil_imc"	REAL,
	"pz_imc"	REAL,
	"pc"	REAL,
	"percentil_pc"	REAL,
	"pz_pc"	REAL,
	"agudeza_der"	TEXT,
	"agudeza_izq"	TEXT,
	"fecha_creacion"	DATETIME,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "consulta" (
	"ID"	INTEGER,
	"paciente_id"	INTEGER,
	"fecha_atencion"	DATE,
	"motivo_consulta"	TEXT,
	"edad_consulta"	INTEGER,
	"diagnostico_consulta"	TEXT,
	"observacion"	TEXT,
	"eval_nutric"	TEXT,
	"eval_soc"	TEXT,
	"fum"	DATE,
	"mac_actual"	TEXT,
	"fecha_mac"	TEXT,
	"fecha_creacion"	DATETIME,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
INSERT INTO "paciente" ("ID","nombre","apellido","dni","fecha_nac","sexo","paraje_atencion","flg_activo","fecha_alta") VALUES (1,'Juan','Perez',32617456,'1986-09-14','Masculino','Paraje 4',1,'2024-02-06 00:00:00');
INSERT INTO "paciente" ("ID","nombre","apellido","dni","fecha_nac","sexo","paraje_atencion","flg_activo","fecha_alta") VALUES (2,'Maria','Gonzalez',38784216,'1992-10-02','Femenino','Paraje 2',1,'2024-02-06 17:17:10');
INSERT INTO "paciente" ("ID","nombre","apellido","dni","fecha_nac","sexo","paraje_atencion","flg_activo","fecha_alta") VALUES (3,'Benicio','Paz',53415983,'2013-09-24','Masculino','Paraje 1',1,'2024-02-06 17:17:10');
INSERT INTO "paciente" ("ID","nombre","apellido","dni","fecha_nac","sexo","paraje_atencion","flg_activo","fecha_alta") VALUES (4,'Gabriela','Sanchez',12935243,'1957-05-01','Femenino','Paraje 1',1,'2024-02-06 17:17:10');
INSERT INTO "paciente" ("ID","nombre","apellido","dni","fecha_nac","sexo","paraje_atencion","flg_activo","fecha_alta") VALUES (5,'Camila','Alvarez',63487561,'2023-12-12','Femenino','Paraje 2',1,'2024-02-06 17:17:10');
INSERT INTO "paciente" ("ID","nombre","apellido","dni","fecha_nac","sexo","paraje_atencion","flg_activo","fecha_alta") VALUES (6,'Roberto','Cáceres',NULL,'1944-09-05','Masculino','Paraje 2',1,'2024-02-08 17:17:24');
INSERT INTO "paciente" ("ID","nombre","apellido","dni","fecha_nac","sexo","paraje_atencion","flg_activo","fecha_alta") VALUES (7,'Patricia','Suarez',30781423,'1984-02-29','Femenino','Paraje 1',0,'2024-02-08 17:17:24');
INSERT INTO "paciente" ("ID","nombre","apellido","dni","fecha_nac","sexo","paraje_atencion","flg_activo","fecha_alta") VALUES (8,'Raúl','Bernuncio',21430993,'1971-02-17','Masculino','Paraje 5',1,'2024-02-19 15:09:54.9382952');
INSERT INTO "paciente" ("ID","nombre","apellido","dni","fecha_nac","sexo","paraje_atencion","flg_activo","fecha_alta") VALUES (9,'Elena','Perez',14430993,'1963-02-17','Femenino','Paraje 3',1,'2024-02-19 15:12:27.1187745');
INSERT INTO "antecedentes" ("ID","paciente_id","sedentarismo","alcohol","drogas","tabaco","alergias","dbt","hta","displemia","obesidad","chagas","hidatidosis","tbc","cancer","quirurgicos","riesgo_nut","riesgo_soc","personales","familiares","hospitalizaciones","ant_perinatales","vacunacion","medicacion","notas","fecha_creacion") VALUES (1,1,'No','Si','No','Si','No','No','No','No','Si','No','No','No','No','No',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'23/11/2023');
INSERT INTO "antecedentes" ("ID","paciente_id","sedentarismo","alcohol","drogas","tabaco","alergias","dbt","hta","displemia","obesidad","chagas","hidatidosis","tbc","cancer","quirurgicos","riesgo_nut","riesgo_soc","personales","familiares","hospitalizaciones","ant_perinatales","vacunacion","medicacion","notas","fecha_creacion") VALUES (2,3,'Si','No','Si','No','No',NULL,NULL,NULL,'No',NULL,NULL,NULL,NULL,'Si',NULL,'Bajo',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'15/12/2023');
INSERT INTO "antecedentes" ("ID","paciente_id","sedentarismo","alcohol","drogas","tabaco","alergias","dbt","hta","displemia","obesidad","chagas","hidatidosis","tbc","cancer","quirurgicos","riesgo_nut","riesgo_soc","personales","familiares","hospitalizaciones","ant_perinatales","vacunacion","medicacion","notas","fecha_creacion") VALUES (3,4,'No','No','No','Si','No','No','No','Si',NULL,'Si','Si','No','No','Si',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'05/01/2024');
INSERT INTO "antecedentes" ("ID","paciente_id","sedentarismo","alcohol","drogas","tabaco","alergias","dbt","hta","displemia","obesidad","chagas","hidatidosis","tbc","cancer","quirurgicos","riesgo_nut","riesgo_soc","personales","familiares","hospitalizaciones","ant_perinatales","vacunacion","medicacion","notas","fecha_creacion") VALUES (4,1,'Si','No','Si','No','No','Si','No',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'08/01/2024');
INSERT INTO "app_log" ("ID","timestamp") VALUES (1,'2024-02-08 17:18:59');
INSERT INTO "complementarios" ("ID","paciente_id","lugar_nac","paraje_residencia","etnia","estado_civil","sabe_leer","escolaridad","ocupacion","ano_ingreso","notas","fecha_creacion") VALUES (1,1,'Resistencia','Paraje 1','Wichi','Soltero','Si','Secundario','Empleado',2022,NULL,NULL);
INSERT INTO "complementarios" ("ID","paciente_id","lugar_nac","paraje_residencia","etnia","estado_civil","sabe_leer","escolaridad","ocupacion","ano_ingreso","notas","fecha_creacion") VALUES (2,4,'Rosario','Paraje 2','Criollo','Casado','Si','Primario','Ama de casa',2023,NULL,NULL);
INSERT INTO "complementarios" ("ID","paciente_id","lugar_nac","paraje_residencia","etnia","estado_civil","sabe_leer","escolaridad","ocupacion","ano_ingreso","notas","fecha_creacion") VALUES (3,7,'Resistencia','Paraje 1','Wichi','Soltero','No',NULL,NULL,2022,NULL,NULL);
INSERT INTO "complementarios" ("ID","paciente_id","lugar_nac","paraje_residencia","etnia","estado_civil","sabe_leer","escolaridad","ocupacion","ano_ingreso","notas","fecha_creacion") VALUES (4,2,'Santa Fe','Paraje 2','Criollo','Casado','Si','Secundario','Empleado',2020,NULL,NULL);
INSERT INTO "complementarios" ("ID","paciente_id","lugar_nac","paraje_residencia","etnia","estado_civil","sabe_leer","escolaridad","ocupacion","ano_ingreso","notas","fecha_creacion") VALUES (5,5,'Rosario','Paraje 1','Wichi',NULL,'No',NULL,NULL,2023,NULL,NULL);
INSERT INTO "complementarios" ("ID","paciente_id","lugar_nac","paraje_residencia","etnia","estado_civil","sabe_leer","escolaridad","ocupacion","ano_ingreso","notas","fecha_creacion") VALUES (6,3,'Resistencia','Paraje 2','Criollo',NULL,NULL,NULL,NULL,2022,NULL,NULL);
INSERT INTO "complementarios" ("ID","paciente_id","lugar_nac","paraje_residencia","etnia","estado_civil","sabe_leer","escolaridad","ocupacion","ano_ingreso","notas","fecha_creacion") VALUES (7,6,'','Paraje 1','Wichi',NULL,NULL,NULL,NULL,2021,NULL,NULL);
INSERT INTO "consulta" ("ID","paciente_id","fecha_atencion","motivo_consulta","edad_consulta","diagnostico_consulta","observacion","eval_nutric","eval_soc","fum","mac_actual","fecha_mac","fecha_creacion") VALUES (1,1,'02/05/2022','Consulta General',36,'Ninguno','Consulta general, sin diagnostico','Bajo','Bajo','','','',NULL);
INSERT INTO "consulta" ("ID","paciente_id","fecha_atencion","motivo_consulta","edad_consulta","diagnostico_consulta","observacion","eval_nutric","eval_soc","fum","mac_actual","fecha_mac","fecha_creacion") VALUES (2,2,'15/08/2023','Dolor estomacal',31,'Infección','','Bajo','Medio','10/08/2023','Ninguno','',NULL);
INSERT INTO "consulta" ("ID","paciente_id","fecha_atencion","motivo_consulta","edad_consulta","diagnostico_consulta","observacion","eval_nutric","eval_soc","fum","mac_actual","fecha_mac","fecha_creacion") VALUES (3,3,'13/11/2022','Fiebre',9,'Inflamación','','','','','','',NULL);
INSERT INTO "consulta" ("ID","paciente_id","fecha_atencion","motivo_consulta","edad_consulta","diagnostico_consulta","observacion","eval_nutric","eval_soc","fum","mac_actual","fecha_mac","fecha_creacion") VALUES (4,4,'04/06/2023','Consulta General',67,'Ninguno','','Medio','Bajo','','DIU','01/04/2023',NULL);
INSERT INTO "consulta" ("ID","paciente_id","fecha_atencion","motivo_consulta","edad_consulta","diagnostico_consulta","observacion","eval_nutric","eval_soc","fum","mac_actual","fecha_mac","fecha_creacion") VALUES (5,5,'20/09/2023','Fiebre','','Infección','','','','','','',NULL);
INSERT INTO "consulta" ("ID","paciente_id","fecha_atencion","motivo_consulta","edad_consulta","diagnostico_consulta","observacion","eval_nutric","eval_soc","fum","mac_actual","fecha_mac","fecha_creacion") VALUES (6,6,'12/12/2021','Migraña',77,'','Realizar seguimiento de síntomas','Medio','Medio','','','',NULL);
INSERT INTO "consulta" ("ID","paciente_id","fecha_atencion","motivo_consulta","edad_consulta","diagnostico_consulta","observacion","eval_nutric","eval_soc","fum","mac_actual","fecha_mac","fecha_creacion") VALUES (7,7,'27/04/2022','Sangrado menstrual anormal',38,'Infección','Tratamiento x','','','','Preservativo','',NULL);
INSERT INTO "consulta" ("ID","paciente_id","fecha_atencion","motivo_consulta","edad_consulta","diagnostico_consulta","observacion","eval_nutric","eval_soc","fum","mac_actual","fecha_mac","fecha_creacion") VALUES (8,1,'24/09/2022','Fiebre',37,'Inflamación','Tratamiento 2','Medio','Medio','','','',NULL);
INSERT INTO "consulta" ("ID","paciente_id","fecha_atencion","motivo_consulta","edad_consulta","diagnostico_consulta","observacion","eval_nutric","eval_soc","fum","mac_actual","fecha_mac","fecha_creacion") VALUES (9,3,'01/10/2023','Consulta General',10,'Ninguno','','','','','','',NULL);
INSERT INTO "consulta" ("ID","paciente_id","fecha_atencion","motivo_consulta","edad_consulta","diagnostico_consulta","observacion","eval_nutric","eval_soc","fum","mac_actual","fecha_mac","fecha_creacion") VALUES (10,4,'18/10/2023','Consulta General',67,'Inflamación','Tratamiento 3',NULL,NULL,NULL,'DUI','05/09/2023',NULL);
COMMIT;
