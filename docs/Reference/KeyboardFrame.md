---
title: "KeyboardFrame"
---

# KeyboardFrame
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/KeyboardFrame.cs)

`#!c# namespace GameSense`

`#!c# public class KeyboardFrame`

:material-subdirectory-arrow-right: [`KeyboardFrame`]()

---

A class that contains a color bitmap for a full keyboard effect. See the [GameSense SDK docs](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/json-handlers-full-keyboard-lighting.md) for more information on full keyboard effects.

## Summary
### Constructors
| Constructor             |
| ----------------------- |
| [`KeyboardFrame`](#keyboardframe_1)`()` |
### Properties
#### `public`
| Type      | Property                         | Get              | Set              |
| --------- | -------------------------------- | ---------------- | ---------------- | 
| `int[][]` | [`Bitmap`](#bitmap) | :material-check: | :material-check: | 

### Methods
#### `public`
| Returns            | Method                                           |
|------------------- | ------------------------------------------------ |
| [`KeyboardFrame`]() | [`SetColor`](#setcolor)`(int index, int r, int g, int b)` |
| [`KeyboardFrame`]() | [`SetColor`](#setcolor_1)`(int index, int[] color)`         |
| [`KeyboardFrame`]() | [`Copy`](#copy)`()`                              |

## Constructors
### `KeyboardFrame`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/KeyboardFrame.cs#L21)

`#!c# public KeyboardFrame()`

Initializes a new instance of the class.

---
## Properties
### `Bitmap`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/KeyboardFrame.cs#L34) · :octicons-milestone-16: Default: A 132 by 3 int array filled with zeros.

`#!c# public int[][] Bitmap {get; set;}`

Gets or sets the color bitmap. This bitmap is used by the GameSense Engine to map a 22x6 grid to the keys of the keyboard.

---
## Methods
### `SetColor`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/KeyboardFrame.cs#L44)

`#!c# public KeyboardFrame SetColor(int index, int r, int g, int b)`

Sets a color in the [`Bitmap`](#bitmap).

#### Returns
Itself

#### Parameters
| Type  | Name    | Description                                                                                           | Default                    |
| ----- | ------- | ----------------------------------------------------------------------------------------------------- | -------------------------- |
| `int` | `index` | The index of the [`Bitmap`](#bitmap) or a [`Key`](/Reference/Key/) to set the color of a specific key | :octicons-diff-removed-16: |
| `int` | `r`     | The red channel value                                                                                 | :octicons-diff-removed-16: |
| `int` | `g`     | The green channel value                                                                               | :octicons-diff-removed-16: |
| `int` | `b`     | The blue channel value                                                                                | :octicons-diff-removed-16: |

---
### `SetColor`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/KeyboardFrame.cs#L55)

`#!c# public KeyboardFrame SetColor(int index, int[] color)`

Sets a color in the [`Bitmap`](#bitmap).

#### Returns
Itself

#### Parameters
| Type    | Name    | Description                                                                          | Default |
| ------- | ------- | ------------------------------------------------------------------------------------ | ------- |
| `int`   | `index` | The index of the [`Bitmap`](#bitmap) or a [`Key`](/Reference/Key/) to set the color of a specific key | -       |
| `int[]` | `color` | The color to be set (RGB format)                                                     | -       |

---
### `Copy`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/KeyboardFrame.cs#L65)

`#!c# public KeyboardFrame Copy()`

Creates a copy of itself.

#### Returns
The copied version of itself.