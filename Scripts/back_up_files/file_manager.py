import os

from cryptography.fernet import Fernet
from datetime import datetime
from googleapiclient.discovery import build
from google.oauth2 import service_account
from googleapiclient.http import MediaFileUpload, MediaIoBaseDownload, io
from tabulate import tabulate

# --- SETTING GLOBAL VARS ---
FOLDER_ID = "1PpXXP5_u2wuDoCvOIX8Lb3m28-8BmU7g"
FILE_ID = ''
PATH = "../../Entidades/lahiguera.db"
SECRETS = "la-higuera-bkp.json"
now = datetime.now().strftime('%d-%m-%Y')


def key_generator():
    key = Fernet.generate_key()
    with open("mykey.key", "wb") as mykey:
        mykey.write(key)

def load_key(key_name):
    with open(key_name, "rb") as mickey:
        key = mickey.read()
    return Fernet(key)

def encrypt_file(file_path, key, str_now):
    with open(file_path, "rb") as original_file:
        original_content = original_file.read()
    encrypted = load_key(key).encrypt(original_content)
    with open(f"backups/enc_{ str_now }.db", "wb") as encripted_file:
        encripted_file = encripted_file.write(encrypted)

def decrypt_file(file_name, key, destination_path):
    with open(f"download/{ file_name }", "rb") as encrypted_file:
        encrypted = encrypted_file.read()
    decrypted = load_key(key).decrypt(encrypted)
    with open(destination_path, "wb") as decripted_file:
        decripted_file = decripted_file.write(decrypted)
        
def upload_file(path, file_name, folder_id):
    drive_service = drive_connection(SECRETS)
    file_metadata = {'name': file_name, 'parents': [ folder_id ]}
    file_path = path
    media = MediaFileUpload(file_path, mimetype='text/plain')
    drive_service.files().create(body=file_metadata, media_body=media).execute()
    print("UPLOADED!")

def list_files():
    drive_service = drive_connection(SECRETS)
    results = drive_service.files().list(pageSize=1000, fields="nextPageToken, files(id, name, mimeType, size, modifiedTime)").execute()
    return results.get('files', [])

def delete_files(ID):
    drive_service = drive_connection(SECRETS)
    drive_service.files().delete(fileId=ID).execute()
    
def download_file(file_path, file_id):
    print("BEGINING DOWNLOAD")
    drive_service = drive_connection(SECRETS)
    query = drive_service.files().get_media(fileId=file_id)
    fh = io.FileIO(file_path, mode='wb')
    downloader = MediaIoBaseDownload(fh, query)
    done = False
    while not done:
        status, done = downloader.next_chunk()
    print("DOWNLOADED!")

def drive_connection(secret_cred):
    SCOPES = ['https://www.googleapis.com/auth/drive']
    creds = service_account.Credentials.from_service_account_file(secret_cred,scopes=SCOPES)
    return build('drive', 'v3', credentials=creds)


print('* Por favor, elija la opción deseada: ')
print("1 - Hacer backup de la base de datos")
print("2 - Descargar base de datos de Google Drive")
while True:
    try:
        OPCION = int(input('* Opción: '))
        if OPCION in [1,2]:
            break
    except:
        print("Por favor, ingrese valores númericos")
if OPCION == 1:
    files = os.listdir(os.getcwd())
    if "mykey.key" in files:
        print('Task 1: Encryptando archivo...')
        try:
            encrypt_file(PATH, "mykey.key", now)
            print('Task 1: OK!')
            print('Task 2: Subiendo archivo...')
            try:
                NAME = f"enc_{ now }.db"
                ENC_PATH = f"backups/{ NAME }"
                upload_file(ENC_PATH, NAME, FOLDER_ID)
                print('Task 3: Borrando archivo local encriptado...')
                os.remove(ENC_PATH)
                print(f'Task 3: OK!')
            except Exception as e:
                print(f'Task 2: failed => { e }')
        except Exception as e:
            print(f'Task 1: failed => { e }')
    else:
        print("LLAVE NO ENCONTRADA, POR FAVOR, CONTACTE AL ADMINISTRADOR")
else:
    files_in_goole = list_files()
    if len(files_in_goole) > 0:
        print('Task 1: Listando archivos...')        
        printable = [ [ index, file["name"], file["modifiedTime"] ] for index, file in enumerate(files_in_goole) ]
        print(tabulate(printable, headers=['Index', 'Nombre', 'Modificado']))        
        list_index = [ x for x in range(len(files_in_goole)) ]
        print(list_index)
        while True:
            try:
                index_in_list = int(input("Por favor, elija el número del archivo que desea descargar: "))
                if index_in_list in list_index:
                    break
            except:
                print("Por favor, ingrese valores númericos")
        print(f'Su elección es: { files_in_goole[index_in_list]["name"] } { files_in_goole[index_in_list]["id"] }')
        print('Task 2: Descargando archivo...')        
        download_file(f'download/{ files_in_goole[index_in_list]["name"] }', files_in_goole[index_in_list]["id"])
        print('Task 3: Desencriptando archivo...')                
        decrypt_file(files_in_goole[index_in_list]["name"], "mykey.key", PATH)
        print("DECRYPTED!")
        print('Task 4: Borrando archivo local encriptado...')
        os.remove(f'download/{ files_in_goole[index_in_list]["name"] }')
        files_postcheck = os.listdir("../../Entidades/")
        if "lahiguera.db" in files_postcheck:
            print("Script finalizado con éxito!")


##### VER POSTCHECK!.
##### VER JSON DE CREDENCIALES, BORRAR ANTES DE SUBIR.


