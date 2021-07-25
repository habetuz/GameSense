---
title: Handler
---

# Handler
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Struct/Request/Handler.cs)

`#!c# namespace GameSense.Struct.Request`

`#!c# public struct Handler`

---

Represents an event handler. More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/writing-handlers-in-json.md).

## Properties
| Type                              | Name         | Description                                                                                                                                                          |
| --------------------------------- | ------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `string`                          | `DeviceType` | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/standard-zones.md#general-device-types). :material-file-code: `device-type` |
| `string`                          | `Zone`       | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/standard-zones.md#zones-by-device-type). :material-file-code: `zone`        |
| `string`                          | `Mode`       | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/writing-handlers-in-json.md#binding-an-event). :material-file-code: `color` |
| [`ColorHandler`](ColorHandler.md) | `Color`      | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/writing-handlers-in-json.md#binding-an-event). :material-file-code: `mode`  |