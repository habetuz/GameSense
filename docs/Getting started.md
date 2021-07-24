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

...[`GameDisplayName`]()...

...[`Developer`]()...

...[`GameName`]()...

...are set.

??? note
    Those three values are needed to register the events and the game in the GameSense Engine.
    Note that `GameName` is limited to uppercase A-Z, 0-9, hyphen, and underscore characters.

```c#
GameSense.Controller.GameName = "TEST";
GameSense.Controller.GameDisplayName = "Test";
GameSense.Controller.Developer = "John Doe";
```

### Activating a keyboard background


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