---
title: "KeyFade"
---

# KeyFade
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/KeyFade.cs)

`#!c# namespace GameSense.Animation`

`#!c# public class KeyFade : IKeyAnimator`


:material-subdirectory-arrow-right: [`IKeyboardAnimator`](IKeyboardAnimator.md)

&ensp;&ensp;&ensp;&ensp; :material-subdirectory-arrow-right: [`IKeyAnimator`](IKeyAnimator.md)

&ensp;&ensp;&ensp;&ensp; &ensp;&ensp;&ensp;&ensp; :material-subdirectory-arrow-right: [`KeyFade`]()

---

An [`IKeyAnimator`](IKeyAnimator.md) that animates a fading color for keys.

## Summary
### Constructors
| Constructor       |
| ----------------- |
| [`KeyFade`]()`()` |

### Properties
#### `public`
| Type    | Property                        | Get              | Set              |
| ------- | ------------------------------- | ---------------- | ---------------- | 
| `int`   | [`FadeDuration`](#fadeduration) |                  | :material-check: |
| `int[]` | [`Color`](#color)               |                  | :material-check: |

### Properties inherited from [`IKeyAnimator`](IKeyboardAnimator.md)
| Type            | Property                               | Get              | Set              |
| --------------- | -------------------------------------- | ---------------- | ---------------- | 
| `bool`          | [`Finished`](IKeyAnimator.md#finished) | :material-check: |                  | 
| [`Key`](Key.md) | [`Key`](IKeyAnimator.md#key)           | :material-check: | :material-check: | 


### Methods inherited from [`IKeyAnimator`](IKeyboardAnimator.md)
| Returns                             | Method                             |
| ----------------------------------- | ---------------------------------- |
| [`IKeyAnimator`](IKeyAnimator.md)   | [`Copy`](IKeyAnimator.md#copy)`()` |

### Methods inherited from [`IKeyboardAnimator`](IKeyboardAnimator.md)
| Returns                             | Method                                                                                             |
| ----------------------------------- | -------------------------------------------------------------------------------------------------- |
| [`KeyboardFrame`](KeyboardFrame.md) | [`NextFrame`](IKeyboardAnimator.md#nextframe)`(`[`KeyboardFrame`](KeyboardFrame.md) `bottomLayer)` |

## Constructors
### `KeyFade`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/KeyFade.cs)

`#!c# public KeyFade()`

Initializes a new instance of the class.

---
## Properties
### FadeDuration
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/KeyFade.cs#L52) · :octicons-milestone-16: Default: `100`

`#!c# public int FadeDuration {set;}`

Sets amount of [`IKeyboardAnimator.NextFrame()`] calls the key needs to fade out. Time dependents on the [`Controller.FrameLength`](Controller.md#framelength).

---
### Color
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/KeyFade.cs#L63) · :octicons-milestone-16: Default: `[255, 255, 255]`

`#!c# public int[] Color {set;}`

Sets the color that should fade away.