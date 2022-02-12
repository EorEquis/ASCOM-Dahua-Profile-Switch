# ASCOM Dahua Profile Switch - Multi Camera Version

This driver will change the Profile of up to 4 Dahua cameras that expose the Dahua API.

It will set the profile to either Day or Night.

SwitchState False (Off) = Night profile

SwitchState True (On) = Day profile

### You should :

* Configure your cameras' Day and Night profiles as desired.  Presumably one will disable IR.
* Configure your client software to select the right switch values before and after the imaging session.

### History of Changes

* 1.0.0 - Initial working build
* 1.0.1 - Fix an issue w/ GetSwitchValue() causing conformance to fail.
* 1.0.2 - Fix an issue w/ SetSwitchValue() causing conformance to fail.
* 1.1.0	- First working multi-camera version
* 1.1.1	- Clean up / add comments, some array sizes changed to use numCameras
* 1.2.0 - I have no idea why this suddenly exploded after wokring fine for years.

**Note for users of Sequence Generator Pro 4.x**:

Because of the weird way SGP v4 currently handles switches, it will insist on connecting BEFORE you are given
an opportunity to configure the switch.  This will result in a long delay starting SGP, and unpredictable
behaviour after it finally starts.

To avoid this, BEFORE starting SGP the first time after driver installation, you should run the Standalone client
and complete proper configuration for your camera(s).


