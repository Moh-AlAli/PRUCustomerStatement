<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class custstatement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(custstatement))
        Me.rbwtcw = New System.Windows.Forms.RadioButton()
        Me.rbcw = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Rbfunc = New System.Windows.Forms.RadioButton()
        Me.CMD_OK = New System.Windows.Forms.Button()
        Me.Rbsource = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btfind = New System.Windows.Forms.Button()
        Me.Txttocus = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bffind = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtfrmcus = New System.Windows.Forms.TextBox()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.Gbpar = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Gbpar.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbwtcw
        '
        Me.rbwtcw.AutoSize = True
        Me.rbwtcw.Location = New System.Drawing.Point(178, 29)
        Me.rbwtcw.Name = "rbwtcw"
        Me.rbwtcw.Size = New System.Drawing.Size(91, 17)
        Me.rbwtcw.TabIndex = 1
        Me.rbwtcw.TabStop = True
        Me.rbwtcw.Text = "Without CW"
        Me.rbwtcw.UseVisualStyleBackColor = True
        '
        'rbcw
        '
        Me.rbcw.AutoSize = True
        Me.rbcw.Location = New System.Drawing.Point(9, 28)
        Me.rbcw.Name = "rbcw"
        Me.rbcw.Size = New System.Drawing.Size(70, 17)
        Me.rbcw.TabIndex = 0
        Me.rbcw.TabStop = True
        Me.rbcw.Text = "with CW"
        Me.rbcw.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbwtcw)
        Me.GroupBox3.Controls.Add(Me.rbcw)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.GroupBox3.Location = New System.Drawing.Point(4, 278)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(279, 62)
        Me.GroupBox3.TabIndex = 65
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cash Work"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(70, 160)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 70
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(69, 131)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 69
        '
        'Rbfunc
        '
        Me.Rbfunc.AutoSize = True
        Me.Rbfunc.Location = New System.Drawing.Point(9, 28)
        Me.Rbfunc.Name = "Rbfunc"
        Me.Rbfunc.Size = New System.Drawing.Size(83, 17)
        Me.Rbfunc.TabIndex = 0
        Me.Rbfunc.TabStop = True
        Me.Rbfunc.Text = "Functional"
        Me.Rbfunc.UseVisualStyleBackColor = True
        '
        'CMD_OK
        '
        Me.CMD_OK.BackColor = System.Drawing.SystemColors.Control
        Me.CMD_OK.Cursor = System.Windows.Forms.Cursors.Default
        Me.CMD_OK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_OK.Location = New System.Drawing.Point(16, 364)
        Me.CMD_OK.Name = "CMD_OK"
        Me.CMD_OK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CMD_OK.Size = New System.Drawing.Size(81, 25)
        Me.CMD_OK.TabIndex = 67
        Me.CMD_OK.Text = "OK"
        Me.CMD_OK.UseVisualStyleBackColor = False
        '
        'Rbsource
        '
        Me.Rbsource.AutoSize = True
        Me.Rbsource.Location = New System.Drawing.Point(178, 29)
        Me.Rbsource.Name = "Rbsource"
        Me.Rbsource.Size = New System.Drawing.Size(64, 17)
        Me.Rbsource.TabIndex = 1
        Me.Rbsource.TabStop = True
        Me.Rbsource.Text = "Source"
        Me.Rbsource.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(6, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "From"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 106)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 83)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(6, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "To"
        '
        'btfind
        '
        Me.btfind.BackColor = System.Drawing.SystemColors.Control
        Me.btfind.Cursor = System.Windows.Forms.Cursors.Default
        Me.btfind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btfind.Image = CType(resources.GetObject("btfind.Image"), System.Drawing.Image)
        Me.btfind.Location = New System.Drawing.Point(247, 55)
        Me.btfind.Name = "btfind"
        Me.btfind.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btfind.Size = New System.Drawing.Size(17, 20)
        Me.btfind.TabIndex = 26
        Me.btfind.TabStop = False
        Me.btfind.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btfind.UseVisualStyleBackColor = False
        '
        'Txttocus
        '
        Me.Txttocus.Location = New System.Drawing.Point(66, 56)
        Me.Txttocus.Name = "Txttocus"
        Me.Txttocus.Size = New System.Drawing.Size(186, 20)
        Me.Txttocus.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "To"
        '
        'bffind
        '
        Me.bffind.BackColor = System.Drawing.SystemColors.Control
        Me.bffind.Cursor = System.Windows.Forms.Cursors.Default
        Me.bffind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bffind.Image = CType(resources.GetObject("bffind.Image"), System.Drawing.Image)
        Me.bffind.Location = New System.Drawing.Point(248, 28)
        Me.bffind.Name = "bffind"
        Me.bffind.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.bffind.Size = New System.Drawing.Size(17, 20)
        Me.bffind.TabIndex = 23
        Me.bffind.TabStop = False
        Me.bffind.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bffind.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        '
        'txtfrmcus
        '
        Me.txtfrmcus.Location = New System.Drawing.Point(66, 29)
        Me.txtfrmcus.Name = "txtfrmcus"
        Me.txtfrmcus.Size = New System.Drawing.Size(186, 20)
        Me.txtfrmcus.TabIndex = 1
        '
        'CmdClose
        '
        Me.CmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.CmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdClose.Location = New System.Drawing.Point(183, 361)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdClose.Size = New System.Drawing.Size(81, 25)
        Me.CmdClose.TabIndex = 68
        Me.CmdClose.Text = "Exit"
        Me.CmdClose.UseVisualStyleBackColor = False
        '
        'Gbpar
        '
        Me.Gbpar.Controls.Add(Me.btfind)
        Me.Gbpar.Controls.Add(Me.Txttocus)
        Me.Gbpar.Controls.Add(Me.Label2)
        Me.Gbpar.Controls.Add(Me.bffind)
        Me.Gbpar.Controls.Add(Me.Label1)
        Me.Gbpar.Controls.Add(Me.txtfrmcus)
        Me.Gbpar.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Gbpar.Location = New System.Drawing.Point(3, 11)
        Me.Gbpar.Name = "Gbpar"
        Me.Gbpar.Size = New System.Drawing.Size(280, 83)
        Me.Gbpar.TabIndex = 61
        Me.Gbpar.TabStop = False
        Me.Gbpar.Text = "Customer"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Rbsource)
        Me.GroupBox2.Controls.Add(Me.Rbfunc)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 202)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(279, 62)
        Me.GroupBox2.TabIndex = 64
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Amount in"
        '
        'custstatement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 391)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.CMD_OK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CmdClose)
        Me.Controls.Add(Me.Gbpar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "custstatement"
        Me.Text = "Customer Statement"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Gbpar.ResumeLayout(False)
        Me.Gbpar.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rbwtcw As RadioButton
    Friend WithEvents rbcw As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Rbfunc As RadioButton
    Public WithEvents CMD_OK As Button
    Friend WithEvents Rbsource As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Public WithEvents btfind As Button
    Friend WithEvents Txttocus As TextBox
    Friend WithEvents Label2 As Label
    Public WithEvents bffind As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtfrmcus As TextBox
    Public WithEvents CmdClose As Button
    Friend WithEvents Gbpar As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
