---
title: Home
---

# Welcome to the GameSense SDK for .Net

The GameSense SDK for .Net with some additional features.

With GameSense you are able to control the LED's of your keyboard and and other products by SteelSeries.

[Installation](/Getting started/#installation) and [usage](/Getting started/#usage) under [Getting started](/Getting started/).

Full documentation under [Reference](Controller.md).

Check out the [GameSense SDK](https://github.com/SteelSeries/gamesense-sdk) by SteelSeries.

## Features

- Manual requests to the GameSense Engine
- Animation for your keyboard as background
- Animation for your keyboard on key strokes

## Example

In this example GameSense gets started and setup with a gradient background and a key stroke fade for the keyboard.

```c#
GameSense.Controller.Background = new KeyboardGradient(new int[] { 255, 85, 0 }, new int[] { 0, 196, 255 }, 4, 2);
GameSense.Controller.DefaultKeyAnimation = new KeyFade();
GameSense.Controller.GameName = "TEST";
GameSense.Controller.GameDisplayName = "Test";
GameSense.Controller.Developer = "John Doe";
```