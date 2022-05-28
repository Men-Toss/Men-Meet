# Changelog

## [1.2.0] - 23/4/2022
---- Fixed ----
- CurrentTimePercentage returning NAN

---- Added ----
- TimeSegment class
- TimeSegmentsController class
- TimeSegment_D struct (_D = Data)
- Demo and prefabs folders
- A lot of ready to use prefabs
- Infinite timer demo scene
- abstract class "UpdatedClass" that has the switching updates function
- The ability for timer holders to function on all 3 update types
- Color changing for TimerPercentage extension class depending on the percentage

---- Changed ----
- Text to TextMeshProUGUI
- Demo scene name to Cooldown timer
- Every word was "Tracker" has been converted to "Recorder"
- Every word was "SaveTime/Saves" has been converted to "RecordTime/Records"
- Timer waves extension after merging it with Timer events extension

---- Modified ----
- Cooldown timer demo
- License, Read me and Change log
- Ability UI
- Tests


## [1.1.0] - 30/3/2022
---- Removed ----
- public properity "MyTimer" from CooldownTimer_H class

---- Modified ----
- old tests
- old namespace for the scripts to become "RiseOfArabs.DevTools.SimpleTimers"
- some names ("TimePercentage" => "TimerPercentage", "Timer" => "InfiniteTimer", "Timer_H" => "InfiniteTimer_H", "Timer_B" => "ATimer", all extension classes now end with _X_H, and structs with _X)

---- Moved ----
- root folder under Rise of Arabs/DevTools root folder
- all extension classes/structs under "RiseOfArabs.DevTools.SimpleTimers.Extensions" namespace

---- Merged ----
- "Additionals" folder with "Extensions" folder, then added subfolders to it

---- Added ----
- more tests
- extensions classes run at different update types
- new extensions ("TimerTracker", "TimerEvents", "TimerWaves"), and made struct version of them
- color percentage for "TimePercentage" class
- "ATimer<>" abstract class for all timer extension classes


## [1.0.0] - 23/3/2022
First release of *com.riseofarabs.devtools.simpletimers*.