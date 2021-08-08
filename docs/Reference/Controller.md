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
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L54) · :octicons-milestone-16: Default: :octicons-diff-removed-16:

`#!c# public static IKeyboardAnimator KeyboardBackground {set;}`

Sets the [`IKeyboardAnimator`](/Reference/Animation/IKeyboardAnimator/) used for the keyboard background.

---
### `DefaultKeyAnimation`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L67) · :octicons-milestone-16: Default: :octicons-diff-removed-16:

`#!c# public static IKeyAnimator DefaultKeyAnimation {set;}`

Sets the [`IKeyAnimator`](/Reference/Animation/IKeyAnimator/) used on key strokes.

---
### `MouseBackground`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L75) · :octicons-milestone-16: Default: :octicons-diff-removed-16: · :material-alert: Not Implemented!

`#!c# public static IMouseAnimator MouseBackground {set;}`

Sets the [`IMouseAnimator`](/Reference/Animation/IMouseAnimator/) used as mouse background.

---
### `GameName`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L88) · :octicons-milestone-16: Default: :octicons-diff-removed-16:

`#!c# public static string GameName {set;}`

Sets the name of the game.

??? note "Naming restrictions"
    Name is limited to uppercase A-Z, 0-9, hyphen, and underscore characters.

---
### `GameDisplayName`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L104) · :octicons-milestone-16: Default: :octicons-diff-removed-16:

`#!c# public static string GameDisplayName {set;}`

Sets the name of the game that will be seen in the GameSense Engine.

---
### `Developer`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L120) · :octicons-milestone-16: Default: :octicons-diff-removed-16:

`#!c# public static string Developer {set;}`

Sets the developer of the game.

---
## Methods
### `Stop`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Controller.cs#L151)

`#!c# public static void Stop()`

Stops GameSense. Should be called at the end of the program.