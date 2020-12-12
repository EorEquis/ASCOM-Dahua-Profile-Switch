Public Class frmMain

    Private driver As ASCOM.DriverAccess.Switch

    ''' <summary>
    ''' This event is where the driver is choosen. The device ID will be saved in the settings.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub buttonChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonChoose.Click
        My.Settings.DriverId = ASCOM.DriverAccess.Switch.Choose(My.Settings.DriverId)
        SetUIState()
    End Sub

    ''' <summary>
    ''' Connects to the device to be tested.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub buttonConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonConnect.Click
        If (IsConnected) Then
            driver.Connected = False
        Else
            driver = New ASCOM.DriverAccess.Switch(My.Settings.DriverId)
            driver.Connected = True
        End If
        SetUIState()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If IsConnected Then
            driver.Connected = False
        End If
        ' the settings are saved automatically when this application is closed.
    End Sub

    ''' <summary>
    ''' Sets the state of the UI depending on the device state
    ''' </summary>
    Private Sub SetUIState()
        buttonConnect.Enabled = Not String.IsNullOrEmpty(My.Settings.DriverId)
        buttonChoose.Enabled = Not IsConnected
        buttonConnect.Text = IIf(IsConnected, "Disconnect", "Connect")
        If IsConnected Then
            ' Show radio button panels for numCameras 
            Dim p As Panel, rbOn As RadioButton, rbOff As RadioButton
            For i As Integer = 1 To 4
                p = Me.Controls("Panel" & i.ToString)
                If i <= driver.MaxSwitch Then
                    p.Enabled = True
                    p.Visible = True
                    rbOn = p.Controls("rbOn" & i)
                    rbOff = p.Controls("rbOff" & i)
                    rbOn.Text = driver.GetSwitchName(i - 1) & " On - Day"
                    rbOff.Text = driver.GetSwitchName(i - 1) & " Off - Night"
                    If driver.GetSwitch(i - 1) Then
                        rbOn.Checked = True
                    Else
                        rbOff.Checked = False
                    End If
                Else
                    p.Enabled = False
                    p.Visible = False
                End If

            Next
        End If
    End Sub

    ''' <summary>
    ''' Gets a value indicating whether this instance is connected.
    ''' </summary>
    ''' <value>
    ''' 
    ''' <c>true</c> if this instance is connected; otherwise, <c>false</c>.
    ''' 
    ''' </value>
    Private ReadOnly Property IsConnected() As Boolean
        Get
            If Me.driver Is Nothing Then Return False
            Return driver.Connected
        End Get
    End Property

    Private Sub rbOn1_CheckedChanged(sender As Object, e As EventArgs) Handles rbOn4.CheckedChanged, rbOn3.CheckedChanged, rbOn2.CheckedChanged, rbOn1.CheckedChanged
        Dim rb As RadioButton = DirectCast(sender, RadioButton)
        Dim id As Short = CShort(Microsoft.VisualBasic.Right(rb.Name, 1))
        driver.SetSwitch(id - 1, rb.Checked)
    End Sub

End Class
