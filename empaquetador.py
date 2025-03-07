import os
import zipfile
os.system("cls")

# Ruta base donde se encuentran los proyectos
base_path = "C:\\Users\\Zhen\\Documents\\GitHub\\Components-for-Borocito"  # Reemplaza esto con la ruta de tu solución
compressed_folder = "binarios"
compress_ext = ".zip"

# Ruta de la carpeta binarios donde se almacenarán los zip
binarios_path = os.path.join(base_path, compressed_folder)
if not os.path.exists(binarios_path):
    os.makedirs(binarios_path)

# Recorremos las carpetas de los proyectos dentro de la solución
for project in os.listdir(base_path):
    project_path = os.path.join(base_path, project)
    
    # Verificamos que sea un directorio y que contenga la carpeta bin/Debug
    if os.path.isdir(project_path) and 'bin' in os.listdir(project_path):
        bin_debug_path = os.path.join(project_path, 'bin', 'Debug')
        
        # Verificamos que la carpeta bin/Debug exista y contenga archivos .exe
        if os.path.exists(bin_debug_path):
            for file in os.listdir(bin_debug_path):
                if file.endswith('.exe'):
                    exe_path = os.path.join(bin_debug_path, file)
                    
                    # Nombre del archivo sin la extensión .exe
                    zip_name = file.replace('.exe', compress_ext)
                    zip_path = os.path.join(binarios_path, zip_name)
                    
                    # Creamos el archivo ZIP con el .exe dentro
                    with zipfile.ZipFile(zip_path, 'w', zipfile.ZIP_DEFLATED) as zipf:
                        zipf.write(exe_path, arcname=file)
                    print(f"Creado archivo ZIP: {zip_path}")

print("¡Empaquetado completado!")
