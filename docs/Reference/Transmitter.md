---
title: Transmitter
---

# Transmitter
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Transmitter.cs)

`#!c# namespace GameSense`

`#!c# public static class Transmitter`

---

Responsible for communication between GameSense and the GameSense Engine.

## Summary
### Methods
#### `public static`
| Returns            | Method                                                                                                  |
| ------------------ | ------------------------------------------------------------------------------------------------------- |
| `void`             | [`Send`](#send)`(`[`BaseRequest`](/Reference/Struct/Request/BaseRequest/) `request, string endpoint)`   |

## Methods
### `Send`
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Transmitter.cs#L79)

`#!c# public static async void Send(BaseRequest request, string endpoint)`

Sends a [`BaseRequest`](/Reference/Struct/Request/BaseRequest/) to an endpoint of the GameSense Engine.

??? note "Endpoints"
    Read the [GameSense SDK documentation](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md) for more information about endpoints. 

#### Parameters
| Type                                                    | Name       | Description                                   | Default                    |
| ------------------------------------------------------- | ---- ----- | --------------------------------------------- | -------------------------- |
| [`BaseRequest`](/Reference/Struct/Request/BaseRequest/) | `request`  | The request to be send                        | :octicons-diff-removed-16: |
| `string`                                                | `endpoint` | The endpoint where the request should be send | :octicons-diff-removed-16: |

---