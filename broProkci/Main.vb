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
        Try
            tcpBorocito = New TCPCliente("localhost", 13120)
            tcpBorocito.ConnectToServer()
            AddHandler tcpBorocito.MessageReceived, AddressOf MensajeBorocitoRecibido
        Catch ex As Exception
            AddToLog("ConectarClienteBorocito@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ConectarClienteProxy()
        Try
            If customIp = Nothing Then
                tcpProxy = New TCPCliente(OwnerServer, 13120)
            Else
                tcpProxy = New TCPCliente(customIp, 13120)
            End If
            tcpProxy.ConnectToServer()
            AddHandler tcpProxy.MessageReceived, AddressOf MensajeProxyRecibido
        Catch ex As Exception
            AddToLog("ConectarClienteProxy@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
    Private Sub MensajeBorocitoRecibido(sender As Object, message As String)
        Try
            Console.WriteLine("Mensaje para Proxy desde Borocito: " & message)
            tcpProxy.SendMesssage(message)
        Catch ex As Exception
            AddToLog("MensajeBorocitoRecibido@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
    Private Sub MensajeProxyRecibido(sender As Object, message As String)
        Try
            Console.WriteLine("Mensaje para Borocito desde Proxy: " & message)
            tcpBorocito.SendMesssage(message)
        Catch ex As Exception
            AddToLog("MensajeProxyRecibido@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
End Class