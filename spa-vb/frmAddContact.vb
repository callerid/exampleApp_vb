Imports System.Data.SQLite
Public Class frmAddContact
    Public Const INSERTRECORD As Integer = 1
    Public Const UPDATERECORD As Integer = 2
    Private UpdateMode As Integer = 1
    Public Property Mode() As Integer
        Get
            Return UpdateMode
        End Get
        Set(ByVal value As Integer)
            UpdateMode = value
            If value = INSERTRECORD Then
                btAdd.Text = "Add"
                Me.Name = "Add Contact"
            Else
                btAdd.Text = "Change"
                Me.Name = "Change Contact"
            End If
        End Set
    End Property

    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        addRecord()
    End Sub

    Private Sub addRecord()
        Dim myConnection As New SQLiteConnection

        myConnection.ConnectionString = "Data Source=" + Application.StartupPath + "\\contactsDatabase.db3;"

        Try
            myConnection.Open()
        Catch ex As Exception
            MessageBox.Show("SQL exception: " + ex.ToString)
        End Try

        Dim myCommand As New SQLiteCommand
        If UpdateMode = INSERTRECORD Then
            myCommand = New SQLiteCommand("INSERT INTO contacts(Name,Phone) Values ('" + tbName.Text + "','" + tbPhone.Text + "')", myConnection)
        Else
            myCommand = New SQLiteCommand("UPDATE contacts SET Name='" + tbName.Text + "' WHERE Phone='" + tbPhone.Text + "';", myConnection)
        End If


        If myConnection.State = ConnectionState.Open Then
            myCommand.ExecuteNonQuery()
        End If

        Try
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("SQL Exception: " + ex.ToString)
        End Try
        Me.Close()
    End Sub

    Public Sub insertValues(ByVal myName As String, ByVal myNumber As String)
        tbName.Text = myName
        tbPhone.Text = myNumber
    End Sub
End Class