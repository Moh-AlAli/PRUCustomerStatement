Imports AccpacCOMAPI

Friend Class custstatement
    Public compid As String = ""
    Private acsignon As New AccpacSignonManager.AccpacSignonMgr
    Public mSession As New AccpacCOMAPI.AccpacSession
    Public frmcust As String
    Public Tocust As String
    Public fdate As String
    Public tdate As String
    Friend xdbcom As AccpacDBLink

    Private Sub custstatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mSession.Init("", "XX", "XX0001", "65A")
            acsignon.Signon(mSession)
            compid = mSession.CompanyID
            xdbcom = mSession.GetDBLink(tagDBLinkTypeEnum.DBLINK_COMPANY, tagDBLinkFlagsEnum.DBLINK_FLG_READONLY)
            If compid = "" Then
                Close()
            End If
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
                    crviewer.Show()

                    'Dim dblinkcomp As AccpacDBLink
                    'Dim dblinksys As AccpacDBLink


                    'dblinkcomp = mSession.OpenDBLink(tagDBLinkTypeEnum.DBLINK_COMPANY, tagDBLinkFlagsEnum.DBLINK_FLG_READWRITE)
                    'dblinksys = mSession.OpenDBLink(tagDBLinkTypeEnum.DBLINK_SYSTEM, tagDBLinkFlagsEnum.DBLINK_FLG_READWRITE)

                    'If Rbfunc.Checked = True Then
                    '    rdoc = mSession.ReportSelect("ARCUSTHOMERPT", "", "")
                    'ElseIf Rbsource.Checked = True Then
                    '    rdoc = mSession.ReportSelect("ARCUSTSURCRPT", "", "")
                    'End If

                    'rdoc.PrinterSetup(mSession.GetPrintSetup("", ""))

                    'rdoc.SetParam("Frmcus", txtfrmcus.Text)
                    'rdoc.SetParam("TOcus", Txttocus.Text)
                    'rdoc.SetParam("frmyearper", fdate)
                    'rdoc.SetParam("toyearper", tdate)


                    'rdoc.NumOfCopies = 1
                    'rdoc.Destination = tagPrintDestinationEnum.PD_PREVIEW
                    'rdoc.PrintReport()

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
        Fromcust.Show()
        bffind.Visible = False
    End Sub



    Private Sub CMD_Exit_Click(sender As Object, e As EventArgs) Handles CMD_Exit.Click
        Close()
    End Sub

    Private Sub Butffrmsal_Click(sender As Object, e As EventArgs) Handles Butffrmsal.Click
        Dim f As Form = New frmsalm
        f.Show()
        Butffrmsal.Visible = False
    End Sub

    Private Sub Butftosal_Click(sender As Object, e As EventArgs) Handles Butftosal.Click
        Dim f As Form = New tosalm
        f.Show()
        Butftosal.Visible = False
    End Sub

    Private Sub btfind_Click(sender As Object, e As EventArgs) Handles btfind.Click
        Dim f As Form = New tocust
        f.Show()
        btfind.Visible = False
    End Sub
End Class
