import os
import re

# Ruta base donde se encuentran los proyectos
base_path = "C:\\Users\\Zhen\\Documents\\GitHub\\Components-for-Borocito"  # Reemplaza esto con la ruta de tu solución

# Carpeta donde se almacenarán los archivos .inf
repositorios_path = os.path.join(base_path, 'repositorios')
if not os.path.exists(repositorios_path):
    os.makedirs(repositorios_path)

# Función para extraer los valores de AssemblyVersion, AssemblyProduct y AssemblyCompany
def extraer_informacion_ensamblado(assembly_info_path):
    with open(assembly_info_path, 'r', encoding='utf-8') as f:
        contenido = f.read()

    # Eliminar el BOM si existe (Byte Order Mark)
    if contenido.startswith('\ufeff'):
        contenido = contenido[1:]

    # Expresión regular para encontrar AssemblyVersion
    version_pattern = r'<Assembly:\s*AssemblyVersion\(\s*"([^"]+)"\s*\)\s*>'

    # Buscar todas las coincidencias de AssemblyVersion
    versions = re.findall(version_pattern, contenido)

    # Si hay al menos 2 versiones, la primera será el comentario, y la segunda es la correcta
    if len(versions) >= 2:
        assembly_version = versions[1]  # La segunda versión es la correcta
    else:
        # Si no encontramos la segunda versión, devolvemos None
        return None

    # Expresión regular para encontrar AssemblyProduct y AssemblyCompany
    product_pattern = r'<Assembly:\s*AssemblyProduct\(\s*"([^"]+)"\s*\)\s*>'
    company_pattern = r'<Assembly:\s*AssemblyCompany\(\s*"([^"]+)"\s*\)\s*>'

    product = re.search(product_pattern, contenido)
    company = re.search(company_pattern, contenido)

    # Si se encuentra alguna de las cadenas, extraer los valores
    if product and company:
        assembly_product = product.group(1)
        assembly_company = company.group(1)
        return assembly_version, assembly_product, assembly_company
    else:
        return None

# Recorremos los proyectos
for project in os.listdir(base_path):
    project_path = os.path.join(base_path, project)

    # Verificamos que sea un directorio y que contenga la carpeta 'My Project'
    if os.path.isdir(project_path) and 'My Project' in os.listdir(project_path):
        assembly_info_path = os.path.join(project_path, 'My Project', 'AssemblyInfo.vb')

        # Verificamos si el archivo AssemblyInfo.vb existe
        if os.path.exists(assembly_info_path):
            # Extraemos la información de ensamblado
            informacion = extraer_informacion_ensamblado(assembly_info_path)

            if informacion:
                assembly_version, assembly_product, assembly_company = informacion

                # Generar el contenido del archivo .inf
                inf_content = f"""
# Boro-Get {assembly_product} Repo file
[GENERAL]
Author={assembly_company}
From=http://github.com/{assembly_company}

[ASSEMBLY]
Name={assembly_product}
Executable={assembly_product}.exe
Version={assembly_version}
Web=https://github.com/Borocito/Components-for-Borocito/tree/main/{assembly_product}

[INSTALLER]
Binaries=http://borocito.local/Boro-Get/REPO/{assembly_product}.zip
Installer=NULL
InstallFolder=%temp%
                """

                # Guardar el archivo .inf en la carpeta repositorios/
                inf_filename = f"{assembly_product}.inf"
                inf_path = os.path.join(repositorios_path, inf_filename)

                with open(inf_path, 'w', encoding='utf-8') as inf_file:
                    inf_file.write(inf_content.strip())

                print(f"Archivo .inf creado: {inf_path}")

print("Proceso completado.")
