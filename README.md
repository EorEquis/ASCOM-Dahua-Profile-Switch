# ASCOM Dahua Profile Switch

This driver will change the Profile of a Dahua camera that exposes the Dahua API.

It will set the profile to either Day or Night.

SwitchState False (Off) = Night profile
SwitechState True (On) = Day profile

### You should :

* Configure your camera's Day and Night profile as desired.  Presumably one will disable IR.
* Configure your client software to select the right switch value before and after the imaging session.

### History of Changes

* 1.0.0 - Initial working build
* 1.0.1 - Fix and issue w/ GetSwitchValue() causing conformance to fail.
* 1.0.2 - Fix and issue w/ SetSwitchValue() causing conformance to fail.

Note :

Because of the weird way SGP v4 handles switches, it will insist on connecting BEFORE you are given
an opportunity to configure the switch.  This will result in a long delay starting SGP, and unpredictable
behaviour after it finally starts.

To avoid this, BEFORE starting SGP the first time after driver installation, launch the ASCOM Profile
Explorer, navigate to "Switch Drivers" -> "ASCOM.TriStarDahuaProfile.Switch" and edit the "Data" column for each "Value" to correctly
connect to your camera.  The most important are IP Address, Username, and Password.

Depending on when you last installed/updated the driver, the "Value" entries may not be there at all.  If that's the case,
then you should enter the following Values, and their appropriate Data.

| Value      | Data |
| ----------- | ----------- |
| Camera Name      | Name of your camera       |
| IP Address   | IP Address of your camera |
| Username   | Username for connecting to your camera |
| Password   | Password for connecting to your camera |


