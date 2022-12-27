Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports ACCPAC.Advantage


Partial Friend Class FrmLogin
        Inherits Form

        Private WithEvents dtSesDate As DateTimePicker
        Private WithEvents label1 As Label
        Private WithEvents cmdCancel As Button
        Private WithEvents cmdOK As Button
        Private WithEvents cmbComp As ComboBox
        Private WithEvents txtPwd As TextBox
        Private WithEvents txtUser As TextBox
        Private WithEvents lblComp As Label
        Private WithEvents lblPwd As Label
        Private WithEvents lblUserid As Label
    Friend Property Company As ERPCompany

    Friend Property SesDate As String
        Friend Property ERPSession As Session
    Public compid As String
    Friend Sub New(ByVal Orgs As XElement)
            InitializeComponent()
            Dim comps = From org In Orgs.Elements("org") Select org

            For Each comp In comps

            Dim c As ERPCompany = New ERPCompany(comp.Elements("name").ElementAt(0).Value, comp.Elements("id").ElementAt(0).Value)
            cmbComp.Items.Add(c)
            Next

            cmbComp.SelectedIndex = 0
        End Sub



        Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.dtSesDate = New System.Windows.Forms.DateTimePicker()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmbComp = New System.Windows.Forms.ComboBox()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.lblComp = New System.Windows.Forms.Label()
        Me.lblPwd = New System.Windows.Forms.Label()
        Me.lblUserid = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtSesDate
        '
        Me.dtSesDate.CustomFormat = "yyyy-MM-dd"
        Me.dtSesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtSesDate.Location = New System.Drawing.Point(87, 103)
        Me.dtSesDate.Name = "dtSesDate"
        Me.dtSesDate.Size = New System.Drawing.Size(96, 20)
        Me.dtSesDate.TabIndex = 25
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(10, 106)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(73, 13)
        Me.label1.TabIndex = 28
        Me.label1.Text = "Session Date:"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(322, 46)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 27
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(322, 14)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 26
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmbComp
        '
        Me.cmbComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComp.FormattingEnabled = True
        Me.cmbComp.Location = New System.Drawing.Point(87, 77)
        Me.cmbComp.Name = "cmbComp"
        Me.cmbComp.Size = New System.Drawing.Size(310, 21)
        Me.cmbComp.TabIndex = 23
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(87, 49)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(151, 20)
        Me.txtPwd.TabIndex = 21
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(87, 22)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(151, 20)
        Me.txtUser.TabIndex = 19
        '
        'lblComp
        '
        Me.lblComp.AutoSize = True
        Me.lblComp.Location = New System.Drawing.Point(9, 81)
        Me.lblComp.Name = "lblComp"
        Me.lblComp.Size = New System.Drawing.Size(56, 13)
        Me.lblComp.TabIndex = 24
        Me.lblComp.Text = "Company:"
        '
        'lblPwd
        '
        Me.lblPwd.AutoSize = True
        Me.lblPwd.Location = New System.Drawing.Point(9, 50)
        Me.lblPwd.Name = "lblPwd"
        Me.lblPwd.Size = New System.Drawing.Size(57, 13)
        Me.lblPwd.TabIndex = 22
        Me.lblPwd.Text = "Password:"
        '
        'lblUserid
        '
        Me.lblUserid.AutoSize = True
        Me.lblUserid.Location = New System.Drawing.Point(9, 25)
        Me.lblUserid.Name = "lblUserid"
        Me.lblUserid.Size = New System.Drawing.Size(47, 13)
        Me.lblUserid.TabIndex = 20
        Me.lblUserid.Text = "User ID:"
        '
        'FrmLogin
        '
        Me.ClientSize = New System.Drawing.Size(406, 136)
        Me.Controls.Add(Me.dtSesDate)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmbComp)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.lblComp)
        Me.Controls.Add(Me.lblPwd)
        Me.Controls.Add(Me.lblUserid)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLogin"
        Me.Text = "Sage 300 ERP Signon "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub



    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If txtUser.Text = "" Then
            MessageBox.Show(Me, "User ID has not been assignd." & vbCrLf & "Enter an existing user ID or ask your system administrator to add a new record for this user.", "Customer Statement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If txtPwd.Text = "" Then
            MessageBox.Show(Me, "Password Can't be blank." & vbCrLf & "Enter an existing user ID and correct password.", "Customer Statement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim c As ERPCompany = CType(cmbComp.SelectedItem, ERPCompany)

        Try
            ERPSession = New Session()
            ERPSession.Init("", "XX", "XX1000", "67A")
            ERPSession.Open(txtUser.Text.ToUpper(), txtPwd.Text.ToUpper(), c.ID.ToUpper(), DateTime.Parse(dtSesDate.Text), 0)
        Catch ex As Exception
            Dim erstr As String = ""
            Dim erlst As List(Of String) = New List(Of String)()
            Util.FillErrors(ex, ERPSession, erlst)

            For Each s As String In erlst
                erstr += s & vbCrLf
            Next

            Dim ms As String = "Sage 300 ERP Error: " & erstr
            ERPSession.Dispose()
            MessageBox.Show(ms, "Customer Satetement", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End Try

        Company = c
        compid = c.ID.ToUpper()
        SesDate = dtSesDate.Text
        DialogResult = DialogResult.OK
        Close()
    End Sub


End Class

