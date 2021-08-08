---
title: "ColorManipulation"
---

# ColorManipulation
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/ColorManipulation.cs)

`#!c# namespace GameSense.Animation`

`#!c# public static class ColorManipulation`

---

Helper class for combining and manipulating colors.

## Summary
### Methods
#### `public static`
| Returns | Method                                                             |
| ------- | ------------------------------------------------------------------ |
| `int[]` | [`Combine`](#combine)`(int[] bottom, int[] top, int transparency)` |

## Methods
### `Combine`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Animation/ColorManipulation.cs#L34-L44)

`#!c# public static int[] Combine(int[] bottom, int[] top, int transparency)`

Combines one bottom color with a translucent top color.

#### Returns
The combined color.

#### Parameters
| Type    | Name           | Description                                 | Default                    |
| ------- | -------------- | ------------------------------------------- | -------------------------- |
| `int[]` | `bottom`       | The bottom color (RGB format)               | :octicons-diff-removed-16: |
| `int[]` | `top`          | The top color (RGB format)                  | :octicons-diff-removed-16: |
| `int`   | `transparency` | The transparency of the top color (`0-100`) | :octicons-diff-removed-16: |

---