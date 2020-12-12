Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports ASCOM.Utilities
Imports ASCOM.TriStarDahuaProfile

<ComVisible(False)> _
Public Class SetupDialogForm

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click ' OK button event handler
        ' Persist new values of user settings to the ASCOM profile
        Switch.traceState = chkTrace.Checked
        Switch.numCameras = CInt(cbNumUnits.SelectedItem)

        Dim p As Panel, ti As TextBox, tn As TextBox, tu As TextBox, tp As TextBox
        For i As Integer = 1 To Switch.numCameras
            p = Me.Controls("Panel" & i.ToString)
            ti = p.Controls("txtIPAddress" & i.ToString)
            tn = p.Controls("txtCamName" & i.ToString)
            tu = p.Controls("txtUsername" & i.ToString)
            tp = p.Controls("txtPassword" & i.ToString)
            Switch.IPAddress(i - 1) = ti.Text
            Switch.CameraName(i - 1) = tn.Text
            Switch.camUsername(i - 1) = tu.Text
            Switch.camPassword(i - 1) = tp.Text
        Next ' i

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click 'Cancel button event handler
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ShowAscomWebPage(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick, PictureBox1.Click
        ' Click on ASCOM logo event handler
        Try
            System.Diagnostics.Process.Start("https://ascom-standards.org/")
        Catch noBrowser As System.ComponentModel.Win32Exception
            If noBrowser.ErrorCode = -2147467259 Then
                MessageBox.Show(noBrowser.Message)
            End If
        Catch other As System.Exception
            MessageBox.Show(other.Message)
        End Try
    End Sub

    Private Sub SetupDialogForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load ' Form load event handler
        ' Retrieve current values of user settings from the ASCOM Profile
        InitUI()
    End Sub

    Private Sub InitUI()
        chkTrace.Checked = Switch.traceState
        If cbNumUnits.Items.Contains(Switch.numCameras.ToString) Then
            cbNumUnits.SelectedItem = Switch.numCameras.ToString
        Else
            cbNumUnits.SelectedItem = "1"
        End If
        ' Enable the config panels based on number of cameras
        Dim p As Panel, ti As TextBox, tn As TextBox, tu As TextBox, tp As TextBox
        For i As Integer = 1 To 4
            p = Me.Controls("Panel" & i.ToString)

            If i <= Switch.numCameras Then      ' This is an active camera, set the panel visible and fille the text boxes
                p.Visible = True
                p.Enabled = True
                ti = p.Controls("txtIPAddress" & i.ToString)
                tn = p.Controls("txtCamName" & i.ToString)
                tu = p.Controls("txtUsername" & i.ToString)
                tp = p.Controls("txtPassword" & i.ToString)
                ti.Text = Switch.IPAddress(i - 1)
                tn.Text = Switch.CameraName(i - 1)
                tu.Text = Switch.camUsername(i - 1)
                tp.Text = Switch.camPassword(i - 1)
            Else
                p.Visible = False
                p.Enabled = False
            End If
        Next ' i

    End Sub

    Private Sub cbNumUnits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNumUnits.SelectedIndexChanged
        Switch.numCameras = CInt(cbNumUnits.SelectedItem)
        InitUI()
    End Sub
End Class
