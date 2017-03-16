Imports System.Data.SQLite
Public Class frmMain

    'Visual display setup
    Dim panels(5) As displayRow

    'Receiving thread setup
    Dim WithEvents UdpReceiver As New UdpReceiverClass
    Dim UdpReceiverThread As Thread

    'Public Variables
    Public StoredName As String
    Public UseStoredName As Boolean
    Public SearchContactFound As Boolean
    Public SearchContact As String
    Public MyLine As String
    Public MyType As String
    Public MyDate As String
    Public MyTime As String
    Public MyCheckSum As String
    Public MyRings As String
    Public MyDuration As String
    Public MyIndicator As String
    Public MyNumber As String
    Public MyName As String
    Public FoundIndex As Integer

    'Start record variables
    Public SMyLine As String
    Public SMyTime As String
    Public SMyDate As String
    Public SMyNumber As String

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Load display rows into an array, for easier access.
        panels(1) = panLine1
        panels(2) = panLine2
        panels(3) = panLine3
        panels(4) = panLine4
        For i As Integer = 1 To 4
            panels(i).Line = i ' Set line numbers for each panel. The panel will update the text label.
            AddHandler panels(i).ButtonDatabaseClick, AddressOf panLine_Database_Click
        Next

        ' Receiving Thread setup
        UdpReceiverThread = New Thread(AddressOf UdpReceiver.UdpIdleReceive)

        ' Check if ELPopup is running and suspend if so.
        ' (ELPopup is a CallerID.com free software app that users sometimes inadvertantly load)
        Dim elpopupFound = False
        ' Get all processes with name of 'elpopup'
        Dim procList = Process.GetProcessesByName("elpopup")
        If procList.Length > 0 Then
            Dim strProcName = procList(0).ProcessName
            Dim iProcID = procList(0).Id

            If My.Computer.FileSystem.FileExists(procList(0).MainModule.FileName) Then
                elpopupFound = True
                Dim processproperties = New ProcessStartInfo
                processproperties.FileName = procList(0).MainModule.FileName
                processproperties.Arguments = "-pause"
                Process.Start(processproperties)
                Thread.Sleep(1000)
            End If
        End If

        ' If ELPopup is found, show a message before proceeding to start UDP listener
        If elpopupFound Then
            MessageBox.Show("ELPopup found and will be suspended if possible. It is important that these two programs do not" +
                    " run at the same time. Failure to do this can cause this program to crash. Make sure ELPopup is closed.")
        End If

        ' Start receiver thread
        UdpReceiverThread.IsBackground = True
        UdpReceiverThread.Start()

        ' Check for database and create it if not found

        If My.Computer.FileSystem.FileExists("callsDatabase.db3") = False Then
            ' Log File Database
            ' Create new SQLite (db3) file for new database since none exist
            ' You could use any database type for logging. We use SQLite since it only requires one DLL file
            createDatabase("callsDatabase.db3", "CREATE TABLE calls(Date varchar(10),Time varchar(10),Line varchar(10),Type varchar(10),Indicator varchar(10),Duration varchar(10),Checksum varchar(10),Rings varchar(10),Number varchar(15),Name varchar(20));")
        End If

        If My.Computer.FileSystem.FileExists("contactsDatabase.db3") = False Then
            ' Database for contacts
            ' In order to show sample code for database lookups, we created an extremely simple contact database
            ' It only contains name and phone number. Your existing contact manager database would be accessed to find matching records based on phone numbers
            createDatabase("contactsDatabase.db3", "CREATE TABLE contacts(Name varchar(20),Phone varchar(15));CREATE TABLE contactsTemp(Name varchar(20),Phone varchar(15));")
        End If

    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If UdpReceiverThread.IsAlive Then
            UdpReceiverThread.Abort()
        End If

        Dim procList = Process.GetProcessesByName("elpopup")
        If procList.Length > 0 Then
            Dim strProcName = procList(0).ProcessName
            Dim iProcID = procList(0).Id

            If My.Computer.FileSystem.FileExists(procList(0).MainModule.FileName) Then
                Dim processProperties = New ProcessStartInfo
                processProperties.FileName = procList(0).MainModule.FileName
                processProperties.Arguments = "-resume"
                Process.Start(processProperties)
            End If
        End If
    End Sub

    Sub SetVars()
        'Clear all variables
        SearchContactFound = False
        SearchContact = ""
        MyLine = ""
        MyType = ""
        MyDate = ""
        MyTime = ""
        MyCheckSum = ""
        MyRings = ""
        MyDuration = ""
        MyIndicator = ""
        MyNumber = ""
        MyName = ""
        FoundIndex = -1

        ' Get UDP received message from event
        Dim receivedMessage = UdpReceiver.ReceivedMessage

        ' Remove header
        Dim rawData As String = receivedMessage.Substring(21, receivedMessage.Length - 21)
        Dim index As Integer = rawData.IndexOf(" ")

        '---- EXTRACTING INDIVIDUAL FIELDS FROM CALL RECORDS -------                   

        ' Deluxe units are capable of sending both Start and End Records on Incoming and Outgoing calls
        ' Deluxe units can also send detail records such as Ring, On-Hook and Off Hook.
        ' This section extracts data from fields and places it into varibles
        ' The code allows for all types of call records that can be sent.  			
        ' 
        ' Note: Basic unit units only send Start Records on Incoming Calls.

        ' Get Line number from string
        MyLine = rawData.Substring(0, 2)
        MyType = rawData.Substring(3, 1) ' Get type from string
        'For Deluxe units, the Data type can be either [I]nbound, [O]utbound, [R]ing, O[N]-hook, OF[F]-hook
        'For Basic units, the only data type will be [I]nbound.

        ' Check whether the record is Incoming/Outgoing. If not, it is a detail record
        ' which needs to be processed differently below.
        If MyType = "I" Or MyType = "O" Then

            MyIndicator = rawData.Substring(5, 1) ' Start or end indicator
            MyDuration = rawData.Substring(7, 4)  ' Duration of call, in seconds
            MyCheckSum = rawData.Substring(12, 1) ' Checksum Pass/Fail ([G]ood or [B]ad)
            MyRings = rawData.Substring(14, 2)    ' Ring type and number of rings
            MyDate = rawData.Substring(17, 5)     ' Date
            MyTime = rawData.Substring(23, 8)     ' Time of day
            MyNumber = rawData.Substring(32, 15).Trim ' Phone number (Trimmed of extra whitespace)
            MyName = rawData.Substring(47, 15).Trim   ' Name (Trimmed of extra whitespace)

        ElseIf MyType = "N" Or MyType = "F" Or MyType = "R" Then

            MyDate = rawData.Substring(5, 5) ' Date
            MyTime = rawData.Substring(11, 8) ' Time of day

        End If

        'MessageBox.Show(MyName + vbCrLf + rawData)

    End Sub

    Sub HeardIt() Handles UdpReceiver.DataReceived

        'Run this sub on the GUI thread, so we can update the visuals.
        'If we don't do something like this, we get a cross-threading exception
        If panels(1).InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf HeardIt))
            Exit Sub
        End If

        'Dim sReceivedText As String = UdpReceiver.ReceivedMessage
        SetVars()

        ' This section handles all the Caller ID window visuals
        Dim intLine = Convert.ToInt32(MyLine)
        Dim command As String = MyType + MyIndicator

        Select Case command
            Case "R"
                'Incoming Call
                'Change picture of phone to ringing
                panels(intLine).picPhone.Image = My.Resources.phoneRing

                'Light up panel green for incoming call
                panels(intLine).BackColor = Color.Green

                'Show time on panel
                panels(intLine).lbTime.Text = MyTime

                'Show name and number on panel
                panels(intLine).lbNumber.Text = MyNumber
                panels(intLine).lbName.Text = MyName

            Case "IS"
                'Ring answered

                'Light-up panel green for incoming call
                panels(intLine).BackColor = Color.LightGreen

                'Show time, name, and number on panel
                panels(intLine).lbTime.Text = MyTime
                panels(intLine).lbName.Text = MyName
                panels(intLine).lbNumber.Text = MyNumber

            Case "F"
                'Phone pickup

                'Change picture of phone to off hook
                panels(intLine).picPhone.Image = My.Resources.phoneOffHook

            Case "N"
                'Phone hangup

                panels(intLine).BackColor = Color.Silver

                'Change picture of phone to not-ringing
                panels(intLine).picPhone.Image = My.Resources.phoneOnHook

            Case "IE"
            Case "OS"
                'Outgoing Call

                'Change picture of phone to off hook
                panels(intLine).picPhone.Image = My.Resources.phoneOffHook

                panels(intLine).BackColor = Color.LightBlue

                'Show time, name, number
                panels(intLine).lbTime.Text = MyTime
                panels(intLine).lbNumber.Text = MyNumber
                panels(intLine).lbName.Text = MyName

            Case "OE"

        End Select

        If command = "IS" Or command = "OS" Then
            'Set values to be checked against the database during end record
            SMyLine = MyLine
            SMyTime = MyTime
            SMyDate = MyDate
            SMyNumber = MyNumber

            'Look for phone number in database
            If searchContacts() Then
                'Number found, change icon for contacts to 'found'
                panels(MyLine).picDatabase.Image = My.Resources.databaseFound

                'Change tag to 'change' so we use the correct function when we click it
                panels(MyLine).picDatabase.Tag = "change"

                'Change the name to the one found in the database
                panels(MyLine).lbName.Text = SearchContact
                MyName = SearchContact
            Else
                'Number not found, change contacts to 'not found'
                panels(MyLine).picDatabase.Image = My.Resources.databaseInsert

                'Change tag to 'insert' so we use the correct function when we click it
                panels(MyLine).picDatabase.Tag = "insert"
            End If

            'Log the call into the database
            logCall()

        ElseIf command = "IE" Or command = "OE" Then 'if incoming or outgoing end record
            If searchContacts() Then
                'If found in database
                MyName = SearchContact
            End If

            ' On deluxe units, the end record replaces the start record
            ' to provide database with more information (duration, rings, etc.)

            updateRecord()
        End If
    End Sub

    Sub logCall()
        Dim myConnection As New SQLiteConnection

        myConnection.ConnectionString = "Data Source=" + Application.StartupPath + "\\callsDatabase.db3;"

        Try
            myConnection.Open()
        Catch ex As Exception
            MessageBox.Show("SQL exception: " + ex.ToString)
        End Try

        Dim myCommand As New SQLiteCommand("INSERT INTO calls(Line,Type,Indicator,Duration,Checksum,Rings,Date,Time,Number,Name) Values ('" + MyLine + "','" + MyType + "','" + MyIndicator + "','" + MyDuration + "','" + MyCheckSum + "','" + MyRings + "','" + MyDate + "','" + MyTime + "','" + MyNumber + "','" + MyName + "');", myConnection)

        If myConnection.State = ConnectionState.Open Then
            myCommand.ExecuteNonQuery()
        End If
        Try
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("SQL Exception: ", ex.ToString)
        End Try

        'Update logfile form
        frmLogFile.refreshDGV()
    End Sub

    Sub updateRecord()
        Dim myConnection As New SQLiteConnection

        myConnection.ConnectionString = "Data Source=" + Application.StartupPath + "\\callsDatabase.db3;"

        Try
            myConnection.Open()
        Catch ex As Exception
            MessageBox.Show("SQL exception: " + ex.ToString)
        End Try

        'Alter data already in database
        Dim myCommand As New SQLiteCommand("UPDATE calls SET Duration='" + MyDuration + "', Rings='" + MyRings + "', Indicator='" + MyIndicator + "', Name='" + MyName +
                "' WHERE Line='" + SMyLine + "' AND Time='" + SMyTime + "' AND Date='" + SMyDate + "' AND Number='" + SMyNumber + "';", myConnection)

        If myConnection.State = ConnectionState.Open Then
            myCommand.ExecuteNonQuery()
        End If
        Try
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("SQL Exception: ", ex.ToString)
        End Try

        'Update logfile form
        frmLogFile.refreshDGV()

    End Sub

    Function searchContacts() As Boolean
        Dim myConnection As New SQLiteConnection

        myConnection.ConnectionString = "Data Source=" + Application.StartupPath + "\\contactsDatabase.db3;"

        Try
            myConnection.Open()
        Catch ex As Exception
            MessageBox.Show("SQL exception: " + ex.ToString)
        End Try

        Dim myCommand As New SQLiteCommand("SELECT Name FROM contacts WHERE Phone='" + MyNumber + "';", myConnection)
        If myConnection.State = ConnectionState.Open Then
            Dim reader As SQLiteDataReader = myCommand.ExecuteReader
            If reader.HasRows Then
                SearchContactFound = True
                While reader.Read
                    SearchContact = reader.GetString(0)
                End While
            Else
                SearchContactFound = False
            End If
            reader.Close()
        End If

        Try
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("SQL Exception: " + ex.ToString)
        End Try

        Return SearchContactFound
    End Function

    Sub createDatabase(ByVal databaseName As String, ByVal createString As String)
        If Not My.Computer.FileSystem.FileExists(databaseName) Then 'Double check if file exists.

            ' Create new SQLite (db3) file for new database since none exist
            SQLiteConnection.CreateFile(databaseName)

            ' Connect to the new database
            Dim myConnection As New SQLiteConnection
            myConnection.ConnectionString = "Data Source=" + Application.StartupPath + "\\" + databaseName + ";"

            Try
                myConnection.Open()
            Catch ex As Exception
                MessageBox.Show("SQL exception: " + ex.ToString)
            End Try

            ' Create all the needed columns (ex. "CREATE TABLE contacts...")
            Dim myCommand As New SQLiteCommand(createString, myConnection)

            ' Execute the command, ignore the results, then close the connection.
            If myConnection.State = ConnectionState.Open Then
                myCommand.ExecuteNonQuery()
            End If
            Try
                myConnection.Close()
            Catch ex As Exception
                MessageBox.Show("SQL Exception: " + ex.ToString)
            End Try
        End If
    End Sub

    Private Sub btLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLog.Click
        frmLogFile.Show()
    End Sub

    Private Sub btContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btContacts.Click
        frmContacts.Show()
    End Sub

    Private Sub panLine_Database_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Linked at form load

        UseStoredName = False

        Dim picDatabase As System.Windows.Forms.PictureBox = sender
        Dim parentPanel As displayRow = picDatabase.Parent

        frmAddContact.Show()
        frmAddContact.insertValues(parentPanel.lbName.Text, parentPanel.lbNumber.Text)

        If picDatabase.Tag.ToString = "insert" Then
            frmAddContact.Mode = frmAddContact.INSERTRECORD
        ElseIf picDatabase.Tag.ToString = "change" Then
            frmAddContact.Mode = frmAddContact.UPDATERECORD
        End If
    End Sub
End Class