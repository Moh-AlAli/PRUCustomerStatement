Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Friend Class crviewer
    Private rdoc As New ReportDocument
    Private conrpt As New ConnectionInfo()
    Dim server As String = ""
    Dim uid As String = ""
    Dim pass As String = ""
    Dim fdate As String = ""
    Dim tdate As String = ""
    Friend Function createdes(ByVal key As String) As TripleDES
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Dim des As TripleDES = New TripleDESCryptoServiceProvider()
        des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key))
        des.IV = New Byte(des.BlockSize \ 8 - 1) {}
        Return des
    End Function
    Friend Function Decryption(ByVal cyphertext As String, ByVal key As String) As String
        Dim b As Byte() = Convert.FromBase64String(cyphertext)
        Dim des As TripleDES = createdes(key)
        Dim ct As ICryptoTransform = des.CreateDecryptor()
        Dim output As Byte() = ct.TransformFinalBlock(b, 0, b.Length)
        Return Encoding.Unicode.GetString(output)
    End Function
    Friend Function Readconnectionstring() As String

        Dim secretkey As String = "Fhghqwjehqwlegtoit123mnk12%&4#"
        Dim path As String = ("txtcon\akhcon.txt")
        Dim sr As New StreamReader(path)

        server = sr.ReadLine()
        Dim db As String = sr.ReadLine()
        uid = sr.ReadLine()
        pass = sr.ReadLine()


        server = Decryption(server, secretkey)
        uid = Decryption(uid, secretkey)
        pass = Decryption(pass, secretkey)

        Dim cons As String = "" '"Data Source =(Local); DataBase =" & custstatement.compid & "; User Id =" & uid & "; Password =" & pass & ";"

        Return cons
    End Function
    

    Private Sub crviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cwvr As New CrystalReportViewer
            cwvr.Dock = DockStyle.Fill
            cwvr.BorderStyle = BorderStyle.None
            cwvr.ExportReport()
            Me.Controls.Add(cwvr)


            If custstatement.Rbfunc.Checked = True And custstatement.rbwtcw.Checked = True Then
                rdoc.Load("reports\ARCUSTHOMERPT.rpt")
            ElseIf custstatement.Rbsource.Checked = True And custstatement.rbwtcw.Checked = True Then
                rdoc.Load("reports\ARCUSTSURCRPT.rpt")
            ElseIf custstatement.Rbfunc.Checked = True And custstatement.rbcw.Checked = True Then
                rdoc.Load("reports\ARCUSTHOMERPTCW.rpt")
            ElseIf custstatement.Rbsource.Checked = True And custstatement.rbcw.Checked = True Then
                rdoc.Load("reports\ARCUSTSURCRPTCw.rpt")
            End If


            Dim tabs As Tables = rdoc.Database.Tables
            Dim parv As New ParameterValues
            Dim dis As New ParameterDiscreteValue

            Dim fmonthnew As String = 0
            If custstatement.DateTimePicker1.Value.Month.ToString.Length < 2 Then
                fmonthnew = "0" & custstatement.DateTimePicker1.Value.Month
            Else
                fmonthnew = custstatement.DateTimePicker1.Value.Month
            End If
            Dim tmonthnew As String = 0
            If custstatement.DateTimePicker2.Value.Month.ToString.Length < 2 Then
                tmonthnew = "0" & custstatement.DateTimePicker2.Value.Month
            Else
                tmonthnew = custstatement.DateTimePicker2.Value.Month
            End If

            Dim fdaynew As String = 0
            If custstatement.DateTimePicker1.Value.Day.ToString.Length < 2 Then
                fdaynew = "0" & custstatement.DateTimePicker1.Value.Day
            Else
                fdaynew = custstatement.DateTimePicker1.Value.Day
            End If

            Dim tdaynew As String = 0

            If custstatement.DateTimePicker2.Value.Day.ToString.Length < 2 Then
                tdaynew = "0" & custstatement.DateTimePicker2.Value.Day
            Else
                tdaynew = custstatement.DateTimePicker2.Value.Day
            End If

            Dim fdate As String = custstatement.DateTimePicker1.Value.Year & fmonthnew & fdaynew

            Dim tdate As String = custstatement.DateTimePicker2.Value.Year & tmonthnew & tdaynew


            Readconnectionstring()



            For Each TAB As CrystalDecisions.CrystalReports.Engine.Table In tabs
                Dim tablog As TableLogOnInfo = TAB.LogOnInfo
                conrpt.ServerName = server
                conrpt.DatabaseName = custstatement.compid
                conrpt.UserID = uid
                conrpt.Password = pass
                tablog.ConnectionInfo = conrpt
                TAB.ApplyLogOnInfo(tablog)
            Next


            Dim sec As Section
            Dim secs As Sections
            Dim rob As ReportObject
            Dim robs As ReportObjects
            Dim subrpobj As SubreportObject
            Dim subrp As ReportDocument
            Dim crSubTables As Tables
            Dim crsubtable As Table
            secs = rdoc.ReportDefinition.Sections
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
            Dim subConInfo As New ConnectionInfo
            For Each sec In secs
                robs = sec.ReportObjects
                For Each rob In robs
                    If rob.Kind = ReportObjectKind.SubreportObject Then
                        subrpobj = CType(rob, SubreportObject)
                        subrp = subrpobj.OpenSubreport(subrpobj.SubreportName)
                        Dim name As String = subrp.Name
                     
                        If subrp.Name = "salesperson.rpt" Then
                            crSubTables = subrp.Database.Tables
                            For Each crsubtable In crSubTables
                                crtableLogoninfo = crsubtable.LogOnInfo
                                subConInfo.ServerName = server
                                subConInfo.DatabaseName = custstatement.compid
                                subConInfo.UserID = uid
                                subConInfo.Password = pass
                                crtableLogoninfo.ConnectionInfo = subConInfo 'ConInfo.ConnectionInfo
                                crsubtable.ApplyLogOnInfo(crtableLogoninfo)
                            Next
                        End If

                        If subrp.Name = "CWRep.rpt" Then
                            crSubTables = subrp.Database.Tables
                            For Each crsubtable In crSubTables
                                crtableLogoninfo = crsubtable.LogOnInfo
                                subConInfo.ServerName = server
                                subConInfo.DatabaseName = custstatement.compid
                                subConInfo.UserID = uid
                                subConInfo.Password = pass
                                crtableLogoninfo.ConnectionInfo = subConInfo 'ConInfo.ConnectionInfo
                                crsubtable.ApplyLogOnInfo(crtableLogoninfo)
                            Next
                        End If
                    End If

                Next
            Next


            rdoc.SetParameterValue("frmyearper", fdate)
            rdoc.SetParameterValue("toyearper", tdate)
            rdoc.SetParameterValue("Frmcus", custstatement.txtfrmcus.Text)
            rdoc.SetParameterValue("TOcus", custstatement.Txttocus.Text)
            rdoc.SetParameterValue("Frmsal", custstatement.Txtfrmsalm.Text)
            rdoc.SetParameterValue("Tosal", custstatement.Txttosalm.Text)
            cwvr.ReportSource = rdoc


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            If rdoc Is Nothing Then
                rdoc.Close()
                rdoc.Dispose()
            End If
        End Try
    End Sub

    Friend Function glar() As DataSet
        Dim cmd As New SqlCommand()
        Dim sql As String = " SELECT GLBATCH,GLENTRY,IDINVC,IDCUST,CNTBTCH,CNTITEM " & _
                            " FROM  ARPJH  where IDCUST between '" & custstatement.txtfrmcus.Text & "' and '" & custstatement.Txttosalm.Text & "'"
        Dim da As New SqlDataAdapter
        Dim con As New SqlConnection(Readconnectionstring())
        With cmd
            .CommandText = Sql
            .CommandType = CommandType.Text
            .Connection = con
        End With

        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds
    End Function
    Friend Function arstate(ByVal tdate As Integer) As DataSet
        Dim cmd As New SqlCommand()
        Dim sql As String = " SELECT DISTINCT AROBL.TRXTYPETXT, AROBL.IDINVC, CSCCD.DECIMALS, AROBL.DATEINVC, AROBL.IDCUST, AROBL.AMTINVCTC, AROBL.DESCINVC, AROBP.TRXTYPE, AROBP.IDMEMOXREF, CSCOM.HOMECUR, AROBP.AMTPAYMHC, AROBL.AMTINVCHC, AROBL.CNTBTCH, AROBL.CNTITEM, AROBP.CNTBTCH, AROBP.CNTITEM, AROBP.IDINVC, AROBL.IDRMIT, ARRRH.TEXTRETRN, AROBP.DATEBUS, ARCUS.IDCUST, ARCUS.NAMECUST, ARTCR.TEXTRMIT, AROBP.IDCUST " & _
                            " FROM   ARCUS  INNER JOIN CSCOM  ON ARCUS.AUDTORG=CSCOM.ORGID LEFT OUTER JOIN SAMDAT.dbo.AROBL AROBL ON ARCUS.IDCUST=AROBL.IDCUST INNER JOIN SAMDAT.dbo.CSCCD CSCCD ON CSCOM.HOMECUR=CSCCD.CURID LEFT OUTER JOIN SAMDAT.dbo.AROBP AROBP ON AROBL.IDCUST=AROBP.IDCUST AND AROBL.IDINVC=AROBP.IDINVC LEFT OUTER JOIN SAMDAT.dbo.ARTCR ARTCR ON AROBL.CNTBTCH=ARTCR.CNTBTCH AND AROBL.CNTITEM=ARTCR.CNTITEM AND AROBL.IDCUST=ARTCR.IDCUST LEFT OUTER JOIN SAMDAT.dbo.ARRRH ARRRH " & _
                            " ON AROBP.IDBANK=ARRRH.IDBANK AND AROBP.IDCUST=ARRRH.IDCUST AND AROBP.IDRMIT=ARRRH.IDRMIT AND AROBP.DEPSEQ=ARRRH.DEPSEQ AND AROBP.DEPLINE=ARRRH.DEPLINE AND AROBP.DATERMIT=ARRRH.DATERMIT " & _
                            " WHERE  AROBL.DATEINVC<=" & tdate & " AND AROBL.IDCUST between '" & custstatement.txtfrmcus.Text & "' and '" & custstatement.Txttosalm.Text & "'"
        Dim da As New SqlDataAdapter
        Dim con As New SqlConnection(Readconnectionstring())
        With cmd
            .CommandText = sql
            .CommandType = CommandType.Text
            .Connection = con
        End With

        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds
    End Function

End Class



