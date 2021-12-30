Imports ACCPAC.Advantage

Public Class frmsalm
    Private i As Integer
    Private j As Integer
    Private os As New Session
    Private adblink As DBLink
    Private Sub frmsalm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            os.Init("", "AR", "AR0018", "65A")
            os.OpenWin("", "", "", custstatement.compid, System.DateTime.Now, 0)
            '   os.Open("ADMIN", "ADMIN", custstatement.compid, System.DateTime.Now, 0)
            adblink = os.OpenDBLink(DBLinkType.Company, DBLinkFlags.ReadOnly)

            Dim arv As View
            arv = adblink.OpenView("AR0018")

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
            icl.HeaderText = "Saelsman"
            icl.Width = 150
            DGfsalm.Columns.Add(icl)
            Dim ncl As New DataGridViewTextBoxColumn
            ncl.DataPropertyName = "NAMEEMPL"
            ncl.Name = "colnc"
            ncl.HeaderText = "Name"
            ncl.Width = 190
            DGfsalm.Columns.Add(ncl)

            DGfsalm.DataSource = arcusds.Tables(0)



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub






    Private Sub Fromcust_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        custstatement.Butffrmsal.Visible = True
    End Sub
    Private Sub Butcan_Click(sender As Object, e As EventArgs) Handles Butcan.Click
        Close()
        custstatement.Butffrmsal.Visible = True
    End Sub


    Private Sub ButSel_Click(sender As Object, e As EventArgs) Handles ButSel.Click
        Try
            Dim arv As View
            arv = adblink.OpenView("AR0018")
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

            i = DGfsalm.CurrentCell.RowIndex
            j = DGfsalm.CurrentCell.ColumnIndex
            custstatement.Txtfrmsalm.Text = dt.Rows(i)(0)
            custstatement.Txttosalm.Text = dt.Rows(i)(0)
            custstatement.Butffrmsal.Visible = True
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




    Private Sub Txtsalm_TextChanged(sender As Object, e As EventArgs) Handles Txtsalm.TextChanged


        Dim arv As View
        arv = adblink.OpenView("AR0018")
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


        DGfsalm.DataSource = arcusds.Tables(0)


    End Sub

    Private Sub Txtsalm_MouseLeave(sender As Object, e As EventArgs) Handles Txtsalm.MouseLeave


        Dim arv As View
        arv = adblink.OpenView("AR0018")
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


        DGfsalm.DataSource = arcusds.Tables(0)


    End Sub

    Private Sub Txtsalm_MouseMove(sender As Object, e As MouseEventArgs) Handles Txtsalm.MouseMove


        Dim arv As View
        arv = adblink.OpenView("AR0018")
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


        DGfsalm.DataSource = arcusds.Tables(0)


    End Sub

    Private Sub Txtname_TextChanged(sender As Object, e As EventArgs) Handles Txtname.TextChanged


        Dim arv As View
        arv = adblink.OpenView("AR0018")
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


        DGfsalm.DataSource = arcusds.Tables(0)


    End Sub

    Private Sub Txtname_MouseMove(sender As Object, e As MouseEventArgs) Handles Txtname.MouseMove


        Dim arv As View
        arv = adblink.OpenView("AR0018")
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


        DGfsalm.DataSource = arcusds.Tables(0)


    End Sub

    Private Sub Txtname_MouseLeave(sender As Object, e As EventArgs) Handles Txtname.MouseLeave


        Dim arv As View
        arv = adblink.OpenView("AR0018")
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


        DGfsalm.DataSource = arcusds.Tables(0)


    End Sub

    Private Sub DGfsalm_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGfsalm.CellContentClick
        Try

            Dim arv As View
            arv = adblink.OpenView("AR0018")


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

            i = DGfsalm.CurrentCell.RowIndex
            j = DGfsalm.CurrentCell.ColumnIndex
            custstatement.Txtfrmsalm.Text = dt.Rows(i)(0)
            custstatement.Txttosalm.Text = dt.Rows(i)(0)
            custstatement.Butffrmsal.Visible = True
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class



