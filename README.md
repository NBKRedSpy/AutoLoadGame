# AutoLoadGame

This is the continuation of gniver's excellent AutoLoadGame mod.  Gniver has transferred the mod for continued development.
Original mod:  https://www.nexusmods.com/battletech/mods/493

# Usage
Simple mod; it loads your most recent game automatically, or go into Skirmish MechBay.  Yes, the entire point is not having to click the buttons.  

It doesn't care if it's career or campaign or skirmish, whatever is most recently saved will be loaded immediately after the game scans your save files.  Or, goes to MechBay (see readme.txt).

## Loading operation
The mod operates as follows:

* By default will load the last save.
* If a [command line argument](#command-line-options) is present, the game will open the specified screen.
* Or, while ModTek is loading:
  * Hold SHIFT to display the main menu normally.
  * Hold CTRL to toggle modes between Save and MechBay auto-loading (See readme.txt)


# Command Line Mode
The parameter -AutoLoadGame={option} can be added on the command line or in a shortcut to specify which screen to launch.

![image](https://user-images.githubusercontent.com/54865934/169669728-c18673e4-5ba4-4ca1-9912-2ca3f4a98472.png)


This is useful for developers that may need to go between the main menu and the last save, but do not wish to hold shift down during the load.

## Example
``battletech.exe -AutoLoadGame=MainMenu``.


## Command Line Options
_**Important:**_ The option is case sensitive and can be one of the following:

|Setting|Description|
|--|--|
Save | Loads the last save
MechBay | Opens the Skirmish screen
MainMenu | Opens the main menu

# Steam Launch Warning
Steam will display a warning when parameters are added to the game outside of Steam's game properties.  This is normal operation.

![image](https://user-images.githubusercontent.com/54865934/169669819-0a7d0640-2774-41c9-acb9-c0e3ea5364c9.png)


