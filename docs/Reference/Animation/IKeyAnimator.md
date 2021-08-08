---
title: "IKeyAnimator"
---

# IKeyAnimator
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/IKeyAnimator.cs)

`#!c# namespace GameSense.Animation`

`#!c# public interface IKeyAnimator : IKeyboardAnimator`

:material-subdirectory-arrow-right: [`IKeyboardAnimator`](IKeyboardAnimator.md)

&ensp;&ensp;&ensp;&ensp; :material-subdirectory-arrow-right: [`IKeyAnimator`]()

---

Interface for key animations.

## Summary
### Properties
| Type            | Property                | Get              | Set              |
| --------------- | ----------------------- | ---------------- | ---------------- | 
| `bool`          | [`Finished`](#finished) | :material-check: |                  | 
| [`Key`](Key.md) | [`Key`](#key)           | :material-check: | :material-check: | 

### Methods
| Returns        | Method              |
| -------------- | ------------------- |
| `IKeyAnimator` | [`Copy`](#copy)`()` |

### Inherited methods from [`IKeyboardAnimator`](IKeyboardAnimator.md)
| Returns                             | Method                                                                                             |
| ----------------------------------- | -------------------------------------------------------------------------------------------------- |
| [`KeyboardFrame`](KeyboardFrame.md) | [`NextFrame`](IKeyboardAnimator.md#nextframe)`(`[`KeyboardFrame`](KeyboardFrame.md) `bottomLayer)` |

## Properties
### `Finished`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/IKeyAnimator.cs#L21) · :octicons-milestone-16: Default: :octicons-diff-removed-16:

Gets a value indicating whether the animation has finished yet.

---
### `Key`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/IKeyAnimator.cs#L26) · :octicons-milestone-16: Default: :octicons-diff-removed-16:

Gets or sets the [`Key`](Key.md) to be animated.

---
## Methods
### `Copy`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/IKeyAnimator.cs#L32)

`#!c# IKeyAnimator Copy()`

Creates a copy of itself.

#### Returns
The copy.

---