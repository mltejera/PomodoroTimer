# PomodoroTimer

<b>Welcome to Mason's Pomodoro Timer App</b>

This is a Univeral Windows Platform app that requires Windows 10 and Visual Studio 2017 to run.

I followed the Model View View-Model design pattern to enable easy testing and proper seperation of concerns.

There are 3 projects:
    PomodoroTimer
        This is the main UI for the project. Most of the UI is layed out in Themes/Generic.xaml, broken up into seperate Templated Controls and Data Templates.
        There are also a few converters to make defining the view models easier.
    PomodoroTimerLogic
        The view models and models live here. There is some boiler plate code in /Common to better enable MVVM.
    Tests
        The unit tests, broken up by file.

The user can add timers, modify, start, stop and reset them.

The user can also add and complete tasks.
