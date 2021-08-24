---
title: "KeyboardGradient"
---

# KeyboardGradient
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/KeyboardGradient.cs)

`#!c# namespace GameSense.Animation`

`#!c# public class KeyboardGradient : IKeyboardAnimator`

:material-subdirectory-arrow-right: [`IKeyboardAnimator`](IKeyboardAnimator.md)

&ensp;&ensp;&ensp;&ensp; :material-subdirectory-arrow-right: [`KeyboardGradient`]()


---

An [`IKeyboardAnimator`](IKeyboardAnimator.md) that generates a gradient background effect. The gradient gets animated moving from right to left.

## Summary
### Constructors
| Constructor                                                                |
| -------------------------------------------------------------------------- |
| [`KeyboardGradient`]()`(int[] color1, int[] color2, int time, int length)` |

### Implemented methods from [`IKeyboardAnimator`](IKeyboardAnimator.md)
| Returns                             | Method                                                                                             |
| ----------------------------------- | -------------------------------------------------------------------------------------------------- |
| [`KeyboardFrame`](KeyboardFrame.md) | [`NextFrame`](IKeyboardAnimator.md#nextframe)`(`[`KeyboardFrame`](KeyboardFrame.md) `bottomLayer)` |

## Constructors
### `KeyboardGradient`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/KeyboardGradient.cs#L42-L116)

`#!c# public KeyboardGradient(int[] color1, int[] color2, int time = 1, int length = 1)`

Initializes a new instance of the class.

#### Parameters
| Type    | Name     | Description                                                                                                                                                                                                                 | Default                    |
| ------- | -------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------- |
| `int[]` | `color1` | The left color of the gradient (RGB format)                                                                                                                                                                                 | :octicons-diff-removed-16: |
| `int[]` | `color2` | The right color of the gradient (RGB format)                                                                                                                                                                                | :octicons-diff-removed-16: |
| `int`   | `time`   | The speed of the animation. The speed is dependent on the [`Controller.FrameLength`](Controller.md#framelength). It needs `22` · `time` [`NextFrame()`](IKeyboardAnimator.md#nextframe) calls for one full animation cycle. | 1                          |
| `int`   | `length` | How long the gradient is compared to the keyboard. The gradient is `keyboard` · `length` long.                                                                                                                              | 1                          |
