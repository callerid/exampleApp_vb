Imports System.Data.SQLite
Public Class frmContacts

    Private Sub frmContacts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        refreshDGV()
    End Sub

    Private Sub refreshDGV()
        Dim myConnection As New SQLiteConnection

        myConnection.ConnectionString = "Data Source=" + Application.StartupPath + "\\contactsDatabase.db3;"

        Try
            myConnection.Open()
        Catch ex As Exception
            MessageBox.Show("SQL exception: " + ex.ToString)
        End Try

        Dim myCommand As New SQLiteCommand("SELECT * FROM contacts", myConnection)

        If myConnection.State = ConnectionState.Open Then
            Dim dataAdapter As New SQLiteDataAdapter(myCommand)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "calls")
            Dim myBind = New BindingSource(dataSet, "calls")
            dgvContacts.DataSource = myBind
        End If
        Try
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("SQL Exception: ", ex.ToString)
        End Try

        'Sort by time
        dgvContacts.Sort(dgvContacts.Columns(1), System.ComponentModel.ListSortDirection.Descending)
    End Sub

End Class