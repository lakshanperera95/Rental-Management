Imports System.IO

Public Class ClsConnection
    Private strServerName As String
    Private strDataBaseName As String
    Private strUserName As String
    Private strPassWord As String
    Private strDataUploadServerName As String
    Private strDataUploadDataBaseName As String
    Private strDataUploadUserName As String
    Private strDataUploadPassWord As String
    Private GG As Integer

#Region "Property"
    Public Property DataUploadServername() As String
        Get
            Return strDataUploadServerName
        End Get
        Set(ByVal Value As String)
            strDataUploadServerName = Value
        End Set
    End Property
    Public Property DataUploadDatabasename() As String
        Get
            Return strDataUploadDataBaseName
        End Get
        Set(ByVal Value As String)
            strDataUploadDataBaseName = Value
        End Set
    End Property
    Public Property DataUploadUsername() As String
        Get
            Return strDataUploadUserName
        End Get
        Set(ByVal Value As String)
            strDataUploadUserName = Value
        End Set
    End Property
    Public Property DataUploadPassword() As String
        Get
            Return strDataUploadPassWord
        End Get
        Set(ByVal Value As String)
            strDataUploadPassWord = Value
        End Set
    End Property
    Public Property Servername() As String
        Get
            Return strServerName
        End Get
        Set(ByVal Value As String)
            strServerName = Value
        End Set
    End Property
    Public Property Databasename() As String
        Get
            Return strDataBaseName
        End Get
        Set(ByVal Value As String)
            strDataBaseName = Value
        End Set
    End Property
    Public Property Username() As String
        Get
            Return strUserName
        End Get
        Set(ByVal Value As String)
            strUserName = Value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return strPassWord
        End Get
        Set(ByVal Value As String)
            strPassWord = Value
        End Set
    End Property
    Public ReadOnly Property ConnectionTimeout() As Integer
        Get
            Return GG
        End Get
    End Property
#End Region
#Region "Get Points Connection"
    Public Function GetConnectionPoints(ByVal getServername As String, ByVal getDatabasename As String, ByVal getUsername As String, ByVal getPassword As String, ByRef strErrorMessage As String) As SqlClient.SqlConnection
        Dim cnn As New SqlClient.SqlConnection
        Try
            strErrorMessage = String.Empty
            If cnn.State = ConnectionState.Open Then cnn.Close()
            cnn.ConnectionString = "data source=" & getServername & ";initial catalog=" & getDatabasename & ";persist security info=False;user id=" & getUsername & " ; password=" & getPassword & "  ;workstation id=" & Servername & ";packet size=4096;Min pool size=2;Connection Timeout=100000"
            cnn.Open()

        Catch xcpsql As System.Data.SqlClient.SqlException
            Dim serrormsg As String
            Dim se As System.Data.SqlClient.SqlError

            For Each se In xcpsql.Errors
                Select Case se.Number
                    Case 17
                        serrormsg = "Wrong Or Missing Server"

                    Case 4060
                        serrormsg = "Wrong Or Missing Database"

                    Case 18456
                        serrormsg = "Wrong Or Missing User Name And The Password"

                    Case Else
                        serrormsg = se.Message

                        strErrorMessage = "Connection Failed"
                End Select
                Dim myStreamWriterLog As New FileStream(GetAppPath() & "\Log.txt", FileMode.Append, FileAccess.Write)
                Dim PrintLog As New StreamWriter(myStreamWriterLog)
                PrintLog.BaseStream.Seek(0, SeekOrigin.End)
                PrintLog.WriteLine(serrormsg & "  " & se.Number & "   " & Trim(Now.ToString("dd/MM/yyyy")) & "  " & Trim(Now.ToString("hh:mm:ss tt")))
                PrintLog.Close()
                'MsgBox(serrormsg, "SQL Server Error", se.Number)
            Next
        Catch xcpinvop As System.InvalidOperationException
            'MsgBox("Close The Conncetion First!", "Invalid Operation")
            Dim myStreamWriterLog As New FileStream(GetAppPath() & "\Log.txt", FileMode.Append, FileAccess.Write)
            Dim PrintLog As New StreamWriter(myStreamWriterLog)
            PrintLog.BaseStream.Seek(0, SeekOrigin.End)
            PrintLog.WriteLine("Close The Conncetion First!" & "   " & Trim(Now.ToString("dd/MM/yyyy")) & "  " & Trim(Now.ToString("hh:mm:ss tt")))
            PrintLog.Close()

            strErrorMessage = "Connection Failed"
        Catch xcp As System.Exception
            Dim myStreamWriterLog As New FileStream(GetAppPath() & "\Log.txt", FileMode.Append, FileAccess.Write)
            Dim PrintLog As New StreamWriter(myStreamWriterLog)
            PrintLog.BaseStream.Seek(0, SeekOrigin.End)
            PrintLog.WriteLine("Unexpected Exception" & "   " & Trim(Now.ToString("dd/MM/yyyy")) & "  " & Trim(Now.ToString("hh:mm:ss tt")))
            PrintLog.Close()
            'MsgBox("Unexpected Exception")
            strErrorMessage = "Connection Failed"
        End Try
        GetConnectionPoints = cnn
    End Function
#End Region

#Region "Get Connection"
    Public Function GetConnection(ByVal getServername As String, ByVal getDatabasename As String, ByVal getUsername As String, ByVal getPassword As String) As SqlClient.SqlConnection
        Dim cnn As New SqlClient.SqlConnection
        Try
            'Servername = getServername
            'Databasename = getDatabasename
            'Username = getUsername
            'Password = getPassword
            cnn.Close()
            cnn.ConnectionString = "data source=" & getServername & ";initial catalog=" & getDatabasename & ";persist security info=False;user id=" & getUsername & " ; password=" & getPassword & "  ;workstation id=" & getServername & ";packet size=4096;Min pool size=2;Connection Timeout=100000"
            cnn.Open()

        Catch xcpsql As System.Data.SqlClient.SqlException
            Dim serrormsg As String
            Dim se As System.Data.SqlClient.SqlError

            For Each se In xcpsql.Errors
                Select Case se.Number
                    Case 17
                        serrormsg = "Wrong Or Missing Server"
                    Case 4060
                        serrormsg = "Wrong Or Missing Database"
                    Case 18456
                        serrormsg = "Wrong Or Missing User Name And The Password"
                    Case Else
                        serrormsg = se.Message
                End Select
                CreateApp()
                Dim myStreamWriterLog As New FileStream(GetAppPath() & "\Log.txt", FileMode.Append, FileAccess.Write)
                Dim PrintLog As New StreamWriter(myStreamWriterLog)
                PrintLog.BaseStream.Seek(0, SeekOrigin.End)
                PrintLog.WriteLine(serrormsg & "  " & se.Number & "   " & Trim(Now.ToString("dd/MM/yyyy")) & "  " & Trim(Now.ToString("hh:mm:ss tt")))
                PrintLog.Close()
                End
            Next
        Catch xcpinvop As System.InvalidOperationException
            CreateApp()
            Dim myStreamWriterLog As New FileStream(GetAppPath() & "\Log.txt", FileMode.Append, FileAccess.Write)
            Dim PrintLog As New StreamWriter(myStreamWriterLog)
            PrintLog.BaseStream.Seek(0, SeekOrigin.End)
            PrintLog.WriteLine("Close The Conncetion First!" & "   " & Trim(Now.ToString("dd/MM/yyyy")) & "  " & Trim(Now.ToString("hh:mm:ss tt")))
            PrintLog.Close()
            End

        Catch xcp As System.Exception
            CreateApp()
            Dim myStreamWriterLog As New FileStream(GetAppPath() & "\Log.txt", FileMode.Append, FileAccess.Write)
            Dim PrintLog As New StreamWriter(myStreamWriterLog)
            PrintLog.BaseStream.Seek(0, SeekOrigin.End)
            PrintLog.WriteLine("Unexpected Exception" & "   " & Trim(Now.ToString("dd/MM/yyyy")) & "  " & Trim(Now.ToString("hh:mm:ss tt")))
            PrintLog.Close()
            End

        End Try
        GetConnection = cnn
    End Function

#End Region
#Region "Get Server Connection"
    Public Function GetServerConnection(ByVal getDataUploadServername As String, ByVal getDataUploadDatabasename As String, ByVal getDataUploadUsername As String, ByVal getDataUploadPassword As String) As Boolean


        Dim con As New SqlClient.SqlConnection

        Dim value As Integer
        Try
            'DataUploadServername = getDataUploadServername
            'DataUploadDatabasename = getDataUploadDatabasename
            'DataUploadUsername = getDataUploadUsername
            'DataUploadPassword = getDataUploadPassword
            con.Close()
            con.ConnectionString = "data source=" & getDataUploadServername & ";initial catalog=" & DataUploadDatabasename & ";persist security info=False;user id=" & getDataUploadUsername & " ; password=" & getDataUploadPassword & "  ;workstation id=" & getDataUploadServername & ";packet size=4096;Min pool size=2;Connection Timeout=100000"
            value = con.ConnectionTimeout

            con.Open()
            If con.State = ConnectionState.Open Then
                GetServerConnection = True
            Else
                GetServerConnection = False
            End If



        Catch xcpsql As System.Data.SqlClient.SqlException
            Dim serrormsg As String
            Dim se As System.Data.SqlClient.SqlError

            For Each se In xcpsql.Errors
                Select Case se.Number
                    Case 17
                        serrormsg = "Wrong Or Missing Server"
                    Case 4060
                        serrormsg = "Wrong Or Missing Database"
                    Case 18456
                        serrormsg = "Wrong Or Missing User Name And The Password"
                    Case Else
                        serrormsg = se.Message
                End Select
                CreateApp()
                Dim myStreamWriterLog As New FileStream(GetAppPath() & "\Log.txt", FileMode.Append, FileAccess.Write)
                Dim PrintLog As New StreamWriter(myStreamWriterLog)
                PrintLog.BaseStream.Seek(0, SeekOrigin.End)
                PrintLog.WriteLine(serrormsg & "  " & se.Number & "   " & Trim(Now.ToString("dd/MM/yyyy")) & "  " & Trim(Now.ToString("hh:mm:ss tt")))
                PrintLog.Close()
            Next
        Catch xcpinvop As System.InvalidOperationException
            CreateApp()
            Dim myStreamWriterLog As New FileStream(GetAppPath() & "\Log.txt", FileMode.Append, FileAccess.Write)
            Dim PrintLog As New StreamWriter(myStreamWriterLog)
            PrintLog.BaseStream.Seek(0, SeekOrigin.End)
            PrintLog.WriteLine("Close The Server Conncetion First!" & "   " & Trim(Now.ToString("dd/MM/yyyy")) & "  " & Trim(Now.ToString("hh:mm:ss tt")))
            PrintLog.Close()

        Catch xcp As System.Exception
            CreateApp()
            Dim myStreamWriterLog As New FileStream(GetAppPath() & "\Log.txt", FileMode.Append, FileAccess.Write)
            Dim PrintLog As New StreamWriter(myStreamWriterLog)
            PrintLog.BaseStream.Seek(0, SeekOrigin.End)
            PrintLog.WriteLine("Unexpected Exception Server Connection" & "   " & Trim(Now.ToString("dd/MM/yyyy")) & "  " & Trim(Now.ToString("hh:mm:ss tt")))
            PrintLog.Close()

        End Try
    End Function

#End Region
#Region "Create Application Path"
    Private Sub CreateApp()
        If File.Exists(GetAppPath() & "\Log.txt") = False Then
            Dim myStreamWriter As StreamWriter
            myStreamWriter = File.CreateText(GetAppPath() & "\Log.txt")
            If Not myStreamWriter Is Nothing Then
                myStreamWriter.Close()
            End If
        End If
    End Sub
#End Region
#Region "Get App Path"
    Private Function GetAppPath() As String
        Dim l_intCharPos As Integer = 0, l_intReturnPos As Integer
        Dim l_strAppPath As String
        l_strAppPath = System.Reflection.Assembly.GetExecutingAssembly.Location()
        While (1)
            l_intCharPos = InStr(l_intCharPos + 1, l_strAppPath, "\", CompareMethod.Text)
            If l_intCharPos = 0 Then
                If Right(Mid(l_strAppPath, 1, l_intReturnPos), 1) <> "\" Then

                    Return Mid(l_strAppPath, 1, l_intReturnPos) & "\"
                Else
                    Return Mid(l_strAppPath, 1, l_intReturnPos)
                End If
                Exit Function
            End If
            l_intReturnPos = l_intCharPos
        End While

    End Function

#End Region
End Class
