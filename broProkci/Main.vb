Imports broProkci.Boro_Comm
Public Class Main
    Dim tcpBorocito As TCPCliente
    Dim tcpProxy As TCPCliente

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        CheckForIllegalCrossThreadCalls = False
        parameters = Command()
        StartUp.Init()
        ConectarClienteBorocito()
        ConectarClienteProxy()
    End Sub

    Sub ConectarClienteBorocito()
        tcpBorocito = New TCPCliente("localhost", 13120)
        tcpBorocito.ConnectToServer()
        AddHandler tcpBorocito.MessageReceived, AddressOf MensajeBorocitoRecibido
    End Sub
    Sub ConectarClienteProxy()
        tcpProxy = New TCPCliente(OwnerServer, 13120)
        tcpProxy.ConnectToServer()
        AddHandler tcpProxy.MessageReceived, AddressOf MensajeProxyRecibido
    End Sub
    Private Sub MensajeBorocitoRecibido(sender As Object, message As String)
        Try
            Console.WriteLine("Mensaje para Borocito desde Proxy: " & message)
            tcpProxy.SendMesssage(message)
        Catch ex As Exception
            AddToLog("MensajeBorocitoRecibido@Boro_Comm::Connector", "Error: " & ex.Message, True)
        End Try
    End Sub
    Private Sub MensajeProxyRecibido(sender As Object, message As String)
        Try
            Console.WriteLine("Mensaje para Borocito desde Proxy: " & message)
            tcpBorocito.SendMesssage(message)
        Catch ex As Exception
            AddToLog("MensajeProxyRecibido@Boro_Comm::Connector", "Error: " & ex.Message, True)
        End Try
    End Sub
End Class