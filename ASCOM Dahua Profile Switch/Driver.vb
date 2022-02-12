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
' 2020-12-12	Eor	1.0.1	Fix an issue w/ GetSwitchValue() causing conformance to fail.
' 2020-12-12	Eor	1.0.2	Fix an issue w/ SetSwitchValue() causing conformance to fail.
' 2020-12-12	Eor	1.1.0	First working multi-camera version
' 2020-12-13	Eor	1.1.1	Clean up / add comments, some array sizes changed to use numCameras
' 2021-11-09    Eor 1.2.0   Trying to make things work with NINA, no clue why this driver has gone kablooey
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
    Friend Shared cameraNameProfileName As String = "Camera Name"
    Friend Shared usernameProfileName As String = "Username"
    Friend Shared passwordProfileName As String = "Password"
    Friend Shared numCamerasProfileName As String = "Number of Cameras"

    Friend Shared IPDefault As String = "192.168.1.108"     ' Default IP of Dahua Cameras
    Friend Shared traceStateDefault As String = "True"
    Friend Shared cameraNameDefault As String = "Camera"
    Friend Shared usernameDefault As String = "admin"       ' Default username for Dahua cameras
    Friend Shared passwordDefault As String = "admin"       ' Default password for Dahua cameras
    Friend Shared numCamerasDefault As Integer = 1

    Friend Shared numCameras As Short

    Friend Shared traceState As Boolean
    ' *******  4 element arrays to hold values for up to 4 cameras
    Friend Shared IPAddress(3) As String                    ' IP Address of Dahua Camera
    Friend Shared CameraName(3) As String                   ' Name of camera and switch
    Friend Shared SwitchState(3) As Boolean                 ' True == Day, False == Night
    Friend Shared camUsername(3) As String                  ' Camera username
    Friend Shared camPassword(3) As String                  ' Camera password

    Private connectedState As Boolean                       ' Private variable to hold the connected state
    Private utilities As Util                               ' Private variable to hold an ASCOM Utilities object
    Private astroUtilities As AstroUtils                    ' Private variable to hold an AstroUtils object to provide the Range method
    Private TL As TraceLogger                               ' Private variable to hold the trace logger object (creates a diagnostic log file with information that you specify)
    Private VerMaj As String = "1"
    Private VerMin As String = "1"
    Private VerBuild As String = "1"

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
        If IsConnected Then     ' Only show setup dialog if not connected.
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
        Throw New MethodNotImplementedException("CommandBlind")
    End Sub

    Public Function CommandBool(ByVal Command As String, Optional ByVal Raw As Boolean = False) As Boolean _
        Implements ISwitchV2.CommandBool
        CheckConnected("CommandBool")
        Throw New MethodNotImplementedException("CommandBool")
    End Function

    Public Function CommandString(ByVal Command As String, Optional ByVal Raw As Boolean = False) As String _
        Implements ISwitchV2.CommandString
        CheckConnected("CommandString")
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
            Dim s_driverInfo As String = "Driver Version: " + VerMaj + "." + VerMin
            TL.LogMessage("DriverInfo Get", s_driverInfo)
            Return s_driverInfo
        End Get
    End Property

    Public ReadOnly Property DriverVersion() As String Implements ISwitchV2.DriverVersion
        Get
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

    ''' <summary>
    ''' The number of switches managed by this driver
    ''' </summary>
    Public ReadOnly Property MaxSwitch As Short Implements ISwitchV2.MaxSwitch
        Get
            TL.LogMessage("MaxSwitch Get", numCameras.ToString())
            Return numCameras       ' numCameras comes from the profile, set when showing setup dialog
        End Get
    End Property

    ''' <summary>
    ''' Return the name of switch n
    ''' </summary>
    ''' <param name="id">The switch number to return</param>
    ''' <returns>The name of the switch</returns>
    Public Function GetSwitchName(id As Short) As String Implements ISwitchV2.GetSwitchName
        Validate("GetSwitchName", id)
        TL.LogMessage("GetSwitchName", "Returning CameraName " + CameraName(id))
        Return CameraName(id)
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
        TL.LogMessage("GetSwitchDescription", "Returning " + CameraName(id))
        Return CameraName(id)
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
        Return True     ' All cameras can be written to : Told to switch profile
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
        TL.LogMessage("GetSwitch", "Returned " + SwitchState(id).ToString)
        Return SwitchState(id)      ' We don't actually check switch state after initial connection...just track it when switch is set.
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
        setMode(id, state)
        SwitchState(id) = state     ' Track the switch state.  No need to bother the camera and as.
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
        TL.LogMessage("MaxSwitchValue", "Returning 1.0")    ' Our switches are boolean.  Either on/off, day/night
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
        TL.LogMessage("MinSwitchValue", "Returning 0.0")   ' Our switches are boolean.  Either on/off, day/night
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
        TL.LogMessage("SwitchStep", "Returning 1.0")   ' Our switches are boolean.  Either on/off, day/night
        Return 1.0
    End Function

    ''' <summary>
    ''' returns the analogue switch value for switch id
    ''' boolean switches must throw a MethodNotImplementedException
    ''' This is not true, they just haven't updated the template.  Docs now say it must not throw MethodNotImplementedException
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function GetSwitchValue(id As Short) As Double Implements ISwitchV2.GetSwitchValue
        Dim retVal As Double
        Validate("GetSwitchValue", id, True)
        If GetSwitch(id) Then
            retVal = 1.0
        Else
            retVal = 0.0
        End If
        TL.LogMessage("GetSwitchValue", String.Format("Switch id {0} : {1}", id, retVal))
        Return retVal
    End Function

    ''' <summary>
    ''' set the analogue value for this switch.
    ''' If the switch cannot be set then throws a MethodNotImplementedException.
    ''' If the value is not between the maximum and minimum then throws an InvalidValueException
    ''' boolean switches must throw a MethodNotImplementedException
    ''' This is not true, they just haven't updated the template.  Docs now say it must not throw MethodNotImplementedException
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="value"></param>
    Sub SetSwitchValue(id As Short, value As Double) Implements ISwitchV2.SetSwitchValue
        Dim setVal As Boolean
        Validate("SetSwitchValue", id, value)
        If value < MinSwitchValue(id) Or value > MaxSwitchValue(id) Then
            Throw New InvalidValueException("", value.ToString(), String.Format("{0} to {1}", MinSwitchValue(id), MaxSwitchValue(id)))
            TL.LogMessage("SetSwitchValue", String.Format("InvalidValueException Switch id {0} : value {1}", id, value))
        End If

        ' We have to math a bit here now.  Despite boolean switches, we must implement this now.
        If value < 0.5 Then
            setVal = False
        Else
            setVal = True
        End If
        TL.LogMessage("SetSwitchValue", String.Format("Switch id {0} : value {1}, set {2}", id, value, setVal.ToString))
        SetSwitch(id, setVal)

    End Sub




#End Region
#End Region

    ''' <summary>
    ''' Checks that the switch id is in range and throws an InvalidValueException if it isn't
    ''' </summary>
    ''' <param name="message">The message.</param>
    ''' <param name="id">The id.</param>
    Private Sub Validate(message As String, id As Short)
        If (id < 0 Or id >= numCameras) Then
            Throw New ASCOM.InvalidValueException(message, id.ToString(), String.Format("0 to {0}", numCameras - 1))
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
        Validate(message, id, True)
        Dim min = MinSwitchValue(id)
        Dim max = MaxSwitchValue(id)
        If (value < min Or value > max) Then
            TL.LogMessage(message, String.Format("Value {1} for Switch {0} is out of the allowed range {2} to {3}", id, value, min, max))
            Throw New InvalidValueException(message, value.ToString(), String.Format("Switch({0}) range {1} to {2}", id, min, max))
        End If
    End Sub


#Region "Private properties and methods"
    ' here are some useful properties and methods that can be used as required

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
            numCameras = CInt(driverProfile.GetValue(driverID, numCamerasProfileName, String.Empty, numCamerasDefault))
            For i As Integer = 0 To 3  ' 4 cameras
                IPAddress(i) = driverProfile.GetValue(driverID, IPProfileName, i.ToString, IPDefault)
                CameraName(i) = driverProfile.GetValue(driverID, cameraNameProfileName, i.ToString, cameraNameDefault)
                camUsername(i) = driverProfile.GetValue(driverID, usernameProfileName, i.ToString, usernameDefault)
                camPassword(i) = driverProfile.GetValue(driverID, passwordProfileName, i.ToString, passwordDefault)
            Next  'i
        End Using
    End Sub

    ''' <summary>
    ''' Write the device configuration to the  ASCOM  Profile store
    ''' </summary>
    Friend Sub WriteProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"

            driverProfile.WriteValue(driverID, traceStateProfileName, traceState.ToString, String.Empty)
            driverProfile.WriteValue(driverID, numCamerasProfileName, numCameras.ToString, String.Empty)
            For i As Integer = 0 To 3
                driverProfile.WriteValue(driverID, IPProfileName, IPAddress(i), i.ToString)
                driverProfile.WriteValue(driverID, cameraNameProfileName, CameraName(i), i.ToString)
                driverProfile.WriteValue(driverID, usernameProfileName, camUsername(i), i.ToString)
                driverProfile.WriteValue(driverID, passwordProfileName, camPassword(i), i.ToString)
            Next  'i
        End Using

    End Sub

#End Region

#Region "My functions"
    ' Extra functions and subs created to perform various tasks needed for this specific driver

    Private Function getCurrentMode() As Boolean()
        ' Gets the current profile for the cameras we know about.  We don't loop through 4 cameras, since any unused cameras probably have
        ' invalid/blank configurations that we won't be able to connect to.

        Dim client As New System.Net.WebClient
        Dim credentials As New System.Net.CredentialCache()
        Dim response As String
        Dim ConfigURI(numCameras - 1) As Uri

        For i = 0 To numCameras - 1     ' THis loop generates credentials for each camera in use
            ConfigURI(i) = New Uri("http://" + IPAddress(i) + "/cgi-bin/configManager.cgi?action=getConfig&name=VideoInMode[0].Config[0]")
            If credentials.GetCredential(ConfigURI(i), "Digest") Is Nothing Then    ' Check to see if credential exists, for multi cam testing w/ 1 cam
                credentials.Add(ConfigURI(i), "Digest", New Net.NetworkCredential(camUsername(i), camPassword(i)))
            End If
        Next  'i

        client.Credentials = credentials    ' Yes we could do this in the loop, and spare having 2 loops.  But this flow made more sense to me. :)

        For i = 0 To numCameras - 1     ' This loop connects to each camera to get its profile
            Try
                response = client.DownloadString(ConfigURI(i))

                ' The Dahua API always responds with this string.  Config[0]=1 for Night, 0 for Day profile.
                ' Probably need to keep an eye on this, as obviously they might change.
                If response = "table.VideoInMode[0].Config[0]=1" Then
                    SwitchState(i) = False        ' Night mode
                Else
                    SwitchState(i) = True         ' Day mode
                End If
            Catch ex As Exception
                SwitchState(i) = True               ' If we fail to get a valid response, we presume Day profile because we have to presume something
            End Try
        Next  'i
        Return SwitchState
    End Function

    Private Sub setMode(id As Short, val As Boolean)
        ' Sets the profile for the given camera ID.
        Dim client As New System.Net.WebClient
        Dim credentials As New System.Net.CredentialCache()
        Dim strURI As String = "http://" + IPAddress(id) + "/cgi-bin/configManager.cgi?action=setConfig&VideoInMode[0].Config[0]"
        If val Then
            strURI = strURI + "=0"      ' True, day mode
        Else
            strURI = strURI + "=1"      ' False, night mode
        End If
        Dim setConfigURI As New Uri(strURI)
        credentials.Add(setConfigURI, "Digest", New Net.NetworkCredential(camUsername(id), camPassword(id)))
        client.Credentials = credentials
        Dim response As String = client.DownloadString(setConfigURI)
    End Sub
#End Region

End Class
