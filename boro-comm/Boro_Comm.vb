Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports System.Net
Namespace Boro_Comm

    Module Cliente
        Public Class TCPCliente
            Private client As TcpClient
            Private clientStream As NetworkStream
            Private thread As Thread
            Private isConnected As Boolean
            Private serverIp As String = "127.0.0.1"
            Private serverPort As Integer = 13120

            Public Event MessageReceived As EventHandler(Of String)

            Public Sub New()
                client = New TcpClient()
                isConnected = False
            End Sub

            ' Método para conectar al servidor
            Public Sub ConnectToServer()
                Try
                    client.Connect(serverIp, serverPort)
                    clientStream = client.GetStream()
                    isConnected = True
                    Console.WriteLine("Conectado al servidor.")
                    ' Iniciar hilo para leer los mensajes del servidor
                    thread = New Thread(AddressOf ReadMessages)
                    thread.Start()
                Catch ex As Exception
                    Console.WriteLine("Error conectando al servidor: " & ex.Message)
                End Try
            End Sub

            ' Método para desconectar del servidor
            Public Sub DisconnectFromServer()
                Try
                    isConnected = False
                    clientStream.Close()
                    client.Close()
                    Console.WriteLine("Desconectado del servidor.")
                Catch ex As Exception
                    Console.WriteLine("Error desconectando: " & ex.Message)
                End Try
            End Sub

            ' Método para enviar un mensaje al servidor
            Public Sub SendMesssage(message As String)
                If isConnected AndAlso clientStream IsNot Nothing Then
                    Try
                        Dim data As Byte() = Encoding.UTF8.GetBytes(message)
                        clientStream.Write(data, 0, data.Length)
                    Catch ex As Exception
                        Console.WriteLine("Error enviando mensaje: " & ex.Message)
                    End Try
                End If
            End Sub

            ' Método para leer los mensajes del servidor
            Private Sub ReadMessages()
                Dim buffer(1024) As Byte
                While isConnected
                    Try
                        If clientStream.DataAvailable Then
                            Dim bytesRead As Integer = clientStream.Read(buffer, 0, buffer.Length)
                            If bytesRead > 0 Then
                                Dim message As String = Encoding.UTF8.GetString(buffer, 0, bytesRead)
                                RaiseEvent MessageReceived(Me, message)
                            End If
                        End If
                        Thread.Sleep(100)
                    Catch ex As Exception
                        Console.WriteLine("Error leyendo mensaje: " & ex.Message)
                        Exit While
                    End Try
                End While
            End Sub
        End Class
    End Module

    Module Servidor
        Public Class TCPServer
            Private server As TcpListener
            Private clients As List(Of TcpClient)
            Private clientStreams As List(Of NetworkStream)
            Private isListening As Boolean
            Private thread As Thread

            ' Evento para notificar cuando un cliente envía un mensaje
            Public Event MessageReceived As EventHandler(Of String)

            Public Sub New()
                server = New TcpListener(IPAddress.Any, 13121)
                clients = New List(Of TcpClient)()
                clientStreams = New List(Of NetworkStream)()
                isListening = False
            End Sub

            ' Método para iniciar el servidor
            Public Sub StartServer()
                server.Start()
                isListening = True
                thread = New Thread(AddressOf ListenForClients)
                thread.Start()
                Console.WriteLine("Servidor iniciado...")
            End Sub

            ' Método para detener el servidor
            Public Sub StopServer()
                isListening = False
                server.Stop()
                For Each client As TcpClient In clients
                    client.Close()
                Next
                clients.Clear()
                clientStreams.Clear()
                Console.WriteLine("Servidor detenido.")
            End Sub

            ' Método para escuchar a los clientes y aceptar conexiones
            Private Sub ListenForClients()
                While isListening
                    If server.Pending() Then
                        Dim newClient As TcpClient = server.AcceptTcpClient()
                        clients.Add(newClient)
                        Dim newStream As NetworkStream = newClient.GetStream()
                        clientStreams.Add(newStream)

                        Console.WriteLine("Nuevo cliente conectado.")
                        ' Iniciar un hilo para manejar la comunicación con el nuevo cliente
                        Dim clientThread As New Thread(AddressOf HandleClientCommunication)
                        clientThread.Start(newClient)
                    End If
                    Thread.Sleep(100)
                End While
            End Sub

            ' Método para manejar la comunicación con cada cliente
            Private Sub HandleClientCommunication(client As TcpClient)
                Dim clientStream As NetworkStream = client.GetStream()
                Dim buffer(1024) As Byte
                While isListening
                    Try
                        If clientStream.DataAvailable Then
                            Dim bytesRead As Integer = clientStream.Read(buffer, 0, buffer.Length)
                            If bytesRead > 0 Then
                                Dim message As String = Encoding.UTF8.GetString(buffer, 0, bytesRead)
                                ' Llamar al evento para notificar a otros componentes
                                RaiseEvent MessageReceived(Me, message)
                            End If
                        End If
                        Thread.Sleep(100)
                    Catch ex As Exception
                        Console.WriteLine("Error con el cliente: " & ex.Message)
                        Exit While
                    End Try
                End While
            End Sub

            ' Método para enviar un mensaje a un cliente específico
            Private Sub SendMessageToClient(client As TcpClient, message As String)
                Dim clientStream As NetworkStream = client.GetStream()
                Dim data As Byte() = Encoding.UTF8.GetBytes(message)
                Try
                    clientStream.Write(data, 0, data.Length)
                Catch ex As Exception
                    Console.WriteLine("Error enviando mensaje al cliente: " & ex.Message)
                End Try
            End Sub
            ' Método para enviar un mensaje a todos los clientes conectados
            Public Sub SendMessageToAllClients(message As String)
                Dim data As Byte() = Encoding.UTF8.GetBytes(message)
                For Each clientStream As NetworkStream In clientStreams
                    Try
                        clientStream.Write(data, 0, data.Length)
                    Catch ex As Exception
                        Console.WriteLine("Error enviando mensaje a los clientes: " & ex.Message)
                    End Try
                Next
            End Sub
        End Class
    End Module

End Namespace