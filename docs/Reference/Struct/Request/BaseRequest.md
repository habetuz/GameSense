---
title: BaseRequest
---

# BaseRequest
[:material-file-code: Source](https://github.com/habetuz/GameSense/blob/main/Struct/Request/BaseRequest.cs)

`#!c# namespace GameSense.Struct.Request`

`#!c# public struct BaseRequest`

---

Request that can be send to the GameSense Engine using the [`Transmitter`](Transmitter.md).

## Properties
| Type                                | Name              | Description                                                                                                                                                                                   |
| ----------------------------------- | ----------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `string`                            | `Game`            | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#registering-a-game). :material-file-code: `game`                              | 
| `string`                            | `GameDisplayName` | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#registering-a-game). :material-file-code: `game_display_name`                 |
| `string`                            | `Developer`       | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#registering-a-game). :material-file-code:`developer`                          |
| `string`                            | `Event`           | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#registering-an-event). :material-file-code:`event`                            |
| `int`                               | `MinValue`        | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#registering-an-event). :material-file-code: `min_value`                       |
| `int`                               | `MaxValue`        | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#registering-an-event). :material-file-code: `max_value`                       |
| `int`                               | `IconId`          | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#registering-an-event). :material-file-code: `icon_id`                         |
| `bool`                              | `ValueOptional`   | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#registering-an-event). :material-file-code: `value_optional`                  |
| [`Handler`](Handler.md)`[]`         | `Handlers`        | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#registering-an-event). :material-file-code: `handler`                         |
| [`EventBinder`](EventBinder.md)`[]` | `Events`          | More information [here](https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#sending-multiple-event-updates-in-one-request). :material-file-code: `events` |