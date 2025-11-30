import socket
import threading
from typing import List

# THIS FILE CAN BE EXECUTED ON A CLOUD SERVER, LIKE EC2, VPS, ETC...

# Configuración del servidor
HOST = 'borocito.local' # USE THE IP OR URL OF THE SERVER
PORT = 13120 # ALLOW THIS PORT ON UFW WITH 'SUDO UFW ALLOW 13120'

# Lista para almacenar los clientes conectados
clients: List[socket.socket] = []

# Bloqueo para manejar el acceso concurrente a la lista de clientes
clients_lock = threading.Lock()

# Función para manejar las conexiones de los clientes
def handle_client(conn: socket.socket, addr):
    print(f"Conexión establecida con {addr}")
    with clients_lock:
        clients.append(conn)
    while True:
        try:
            data = conn.recv(1024)
            if not data:
                break
            # Enviar el mensaje recibido a todos los clientes (menos al que lo envió)
            with clients_lock:
                for client in clients:
                    if client != conn:
                        try:
                            client.sendall(data)  # Enviar mensaje a todos los clientes
                        except:
                            clients.remove(client)  # Si el cliente ya no está conectado, lo eliminamos
            # Registra el mensaje en consola
            conn_host, conn_port = conn.getpeername()
            mensaje = str("{}:{}> {}".format(conn_host, conn_port, data.decode()))
            print(mensaje)
        except ConnectionResetError:
            break
    # Cerrar la conexión del cliente
    print(f"Conexión cerrada con {addr}")
    with clients_lock:
        clients.remove(conn)
    conn.close()

# Configuración del socket
def start_server():
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.bind((HOST, PORT))  # Enlazamos el socket al host y puerto
        s.listen()  # El servidor escucha por conexiones entrantes
        print(f"Servidor escuchando en {HOST}:{PORT}")
        while True:
            conn, addr = s.accept()  # Aceptamos la conexión entrante
            # Creamos un hilo para manejar la conexión del cliente
            thread = threading.Thread(target=handle_client, args=(conn, addr))
            thread.start()

if __name__ == "__main__":
    start_server()
