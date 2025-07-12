Imports System.IO

Public Class DbconForReceipt
#Region "Get Points Connection"
    Public Function GetConnectionPoints(ByVal getServername As String, ByVal getDatabasename As String, ByVal getUsername As String, ByVal getPassword As String, ByRef strErrorMessage As String) As SqlClient.SqlConnection
        Dim cnn As New SqlClient.SqlConnection
        Try
            strErrorMessage = String.Empty
            If cnn.State = ConnectionState.Open Then cnn.Close()
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
