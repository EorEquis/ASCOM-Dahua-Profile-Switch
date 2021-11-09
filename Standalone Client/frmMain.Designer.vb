<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.labelDriverId = New System.Windows.Forms.Label()
        Me.buttonConnect = New System.Windows.Forms.Button()
        Me.buttonChoose = New System.Windows.Forms.Button()
        Me.rbOn1 = New System.Windows.Forms.RadioButton()
        Me.rbOff1 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbOn2 = New System.Windows.Forms.RadioButton()
        Me.rbOff2 = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbOn3 = New System.Windows.Forms.RadioButton()
        Me.rbOff3 = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbOn4 = New System.Windows.Forms.RadioButton()
        Me.rbOff4 = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelDriverId
        '
        Me.labelDriverId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labelDriverId.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.TriStarDahuaProfile.My.MySettings.Default, "DriverId", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.labelDriverId.Location = New System.Drawing.Point(12, 28)
        Me.labelDriverId.Name = "labelDriverId"
        Me.labelDriverId.Size = New System.Drawing.Size(325, 21)
        Me.labelDriverId.TabIndex = 5
        Me.labelDriverId.Text = Global.ASCOM.TriStarDahuaProfile.My.MySettings.Default.DriverId
        Me.labelDriverId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'buttonConnect
        '
        Me.buttonConnect.Location = New System.Drawing.Point(352, 41)
        Me.buttonConnect.Name = "buttonConnect"
        Me.buttonConnect.Size = New System.Drawing.Size(72, 23)
        Me.buttonConnect.TabIndex = 4
        Me.buttonConnect.Text = "Connect"
        Me.buttonConnect.UseVisualStyleBackColor = True
        '
        'buttonChoose
        '
        Me.buttonChoose.Location = New System.Drawing.Point(352, 12)
        Me.buttonChoose.Name = "buttonChoose"
        Me.buttonChoose.Size = New System.Drawing.Size(72, 23)
        Me.buttonChoose.TabIndex = 3
        Me.buttonChoose.Text = "Choose"
        Me.buttonChoose.UseVisualStyleBackColor = True
        '
        'rbOn1
        '
        Me.rbOn1.AutoSize = True
        Me.rbOn1.Location = New System.Drawing.Point(3, 3)
        Me.rbOn1.Name = "rbOn1"
        Me.rbOn1.Size = New System.Drawing.Size(100, 17)
        Me.rbOn1.TabIndex = 6
        Me.rbOn1.Text = "Cam 1 On - Day"
        Me.rbOn1.UseVisualStyleBackColor = True
        '
        'rbOff1
        '
        Me.rbOff1.AutoSize = True
        Me.rbOff1.Location = New System.Drawing.Point(3, 26)
        Me.rbOff1.Name = "rbOff1"
        Me.rbOff1.Size = New System.Drawing.Size(106, 17)
        Me.rbOff1.TabIndex = 7
        Me.rbOff1.Text = "Cam 1 Off - Night"
        Me.rbOff1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbOn1)
        Me.Panel1.Controls.Add(Me.rbOff1)
        Me.Panel1.Location = New System.Drawing.Point(12, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(155, 52)
        Me.Panel1.TabIndex = 8
        Me.Panel1.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbOn2)
        Me.Panel2.Controls.Add(Me.rbOff2)
        Me.Panel2.Location = New System.Drawing.Point(182, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(155, 52)
        Me.Panel2.TabIndex = 9
        Me.Panel2.Visible = False
        '
        'rbOn2
        '
        Me.rbOn2.AutoSize = True
        Me.rbOn2.Location = New System.Drawing.Point(3, 3)
        Me.rbOn2.Name = "rbOn2"
        Me.rbOn2.Size = New System.Drawing.Size(100, 17)
        Me.rbOn2.TabIndex = 6
        Me.rbOn2.TabStop = True
        Me.rbOn2.Text = "Cam 2 On - Day"
        Me.rbOn2.UseVisualStyleBackColor = True
        '
        'rbOff2
        '
        Me.rbOff2.AutoSize = True
        Me.rbOff2.Location = New System.Drawing.Point(3, 26)
        Me.rbOff2.Name = "rbOff2"
        Me.rbOff2.Size = New System.Drawing.Size(106, 17)
        Me.rbOff2.TabIndex = 7
        Me.rbOff2.TabStop = True
        Me.rbOff2.Text = "Cam 2 Off - Night"
        Me.rbOff2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rbOn3)
        Me.Panel3.Controls.Add(Me.rbOff3)
        Me.Panel3.Location = New System.Drawing.Point(12, 125)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(155, 52)
        Me.Panel3.TabIndex = 9
        Me.Panel3.Visible = False
        '
        'rbOn3
        '
        Me.rbOn3.AutoSize = True
        Me.rbOn3.Location = New System.Drawing.Point(3, 3)
        Me.rbOn3.Name = "rbOn3"
        Me.rbOn3.Size = New System.Drawing.Size(100, 17)
        Me.rbOn3.TabIndex = 6
        Me.rbOn3.TabStop = True
        Me.rbOn3.Text = "Cam 3 On - Day"
        Me.rbOn3.UseVisualStyleBackColor = True
        '
        'rbOff3
        '
        Me.rbOff3.AutoSize = True
        Me.rbOff3.Location = New System.Drawing.Point(3, 26)
        Me.rbOff3.Name = "rbOff3"
        Me.rbOff3.Size = New System.Drawing.Size(106, 17)
        Me.rbOff3.TabIndex = 7
        Me.rbOff3.TabStop = True
        Me.rbOff3.Text = "Cam 3 Off - Night"
        Me.rbOff3.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rbOn4)
        Me.Panel4.Controls.Add(Me.rbOff4)
        Me.Panel4.Location = New System.Drawing.Point(182, 125)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(155, 52)
        Me.Panel4.TabIndex = 9
        Me.Panel4.Visible = False
        '
        'rbOn4
        '
        Me.rbOn4.AutoSize = True
        Me.rbOn4.Location = New System.Drawing.Point(3, 3)
        Me.rbOn4.Name = "rbOn4"
        Me.rbOn4.Size = New System.Drawing.Size(100, 17)
        Me.rbOn4.TabIndex = 6
        Me.rbOn4.TabStop = True
        Me.rbOn4.Text = "Cam 4 On - Day"
        Me.rbOn4.UseVisualStyleBackColor = True
        '
        'rbOff4
        '
        Me.rbOff4.AutoSize = True
        Me.rbOff4.Location = New System.Drawing.Point(3, 26)
        Me.rbOff4.Name = "rbOff4"
        Me.rbOff4.Size = New System.Drawing.Size(106, 17)
        Me.rbOff4.TabIndex = 7
        Me.rbOff4.TabStop = True
        Me.rbOff4.Text = "Cam 4 Off - Night"
        Me.rbOff4.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 195)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.labelDriverId)
        Me.Controls.Add(Me.buttonConnect)
        Me.Controls.Add(Me.buttonChoose)
        Me.Name = "frmMain"
        Me.Text = "Dahua Profile Switcher Standalone Client"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents labelDriverId As System.Windows.Forms.Label
    Private WithEvents buttonConnect As System.Windows.Forms.Button
    Private WithEvents buttonChoose As System.Windows.Forms.Button
    Friend WithEvents rbOn1 As RadioButton
    Friend WithEvents rbOff1 As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rbOn2 As RadioButton
    Friend WithEvents rbOff2 As RadioButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rbOn3 As RadioButton
    Friend WithEvents rbOff3 As RadioButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents rbOn4 As RadioButton
    Friend WithEvents rbOff4 As RadioButton
End Class
