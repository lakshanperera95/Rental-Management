Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports DbConnection
Imports WindowsApplication1.My.MySettings
Imports System.Security
Imports System.Security.Cryptography
Public Class Form1
    Dim objDBCon As New dbcon
    Dim Cn As New SqlConnection
    Dim myStreamReader As StreamReader

    Public Function Encrypt(ByVal srcValue As String) As String
        'Dim Key64() As Byte = New Byte() {165, 15, 146, 156, 78, 16, 218, 59}
        'Dim IV64() As Byte = New Byte() {55, 20, 246, 80, 239, 81, 167, 19}
        ' Dim Key64() As Byte = New Byte() {165, 15, 146, 156, 78, 16, 218, 59}
        ' Dim IV64() As Byte = New Byte() {55, 23, 246, 79, 239, 81, 167, 18}
        Dim Key64() As Byte = New Byte() {165, 15, 140, 156, 78, 16, 218, 55}
        Dim IV64() As Byte = New Byte() {40, 23, 246, 85, 230, 81, 167, 18}
        Dim retVal As String = ""
        Dim cryptoProvider As New Security.Cryptography.DESCryptoServiceProvider
        Dim ms As New IO.MemoryStream
        Dim cs As New Security.Cryptography.CryptoStream(ms, cryptoProvider.CreateEncryptor(Key64, IV64), Security.Cryptography.CryptoStreamMode.Write)
        Dim sw As New IO.StreamWriter(cs)
        sw.Write(srcValue)
        sw.Flush()
        cs.FlushFinalBlock()
        retVal = Convert.ToBase64String(ms.GetBuffer, 0, ms.Length)
        Return retVal
    End Function

    Public Function Decrypt(ByVal srcValue As String) As String
        '  Dim Key64() As Byte = New Byte() {165, 15, 146, 156, 78, 16, 218, 59}
        '  Dim IV64() As Byte = New Byte() {55, 20, 246, 80, 239, 81, 167, 19}
        ' Dim Key64() As Byte = New Byte() {165, 15, 146, 156, 78, 16, 218, 59}
        ' Dim IV64() As Byte = New Byte() {55, 23, 246, 79, 239, 81, 167, 18}
        Dim Key64() As Byte = New Byte() {165, 15, 140, 156, 78, 16, 218, 55}
        Dim IV64() As Byte = New Byte() {40, 23, 246, 85, 230, 81, 167, 18}
        ' convert attachment to base64
       
        Dim retVal As String = ""
        Dim EndOfStream As Boolean = False
        Dim bByte As Byte
        Dim cryptoProvider As New Security.Cryptography.DESCryptoServiceProvider
        Dim buffer() As Byte = Convert.FromBase64String(srcValue)
        Dim ms As New IO.MemoryStream(buffer)
        Dim cs As New Security.Cryptography.CryptoStream(ms, cryptoProvider.CreateDecryptor(Key64, IV64), Security.Cryptography.CryptoStreamMode.Read)
        Do Until EndOfStream
            Try
                bByte = cs.ReadByte
            Catch ex As Exception
                EndOfStream = True
            End Try
            If Not EndOfStream Then
                retVal = retVal & Chr(bByte)
            End If
        Loop
        Return retVal

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dd As String
        dd = Encrypt(TextBox1.Text)
        TextBox1.Text = dd
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ff As String
        ff = Decrypt(Trim(TextBox1.Text))
        TextBox1.Text = ff
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Dim myStreamReader As StreamReader

        Dim strJournalName As String
        Dim strSourcePath As String
        Dim strAppPath As String
        Try
            TextBox2.Text = ""
            If ComboBox1.Text = "" Then
                MessageBox.Show("Pos Terminal Not Found. Please Select Pos Terminal", "Invalid Terminal", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            strSourcePath = ""
            strJournalName = ""
            strAppPath = Application.StartupPath
            strAppPath = strAppPath & "\Journal"
            If Directory.Exists(strAppPath) = False Then
                Directory.CreateDirectory(strAppPath)
            End If

            Cn.ConnectionString = dbcon.ConnectionString
            If Cn.State = ConnectionState.Closed Then
                Cn.Open()
            End If

            Dim Comm As New SqlCommand()
            Dim DataReader As SqlDataReader
            Comm.Connection = Cn
            Comm.CommandText = "SELECT Journal_Path FROM tbPosTerminalDetails WHERE Terminal_No = '" + ComboBox1.Text.Trim() + "'"
            DataReader = Comm.ExecuteReader()

            If DataReader.Read() = True Then
                strSourcePath = DataReader.GetString(0)
            End If

            If Cn.State = ConnectionState.Open Then
                Cn.Close()
            End If

            strJournalName = Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt"
            strSourcePath = strSourcePath & strJournalName
            strAppPath = strAppPath & "\" & strJournalName

            Dim fs As FileStream = Nothing
            fs = File.Create(strAppPath)
            fs.Close()
            If File.Exists(strAppPath) Then
                'If My.Computer.FileSystem.FileExists(strAppPath) = True Then
                '    My.Computer.FileSystem.DeleteFile(strAppPath)
                'End If
                My.Computer.FileSystem.CopyFile(strSourcePath, strAppPath, True)
            Else
                'My.Computer.FileSystem.CopyFile(strSourcePath, strAppPath)
                TextBox2.Text = ""
                MessageBox.Show("Journal File Not Found. Please Select Valid Journal File", "Invalid Journal", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            '**********************************************
            ' ''Path = ""
            ' ''srrs = ""
            ' ''If Directory.Exists("C:\") = False Then
            ' ''    Directory.CreateDirectory("C:\Rayan")
            ' ''    Path = "C:\Rayan\"
            ' ''End If

            ' ''If ComboBox1.Text = "1" Then
            ' ''    My.Computer.FileSystem.CopyFile("\\OITPOS01\D$\RAYAN\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", Path & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", FileIO.UIOption.AllDialogs)

            ' ''    srrs = "C:\Rayan\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt"

            ' ''ElseIf ComboBox1.Text = "2" Then
            ' ''    My.Computer.FileSystem.CopyFile("\\OITPOS02\D$\RAYAN\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", Path & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", FileIO.UIOption.AllDialogs)
            ' ''    srrs = "C:\Rayan\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt"
            ' ''End If
            '*******************************************

            ' srrs = "c:\sales.txt"
            myStreamReader = File.OpenText(strAppPath)


            'Me.TextBox2.Text = myStreamReader.ReadToEnd()
            'Dim ff As String
            'While Not Trim(TextBox2.Text) Is Nothing
            '    ff = TextBox2.ToString()
            '    ff = Decrypt(Trim(TextBox2.ToString()))
            '    TextBox2.Text = ff
            'End While
            'ff = Decrypt(Trim(TextBox2.Text))
            'TextBox2.Text = ff

            'myNextInt = myStreamReader.Read()
            'While myNextInt <> -1
            '    ff = Decrypt(Trim(TextBox2.ToString()))

            'End While

            TextBox2.Text = ""
            Dim myInputString As String

            If chkJournal.Checked = False Then
                Dim rowCount As Integer = 0
                myInputString = myStreamReader.ReadLine()
                While Not myInputString Is Nothing
                    ' Output the text with a line number
                    Dim strLine As String = Decrypt(Trim(myInputString))
                    TextBox2.Text += strLine + vbCrLf
                    rowCount += 1
                    TextBox2.Refresh()
                    ' Read the next line.
                    myInputString = myStreamReader.ReadLine()

                End While

            Else
                TextBox2.Text = myStreamReader.ReadToEnd()
            End If




            'TextBox2.Text = myStreamReader.OpenText().ReadToEnd()

            TextBox2.ReadOnly = True
            myStreamReader.Close()



            If My.Computer.FileSystem.FileExists(strAppPath) = True Then
                My.Computer.FileSystem.DeleteFile(strAppPath)
            End If
        Catch ex As Exception
            MessageBox.Show("Error Found. " & ex.Message, "Path Error", MessageBoxButtons.OK)

        End Try
    End Sub

    Private Function DisOld() As String
        Dim myStreamReader As StreamReader

        Dim strJournalName As String
        Dim strSourcePath As String
        Dim strPath As String
        Dim strAppPath As String
        Try

            If ComboBox1.Text = "" Then
                MessageBox.Show("Pos Terminal Not Found. Please Select Pos Terminal", "Invalid Terminal", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Function
            End If

            strSourcePath = ""
            strJournalName = ""
            strAppPath = Application.StartupPath
            strAppPath = strAppPath & "\Journal"
            If Directory.Exists(strAppPath) = False Then
                Directory.CreateDirectory(strAppPath)
            End If

            Cn.ConnectionString = dbcon.ConnectionString
            If Cn.State = ConnectionState.Closed Then
                Cn.Open()
            End If

            Dim Comm As New SqlCommand()
            Dim DataReader As SqlDataReader
            Comm.Connection = Cn
            Comm.CommandText = "SELECT Journal_Path FROM tbPosTerminalDetails WHERE Terminal_No = '" + ComboBox1.Text.Trim() + "'"
            DataReader = Comm.ExecuteReader()

            If DataReader.Read() = True Then
                strSourcePath = DataReader.GetString(0)
            End If

            If Cn.State = ConnectionState.Open Then
                Cn.Close()
            End If

            strPath = strSourcePath
            strJournalName = Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt"
            strSourcePath = strSourcePath & strJournalName
            strAppPath = strAppPath & "\" & strJournalName

            Dim fs As FileStream = Nothing
            'fs = File.Create(strAppPath)
            ' fs.Close()
            If File.Exists(strAppPath) Then
                'If My.Computer.FileSystem.FileExists(strAppPath) = True Then
                '    My.Computer.FileSystem.DeleteFile(strAppPath)
                'End If
                'My.Computer.FileSystem.CopyFile(strSourcePath, strAppPath, True)
            Else
                'My.Computer.FileSystem.CopyFile(strSourcePath, strAppPath)
                MessageBox.Show("Journal File Not Found. Please Select Valid Journal File", "Invalid Journal", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Function
            End If

            '**********************************************
            ' ''Path = ""
            ' ''srrs = ""
            ' ''If Directory.Exists("C:\") = False Then
            ' ''    Directory.CreateDirectory("C:\Rayan")
            ' ''    Path = "C:\Rayan\"
            ' ''End If

            ' ''If ComboBox1.Text = "1" Then
            ' ''    My.Computer.FileSystem.CopyFile("\\OITPOS01\D$\RAYAN\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", Path & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", FileIO.UIOption.AllDialogs)

            ' ''    srrs = "C:\Rayan\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt"

            ' ''ElseIf ComboBox1.Text = "2" Then
            ' ''    My.Computer.FileSystem.CopyFile("\\OITPOS02\D$\RAYAN\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", Path & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", FileIO.UIOption.AllDialogs)
            ' ''    srrs = "C:\Rayan\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt"
            ' ''End If
            '*******************************************

            ' srrs = "c:\sales.txt"
            myStreamReader = File.OpenText(strAppPath)


            'Me.TextBox2.Text = myStreamReader.ReadToEnd()
            'Dim ff As String
            'While Not Trim(TextBox2.Text) Is Nothing
            '    ff = TextBox2.ToString()
            '    ff = Decrypt(Trim(TextBox2.ToString()))
            '    TextBox2.Text = ff
            'End While
            'ff = Decrypt(Trim(TextBox2.Text))
            'TextBox2.Text = ff

            'myNextInt = myStreamReader.Read()
            'While myNextInt <> -1
            '    ff = Decrypt(Trim(TextBox2.ToString()))

            'End While

            'TextBox2.Text = ""
            Dim myInputString As String
            TextBox2.Text = ""

            '  If chkJournal.Checked = False Then

            '     Dim rowCount As Integer = 0
            '   myInputString = myStreamReader.ReadLine()
            '    While Not myInputString Is Nothing
            ' ' Output the text with a line number
            Dim strLine As String = Decrypt(Trim(myInputString))
            '   TextBox2.Text += strLine + vbCrLf
            '   rowCount += 1
            '  TextBox2.Refresh()
            '   ' Read the next line.
            '  myInputString = myStreamReader.ReadLine()
            ' End While

            'TextBox2.Text = myStreamReader.OpenText().ReadToEnd()

            TextBox2.ReadOnly = True
            myStreamReader.Close()



            If My.Computer.FileSystem.FileExists(strAppPath) = True Then
                My.Computer.FileSystem.DeleteFile(strAppPath)
            End If
        Catch ex As Exception
            MessageBox.Show("Error Found. " & ex.Message, "Path Error", MessageBoxButtons.OK)

        End Try
    End Function


    'Mindada's Sample  

    Private Function GrabFile(ByVal file_name As String) As String
        Try
            Dim stream_reader As New IO.StreamReader(file_name)
            Dim txt As String = stream_reader.ReadToEnd()
            stream_reader.Close()
            Return txt
        Catch exc As System.IO.FileNotFoundException
            ' Ignore this error.
            Return ""
        Catch exc As Exception
            ' Report other errors.
            MsgBox(exc.Message, MsgBoxStyle.Exclamation, "Read Error")
            Return ""
        End Try
    End Function

    'End Mindada's Sample

    Private Sub Form1_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ClientSizeChanged

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DateTimePicker1.Value = Now.ToString("dd/MM/yyyy")

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            myStreamReader.Close()
            myStreamReader.Dispose()
            My.Settings.Save()
        Catch ex As Exception
        End Try
    End Sub

   
End Class
