---
title: EventBinder
---

# EventBinder
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Struct/Request/EventBinder.cs)

`#!c# namespace GameSense.Struct.Request`

`#!c# public struct EventBinder`

---

Holds information about an event. More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/83127ca35a108a3bab3fb3273e4e9c3c2a8ff9ac/doc/api/sending-game-events.md#sending-multiple-event-updates-in-one-request).

## Properties
| Type                   | Name    | Description                                                                                                                                                                                                                    |
| ---------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `string`               | `Event` | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/83127ca35a108a3bab3fb3273e4e9c3c2a8ff9ac/doc/api/sending-game-events.md#sending-multiple-event-updates-in-one-request). :material-file-code: `event` |
| [`Data`](EventData.md) | `Data`  | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/83127ca35a108a3bab3fb3273e4e9c3c2a8ff9ac/doc/api/sending-game-events.md#sending-multiple-event-updates-in-one-request). :material-file-code: `data`  |