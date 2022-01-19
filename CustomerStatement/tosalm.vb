'Imports ACCPAC.Advantage
Imports AccpacCOMAPI
Public Class tosalm
    Private i As Integer
    Private j As Integer
    'Private os As New Session
    'Private adblink As DBLink

    Private Sub tosalm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'os.Init("", "AR", "AR0018", "65A")
            'os.OpenWin("", "", "", custstatement.compid, System.DateTime.Now, 0)
            ''os.Open("ADMIN", "ADMIN", custstatement.compid, System.DateTime.Now, 0)
            'adblink = os.OpenDBLink(DBLinkType.Company, DBLinkFlags.ReadOnly)
            Dim arv As AccpacView
            arv = custstatement.xdbcom.OpenView2("AR0018")

            Dim arcusds As DataSet = New DataSet("AR")

            Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            Dim name As DataColumn = cust.Columns.Add("CODESLSP", Type.GetType("System.String"))
            Dim id As DataColumn = cust.Columns.Add("NAMEEMPL", Type.GetType("System.String"))

            Dim row As DataRow
            row = cust.NewRow()
            Do While arv.FilterFetch(False)
                Dim cid As String = arv.Fields.FieldByName("CODESLSP").Value.ToString()
                Dim cn As String = arv.Fields.FieldByName("NAMEEMPL").Value.ToString()
                row("CODESLSP") = cid
                row("NAMEEMPL") = cn
                arcusds.Tables(0).Rows.Add(row)
                row = cust.NewRow()
            Loop
            Dim icl As New DataGridViewTextBoxColumn
            icl.DataPropertyName = "CODESLSP"
            icl.Name = "clidc"
            icl.HeaderText = "Salesman"
            icl.Width = 150
            DGtosalm.Columns.Add(icl)
            Dim ncl As New DataGridViewTextBoxColumn
            ncl.DataPropertyName = "NAMEEMPL"
            ncl.Name = "colnc"
            ncl.HeaderText = "Name"
            ncl.Width = 190
            DGtosalm.Columns.Add(ncl)

            DGtosalm.DataSource = arcusds.Tables(0)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSel.Click
        Try


            Dim arv As AccpacView
            arv = custstatement.xdbcom.OpenView2("AR0018")
            Dim searfil As String = ""

            If Txtsalm.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
            ElseIf Txtname.Text <> Nothing And Txtsalm.Text = Nothing Then
                searfil = "NAMEEMPL like ""%" + Txtname.Text + "%"" "
            ElseIf Txtsalm.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = "CODESLSP like ""%" + Txtsalm.Text + "%"" "
            Else
                searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
            End If

            arv.Browse(searfil, True)
            Dim arcusds As DataSet = New DataSet("AR")

            Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            Dim id As DataColumn = cust.Columns.Add("CODESLSP", Type.GetType("System.String"))
            Dim name As DataColumn = cust.Columns.Add("NAMEEMPL", Type.GetType("System.String"))
            cust.PrimaryKey = New DataColumn() {id}
            Dim row As DataRow
            row = cust.NewRow()
            Do While arv.FilterFetch(False)
                Dim cid As String = arv.Fields.FieldByName("CODESLSP").Value.ToString()
                Dim cn As String = arv.Fields.FieldByName("NAMEEMPL").Value.ToString()
                row("CODESLSP") = cid
                row("NAMEEMPL") = cn
                arcusds.Tables(0).Rows.Add(row)
                row = cust.NewRow()
            Loop
            Dim dt As DataTable = arcusds.Tables(0)

            i = DGtosalm.CurrentCell.RowIndex
            j = DGtosalm.CurrentCell.ColumnIndex
            custstatement.Txttosalm.Text = dt.Rows(i)(0)
            custstatement.Butftosal.Visible = True
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Butcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Butcan.Click
        Close()
        custstatement.Butftosal.Visible = True
    End Sub

    Private Sub Txtsalm_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtsalm.MouseLeave

        If Txtsalm.Text <> Nothing Then



            Dim arv As AccpacView
            arv = custstatement.xdbcom.OpenView2("AR0018")
            Dim searfil As String = ""
            If Txtsalm.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
            ElseIf Txtname.Text <> Nothing And Txtsalm.Text = Nothing Then
                searfil = "NAMEEMPL like ""%" + Txtname.Text + "%"" "
            ElseIf Txtsalm.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = "CODESLSP like ""%" + Txtsalm.Text + "%"" "
            Else
                searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
            End If
            arv.Browse(searfil, True)


            Dim arcusds As DataSet = New DataSet("AR")

            Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            Dim id As DataColumn = cust.Columns.Add("CODESLSP", Type.GetType("System.String"))
            Dim name As DataColumn = cust.Columns.Add("NAMEEMPL", Type.GetType("System.String"))
            cust.PrimaryKey = New DataColumn() {id}
            Dim row As DataRow
            row = cust.NewRow()

            Do While arv.FilterFetch(False)

                Dim cid As String = arv.Fields.FieldByName("CODESLSP").Value.ToString()
                Dim cn As String = arv.Fields.FieldByName("NAMEEMPL").Value.ToString()
                row("CODESLSP") = cid
                row("NAMEEMPL") = cn
                arcusds.Tables(0).Rows.Add(row)
                row = cust.NewRow()

            Loop


            DGtosalm.DataSource = arcusds.Tables(0)

        End If

    End Sub

    Private Sub Txtname_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtname.MouseLeave

        Try

            If Txtname.Text <> Nothing Then



                Dim arv As AccpacView
                arv = custstatement.xdbcom.OpenView2("AR0018")
                Dim searfil As String = ""

                If Txtsalm.Text <> Nothing And Txtname.Text <> Nothing Then
                    searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
                ElseIf Txtname.Text <> Nothing And Txtsalm.Text = Nothing Then
                    searfil = "NAMEEMPL like ""%" + Txtname.Text + "%"" "
                ElseIf Txtsalm.Text <> Nothing And Txtname.Text = Nothing Then
                    searfil = "CODESLSP like ""%" + Txtsalm.Text + "%"" "
                Else
                    searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
                End If

                arv.Browse(searfil, True)
                Dim arcusds As DataSet = New DataSet("AR")

                Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
                Dim id As DataColumn = cust.Columns.Add("CODESLSP", Type.GetType("System.String"))
                Dim name As DataColumn = cust.Columns.Add("NAMEEMPL", Type.GetType("System.String"))
                cust.PrimaryKey = New DataColumn() {id}
                Dim row As DataRow
                row = cust.NewRow()
                Do While arv.FilterFetch(False)
                    Dim cid As String = arv.Fields.FieldByName("CODESLSP").Value.ToString()
                    Dim cn As String = arv.Fields.FieldByName("NAMEEMPL").Value.ToString()
                    row("CODESLSP") = cid
                    row("NAMEEMPL") = cn
                    arcusds.Tables(0).Rows.Add(row)
                    row = cust.NewRow()
                Loop
                DGtosalm.DataSource = arcusds.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txtsalm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtsalm.TextChanged
        Try
            If Txtsalm.Text <> Nothing Then



                Dim arv As AccpacView
                arv = custstatement.xdbcom.OpenView2("AR0018")
                Dim searfil As String = ""
                If Txtsalm.Text <> Nothing And Txtname.Text <> Nothing Then
                    searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
                ElseIf Txtname.Text <> Nothing And Txtsalm.Text = Nothing Then
                    searfil = "NAMEEMPL like ""%" + Txtname.Text + "%"" "
                ElseIf Txtsalm.Text <> Nothing And Txtname.Text = Nothing Then
                    searfil = "CODESLSP like ""%" + Txtsalm.Text + "%"" "
                Else
                    searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
                End If

                arv.Browse(searfil, True)
                Dim arcusds As DataSet = New DataSet("AR")

                Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
                Dim id As DataColumn = cust.Columns.Add("CODESLSP", Type.GetType("System.String"))
                Dim name As DataColumn = cust.Columns.Add("NAMEEMPL", Type.GetType("System.String"))
                cust.PrimaryKey = New DataColumn() {id}
                Dim row As DataRow
                row = cust.NewRow()
                Do While arv.FilterFetch(False)
                    Dim cid As String = arv.Fields.FieldByName("CODESLSP").Value.ToString()
                    Dim cn As String = arv.Fields.FieldByName("NAMEEMPL").Value.ToString()
                    row("CODESLSP") = cid
                    row("NAMEEMPL") = cn
                    arcusds.Tables(0).Rows.Add(row)
                    row = cust.NewRow()
                Loop
                DGtosalm.DataSource = arcusds.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtname.TextChanged
        Try
            If Txtname.Text <> Nothing Then



                Dim arv As AccpacView
                arv = custstatement.xdbcom.OpenView2("AR0018")
                Dim searfil As String = ""

                If Txtsalm.Text <> Nothing And Txtname.Text <> Nothing Then
                    searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
                ElseIf Txtname.Text <> Nothing And Txtsalm.Text = Nothing Then
                    searfil = "NAMEEMPL like ""%" + Txtname.Text + "%"" "
                ElseIf Txtsalm.Text <> Nothing And Txtname.Text = Nothing Then
                    searfil = "CODESLSP like ""%" + Txtsalm.Text + "%"" "
                Else
                    searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
                End If

                arv.Browse(searfil, True)
                Dim arcusds As DataSet = New DataSet("AR")

                Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
                Dim id As DataColumn = cust.Columns.Add("CODESLSP", Type.GetType("System.String"))
                Dim name As DataColumn = cust.Columns.Add("NAMEEMPL", Type.GetType("System.String"))
                cust.PrimaryKey = New DataColumn() {id}
                Dim row As DataRow
                row = cust.NewRow()
                Do While arv.FilterFetch(False)
                    Dim cid As String = arv.Fields.FieldByName("CODESLSP").Value.ToString()
                    Dim cn As String = arv.Fields.FieldByName("NAMEEMPL").Value.ToString()
                    row("CODESLSP") = cid
                    row("NAMEEMPL") = cn
                    arcusds.Tables(0).Rows.Add(row)
                    row = cust.NewRow()
                Loop
                DGtosalm.DataSource = arcusds.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DGtosalm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGtosalm.CellContentClick
        Try


            Dim arv As AccpacView
            arv = custstatement.xdbcom.OpenView2("AR0018")
            Dim searfil As String = ""
            If Txtsalm.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
            ElseIf Txtname.Text <> Nothing And Txtsalm.Text = Nothing Then
                searfil = "NAMEEMPL like ""%" + Txtname.Text + "%"" "
            ElseIf Txtsalm.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = "CODESLSP like ""%" + Txtsalm.Text + "%"" "
            Else
                searfil = "NAMEEMPL Like ""%" + Txtname.Text + "%"" and CODESLSP like ""%" + Txtsalm.Text + "%"" "
            End If

            arv.Browse(searfil, True)
            Dim arcusds As DataSet = New DataSet("AR")

            Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            Dim id As DataColumn = cust.Columns.Add("CODESLSP", Type.GetType("System.String"))
            Dim name As DataColumn = cust.Columns.Add("NAMEEMPL", Type.GetType("System.String"))
            cust.PrimaryKey = New DataColumn() {id}
            Dim row As DataRow
            row = cust.NewRow()
            Do While arv.FilterFetch(False)
                Dim cid As String = arv.Fields.FieldByName("CODESLSP").Value.ToString()
                Dim cn As String = arv.Fields.FieldByName("NAMEEMPL").Value.ToString()
                row("CODESLSP") = cid
                row("NAMEEMPL") = cn
                arcusds.Tables(0).Rows.Add(row)
                row = cust.NewRow()
            Loop
            Dim dt As DataTable = arcusds.Tables(0)

            i = DGtosalm.CurrentCell.RowIndex
            j = DGtosalm.CurrentCell.ColumnIndex
            custstatement.Txttosalm.Text = dt.Rows(i)(0)
            custstatement.Butftosal.Visible = True
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tocust_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        custstatement.Butftosal.Visible = True
    End Sub
End Class



