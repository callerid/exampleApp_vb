Imports System.Data.SQLite
Public Class frmLogFile

    Private Sub frmLogFile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        refreshDGV()
    End Sub

    Public Sub refreshDGV()

        Dim myConnection As New SQLiteConnection

        myConnection.ConnectionString = "Data Source=" + Application.StartupPath + "\\callsDatabase.db3;"

        Try
            myConnection.Open()
        Catch ex As Exception
            MessageBox.Show("SQL exception: " + ex.ToString)
        End Try

        'Sort by date, then time from the database. The DataGridView can only sort by one at a time.
        Dim myCommand As New SQLiteCommand("SELECT * FROM calls ORDER BY ID DESC;", myConnection)

        If myConnection.State = ConnectionState.Open Then
            Dim dataAdapter As New SQLiteDataAdapter(myCommand)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "calls")
            Dim myBind = New BindingSource(dataSet, "calls")
            dgvLogFile.DataSource = myBind
            dgvLogFile.Columns(0).Visible = False
        End If
        Try
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("SQL Exception: ", ex.ToString)
        End Try
        dgvLogFile.Refresh()
    End Sub

End Class