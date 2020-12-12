'tabs=4
' --------------------------------------------------------------------------------
' ASCOM Switch driver for TriStarDahuaProfile
'
' Description:	An ASCOM switch to allow turning Dahua camera IR on/off for imaging. 
'				Uses the Dahua API to switch between a Day and Night profile.
'				Presumes Night profile has IR disabled.
'
' Implements:	ASCOM Switch interface version: 1.0
' Author:		(Eor) EorEquis@tristarobservatory.com
'
' Edit Log:
'
' Date			Who	Vers	Description
' -----------	---	-----	-------------------------------------------------------
' 2020-12-12	Eor	1.0.0	Initial edit, from Switch template
' ---------------------------------------------------------------------------------
'
'
' Your driver's ID is ASCOM.TriStarDahuaProfile.Switch
'
' The Guid attribute sets the CLSID for ASCOM.DeviceName.Switch
' The ClassInterface/None attribute prevents an empty interface called
' _Switch from being created and used as the [default] interface
'

' This definition is used to select code that's only applicable for one device type
#Const Device = "Switch"

Imports ASCOM
Imports ASCOM.Astrometry
Imports ASCOM.Astrometry.AstroUtils
Imports ASCOM.DeviceInterface
Imports ASCOM.Utilities

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Text

<Guid("d06307d8-ed81-4611-8c71-4ba2a46dd4c1")>
<ClassInterface(ClassInterfaceType.None)>
Public Class Switch

    ' The Guid attribute sets the CLSID for ASCOM.TriStarDahuaProfile.Switch
    ' The ClassInterface/None attribute prevents an empty interface called
    ' _TriStarDahuaProfile from being created and used as the [default] interface

    ' TODO Replace the not implemented exceptions with code to implement the function or
    ' throw the appropriate ASCOM exception.
    '
    Implements ISwitchV2

    '
    ' Driver ID and descriptive string that shows in the Chooser
    '
    Friend Shared driverID As String = "ASCOM.TriStarDahuaProfile.Switch"
    Private Shared driverDescription As String = "TriStar Dahua Camera Profile Switch"

    Friend Shared IPProfileName As String = "IP Address"
    Friend Shared traceStateProfileName As String = "Trace Level"
    Friend Shared IPDefault As String = "192.168.1.108"     ' Default IP of Dahua Cameras
    Friend Shared traceStateDefault As String = "True"
    Friend Shared cameraNameProfileName As String = "Camera Name"
    Friend Shared cameraNameDefault As String = "ObsCam"
    Friend Shared usernameProfileName As String = "Username"
    Friend Shared usernameDefault As String = "admin"
    Friend Shared passwordProfileName As String = "Password"
    Friend Shared passwordDefault As String = ""

    Friend Shared IPAddress As String                       ' IP Address of Dahua Camera
    Friend Shared traceState As Boolean
    Friend Shared CameraName As String                      ' Name of camera and switch
    Friend Shared SwitchState As Boolean                    ' True == Day, False == Night
    Friend Shared camUsername As String                     ' Camera username
    Friend Shared camPassword As String                     ' Camera password

    Private connectedState As Boolean                       ' Private variable to hold the connected state
    Private utilities As Util                               ' Private variable to hold an ASCOM Utilities object
    Private astroUtilities As AstroUtils                    ' Private variable to hold an AstroUtils object to provide the Range method
    Private TL As TraceLogger                               ' Private variable to hold the trace logger object (creates a diagnostic log file with information that you specify)
    Private VerMaj As String = "1"
    Private VerMin As String = "0"
    Private VerBuild As String = "0"

    '
    ' Constructor - Must be public for COM registration!
    '
    Public Sub New()

        ReadProfile() ' Read device configuration from the ASCOM Profile store
        TL = New TraceLogger("", "TriStarDahuaProfile")
        TL.Enabled = traceState
        TL.LogMessage("Switch", "Starting initialisation")

        connectedState = False ' Initialise connected to false
        utilities = New Util() ' Initialise util object
        astroUtilities = New AstroUtils 'Initialise new astro utilities object
        numSwitches = 1
        TL.LogMessage("Switch", "Completed initialisation")
    End Sub

    '
    ' PUBLIC COM INTERFACE ISwitchV2 IMPLEMENTATION
    '

#Region "Common properties and methods"
    ''' <summary>
    ''' Displays the Setup Dialog form.
    ''' If the user clicks the OK button to dismiss the form, then
    ''' the new settings are saved, otherwise the old values are reloaded.
    ''' THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
    ''' </summary>
    Public Sub SetupDialog() Implements ISwitchV2.SetupDialog
        ' consider only showing the setup dialog if not connected
        ' or call a different dialog if connected
        If IsConnected Then
            System.Windows.Forms.MessageBox.Show("Already connected, just press OK")
        End If

        Using F As SetupDialogForm = New SetupDialogForm()
            Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
            If result = DialogResult.OK Then
                WriteProfile() ' Persist device configuration values to the ASCOM Profile store
            End If
        End Using
    End Sub

    Public ReadOnly Property SupportedActions() As ArrayList Implements ISwitchV2.SupportedActions
        Get
            TL.LogMessage("SupportedActions Get", "Returning empty arraylist")
            Return New ArrayList()
        End Get
    End Property

    Public Function Action(ByVal ActionName As String, ByVal ActionParameters As String) As String Implements ISwitchV2.Action
        Throw New ActionNotImplementedException("Action " & ActionName & " is not supported by this driver")
    End Function

    Public Sub CommandBlind(ByVal Command As String, Optional ByVal Raw As Boolean = False) Implements ISwitchV2.CommandBlind
        CheckConnected("CommandBlind")
        ' TODO The optional CommandBlind method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandBlind must send the supplied command to the mount And return immediately without waiting for a response

        Throw New MethodNotImplementedException("CommandBlind")
    End Sub

    Public Function CommandBool(ByVal Command As String, Optional ByVal Raw As Boolean = False) As Boolean _
        Implements ISwitchV2.CommandBool
        CheckConnected("CommandBool")
        ' TODO The optional CommandBool method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandBool must send the supplied command to the mount, wait for a response and parse this to return a True Or False value

        ' Dim retString as String = CommandString(command, raw) ' Send the command And wait for the response
        ' Dim retBool as Boolean = XXXXXXXXXXXXX ' Parse the returned string And create a boolean True / False value
        ' Return retBool ' Return the boolean value to the client

        Throw New MethodNotImplementedException("CommandBool")
    End Function

    Public Function CommandString(ByVal Command As String, Optional ByVal Raw As Boolean = False) As String _
        Implements ISwitchV2.CommandString
        CheckConnected("CommandString")
        ' TODO The optional CommandString method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandString must send the supplied command to the mount and wait for a response before returning this to the client

        Throw New MethodNotImplementedException("CommandString")
    End Function

    Public Property Connected() As Boolean Implements ISwitchV2.Connected
        Get
            TL.LogMessage("Connected Get", IsConnected.ToString())
            Return IsConnected
        End Get
        Set(value As Boolean)
            TL.LogMessage("Connected Set", value.ToString())
            If value = IsConnected Then
                Return
            End If

            ' There is no persistent connection to the camera by this driver, so we just do whatever the client asked for.
            SwitchState = getCurrentMode()
            connectedState = value
            TL.LogMessage("Connected Set", value.ToString)
        End Set
    End Property

    Public ReadOnly Property Description As String Implements ISwitchV2.Description
        Get
            ' this pattern seems to be needed to allow a public property to return a private field
            Dim d As String = driverDescription
            TL.LogMessage("Description Get", d)
            Return d
        End Get
    End Property

    Public ReadOnly Property DriverInfo As String Implements ISwitchV2.DriverInfo
        Get
            Dim m_version As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
            ' TODO customise this driver description
            Dim s_driverInfo As String = "Information about the driver itself. Version: " + VerMaj + "." + VerMin
            TL.LogMessage("DriverInfo Get", s_driverInfo)
            Return s_driverInfo
        End Get
    End Property

    Public ReadOnly Property DriverVersion() As String Implements ISwitchV2.DriverVersion
        Get
            ' Get our own assembly and report its version number
            Dim s_driverInfo As String = VerMaj + "." + VerMin
            TL.LogMessage("DriverVersion Get", s_driverInfo)
            Return s_driverInfo
        End Get
    End Property

    Public ReadOnly Property InterfaceVersion() As Short Implements ISwitchV2.InterfaceVersion
        Get
            TL.LogMessage("InterfaceVersion Get", "2")
            Return 2
        End Get
    End Property

    Public ReadOnly Property Name As String Implements ISwitchV2.Name
        Get
            Dim s_name As String = "Dahua Profile Switch"
            TL.LogMessage("Name Get", s_name)
            Return s_name
        End Get
    End Property

    Public Sub Dispose() Implements ISwitchV2.Dispose
        ' Clean up the trace logger and util objects
        TL.Enabled = False
        TL.Dispose()
        TL = Nothing
        utilities.Dispose()
        utilities = Nothing
        astroUtilities.Dispose()
        astroUtilities = Nothing
    End Sub

#End Region

#Region "ISwitchV2 Implementation"

    Dim numSwitches As Short    ' Only support one camera for now.  I'll build out multi cam support if I ever get another Dahua :)


    ''' <summary>
    ''' The number of switches managed by this driver
    ''' </summary>
    Public ReadOnly Property MaxSwitch As Short Implements ISwitchV2.MaxSwitch
        Get
            TL.LogMessage("MaxSwitch Get", numSwitches.ToString())
            Return numSwitches
        End Get
    End Property

    ''' <summary>
    ''' Return the name of switch n
    ''' </summary>
    ''' <param name="id">The switch number to return</param>
    ''' <returns>The name of the switch</returns>
    Public Function GetSwitchName(id As Short) As String Implements ISwitchV2.GetSwitchName
        Validate("GetSwitchName", id)
        TL.LogMessage("GetSwitchName", "Returning CameraName " + CameraName)
        Return CameraName
    End Function

    ''' <summary>
    ''' Sets a switch name to a specified value
    ''' </summary>
    ''' <param name="id">The number of the switch whose name is to be set</param>
    ''' <param name="name">The name of the switch</param>
    Sub SetSwitchName(id As Short, name As String) Implements ISwitchV2.SetSwitchName
        Validate("SetSwitchName", id)
        TL.LogMessage("SetSwitchName", "Not Implemented")
        Throw New ASCOM.MethodNotImplementedException("SetSwitchName")
    End Sub

    ''' <summary>
    ''' Gets the description of the specified switch. This is to allow a fuller description of
    ''' the switch to be returned, for example for a tool tip.
    ''' </summary>
    ''' <param name="id">The number of the switch whose description is to be returned</param><returns></returns>
    ''' <exception cref="MethodNotImplementedException">If the method is not implemented</exception>
    ''' <exception cref="InvalidValueException">If id is outside the range 0 to MaxSwitch - 1</exception>
    Public Function GetSwitchDescription(id As Short) As String Implements ISwitchV2.GetSwitchDescription
        Validate("GetSwitchDescription", id)
        TL.LogMessage("GetSwitchDescription", "Not Implemented")
        Throw New ASCOM.MethodNotImplementedException("GetSwitchDescription")
    End Function

    ''' <summary>
    ''' Reports if the specified switch can be written to.
    ''' This is false if the switch cannot be written to, for example a limit switch or a sensor.
    ''' The default is true.
    ''' </summary>
    ''' <param name="id">The number of the switch whose write state is to be returned</param><returns>
    '''   <c>true</c> if the switch can be set, otherwise <c>false</c>.
    ''' </returns>
    ''' <exception cref="MethodNotImplementedException">If the method is not implemented</exception>
    ''' <exception cref="InvalidValueException">If id is outside the range 0 to MaxSwitch - 1</exception>
    Public Function CanWrite(id As Short) As Boolean Implements ISwitchV2.CanWrite
        Validate("CanWrite", id)
        TL.LogMessage("CanWrite", "Default true")
        Return True
    End Function

#Region "boolean members"
    ''' <summary>
    ''' Return the state of switch n as a boolean
    ''' A multi-value switch must throw a MethodNotImplementedException.
    ''' </summary>
    ''' <param name="id">The switch number to return</param>
    ''' <returns>True or false</returns>
    Function GetSwitch(id As Short) As Boolean Implements ISwitchV2.GetSwitch
        Validate("GetSwitch", id, True)
        TL.LogMessage("GetSwitch", "Returned " + SwitchState.ToString)
        Return SwitchState
    End Function

    ''' <summary>
    ''' Sets a switch to the specified state, true or false.
    ''' If the switch cannot be set then throws a MethodNotImplementedException.
    ''' A multi-value switch must throw a MethodNotImplementedException.
    ''' </summary>
    ''' <param name="ID">The number of the switch to set</param>
    ''' <param name="State">The required switch state</param>
    Sub SetSwitch(id As Short, state As Boolean) Implements ISwitchV2.SetSwitch
        Validate("SetSwitch", id, True)
        setMode(state)
        SwitchState = state
        TL.LogMessage("SetSwitch", "Set SwitchState to " + SwitchState.ToString)
    End Sub

#End Region

#Region "Analogue members"
    ''' <summary>
    ''' returns the maximum analogue value for this switch
    ''' boolean switches must return 1.0
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function MaxSwitchValue(id As Short) As Double Implements ISwitchV2.MaxSwitchValue
        Validate("MaxSwitchValue", id)
        TL.LogMessage("MaxSwitchValue", "Returning 1.0")
        Return 1.0
    End Function

    ''' <summary>
    ''' returns the minimum analogue value for this switch
    ''' boolean switches must return 0.0
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function MinSwitchValue(id As Short) As Double Implements ISwitchV2.MinSwitchValue
        Validate("MinSwitchValue", id)
        TL.LogMessage("MinSwitchValue", "Returning 0.0")
        Return 0.0
    End Function

    ''' <summary>
    ''' returns the step size that this switch supports. This gives the difference between
    ''' successive values of the switch.
    ''' The number of values is ((MaxSwitchValue - MinSwitchValue) / SwitchStep) + 1
    ''' boolean switches must return 1.0, giving two states.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function SwitchStep(id As Short) As Double Implements ISwitchV2.SwitchStep
        Validate("SwitchStep", id)
        TL.LogMessage("SwitchStep", "Returning 1.0")
        Return 1.0
    End Function

    ''' <summary>
    ''' returns the analogue switch value for switch id
    ''' boolean switches must throw a MethodNotImplementedException
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function GetSwitchValue(id As Short) As Double Implements ISwitchV2.GetSwitchValue
        Validate("GetSwitchValue", id, False)
        TL.LogMessage("GetSwitchValue", "Not Implemented")
        Throw New ASCOM.MethodNotImplementedException("GetSwitchValue")
    End Function

    ''' <summary>
    ''' set the analogue value for this switch.
    ''' If the switch cannot be set then throws a MethodNotImplementedException.
    ''' If the value is not between the maximum and minimum then throws an InvalidValueException
    ''' boolean switches must throw a MethodNotImplementedException
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="value"></param>
    Sub SetSwitchValue(id As Short, value As Double) Implements ISwitchV2.SetSwitchValue
        Validate("SetSwitchValue", id, value)
        If value < MinSwitchValue(id) Or value > MaxSwitchValue(id) Then
            Throw New InvalidValueException("", value.ToString(), String.Format("{0} to {1}", MinSwitchValue(id), MaxSwitchValue(id)))
        End If
        TL.LogMessage("SetSwitchValue", "Not Implemented")
        Throw New ASCOM.MethodNotImplementedException("SetSwitchValue")
    End Sub

#End Region
#End Region

    ''' <summary>
    ''' Checks that the switch id is in range and throws an InvalidValueException if it isn't
    ''' </summary>
    ''' <param name="message">The message.</param>
    ''' <param name="id">The id.</param>
    Private Sub Validate(message As String, id As Short)
        If (id < 0 Or id >= numSwitches) Then
            Throw New ASCOM.InvalidValueException(message, id.ToString(), String.Format("0 to {0}", numSwitches - 1))
        End If
    End Sub

    ''' <summary>
    ''' Checks that the number of states for the switch is correct and throws a methodNotImplemented exception if not.
    ''' Boolean switches must have 2 states and multi-value switches more than 2.
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="id"></param>
    ''' <param name="expectBoolean"></param>
    Private Sub Validate(message As String, id As Short, expectBoolean As Boolean)
        Validate(message, id)
        Dim ns As Integer = (((MaxSwitchValue(id) - MinSwitchValue(id)) / SwitchStep(id)) + 1)
        If (expectBoolean And ns <> 2) Or (Not expectBoolean And ns <= 2) Then
            TL.LogMessage(message, String.Format("Switch {0} has the wrong number of states", id, ns))
            Throw New MethodNotImplementedException(String.Format("{0}({1})", message, id))
        End If
    End Sub

    ''' <summary>
    ''' Checks that the switch id and value are in range and throws an
    ''' InvalidValueException if they are not.
    ''' </summary>
    ''' <param name="message">The message.</param>
    ''' <param name="id">The id.</param>
    ''' <param name="value">The value.</param>
    Private Sub Validate(message As String, id As Short, value As Double)
        Validate(message, id, False)
        Dim min = MinSwitchValue(id)
        Dim max = MaxSwitchValue(id)
        If (value < min Or value > max) Then
            TL.LogMessage(message, String.Format("Value {1} for Switch {0} is out of the allowed range {2} to {3}", id, value, min, max))
            Throw New InvalidValueException(message, value.ToString(), String.Format("Switch({0}) range {1} to {2}", id, min, max))
        End If
    End Sub


#Region "Private properties and methods"
    ' here are some useful properties and methods that can be used as required
    ' to help with

#Region "ASCOM Registration"

    Private Shared Sub RegUnregASCOM(ByVal bRegister As Boolean)

        Using P As New Profile() With {.DeviceType = "Switch"}
            If bRegister Then
                P.Register(driverID, driverDescription)
            Else
                P.Unregister(driverID)
            End If
        End Using

    End Sub

    <ComRegisterFunction()>
    Public Shared Sub RegisterASCOM(ByVal T As Type)

        RegUnregASCOM(True)

    End Sub

    <ComUnregisterFunction()>
    Public Shared Sub UnregisterASCOM(ByVal T As Type)

        RegUnregASCOM(False)

    End Sub

#End Region

    ''' <summary>
    ''' Returns true if there is a valid connection to the driver hardware
    ''' </summary>
    Private ReadOnly Property IsConnected As Boolean
        Get
            ' TODO check that the driver hardware connection exists and is connected to the hardware
            Return connectedState
        End Get
    End Property

    ''' <summary>
    ''' Use this function to throw an exception if we aren't connected to the hardware
    ''' </summary>
    ''' <param name="message"></param>
    Private Sub CheckConnected(ByVal message As String)
        If Not IsConnected Then
            Throw New NotConnectedException(message)
        End If
    End Sub

    ''' <summary>
    ''' Read the device configuration from the ASCOM Profile store
    ''' </summary>
    Friend Sub ReadProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"
            traceState = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, String.Empty, traceStateDefault))
            IPAddress = driverProfile.GetValue(driverID, IPProfileName, String.Empty, IPDefault)
            CameraName = driverProfile.GetValue(driverID, cameraNameProfileName, String.Empty, cameraNameDefault)
            camUsername = driverProfile.GetValue(driverID, usernameProfileName, String.Empty, usernameDefault)
            camPassword = driverProfile.GetValue(driverID, passwordProfileName, String.Empty, passwordDefault)
        End Using
    End Sub

    ''' <summary>
    ''' Write the device configuration to the  ASCOM  Profile store
    ''' </summary>
    Friend Sub WriteProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"
            driverProfile.WriteValue(driverID, traceStateProfileName, traceState.ToString())
            driverProfile.WriteValue(driverID, IPProfileName, IPAddress)
            driverProfile.WriteValue(driverID, cameraNameProfileName, CameraName)
            driverProfile.WriteValue(driverID, usernameProfileName, camUsername)
            driverProfile.WriteValue(driverID, passwordProfileName, camPassword)
        End Using

    End Sub

#End Region

#Region "My functions"
    Private Function getCurrentMode() As Boolean
        Dim client As New System.Net.WebClient
        Dim credentials As New System.Net.CredentialCache()
        Dim getConfigURI As New Uri("http://" + IPAddress + "/cgi-bin/configManager.cgi?action=getConfig&name=VideoInMode[0].Config[0]")
        credentials.Add(getConfigURI, "Digest", New Net.NetworkCredential(camUsername, camPassword))
        client.Credentials = credentials
        Dim response As String
        Try
            response = client.DownloadString(getConfigURI)
            If response = "table.VideoInMode[0].Config[0]=1" Then
                Return False        ' Night mode, no IR
            Else
                Return True         ' Day mode, IR available
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub setMode(val As Boolean)
        Dim client As New System.Net.WebClient
        Dim credentials As New System.Net.CredentialCache()
        Dim strURI As String = "http://" + IPAddress + "/cgi-bin/configManager.cgi?action=setConfig&VideoInMode[0].Config[0]"
        If val Then
            strURI = strURI + "=0"
        Else
            strURI = strURI + "=1"
        End If
        Dim setConfigURI As New Uri(strURI)
        credentials.Add(setConfigURI, "Digest", New Net.NetworkCredential(camUsername, camPassword))
        client.Credentials = credentials
        Dim response As String = client.DownloadString(setConfigURI)
    End Sub
#End Region

End Class
