Imports System
Imports System.Windows.Forms
Imports System.Linq
Imports System.Xml.Linq
Imports System.IO
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports acc = ACCPAC.Advantage
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.ComponentModel

Friend Class custstatement
    'Public compid As String = ""
    ' Private acsignon As New AccpacSignonManager.AccpacSignonMgr
    '  Public mSession As New AccpacCOMAPI.AccpacSession
    Public frmcust As String
    Public Tocust As String
    Public fdate As String
    Public tdate As String
    ' Friend xdbcom As AccpacDBLink
    Friend Property ERPSession As acc.Session
    Friend Property Company As ERPCompany
    Friend Property SessionDate As String
    Friend Property ObjectHandle As String
    Friend compid As String
    'Private DS As DataSet = New DataSet()
    'Private crSubItem As ListViewItem.ListViewSubItem = Nothing
    'Private crItem As ListViewItem = Nothing
    'Private _lsvFinderLounched As Boolean = False
    'Private processWithTab As Boolean = False
    'Private processWithEsc As Boolean = False
    'Private _curPoSeq As Integer = 0
    Private _oldVendNumb As String = ""
    'Private _oldPONumb As String = ""
    'Private _iniData As Boolean = True
    'Private _detailsChanged As Boolean = False
    'Private _hdrOldData As Hashtable = New Hashtable()
    <DllImport("a4wroto.dll", EntryPoint:="rotoSetObjectWindow", CharSet:=CharSet.Ansi)>
    Private Shared Sub rotoSetObjectWindow(
        <MarshalAs(UnmanagedType.I8)> ByVal objectHandle As Long,
        <MarshalAs(UnmanagedType.I8)> ByVal hWnd As Long)
    End Sub

    Public Sub New(ByVal ses As acc.Session, ByVal comp As ERPCompany, ByVal sesDate As String)
        InitializeComponent()
        'ObjectHandle = ""
        ERPSession = ses
        Company = comp
        compid = comp.ID
        SessionDate = sesDate

    End Sub

    Public Sub New(ByVal _objectHandle As String)
        InitializeComponent()
        ObjectHandle = _objectHandle
    End Sub
    Public Sub New()
        InitializeComponent()

    End Sub


    Private Sub custstatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not ObjectHandle Is Nothing Then
                SessionFromERP(Handle)

            End If
            'mSession.Init("", "XX", "XX0001", "65A")
            'acsignon.Signon(mSession)
            'compid = mSession.CompanyID
            'xdbcom = mSession.GetDBLink(tagDBLinkTypeEnum.DBLINK_COMPANY, tagDBLinkFlagsEnum.DBLINK_FLG_READONLY)
            'If compid = "" Then
            '    Close()
            'End If
            'InitializeComponent()
            'ObjectHandle = ""
            'Dim ses As New acc.Session
            'Dim comp As ERPCompany
            'Dim sesDate As String
            'ERPSession = ses
            'Company = comp
            'SessionDate = sesDate

            Txttocus.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttosalm.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Rbfunc.Checked = True
            rbcw.Checked = True
            Rbwosm.Checked = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Close()
        End Try
    End Sub


    Private Sub CMD_OK_Click(sender As Object, e As EventArgs) Handles CMD_OK.Click
        Try
            Dim fmonthnew As String = 0
            If DateTimePicker1.Value.Month.ToString.Length < 2 Then
                fmonthnew = "0" & DateTimePicker1.Value.Month
            Else
                fmonthnew = DateTimePicker1.Value.Month
            End If
            Dim tmonthnew As String = 0
            If DateTimePicker2.Value.Month.ToString.Length < 2 Then
                tmonthnew = "0" & DateTimePicker2.Value.Month
            Else
                tmonthnew = DateTimePicker2.Value.Month
            End If

            Dim fdaynew As String = 0
            If DateTimePicker1.Value.Day.ToString.Length < 2 Then
                fdaynew = "0" & DateTimePicker1.Value.Day
            Else
                fdaynew = DateTimePicker1.Value.Day
            End If
            Dim tdaynew As String = 0
            If DateTimePicker2.Value.Day.ToString.Length < 2 Then
                tdaynew = "0" & DateTimePicker2.Value.Day
            Else
                tdaynew = DateTimePicker2.Value.Day
            End If

            fdate = DateTimePicker1.Value.Year & fmonthnew & fdaynew

            tdate = DateTimePicker2.Value.Year & tmonthnew & tdaynew
            If Trim(txtfrmcus.Text) <= Trim(Txttocus.Text) Then
                If fdate <= tdate Then
                    'ByVal rbfun As Boolean, ByVal rbsrc As Boolean, ByVal rbcw As Boolean, ByVal rbwcw As Boolean, ByVal fdate As String, ByVal tdate As String, ByVal frmsales As String, ByVal tosales As String, ByVal frmcus As String, ByVal tocust As String, ByVal wsalm As Boolean, ByVal wosalm As Boolean
                    Dim f As Form = New crviewer(ObjectHandle, compid, Rbfunc.Checked, Rbsource.Checked, rbcw.Checked, rbwtcw.Checked, fdate, tdate, Txtfrmsalm.Text, Txttosalm.Text, txtfrmcus.Text, Txttocus.Text, Rbwsm.Checked, Rbwosm.Checked)

                    f.Show()

                Else
                    MessageBox.Show("From Date  greater than To Date")
                End If
            Else
                MessageBox.Show("From Vendor No greater than To Vendor No")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub bffind_Click(sender As Object, e As EventArgs) Handles bffind.Click
        Dim vfnd As FromFinder = New FromFinder("ARCUS", "Customers", New String() {"IDCUST", "NAMECUST"}, ERPSession, "", "")

        Dim r As DialogResult = vfnd.ShowDialog(Me)
        If r = DialogResult.OK Then
            txtfrmcus.Text = vfnd.Result.ToArray()(0)

            fndEditBoxValidate(txtfrmcus, EventArgs.Empty)
        End If

    End Sub
    Private Sub btfind_Click(sender As Object, e As EventArgs) Handles btfind.Click
        Dim vfnd As FromFinder = New FromFinder("ARCUS", "Customers", New String() {"IDCUST", "NAMECUST"}, ERPSession, "", "")

        Dim r As DialogResult = vfnd.ShowDialog(Me)
        If r = DialogResult.OK Then
            Txttocus.Text = vfnd.Result.ToArray()(0)

            fndEditBoxValidate(Txttocus, EventArgs.Empty)
        End If
    End Sub


    Private Sub Butffrmsal_Click(sender As Object, e As EventArgs) Handles Butffrmsal.Click
        Dim vfnd As FromFinder = New FromFinder("ARSAP", "SalesPerson", New String() {"CODESLSP", "NAMEEMPL"}, ERPSession, "", "")

        Dim r As DialogResult = vfnd.ShowDialog(Me)
        If r = DialogResult.OK Then
            Txtfrmsalm.Text = vfnd.Result.ToArray()(0)

            fndEditBoxValidate(Txtfrmsalm, EventArgs.Empty)
        End If
    End Sub

    Private Sub Butftosal_Click(sender As Object, e As EventArgs) Handles Butftosal.Click
        Dim vfnd As FromFinder = New FromFinder("ARSAP", "SalesPerson", New String() {"CODESLSP", "NAMEEMPL"}, ERPSession, "", "")

        Dim r As DialogResult = vfnd.ShowDialog(Me)
        If r = DialogResult.OK Then
            Txttosalm.Text = vfnd.Result.ToArray()(0)

            fndEditBoxValidate(Txttosalm, EventArgs.Empty)
        End If
    End Sub

    Private Sub CMD_Exit_Click(sender As Object, e As EventArgs) Handles CmdClose.Click
        Close()
    End Sub
    Private Sub fndEditBoxValidate(ByVal sender As Object, ByVal e As EventArgs)
        If CmdClose.Focused Then Return
        Dim txb As TextBox = CType(sender, TextBox)
        If String.IsNullOrEmpty(txb.Text) Then Return
        Dim msg As String = ""
        Dim s As String() = New String() {}

        Select Case txb.Name.Trim()
            Case "txtfrmcus"

                If _oldVendNumb.Trim() <> txb.Text.Trim() Then
                    msg = getValidationData("select ID=IDCUST,NAM=NAMECUST,SW=SWACTV from ARCUS where IDCUST='" & txb.Text & "'", s)

                    If msg <> "" Then
                        MessageBox.Show(Me, msg, "Cutomer Statement", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        Return
                    End If

                    If s.Length = 0 Then
                        MessageBox.Show(Me, "Customer """ & txb.Text & """ does not exists.", "Cutomer Statement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txb.Focus()
                        txb.SelectAll()
                        Return
                    End If

                    If s(2).Trim() = "0" Then
                        MessageBox.Show(Me, "Customer """ & txb.Text & """ is not active.", "Cutomer Statement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txb.Focus()
                        txb.SelectAll()
                        Return
                    End If


                End If
                txtfrmcus.Text = s(0)
            Case "Txttocus"

                If _oldVendNumb.Trim() <> txb.Text.Trim() Then
                    msg = getValidationData("select ID=IDCUST,NAM=NAMECUST,SW=SWACTV from ARCUS where IDCUST='" & txb.Text & "'", s)

                    If msg <> "" Then
                        MessageBox.Show(Me, msg, "Cutomer Statement", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        Return
                    End If

                    If s.Length = 0 Then
                        MessageBox.Show(Me, "Customer """ & txb.Text & """ does not exists.", "Cutomer Statement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txb.Focus()
                        txb.SelectAll()
                        Return
                    End If

                    If s(2).Trim() = "0" Then
                        MessageBox.Show(Me, "Customer """ & txb.Text & """ is not active.", "Cutomer Statement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txb.Focus()
                        txb.SelectAll()
                        Return
                    End If


                End If


                Txttocus.Text = s(0)
                ' End If
        End Select
    End Sub
    Private Function getValidationData(ByVal sql As String, <Out> ByRef data As String()) As String
        data = New String(2) {}
        Dim hasRecs As Boolean = False

        Try
            Dim lnk As acc.DBLink = ERPSession.OpenDBLink(acc.DBLinkType.Company, acc.DBLinkFlags.[ReadOnly])
            Dim opQry As acc.View = lnk.OpenView("CS0120")
            opQry.Cancel()
            opQry.Browse(sql, True)
            opQry.InternalSet(256)

            While opQry.Fetch(False)
                hasRecs = True
                data(0) = opQry.Fields.FieldByName("ID").Value.ToString().Trim()
                data(1) = opQry.Fields.FieldByName("NAM").Value.ToString().Trim()
                data(2) = opQry.Fields.FieldByName("SW").Value.ToString().Trim()

            End While

            opQry.Dispose()
            lnk.Dispose()
            If Not hasRecs Then data = New String() {}
            Return ""
        Catch ex As Exception
            Dim erstr As String = ""
            Dim erlst As List(Of String) = New List(Of String)()
            Util.FillErrors(ex, ERPSession, erlst)

            For Each s As String In erlst
                erstr += s & vbCrLf
            Next

            Dim ms As String = "Sage 300 ERP Error: " & erstr
            Return ms
        End Try
    End Function
    Private Sub SessionFromERP(ByVal frmHwnd As IntPtr)
        Dim lhWnd As Long = Nothing

        Try
            If ERPSession Is Nothing Then ERPSession = New acc.Session()
            If ERPSession.IsOpened Then ERPSession.Dispose()
            ERPSession.Init(ObjectHandle, "AS", "AS0001", "65A")

            If Not Long.TryParse(ObjectHandle, lhWnd) Then
                MessageBox.Show("Invalid Sage 300 ERP object handle.", "Receive PO Utility", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                ERPSession.Dispose()
                Return
            End If

            rotoSetObjectWindow(lhWnd, frmHwnd.ToInt64())
            Company = New ERPCompany(ERPSession.CompanyName, ERPSession.CompanyID)
            SessionDate = ERPSession.SessionDate.ToString()
        Catch ex As Exception
            Dim erstr As String = ""
            Dim erlst As List(Of String) = New List(Of String)()
            Util.FillErrors(ex, ERPSession, erlst)

            For Each s As String In erlst
                erstr += s & vbCrLf
            Next

            Dim ms As String = "Sage 300 ERP Error: " & erstr
            ERPSession.Dispose()
            MessageBox.Show(ms, "Customer Statement", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End Try
    End Sub

    Private Sub ClearAll(ByVal Optional includeVend As Boolean = True)
        If includeVend Then
            txtfrmcus.Clear()

        End If

        _oldVendNumb = ""

    End Sub
End Class
