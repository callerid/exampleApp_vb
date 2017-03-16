Public Class UdpReceiverClass
    Public Done As Boolean
    Public ReceivedMessage As String
    Public ReceivedMessageByte As Byte()
    Public NListenPort As Integer = 3520

    Public Delegate Sub UdpEventHandler(ByVal UdpReceiverClass, ByVal EventArgs)
    Public Event DataReceived As UdpEventHandler

    Public Sub UdpIdleReceive()

        Done = False

        Dim filterMessageSmallerThan As Integer = 4

        Dim listener As New UdpClient(NListenPort)
        Dim groupEP As New IPEndPoint(IPAddress.Any, NListenPort)

        Try
            Do Until (Done)
                ReceivedMessageByte = listener.Receive(groupEP)
                ReceivedMessage = System.Text.Encoding.UTF7.GetString(ReceivedMessageByte, 0, ReceivedMessageByte.Length)


                If ReceivedMessageByte.Length > filterMessageSmallerThan Then
                    RaiseEvent DataReceived(Me, EventArgs.Empty)
                End If
            Loop
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

        listener.Close()


    End Sub
End Class
