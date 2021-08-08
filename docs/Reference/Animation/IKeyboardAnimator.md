---
title: "IKeyboardAnimator"
---

# IKeyboardAnimator
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/IKeyboardAnimator.cs)

`#!c# namespace GameSense.Animation`

`#!c# public interface IKeyboardAnimator`

:material-subdirectory-arrow-right: [`IKeyboardAnimator`]()

---

Interface for keyboard animations.

## Summary
### Methods
| Returns                             | Method                                                                         |
| ----------------------------------- | ------------------------------------------------------------------------------ |
| [`KeyboardFrame`](KeyboardFrame.md) | [`NextFrame`](#nextframe)`(`[`KeyboardFrame`](KeyboardFrame.md) `bottomLayer)` |

## Methods
### `NextFrame`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/IKeyboardAnimator.cs#L23)

`#!c# KeyboardFrame NextFrame(KeyboardFrame bottomLayer = null)`

Generates the next [`KeyboardFrame`](KeyboardFrame.md) of the animation.

#### Returns
The next [`KeyboardFrame`](KeyboardFrame.md).

#### Parameters
| Type                                | Name          | Description                                                                     | Default |
| ----------------------------------- | ------------- | ------------------------------------------------------------------------------- | ------- |
| [`KeyboardFrame`](KeyboardFrame.md) | `bottomLayer` | The bottom [`KeyboardFrame`](KeyboardFrame.md) the next frame will be added on. | `null`  |

---