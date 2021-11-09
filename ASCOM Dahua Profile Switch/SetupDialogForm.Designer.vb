<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupDialogForm
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.chkTrace = New System.Windows.Forms.CheckBox()
        Me.txtIPAddress1 = New System.Windows.Forms.TextBox()
        Me.txtCamName1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUsername1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUsername2 = New System.Windows.Forms.TextBox()
        Me.txtIPAddress2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPassword2 = New System.Windows.Forms.TextBox()
        Me.txtCamName2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtUsername4 = New System.Windows.Forms.TextBox()
        Me.txtIPAddress4 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPassword4 = New System.Windows.Forms.TextBox()
        Me.txtCamName4 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtUsername3 = New System.Windows.Forms.TextBox()
        Me.txtIPAddress3 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPassword3 = New System.Windows.Forms.TextBox()
        Me.txtCamName3 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbNumUnits = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(545, 306)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 17
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 18
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 310)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "V 1.1.1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.ASCOM.TriStarDahuaProfile.My.Resources.Resources.ASCOM
        Me.PictureBox1.Location = New System.Drawing.Point(642, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(4, 13)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(106, 13)
        Me.label2.TabIndex = 7
        Me.label2.Text = "Camera 1 IP Address"
        '
        'chkTrace
        '
        Me.chkTrace.AutoSize = True
        Me.chkTrace.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTrace.Location = New System.Drawing.Point(11, 290)
        Me.chkTrace.Name = "chkTrace"
        Me.chkTrace.Size = New System.Drawing.Size(69, 17)
        Me.chkTrace.TabIndex = 16
        Me.chkTrace.Text = "Trace on"
        Me.chkTrace.UseVisualStyleBackColor = True
        '
        'txtIPAddress1
        '
        Me.txtIPAddress1.Location = New System.Drawing.Point(116, 10)
        Me.txtIPAddress1.Name = "txtIPAddress1"
        Me.txtIPAddress1.Size = New System.Drawing.Size(165, 20)
        Me.txtIPAddress1.TabIndex = 0
        '
        'txtCamName1
        '
        Me.txtCamName1.Location = New System.Drawing.Point(116, 34)
        Me.txtCamName1.Name = "txtCamName1"
        Me.txtCamName1.Size = New System.Drawing.Size(165, 20)
        Me.txtCamName1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Camera 1 Name"
        '
        'txtPassword1
        '
        Me.txtPassword1.Location = New System.Drawing.Point(116, 86)
        Me.txtPassword1.Name = "txtPassword1"
        Me.txtPassword1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword1.Size = New System.Drawing.Size(165, 20)
        Me.txtPassword1.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Camera 1 Password"
        '
        'txtUsername1
        '
        Me.txtUsername1.Location = New System.Drawing.Point(116, 60)
        Me.txtUsername1.Name = "txtUsername1"
        Me.txtUsername1.Size = New System.Drawing.Size(165, 20)
        Me.txtUsername1.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Camera 1 User Name"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.label2)
        Me.Panel1.Controls.Add(Me.txtUsername1)
        Me.Panel1.Controls.Add(Me.txtIPAddress1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtPassword1)
        Me.Panel1.Controls.Add(Me.txtCamName1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(302, 117)
        Me.Panel1.TabIndex = 16
        Me.Panel1.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtUsername2)
        Me.Panel2.Controls.Add(Me.txtIPAddress2)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtPassword2)
        Me.Panel2.Controls.Add(Me.txtCamName2)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Location = New System.Drawing.Point(320, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(302, 117)
        Me.Panel2.TabIndex = 17
        Me.Panel2.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Camera 2 IP Address"
        '
        'txtUsername2
        '
        Me.txtUsername2.Location = New System.Drawing.Point(116, 60)
        Me.txtUsername2.Name = "txtUsername2"
        Me.txtUsername2.Size = New System.Drawing.Size(165, 20)
        Me.txtUsername2.TabIndex = 6
        '
        'txtIPAddress2
        '
        Me.txtIPAddress2.Location = New System.Drawing.Point(116, 10)
        Me.txtIPAddress2.Name = "txtIPAddress2"
        Me.txtIPAddress2.Size = New System.Drawing.Size(165, 20)
        Me.txtIPAddress2.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Camera 2 User Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Camera 2 Name"
        '
        'txtPassword2
        '
        Me.txtPassword2.Location = New System.Drawing.Point(116, 86)
        Me.txtPassword2.Name = "txtPassword2"
        Me.txtPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword2.Size = New System.Drawing.Size(165, 20)
        Me.txtPassword2.TabIndex = 7
        '
        'txtCamName2
        '
        Me.txtCamName2.Location = New System.Drawing.Point(116, 34)
        Me.txtCamName2.Name = "txtCamName2"
        Me.txtCamName2.Size = New System.Drawing.Size(165, 20)
        Me.txtCamName2.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Camera 2 Password"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.txtUsername4)
        Me.Panel4.Controls.Add(Me.txtIPAddress4)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.txtPassword4)
        Me.Panel4.Controls.Add(Me.txtCamName4)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Location = New System.Drawing.Point(320, 167)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(302, 117)
        Me.Panel4.TabIndex = 19
        Me.Panel4.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Camera 4 IP Address"
        '
        'txtUsername4
        '
        Me.txtUsername4.Location = New System.Drawing.Point(116, 60)
        Me.txtUsername4.Name = "txtUsername4"
        Me.txtUsername4.Size = New System.Drawing.Size(165, 20)
        Me.txtUsername4.TabIndex = 14
        '
        'txtIPAddress4
        '
        Me.txtIPAddress4.Location = New System.Drawing.Point(116, 10)
        Me.txtIPAddress4.Name = "txtIPAddress4"
        Me.txtIPAddress4.Size = New System.Drawing.Size(165, 20)
        Me.txtIPAddress4.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(2, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Camera 4 User Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(27, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Camera 4 Name"
        '
        'txtPassword4
        '
        Me.txtPassword4.Location = New System.Drawing.Point(116, 86)
        Me.txtPassword4.Name = "txtPassword4"
        Me.txtPassword4.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword4.Size = New System.Drawing.Size(165, 20)
        Me.txtPassword4.TabIndex = 15
        '
        'txtCamName4
        '
        Me.txtCamName4.Location = New System.Drawing.Point(116, 34)
        Me.txtCamName4.Name = "txtCamName4"
        Me.txtCamName4.Size = New System.Drawing.Size(165, 20)
        Me.txtCamName4.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Camera 4 Password"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txtUsername3)
        Me.Panel3.Controls.Add(Me.txtIPAddress3)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.txtPassword3)
        Me.Panel3.Controls.Add(Me.txtCamName3)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Location = New System.Drawing.Point(12, 167)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(302, 117)
        Me.Panel3.TabIndex = 18
        Me.Panel3.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Camera 3 IP Address"
        '
        'txtUsername3
        '
        Me.txtUsername3.Location = New System.Drawing.Point(116, 60)
        Me.txtUsername3.Name = "txtUsername3"
        Me.txtUsername3.Size = New System.Drawing.Size(165, 20)
        Me.txtUsername3.TabIndex = 10
        '
        'txtIPAddress3
        '
        Me.txtIPAddress3.Location = New System.Drawing.Point(116, 10)
        Me.txtIPAddress3.Name = "txtIPAddress3"
        Me.txtIPAddress3.Size = New System.Drawing.Size(165, 20)
        Me.txtIPAddress3.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(2, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Camera 3 User Name"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(27, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Camera 3 Name"
        '
        'txtPassword3
        '
        Me.txtPassword3.Location = New System.Drawing.Point(116, 86)
        Me.txtPassword3.Name = "txtPassword3"
        Me.txtPassword3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword3.Size = New System.Drawing.Size(165, 20)
        Me.txtPassword3.TabIndex = 11
        '
        'txtCamName3
        '
        Me.txtCamName3.Location = New System.Drawing.Point(116, 34)
        Me.txtCamName3.Name = "txtCamName3"
        Me.txtCamName3.Size = New System.Drawing.Size(165, 20)
        Me.txtCamName3.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 89)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 13)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Camera 3 Password"
        '
        'cbNumUnits
        '
        Me.cbNumUnits.FormattingEnabled = True
        Me.cbNumUnits.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cbNumUnits.Location = New System.Drawing.Point(128, 12)
        Me.cbNumUnits.Name = "cbNumUnits"
        Me.cbNumUnits.Size = New System.Drawing.Size(62, 21)
        Me.cbNumUnits.TabIndex = 20
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(21, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 13)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Number of Cameras"
        '
        'SetupDialogForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(703, 347)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cbNumUnits)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkTrace)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetupDialogForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Profile Switcher Setup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents chkTrace As System.Windows.Forms.CheckBox
    Friend WithEvents txtIPAddress1 As TextBox
    Friend WithEvents txtCamName1 As TextBox
    Private WithEvents Label3 As Label
    Friend WithEvents txtPassword1 As TextBox
    Private WithEvents Label4 As Label
    Friend WithEvents txtUsername1 As TextBox
    Private WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Private WithEvents Label6 As Label
    Friend WithEvents txtUsername2 As TextBox
    Friend WithEvents txtIPAddress2 As TextBox
    Private WithEvents Label7 As Label
    Private WithEvents Label8 As Label
    Friend WithEvents txtPassword2 As TextBox
    Friend WithEvents txtCamName2 As TextBox
    Private WithEvents Label9 As Label
    Friend WithEvents Panel4 As Panel
    Private WithEvents Label10 As Label
    Friend WithEvents txtUsername4 As TextBox
    Friend WithEvents txtIPAddress4 As TextBox
    Private WithEvents Label11 As Label
    Private WithEvents Label12 As Label
    Friend WithEvents txtPassword4 As TextBox
    Friend WithEvents txtCamName4 As TextBox
    Private WithEvents Label13 As Label
    Friend WithEvents Panel3 As Panel
    Private WithEvents Label14 As Label
    Friend WithEvents txtUsername3 As TextBox
    Friend WithEvents txtIPAddress3 As TextBox
    Private WithEvents Label15 As Label
    Private WithEvents Label16 As Label
    Friend WithEvents txtPassword3 As TextBox
    Friend WithEvents txtCamName3 As TextBox
    Private WithEvents Label17 As Label
    Friend WithEvents cbNumUnits As ComboBox
    Friend WithEvents Label18 As Label
End Class
