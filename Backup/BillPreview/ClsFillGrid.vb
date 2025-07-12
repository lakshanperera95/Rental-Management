Imports System.Data.SqlClient

Public Class ClsFillGrid

    Dim qry As String 'Query for filling dataset
    Dim dsadapter As Data.SqlClient.SqlDataAdapter
    Dim dsdata As Data.DataSet
    Dim tbl_name As String 'Name of the table
    Dim dtview As Data.DataView
    Dim fld As String 'Name of the search Field
    Dim run As Boolean
    Dim current_row As Integer
    Dim Columns As Integer 'Stores the no. of columns in the table
    Dim strdtview As Data.DataView
    Dim strdtset As Data.DataSet
    Dim dtset As Data.DataSet
    Dim getdataReader As SqlDataReader








    Public Property TblQuery() As String 'Gets or Sets the table query
        Get
            Return qry
        End Get
        Set(ByVal Value As String)
            qry = Value
        End Set
    End Property
    Public Property TableName() As String 'Gets or Sets the table name
        Get
            Return tbl_name
        End Get
        Set(ByVal Value As String)
            tbl_name = Value
        End Set
    End Property
    Public Property HelpField() As String 'Gets or Sets the Field name on which help is to be given.
        Get
            Return fld
        End Get
        Set(ByVal Value As String)
            fld = Value
        End Set
    End Property
    Public Function DataUpdate(ByVal strsql As String, ByVal getServername As String, ByVal getDatabasename As String, ByVal getUsername As String, ByVal getPassword As String, ByRef ConMessage As String) As Boolean
        Dim objconcetion As New ClsConnection
        Dim cmdcommand As New Data.SqlClient.SqlCommand
        cmdcommand.Connection = objconcetion.GetConnectionPoints(getServername, getDatabasename, getUsername, getPassword, strConMessage)
        If strConMessage = String.Empty Then
            cmdcommand.CommandTimeout = 10000
            cmdcommand.CommandText = strsql
            getdatasetReturn = cmdcommand.ExecuteReader
        Else
            ConMessage = strConMessage
            strConMessage = String.Empty
        End If
    End Function
    Public Function UpdateIDS(ByVal strsql As String, ByVal getServername As String, ByVal getDatabasename As String, ByVal getUsername As String, ByVal getPassword As String, ByRef ConMessage As String) As Boolean
        Dim objconcetion As New ClsConnection
        Dim cmdcommand As New Data.SqlClient.SqlCommand
        cmdcommand.Connection = objconcetion.GetConnectionPoints(getServername, getDatabasename, getUsername, getPassword, strConMessage)
        If strConMessage = String.Empty Then
            cmdcommand.CommandText = strsql
            cmdcommand.ExecuteNonQuery()
        Else
            ConMessage = strConMessage
            strConMessage = String.Empty
        End If
    End Function
    Public Function getRecordsetForPrintPoints(ByVal strsql As String, ByVal getServername As String, ByVal getDatabasename As String, ByVal getUsername As String, ByVal getPassword As String, ByRef ConMessage As String) As Boolean
        Dim objconcetion As New ClsConnection
        Dim cmdcommand As New Data.SqlClient.SqlCommand
        cmdcommand.Connection = objconcetion.GetConnectionPoints(getServername, getDatabasename, getUsername, getPassword, strConMessage)
        If strConMessage = String.Empty Then
            cmdcommand.CommandText = strsql
            getdatasetReturn = cmdcommand.ExecuteReader
        Else
            ConMessage = strConMessage
            strConMessage = String.Empty
        End If
    End Function
    Public Function GetRecordset(ByVal TblQuery As String, ByVal TableName As String, ByVal HelpField As String, ByVal getServername As String, ByVal getDatabasename As String, ByVal getUsername As String, ByVal getPassword As String) As Boolean

        Dim objconcetion As New ClsConnection
        Dim cmdcommand As New Data.SqlClient.SqlCommand
        cmdcommand.Connection = objconcetion.GetConnection(getServername, getDatabasename, getUsername, getPassword)
        dsadapter = New Data.SqlClient.SqlDataAdapter(TblQuery, cmdcommand.Connection)
        dsdata = New Data.DataSet
        dsadapter.Fill(dsdata, TableName)
        dtview = New Data.DataView(dsdata.Tables(TableName))
        Columns = dsdata.Tables(TableName).Columns.Count
        getdataview = dtview
    End Function
    Public Function getRecordsetForPrint(ByVal strsql As String, ByVal getServername As String, ByVal getDatabasename As String, ByVal getUsername As String, ByVal getPassword As String) As Boolean
        Dim objconcetion As New ClsConnection
        Dim cmdcommand As New Data.SqlClient.SqlCommand
        cmdcommand.Connection = objconcetion.GetConnection(getServername, getDatabasename, getUsername, getPassword)
        cmdcommand.CommandText = strsql
        getdatasetReturn = cmdcommand.ExecuteReader
    End Function
    Public Property getdataview() As Data.DataView  'Gets or Sets the Field name on which help is to be given.
        Get
            Return strdtview
        End Get
        Set(ByVal Value As Data.DataView)
            strdtview = Value
        End Set
    End Property
    Public Property getdatasetReturn() As Data.SqlClient.SqlDataReader 'Gets or Sets the Field name on which help is to be given.
        Get
            Return getdataReader
        End Get
        Set(ByVal Value As Data.SqlClient.SqlDataReader)
            getdataReader = Value
        End Set
    End Property

    Public Function Print(ByVal strGetReceipt As String, ByVal StrIid As String, ByVal TxtRecpt As TextBox, ByVal UserName As String, ByVal BillDate As String)
        Module1.Print_HeaderSection(strGetReceipt, StrIid, TxtRecpt, UserName, BillDate)

    End Function

    Public Function ModuleReader(ByVal strGetReceipt As String, ByVal strCust As String, ByVal strSman As String, ByVal strOrderReceipt As String, ByVal Loca As String, ByVal Unit As String, ByVal TxtB As TextBox, ByVal Server As String, ByVal Database As String, ByVal Password As String)
        Module1.Bill_Print(strGetReceipt, strCust, strSman, strOrderReceipt, Loca, Unit, TxtB, Server, Database, Password)

    End Function

    Public Function Print_Middle(ByVal dblAmount As Double, ByVal dblUnit_Price As Double, ByVal dblQty As Double, ByVal strPlu As String, ByVal strDescription As String, ByVal getIid As String, ByVal TxtRecpt As TextBox)

        Module1.Print_Middle(dblAmount, dblUnit_Price, dblQty, strPlu, strDescription, getIid, TxtRecpt)



    End Function

    Public Function Print_Bottom(ByVal getstrcust As String, ByVal getAllSignatureTrue As Boolean, ByVal DiscVal As Double, ByVal TxtB AS TextBox)
        Module1.Print_Bottom(getstrcust, getAllSignatureTrue, DiscVal, TxtB)


    End Function

End Class
