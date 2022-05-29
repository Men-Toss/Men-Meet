# Summary
Different type of in-code and drag-and-drop timers that help running time based events and displaying the time easily in the UI

# Description
Simple timer tool that allows you to do varaiaty of stuff with time, wheather it's converting time, or displaying it in a many different ways, doing a cooldown and knowing when it's done, or just have an infinite timer

the package tools can be used by coders and non-coders since it's provide a variaty of sulotions for the same problem.

# Technecal details
**** General ****
* Infinite timer (struct, MonoBehaviour class)
* Cooldown timer (struct, MonoBehaviour class)
* Bases (ITimer interface, ATimer_H abstract class, ITimer_X interface, ATimer_X_H abstract class, UpdatedClass)
* Timer extension methods
* Watch class with extensions methods (for testing code speed)

**** Timers can ****
* Start
* Restart
* Stop
* Pause
* Resume
* return curren time

**** Cooldown timer can also ****
* Is ready
* Inverted

**** Timer holders can ****
* Auto start timer on (Awake, Start, OnEnable)
* Start time delay
* Choose time and it's type in inspector
* Loop
* Methods have context menu attribute
* Run on all 3 different types of update calls (also extensions)

**** Timer extensions class/struct ****
** TimerWaves
* Choosing list of numbers
* Unity events will run whenever on of those numbers or their multipliers are hit
* Get the time of the NextWave and PreviousWave
* Number of times the wave will repeat
* The multiplying of the wave each time it hits
** TimerRecorder (List/Dictionary)
* Records the current time of timer when told to
* Print recorded times on a json file

**** Timer extensions class only ****
** TimerText
* Unity events returning timer current time as normal/clock format
* Choosing text max type
* Choosing text format
** TimerPercentage
* Unity events returning timer current time as 0-1/0-100 percentage
* Unity events returning color based on timer current time percentage
* Choosing percentage colors with gradient class

**** Updates manager ****
* Public static events run on all updates
* Timer holders and extensions need it to work, can choose between (normal update, fixed update, late update)

**** Time ****
* Converting time between (Seconds, Minutes, Hours, Days)
* Clock text format [00:00]
* time type code text format [m00 s00]