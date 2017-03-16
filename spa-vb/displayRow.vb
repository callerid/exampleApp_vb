Public Class displayRow

    Public Event ButtonDatabaseClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event ButtonPhoneClick(ByVal sender As System.Object, ByVal e As System.EventArgs)


    Private Sub picPhone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picPhone.Click
        RaiseEvent ButtonPhoneClick(sender, e)
    End Sub

    Private Sub picDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picDatabase.Click
        RaiseEvent ButtonDatabaseClick(sender, e)
    End Sub

    Private lineNumber As Integer
    Public Property Line() As Integer
        Get
            Return lineNumber
        End Get
        Set(ByVal value As Integer)
            lineNumber = value
            lbLine.Text = value.ToString.PadLeft(2, "0")
        End Set
    End Property

End Class
