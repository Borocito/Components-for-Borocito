Imports boro_comm.Boro_Comm
Public Class Main
    Dim tcpServer As TCPServer
    Dim tcpClient As TCPCliente

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        CheckForIllegalCrossThreadCalls = False
        parameters = Command()
        StartUp.Init()
        ReadParameters(parameters)
        ConectarClienteBorocito()
        CrearServidorPublico()
        AddHandler Microsoft.Win32.SystemEvents.SessionEnding, AddressOf SessionEvent
    End Sub

    Sub ConectarClienteBorocito()
        tcpClient = New TCPCliente()
        ' Conectar al servidor
        tcpClient.ConnectToServer()
        ' Manejar el evento de mensaje recibido
        AddHandler tcpClient.MessageReceived, AddressOf MensajeBorocitoRecibido
    End Sub
    Sub CrearServidorPublico()
        tcpServer = New TCPServer()
        AddHandler tcpServer.MessageReceived, AddressOf MensajeServidorRecibido
        tcpServer.StartServer()
    End Sub
    Private Sub MensajeBorocitoRecibido(sender As Object, message As String)
        Try
            'Envia el mensaje recibido de Borocito a todos los clientes del servidor
            If message.Trim().StartsWith("¡#") Then 'es un mensaje para broadcast only
                Exit Sub
            End If
            Console.WriteLine("Mensaje desde Borocito para todos: " & message)
            tcpServer.SendMessageToAllClients(message)
        Catch ex As Exception
            AddToLog("MensajeBorocitoRecibido@Boro_Comm::Connector", "Error: " & ex.Message, True)
        End Try
    End Sub
    Private Sub MensajeServidorRecibido(sender As Object, message As String)
        Try
            'Envia el mensaje recibido del servidor al cliente de Borocito
            Console.WriteLine("Mensaje para Borocito desde todos: " & message)
            tcpClient.SendMesssage(message)
        Catch ex As Exception
            AddToLog("MensajeServidorRecibido@Boro_Comm::Connector", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SessionEvent(ByVal sender As Object, ByVal e As Microsoft.Win32.SessionEndingEventArgs)
        Try
            If e.Reason = Microsoft.Win32.SessionEndReasons.Logoff Then
                AddToLog("SessionEvent", "User is logging off!", True)
            ElseIf e.Reason = Microsoft.Win32.SessionEndReasons.SystemShutdown Then
                AddToLog("SessionEvent", "System is shutting down!", True)
            Else
                AddToLog("SessionEvent", "Something happend!", True)
            End If
        Catch ex As Exception
            AddToLog("SessionEvent@Init", "Error: " & ex.Message, True)
        End Try
    End Sub
End Class