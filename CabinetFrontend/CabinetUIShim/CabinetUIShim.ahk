;  Game Dev Club - Arcade Cabinet UI Shim
;  ---
;  Launches a game, and quits when it quits.
;  Also provides a hotkey to kill the game.

; Startup Commands
#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
#Warn   ; Enable warnings to assist with detecting common errors.
#SingleInstance force ; Make sure this script can't have two instances.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.

; Constants

TimeToWait = 5 ; The time to wait for the new process to be created before closing

FullPath = %1%\%2% ; Just in case, but this isn't used...
SetWorkingDir %1%  ; Set the working directory to the path provided by the UI.

ParamsToPass = 

; Loop to collect arguments passed besides the path and executable name.
Loop, %0% ; %0% is the number of passed arguments
{
   if (A_Index == 1 or A_Index == 2)
      Continue ; This is the path and the executable so disregard it
   ParamsToPass := ParamsToPass . " " . %A_Index%
}

; Show the command to run just to test (uncomment).
; MsgBox %2% %ParamsToPass%

Run, %2% %ParamsToPass% ; Run the program and its parameters
Process, Wait, %2%, %TimeToWait% ; Wait for the program to launch
if (ErrorLevel == 0) { ; If the process did not create successfully
   ExitApp ; Just close so the UI functions
}

Process, WaitClose, %2% ; Wait on the process to close
ExitApp                 ; ...then close yourself.

; Define the exit hotkey here.
*f::
   Process, Close, %2%
   ExitApp
return