---
title: "Controller"
---

# Controller
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs)

`#!c# namespace GameSense`

`#!c# public static class Controller`

---

Controls the GameSense SDK. Will do the most things you need.

## Summary

### Properties
#### `public static`
| Type                                                           | Property                                      | Get              | Set              |
| -------------------------------------------------------------- | --------------------------------------------- | ---------------- | ---------------- | 
| [`IKeyboardAnimator`](/Reference/Animation/IKeyboardAnimator/) | [`KeyboardBackground`](#defaultkeyanimation)  |                  | :material-check: | 
| [`IKeyAnimator`](/Reference/Animation/IKeyAnimator/)           | [`DefaultKeyAnimation`](#defaultkeyanimation) |                  | :material-check: | 
| [`IMouseAnimator`](/Reference/Animation/IMouseAnimator/)       | [`MouseBackground`](#mousebackground)         |                  | :material-check: | 
| `string`                                                       | [`GameName`](#gamename)                       |                  | :material-check: | 
| `string`                                                       | [`GameDisplayName`](#gamedisplayname)         |                  | :material-check: | 
| `string`                                                       | [`Developer`](#developer)                     |                  | :material-check: | 

### Methods
#### `public static`
| Returns            | Method                |
| ------------------ | --------------------- |
| `void`             | [`Stop`](#stop)`()`   |

## Properties
### `KeyboardBackground`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L54) · :material-sign-direction: Default: `none`

`#!c# public static IKeyboardAnimator KeyboardBackground {set;}`

Sets the [`IKeyboardAnimator`](/Reference/Animation/IKeyboardAnimator/) used for the keyboard background.

---
### `DefaultKeyAnimation`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L67) · :material-sign-direction: Default: `none`

`#!c# public static IKeyAnimator DefaultKeyAnimation {set;}`

Sets the [`IKeyAnimator`](/Reference/Animation/IKeyAnimator/) used on key strokes.

---
### `MouseBackground`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L75) · :material-sign-direction: Default: `none` · :material-alert: Not Implemented!

`#!c# public static IMouseAnimator MouseBackground {set;}`

Sets the [`IMouseAnimator`](/Reference/Animation/IMouseAnimator/) used as mouse background.

---
### `GameName`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L88) · :material-sign-direction: Default: `none`

`#!c# public static IMouseAnimator MouseBackground {set;}`

Sets the name of the game.

??? note Naming restrictions
    Name is limited to uppercase A-Z, 0-9, hyphen, and underscore characters.

---
## Methods
### `Stop`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L151)

`#!c# public static void Stop()`

Stops GameSense. Should be called at the end of the program.