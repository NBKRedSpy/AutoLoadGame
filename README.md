# AutoLoadGame

This is a temporary fork of gniver's excellent AutoLoadGame mod:
https://www.nexusmods.com/battletech/mods/493

Please see the orginal mod on NexusMods for more information.

The version adds command line parameters to go directly to a screen.  This does not affect the mod's toggle mode (ctrl) and overrides the ctrl and shift functionality.

![image](https://user-images.githubusercontent.com/54865934/169122686-e1617445-e4a2-4556-8d2e-fb60b996dceb.png)

# Usage

When running battletech.exe, add the parameter -AutoLoadGame={option}.  For example, ``battletech.exe -AutoLoadGame=MainMenu``.

The option is case sensitive and can be one of the following:

|Setting|Description|
|--|--|
Save | Loads the last save
MechBay | Loads the Skirmish screen
MainMenu | Opens the main menu

# Steam Launch Warning
Steam will give a warning about parameters being added to the game when launched from the command line or a shortcut.  This is normal.
