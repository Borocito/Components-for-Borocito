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
            Private serverIp As String
            Private serverPort As Integer

            Public Event MessageReceived As EventHandler(Of String)

            Public Sub New(Optional host As String = "127.0.0.1", Optional port As Integer = 13120)
                client = New TcpClient()
                serverIp = host
                serverPort = port
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

End Namespace