---
title: Getting started
---

# Getting started

## Installation
[![Build Status](https://img.shields.io/nuget/v/GameSense.svg)](https://www.nuget.org/packages/GameSense/)

Install the package from [nuget](https://www.nuget.org/packages/GameSense/).

## Usage

### Setup

GameSense automatically starts when...

...[`GameDisplayName`](Controller.md#gamedisplayname)...

...[`Developer`](Controller.md#developer)...

...[`GameName`](Controller.md#gamename)...

...are set.

??? note
    Those three values are needed to register the events and the game in the GameSense Engine.
    Note that `GameName` is limited to uppercase A-Z, 0-9, hyphen, and underscore characters.

```c#
GameSense.Controller.GameName = "TEST";
GameSense.Controller.GameDisplayName = "Test";
GameSense.Controller.Developer = "John Doe";
```

---
### Background animations for keyboards
Set the [`KeyboardBackground`](Controller.md#keyboardbackground) property. 
You can either use the [`KeyboardGradient`](KeyboardGradient.md) [`IKeyboardAnimator`](IKeyboardAnimator.md) or create you own [`IKeyboardAnimator`](IKeyboardAnimator.md).

```c#
GameSense.Controller.KeyboardBackground = new KeyboardGradient (
    new int[] { 255,  85,   0 }, 
    new int[] {   0, 196, 255 }, 
    4, 
    2
);
```

---
### Background animations for mice
:material-alert: Not Implemented! Coming soon.

---
### Background animations for mousepads
:material-alert: Not Implemented! Coming soon.

---
### Animated key strokes
Set the [`DefaultKeyAnimation`](Controller.md#defaultkeyanimation) property. 
You can either use the [`KeyFade`](KeyFade.md) [`IKeyAnimator`](IKeyAnimator.md) or create you own [`IKeyAnimator`](IKeyboardAnimator.md).

```c#
GameSense.Controller.DefaultKeyAnimation = new KeyFade();
```

???+ warning
    This program uses the [`globalmousekeyhook`](https://github.com/gmamaladze/globalmousekeyhook) library to register key strokes.
    In order to not block the program you need to run a new application context after your setup when animating key strokes.
    
    Your program could look something like this:

    ```c#
    GameSense.Controller.GameName = "TEST";
    GameSense.Controller.GameDisplayName = "Test";
    GameSense.Controller.Developer = "John Doe";

    GameSense.Controller.DefaultKeyAnimation = new KeyFade();

    System.Windows.Forms.Application.Run(new ApplicationContext()); // Important!

    GameSense.Controller.Stop();
    System.Windows.Forms.Application.Exit()
    ```



---
### Sending requests manually

To send a request to the GameSense Engine create a [`BaseRequest`]() and send it using the [`Transmitter`]().

See the [GameSense SDK docs](https://github.com/SteelSeries/gamesense-sdk) for more information on requests.

```c#
GameSense.Struct.Request.BaseRequest request = new GameSense.Struct.BaseRequest
{
    Game = "KALE"
};
GameSense.Transmitter.Send(request, "game_heartbeat");
```

---