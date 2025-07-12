Imports System.IO
Imports Inventory





Module Module1
#Region "get Data For Print"
    Public getServername As String = String.Empty
    Public getDatabasename As String = String.Empty
    Public getUsername As String = String.Empty
    Public getPassword As String = String.Empty
    Public getPrint_Type As Integer = 0
    Public intgetPrintSleep As Integer = 0
    Public strCRM_Status As String = String.Empty
    Public strServerCustBalance As Double = 0
    Public getConnectionMessage As String
    Public getShowDisc As String = String.Empty
    Public getErrorLog As String = String.Empty
    Public Oni_Date As String = String.Empty
    Public Oni_Time As String = String.Empty
    'Dim objRecpt As New Inventory.frmDisplayReceipt
    Public TxtRecpt As TextBox
    Dim NoQty As Double
    Public Oni_Unit As String = String.Empty
    Dim PrintBillTime As String = String.Empty
    Dim NoOfQty As Double
    Dim NoOfItemSold As Double
    Dim ReturnUserName As String
    Dim objInvenCon As clsLibrary.clsSplash
    Dim ReturnReceipt_No As String
    Public getPrintBrand As String = String.Empty

    Public get_Head1 As String = String.Empty
    Public get_Head2 As String = String.Empty
    Public get_Head3 As String = String.Empty
    Public get_Head4 As String = String.Empty
    Public get_Head5 As String = String.Empty
    Public get_Head6 As String = String.Empty
    Public get_Head7 As String = String.Empty
    Public get_Tail1 As String = String.Empty
    Public get_Tail2 As String = String.Empty
    Public get_Tail3 As String = String.Empty
    Public get_Tail4 As String = String.Empty
    Public get_Tail5 As String = String.Empty
    Public get_Tail6 As String = String.Empty
    Public get_Tail7 As String = String.Empty
    Public get_Tail8 As String = String.Empty
    Public get_Tail9 As String = String.Empty
    Public get_Tail10 As String = String.Empty
    Public Oni_NoQty As String = "0"
    Public getShowTime As String = String.Empty
    Private ConMessage As String = String.Empty
    Public get_Location As String = String.Empty
    Public getSusBillPrint As String = String.Empty
    Public Property strConMessage() As String
        Get
            Return ConMessage
        End Get
        Set(ByVal Value As String)
            ConMessage = Value
        End Set
    End Property




    Public Sub Bill_Print(ByVal strGetReceipt As String, ByVal strCust As String, ByVal strSman As String, ByVal strOrderReceipt As String, ByVal Loca As String, ByVal Unit As String, ByVal TextB As TextBox, ByVal Server As String, ByVal Database As String, ByVal Password As String)
        Dim dblRecourd_Count As Double
        Dim dblBill_Count As Double
        Dim strSql As String
        Dim ReturnIid As String
        Dim ReturnItem_Code As String
        Dim ReturnItem_Descrip As String
        Dim ReturnUnit_Price As Double
        Dim ReturnQty As Double
        Dim ReturnReceipt_No As String
        Dim ReturnSalesMan As String
        Dim ReturnDiscount As Double
        Dim ReturnDis As String
        Dim ReturnCustomer As String
        Dim ReturnBillDate As String
        Dim ReturnBillTime As String
        Dim ReturnUserName As String
        Dim ReturnAmount As Double
        Dim ExeReceipt As String
        Dim OldExeReceipt As String
        Dim SavingDiscVal As Double = 0
        Dim ReturnMakr_Price As Double = 0
        Dim OldSalesman As String = String.Empty
        Dim AllSignatureTrue As Boolean = False
        Dim User_Name As String = String.Empty

        '============
        dblRecourd_Count = 1
        dblBill_Count = 0
        NoQty = 0
        OldExeReceipt = String.Empty
        Dim Y As String
        Try
            Dim objSelectGrid As New ClsFillGrid
            Dim PrintData As Data.SqlClient.SqlDataReader
            getPrint_Type = 42
            getServername = Server
            getDatabasename = Database
            getUsername = "sa"
            getPassword = Password
            Oni_Unit = Unit
            get_Location = Loca
            strSql = "SELECT DISTINCT UserName AS [User_Name] FROM  DayEnd_Pos_TransactionForReport WHERE Loca='" & get_Location & "' AND  ((Qty<>0 AND Amount<>0) OR Iid='BAL' OR Iid='CSH' OR Iid='SBTT' OR Iid='CRD' ) AND Receipt_No='" & Trim(strGetReceipt) & "'  And Unit='" & Trim(Oni_Unit) & "' AND BillDate='" & Trim(strSman) & "' AND ReportID='" & Trim(strCust) & "' "
            objSelectGrid.getRecordsetForPrint(strSql, getServername, getDatabasename, getUsername, getPassword)
            PrintData = objSelectGrid.getdatasetReturn
            Do While PrintData.Read()
                User_Name = Trim(PrintData("User_Name"))
            Loop

            '=============
            Call Print_HeaderSection(strGetReceipt, "T", TextB, User_Name, strSman)
            '=============

            strSql = "SELECT Iid,Item_Code,Item_Descrip,Unit_Price,Qty,Amount,Receipt_No,SalesMan,Discount,Dis,Customer,BillDate,BillTime,UserName,ExchangeReceipt,0 Mark_Price FROM  DayEnd_Pos_TransactionForReport WHERE Loca='" & get_Location & "' AND  ((Qty<>0 AND Amount<>0) OR Iid='BAL' OR Iid='CSH' OR Iid='SBTT' OR Iid='CRD' ) AND Receipt_No='" & Trim(strGetReceipt) & "'  And Unit='" & Trim(Oni_Unit) & "' ORDER BY Id_No"
            objSelectGrid.getRecordsetForPrint(strSql, getServername, getDatabasename, getUsername, getPassword)
            PrintData = objSelectGrid.getdatasetReturn
            Do While PrintData.Read()
                ReturnIid = Trim(PrintData("Iid"))
                ReturnItem_Code = Trim(PrintData("Item_Code"))
                ReturnItem_Descrip = Trim(PrintData("Item_Descrip"))
                ReturnUnit_Price = PrintData("Unit_Price")
                ReturnQty = PrintData("Qty")
                ReturnReceipt_No = Trim(PrintData("Receipt_No"))
                ReturnSalesMan = Trim(PrintData("SalesMan"))
                ReturnDiscount = PrintData("Discount")
                ReturnDis = Trim(PrintData("Dis"))
                ReturnCustomer = Trim(PrintData("Customer"))
                ReturnBillDate = Trim(PrintData("BillDate"))
                ReturnBillTime = Trim(PrintData("BillTime"))
                PrintBillTime = Trim(PrintData("BillTime"))
                ReturnUserName = Trim(PrintData("UserName"))
                ReturnAmount = Trim(PrintData("Amount"))
                ExeReceipt = Trim(PrintData("ExchangeReceipt"))
                ReturnMakr_Price = PrintData("Mark_Price")
                If getPrint_Type = 33 Then
                    If dblBill_Count = 10 Then
                        getSleep()
                        dblBill_Count = 0
                    End If
                End If
                If OldExeReceipt = ExeReceipt Then
                    ExeReceipt = String.Empty
                Else
                    OldExeReceipt = ExeReceipt
                End If
                If OldSalesman = ReturnSalesMan Then
                    ReturnSalesMan = String.Empty
                Else
                    OldSalesman = ReturnSalesMan
                End If

                If (ReturnIid = "001" Or ReturnIid = "002" Or ReturnIid = "003" Or ReturnIid = "G01") Then
                    Y = StrDup(2 - Len(Strings.Right(Trim(Str(dblRecourd_Count)), 2)), "0") & (Strings.Right(Trim(Str(dblRecourd_Count)), 2))
                    If ExeReceipt <> "" Then
                        If Strings.Left(ExeReceipt, 2) = "CR" Then
                            Print_Middle(0, 0, 0, String.Empty, "Credit Receipt" & "   " & ExeReceipt, "ExchangeReceipt", TextB)
                        Else
                            Print_Middle(0, 0, 0, String.Empty, "Exchange Receipt" & "   " & ExeReceipt, "ExchangeReceipt", TextB)
                        End If
                    End If
                    If ReturnSalesMan <> String.Empty And UCase(ReturnSalesMan) <> "DEFAULT" And (ReturnIid = "001" Or ReturnIid = "002") Then
                        Print_Middle(0, 0, 0, String.Empty, "   S/M " & "   " & ReturnSalesMan, "Salesman", TextB)
                    End If
                    If getPrint_Type = 42 Then
                        If ReturnMakr_Price > 0 Then
                            If getShowDisc = "T" Then
                                Print_Middle((ReturnMakr_Price * ReturnQty), ReturnMakr_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 27), "Item", TextB)
                                If ((ReturnMakr_Price * ReturnQty) - (ReturnUnit_Price * ReturnQty)) <> 0 Then
                                    Print_Middle(-((ReturnMakr_Price * ReturnQty) - (ReturnUnit_Price * ReturnQty)), 0, 0, String.Empty, "SPECIAL DISCOUNT", "ItemDiscount", TextB)
                                End If
                            Else
                                Print_Middle(ReturnAmount + PrintData("Discount"), ReturnMakr_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 27), "Item", TextB)
                            End If
                        Else
                            Print_Middle(ReturnAmount + PrintData("Discount"), ReturnUnit_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 27), "Item", TextB)
                        End If
                    ElseIf getPrint_Type = 33 Then
                        If ReturnMakr_Price > 0 Then
                            If getShowDisc = "T" Then
                                Print_Middle((ReturnMakr_Price * ReturnQty), ReturnMakr_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 26), "Item", TextB)
                                If ((ReturnMakr_Price * ReturnQty) - (ReturnUnit_Price * ReturnQty)) <> 0 Then
                                    Print_Middle(-((ReturnMakr_Price * ReturnQty) - (ReturnUnit_Price * ReturnQty)), 0, 0, String.Empty, "SPECIAL DISCOUNT", "ItemDiscount", TextB)
                                End If
                            Else
                                Print_Middle(ReturnAmount + PrintData("Discount"), ReturnMakr_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 26), "Item", TextB)
                            End If
                        Else
                            Print_Middle(ReturnAmount + PrintData("Discount"), ReturnUnit_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 26), "Item", TextB)
                        End If
                    End If
                    dblRecourd_Count = dblRecourd_Count + 1
                    dblBill_Count = dblBill_Count + 1
                    NoQty = NoQty + ReturnQty
                    If ReturnIid = "003" Then
                        AllSignatureTrue = True
                    End If
                    If ReturnIid = "001" And ReturnMakr_Price > 0 Then
                        SavingDiscVal = SavingDiscVal + ((ReturnMakr_Price * ReturnQty) - (ReturnAmount + ReturnDiscount))
                    End If
                ElseIf (ReturnIid = "R01" Or ReturnIid = "R02" Or ReturnIid = "R03" Or ReturnIid = "G02") Then
                    Y = StrDup(2 - Len(Strings.Right(Trim(Str(dblRecourd_Count)), 2)), "0") & (Strings.Right(Trim(Str(dblRecourd_Count)), 2))
                    If ExeReceipt <> "" Then
                        If Strings.Left(ExeReceipt, 2) = "CR" Then
                            Print_Middle(0, 0, 0, String.Empty, "Credit Receipt" & "   " & ExeReceipt, "ExchangeReceipt", TextB)
                        Else
                            Print_Middle(0, 0, 0, String.Empty, "Exchange Receipt" & "   " & ExeReceipt, "ExchangeReceipt", TextB)
                        End If
                    End If
                    If ReturnSalesMan <> String.Empty And UCase(ReturnSalesMan) <> "DEFAULT" And (ReturnIid = "R01" Or ReturnIid = "R02") Then
                        Print_Middle(0, 0, 0, String.Empty, "   S/M " & "   " & ReturnSalesMan, "Salesman", TextB)
                    End If
                    If getPrint_Type = 42 Then
                        If ReturnMakr_Price > 0 Then
                            If getShowDisc = "T" Then
                                Print_Middle((ReturnMakr_Price * ReturnQty), ReturnMakr_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 18) & " " & "-EXCHANGE", "Item", TextB)
                                If Math.Abs((ReturnMakr_Price * ReturnQty) - (ReturnUnit_Price * ReturnQty)) <> 0 Then
                                    Print_Middle(Math.Abs((ReturnMakr_Price * ReturnQty) - (ReturnUnit_Price * ReturnQty)), 0, 0, String.Empty, "SPECIAL DISCOUNT", "ItemDiscount", TextB)
                                End If
                            Else
                                Print_Middle(ReturnAmount + PrintData("Discount"), ReturnMakr_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 18) & " " & "-EXCHANGE", "Item", TextB)
                            End If
                        Else
                            Print_Middle(ReturnAmount + PrintData("Discount"), ReturnUnit_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 18) & " " & "-EXCHANGE", "Item", TextB)
                        End If
                    ElseIf getPrint_Type = 33 Then
                        If ReturnMakr_Price > 0 Then
                            If getShowDisc = "T" Then
                                Print_Middle((ReturnMakr_Price * ReturnQty), ReturnMakr_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 16) & " " & "-EXCHANGE", "Item", TextB)
                                If Math.Abs((ReturnMakr_Price * ReturnQty) - (ReturnUnit_Price * ReturnQty)) <> 0 Then
                                    Print_Middle(Math.Abs((ReturnMakr_Price * ReturnQty) - (ReturnUnit_Price * ReturnQty)), 0, 0, String.Empty, "SPECIAL DISCOUNT", "ItemDiscount", TextB)
                                End If
                            Else
                                Print_Middle(ReturnAmount + PrintData("Discount"), ReturnMakr_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 16) & " " & "-EXCHANGE", "Item", TextB)
                            End If
                        Else
                            Print_Middle(ReturnAmount + PrintData("Discount"), ReturnUnit_Price, ReturnQty, ReturnItem_Code, Y & " " & Strings.Left(ReturnItem_Code, 10) & " " & Strings.Left(ReturnItem_Descrip, 16) & " " & "-EXCHANGE", "Item", TextB)
                        End If
                    End If
                    dblRecourd_Count = dblRecourd_Count + 1
                    dblBill_Count = dblBill_Count + 1
                    If ReturnIid = "R03" Then
                        AllSignatureTrue = True
                    End If
                    If ReturnIid = "R01" And ReturnMakr_Price > 0 Then
                        SavingDiscVal = SavingDiscVal + (((ReturnMakr_Price * ReturnQty) - (ReturnAmount + ReturnDiscount)))
                    End If
                ElseIf ReturnIid = "004" Then
                    If Strings.Right(ReturnDis, 1) = "%" Then
                        Print_Middle(ReturnAmount, 0, 0, String.Empty, "DISCOUNT" & " " & ReturnDis, "ItemDiscount", TextB)
                    Else
                        Print_Middle(ReturnAmount, 0, 0, String.Empty, "DISCOUNT", "ItemDiscount", TextB)
                    End If
                    dblBill_Count = dblBill_Count + 1
                    SavingDiscVal = SavingDiscVal - ReturnAmount
                ElseIf ReturnIid = "005" Then
                    If Strings.Right(ReturnDis, 1) = "%" Then
                        Print_Middle(ReturnAmount, 0, 0, String.Empty, ReturnItem_Descrip & " " & ReturnDis, "SubTotalDiscount", TextB)
                    Else
                        Print_Middle(ReturnAmount, 0, 0, String.Empty, ReturnItem_Descrip, "SubTotalDiscount", TextB)
                    End If
                    dblBill_Count = dblBill_Count + 1
                    SavingDiscVal = SavingDiscVal - ReturnAmount
                ElseIf ReturnIid = "SBTT" Then
                    Print_Middle(ReturnAmount, 0, 0, String.Empty, ReturnItem_Descrip, "SubTotal", TextB)
                    dblBill_Count = dblBill_Count + 1
                ElseIf ReturnIid = "CSH" Then
                    Print_Middle(ReturnAmount, 0, 0, String.Empty, ReturnItem_Descrip, "Cash", TextB)
                    dblBill_Count = dblBill_Count + 1
                ElseIf ReturnIid = "CRD" Then
                    Print_Middle(ReturnAmount, 0, 0, String.Empty, ReturnItem_Descrip, "Credit", TextB)
                    dblBill_Count = dblBill_Count + 1
                ElseIf ReturnIid = "BAL" Then
                    Print_Middle(ReturnAmount, 0, 0, String.Empty, ReturnItem_Descrip, "Balance", TextB)
                    dblBill_Count = dblBill_Count + 1

                End If
            Loop
            '=============
            Call Print_Bottom(strCust, AllSignatureTrue, SavingDiscVal, TxtRecpt)
            SavingDiscVal = 0
            '=============
        Catch ex As Exception
            Dim myStreamWriterLog As New FileStream(getErrorLog, FileMode.Append, FileAccess.Write)
            Dim PrintLog As New StreamWriter(myStreamWriterLog)
            PrintLog.BaseStream.Seek(0, SeekOrigin.End)
            PrintLog.WriteLine(ex.Message & " frmFront-Bill Print  " & Trim(Oni_Date) & "  " & Trim(Oni_Time))
            PrintLog.Close()

        End Try
    End Sub
#End Region

#Region "Sleep"
    Public Sub getSleep()
        System.Threading.Thread.Sleep(intgetPrintSleep)
    End Sub
#End Region

#Region "Print Bottom"
    Public Sub Print_Bottom(ByVal getstrcust As String, ByVal getAllSignatureTrue As Boolean, ByVal DiscVal As Double, ByVal TxtRecpts As TextBox)
        ' For Each item As Control In objRecpt.Controls


        'If TypeOf item Is TextBox Then TxtRecpt = item


        'Next
        TxtRecpt = TxtRecpts
        Try
            Dim Xx As Integer
            NoQty = 0
            If Format(DiscVal, "0.00") <> 0 Then
                For Xx = 0 To 0
                    TxtRecpt.Text += vbCrLf
                Next Xx
                If getPrintBrand = "BIXOLON" And getPrint_Type = 33 Then
                    TxtRecpt.Text += (Space(1) + "Save Value : " + Format(DiscVal, "0.00")) + vbCrLf
                Else
                    TxtRecpt.Text += ("Save Value : " + Format(DiscVal, "0.00")) + vbCrLf
                End If
                For Xx = 0 To 0
                    TxtRecpt.Text += vbCrLf
                Next Xx
            End If
            If getAllSignatureTrue = True Then
                For Xx = 0 To 1
                    TxtRecpt.Text += vbCrLf
                Next Xx
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim("------------------------------"), getPrint_Type))) / 2) + Strings.Left(Trim("------------------------------"), getPrint_Type)) + vbCrLf
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim("Signature"), getPrint_Type))) / 2) + Strings.Left(Trim("Signature"), getPrint_Type)) + vbCrLf
                For Xx = 0 To 0
                    TxtRecpt.Text += vbCrLf
                Next Xx
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(PrintBillTime), getPrint_Type))) / 2) + Strings.Left(Trim(PrintBillTime), getPrint_Type)) + vbCrLf
                PrintBillTime = String.Empty

                For Xx = 0 To 0
                    TxtRecpt.Text += vbCrLf
                Next Xx
            Else

                If get_Tail1 <> String.Empty Then
                    TxtRecpt.Text += (Space((getPrint_Type - Len(Trim(get_Tail1))) / 2) + Trim(get_Tail1)) + vbCrLf
                End If
                If get_Tail2 <> String.Empty Then
                    TxtRecpt.Text += (Space((getPrint_Type - Len(Trim(get_Tail2))) / 2) + Trim(get_Tail2)) + vbCrLf
                End If
                If get_Tail3 <> String.Empty Then
                    TxtRecpt.Text += (Space((getPrint_Type - Len(Trim(get_Tail3))) / 2) + Trim(get_Tail3)) + vbCrLf
                End If
                If get_Tail4 <> String.Empty Then
                    TxtRecpt.Text += (Space((getPrint_Type - Len(Trim(get_Tail4))) / 2) + Trim(get_Tail4)) + vbCrLf
                End If
                If get_Tail5 <> String.Empty Then
                    TxtRecpt.Text += (Space((getPrint_Type - Len(Trim(get_Tail5))) / 2) + Trim(get_Tail5)) + vbCrLf
                End If
                If get_Tail6 <> String.Empty Then
                    TxtRecpt.Text += (Space((getPrint_Type - Len(Trim(get_Tail6))) / 2) + Trim(get_Tail6)) + vbCrLf
                End If
                If get_Tail7 <> String.Empty Then
                    TxtRecpt.Text += (Space((getPrint_Type - Len(Trim(get_Tail7))) / 2) + Trim(get_Tail7)) + vbCrLf
                End If
                If get_Tail8 <> String.Empty Then
                    TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(get_Tail8), getPrint_Type))) / 2) + Strings.Left(Trim(get_Tail8), getPrint_Type)) + vbCrLf
                End If
                If get_Tail9 <> String.Empty Then
                    TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(get_Tail9), getPrint_Type))) / 2) + Strings.Left(Trim(get_Tail9), getPrint_Type)) + vbCrLf
                End If
                If get_Tail10 <> String.Empty Then
                    TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(get_Tail10), getPrint_Type))) / 2) + Strings.Left(Trim(get_Tail10), getPrint_Type)) + vbCrLf
                End If

                Dim CompanyName As String
                CompanyName = "System by onimta IT"
                TxtRecpt.Text += (Space((getPrint_Type - Len(Trim(CompanyName))) / 2) + Trim(CompanyName)) + vbCrLf

                Dim CompanyTel As String
                CompanyTel = "TELE:011 2509803"
                TxtRecpt.Text += (Space((getPrint_Type - Len(Trim(CompanyTel))) / 2) + Trim(CompanyTel)) + vbCrLf

            End If

        Catch ex As Exception

            Dim myStreamWriterLog As New FileStream(getErrorLog, FileMode.Append, FileAccess.Write)
            Dim PrintLog As New StreamWriter(myStreamWriterLog)
            PrintLog.BaseStream.Seek(0, SeekOrigin.End)
            PrintLog.WriteLine(ex.Message & " Print Middle  " & Trim(Oni_Date) & "  " & Trim(Oni_Time))
            PrintLog.Close()

        End Try

    End Sub
#End Region
#Region "Print Middle"
    Public Sub Print_Middle(ByVal dblAmount As Double, ByVal dblUnit_Price As Double, ByVal dblQty As Double, ByVal strPlu As String, ByVal strDescription As String, ByVal getIid As String, ByVal TxtRecpts As TextBox)
        Try
            Dim strItemPriceDet As String
            strItemPriceDet = String.Empty
            TxtRecpt = TxtRecpts
            If getIid = "Item" Then
                TxtRecpt.Text += (strDescription) + vbCrLf
                strItemPriceDet = String.Empty
                strItemPriceDet = Space(2) & strPlu
                Dim ssaa As Double
                Dim ssaa1 As Double
                Dim ssaa2 As Double
                Dim ssaa3 As Double
                Dim ssaa4 As Double
                Dim ssaa5 As Double
                Dim dd As String 'Amount
                Dim dd2 As String 'Unit Price
                dd = Format(dblAmount, "#0.00")
                dd2 = Format((dblUnit_Price), "#0.00")
                ssaa = Len(Strings.Left(strItemPriceDet, 11)) 'Len Item Code
                ssaa1 = Len(Trim(dd))                         'Len Amount   
                ssaa2 = Len(Trim(dd2))                        'Len Unit Price  
                ssaa4 = Len(Trim(CStr(dblQty)))                'Len Qty  
                If getPrint_Type = 42 Then
                    ssaa3 = (39 - ssaa - ssaa1 - ssaa2 - ssaa4)
                    ssaa5 = (39 - ssaa - ssaa1 - ssaa2 - ssaa4)
                    strItemPriceDet = Space(16 - ssaa2) & Format((dblUnit_Price), "#0.00") & "X" & Space(10 - ssaa4) & dblQty & Space(15 - ssaa1) & Format(dblAmount, "#0.00")
                Else
                    ssaa3 = (30 - ssaa - ssaa1 - ssaa2 - ssaa4)
                    ssaa5 = (30 - ssaa - ssaa1 - ssaa2 - ssaa4)
                    strItemPriceDet = Space(14 - ssaa2) & Format((dblUnit_Price), "#0.00") & "X" & Space(8 - ssaa4) & dblQty & Space(10 - ssaa1) & Format(dblAmount, "#0.00")
                End If
                TxtRecpt.Text += (strItemPriceDet) + vbCrLf
            ElseIf getIid = "ItemDiscount" Then
                TxtRecpt.Text += (Space(2) + Trim(strDescription) + Space(getPrint_Type - 2 - Len(Trim(strDescription)) - Len(Format(dblAmount, "0.00"))) + Format(dblAmount, "0.00")) + vbCrLf
            ElseIf getIid = "SubTotalDiscount" Then
                TxtRecpt.Text += (Trim(strDescription) + Space(getPrint_Type - Len(Trim(strDescription)) - Len(Format(dblAmount, "0.00"))) + Format(dblAmount, "0.00")) + vbCrLf
            ElseIf getIid = "SubTotal" Then
                TxtRecpt.Text += (StrDup(getPrint_Type, "-")) + vbCrLf
                If getPrintBrand = "BIXOLON" And getPrint_Type = 33 Then
                    TxtRecpt.Text += (Space(1) + Trim(strDescription) + Space((getPrint_Type) - Len(Trim(strDescription)) - Len(Format(dblAmount, "0.00"))) + Format(dblAmount, "0.00")) + vbCrLf
                Else
                    TxtRecpt.Text += (Trim(strDescription) + Space(getPrint_Type - Len(Trim(strDescription)) - Len(Format(dblAmount, "0.00"))) + Format(dblAmount, "0.00")) + vbCrLf
                End If
            ElseIf getIid = "Cash" Or getIid = "Credit" Then
                TxtRecpt.Text += (Trim(strDescription) + Space(getPrint_Type - Len(Trim(strDescription)) - Len(Format(dblAmount, "0.00"))) + Format(dblAmount, "0.00")) + vbCrLf
            ElseIf getIid = "Balance" Then
                TxtRecpt.Text += (Trim(strDescription) + Space(getPrint_Type - Len(Trim(strDescription)) - Len(Format(dblAmount, "0.00"))) + Format(dblAmount, "0.00")) + vbCrLf
            ElseIf getIid = "ExchangeReceipt" Then
                TxtRecpt.Text += (strDescription) + vbCrLf
            End If
        Catch ex As Exception
            Dim myStreamWriterLog As New FileStream(getErrorLog, FileMode.Append, FileAccess.Write)
            Dim PrintLog As New StreamWriter(myStreamWriterLog)
            PrintLog.BaseStream.Seek(0, SeekOrigin.End)
            PrintLog.WriteLine(ex.Message & " Print Middle  " & Trim(Oni_Date) & "  " & Trim(Oni_Time))
            PrintLog.Close()
        End Try
    End Sub
#End Region
#Region "Print Header Section"
    Public Sub Print_HeaderSection(ByVal strReceiptNo As String, ByVal strIid As String, ByVal txtBox As TextBox, ByVal ReturnReceipt_No As String, ByVal BillDate As String)
        Try

            TxtRecpt = txtBox
            If get_Head1 <> String.Empty Then
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(get_Head1), getPrint_Type))) / 2) + Strings.Left(Trim(get_Head1), getPrint_Type)) + vbCrLf
            End If
            If get_Head2 <> String.Empty Then
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(get_Head2), getPrint_Type))) / 2) + Strings.Left(Trim(get_Head2), getPrint_Type)) + vbCrLf
            End If
            If get_Head3 <> String.Empty Then
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(get_Head3), getPrint_Type))) / 2) + Strings.Left(Trim(get_Head3), getPrint_Type)) + vbCrLf
            End If
            If get_Head4 <> String.Empty Then
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(get_Head4), getPrint_Type))) / 2) + Strings.Left(Trim(get_Head4), getPrint_Type)) + vbCrLf
            End If
            If get_Head5 <> String.Empty Then
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(get_Head5), getPrint_Type))) / 2) + Strings.Left(Trim(get_Head5), getPrint_Type)) + vbCrLf
            End If
            If get_Head6 <> String.Empty Then
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(get_Head6), getPrint_Type))) / 2) + Strings.Left(Trim(get_Head6), getPrint_Type)) + vbCrLf
            End If
            If get_Head7 <> String.Empty Then
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left(Trim(get_Head7), getPrint_Type))) / 2) + Strings.Left(Trim(get_Head7), getPrint_Type)) + vbCrLf
            End If
            If getPrint_Type = 33 Then
                TxtRecpt.Text += ("Date:" + BillDate + Space(33 - 24 - Len(Strings.Left(Trim(ReturnReceipt_No), 7))) + "Operator:" + Strings.Left(Trim(ReturnReceipt_No), 7)) + vbCrLf
                If strIid = "E" Then
                    TxtRecpt.Text += ("Exchange No:" + Trim(strReceiptNo) + Space(33 - 16 - Len(Trim(strReceiptNo)) - Len(strReceiptNo)) + "Unit:" + Space(7 - Len(Trim(Oni_Unit))) + Trim(Oni_Unit)) + vbCrLf
                Else
                    TxtRecpt.Text += ("Order No:" + Trim(strReceiptNo) + Space(33 - 13 - Len(Trim(strReceiptNo)) - Len(strReceiptNo)) + "Unit:" + Space(7 - Len(Trim(Oni_Unit))) + Trim(Oni_Unit)) + vbCrLf
                End If
                TxtRecpt.Text += (StrDup(getPrint_Type, "-")) + vbCrLf
            ElseIf getPrint_Type = 42 Then
                TxtRecpt.Text += ("Date    : " + BillDate + Space(42 - 30 - Len(Trim(ReturnReceipt_No))) + "Operator:" + Space(1) + Strings.Left(Trim(ReturnReceipt_No), 10)) + vbCrLf
                If strIid = "E" Then
                    TxtRecpt.Text += ("Exchange No:" + Trim(strReceiptNo) + Space(42 - 15 - Len(Trim(strReceiptNo)) - Len(strReceiptNo)) + "Unit:" + Space(1) + Trim(Oni_Unit)) + vbCrLf
                Else
                    TxtRecpt.Text += ("Order No:   " + Trim(strReceiptNo) + Space(42 - 20 - Len(Trim(strReceiptNo)) - Len(strReceiptNo)) + "Unit    :" + Space(7 - Len(Trim(Oni_Unit))) + Trim(Oni_Unit)) + vbCrLf
                End If
                TxtRecpt.Text += (StrDup(getPrint_Type, "-")) + vbCrLf
            End If
            If strIid = "T" Then
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left("DUPLICATE COPY", getPrint_Type))) / 2) + Strings.Left(Trim("DUPLICATE COPY"), getPrint_Type)) + vbCrLf
                TxtRecpt.Text += (StrDup(getPrint_Type, "-")) + vbCrLf
            End If
            If strIid = "S" Then
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left("ORDER CANCEL", getPrint_Type))) / 2) + Strings.Left(Trim("ORDER CANCEL"), getPrint_Type)) + vbCrLf
                TxtRecpt.Text += (StrDup(getPrint_Type, "-")) + vbCrLf
            End If
            If strIid = "E" Then
                TxtRecpt.Text += (Space((getPrint_Type - Len(Strings.Left("SUSPENDED RECEIPT", getPrint_Type))) / 2) + Strings.Left(Trim("SUSPENDED RECEIPT"), getPrint_Type)) + vbCrLf
                If strIid = "E" And getSusBillPrint = "F" Then
                Else
                    TxtRecpt.Text += (StrDup(getPrint_Type, "-")) + vbCrLf
                End If
            End If
            If strIid = "E" And getSusBillPrint = "F" Then
            Else
                If getPrint_Type = 33 Then
                    TxtRecpt.Text += ("Ln" + Space(2) + "Product" + Space(3) + "Price" + Space(3) + "Qty" + Space(2) + "Amount") + vbCrLf
                Else
                    TxtRecpt.Text += ("Ln" + Space(2) + "Product" + Space(3) + "Price" + Space(5) + "Qty" + Space(9) + "Amount") + vbCrLf
                End If
                TxtRecpt.Text += (StrDup(getPrint_Type, "-")) + vbCrLf
            End If
        Catch ex As Exception
            Dim myStreamWriterLog As New FileStream(getErrorLog, FileMode.Append, FileAccess.Write)
            Dim PrintLog As New StreamWriter(myStreamWriterLog)
            PrintLog.BaseStream.Seek(0, SeekOrigin.End)
            PrintLog.WriteLine(ex.Message & " frmBillView-PrintHeader  " & Trim(Oni_Date) & "  " & Trim(Oni_Time))
            PrintLog.Close()
        End Try
    End Sub

#End Region

End Module
