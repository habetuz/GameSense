// <copyright file="Controller.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

namespace GameSense
{
    using System;
    using System.Timers;
    using System.Collections.Generic;
    using GameSense.Animation;
    using GameSense.Struct.Request;
    using SharpLog;
    using SharpLog.Output;

    /// <summary>
    /// Controls communication with the game sense API and the animation cycle. It starts automatically when <see cref="GradientColor1"/>, <see cref="GradientColor2"/>, <see cref="GameName"/>, <see cref="GameDisplayName"/> and <see cref="Developer"/> are set.
    /// </summary>
    public static class Controller
    {
        private const string EventKeyboard      = "KEYBOARD_BITMAP";
        private const string EventMouseWheel    = "MOUSE_WHEEL";
        private const string EventMouseLogo     = "MOUSE_LOGO";
        private const string EventMouseLeft1    = "MOUSE_LEFT1";
        private const string EventMouseLeft2    = "MOUSE_LEFT2";
        private const string EventMouseLeft3    = "MOUSE_LEFT3";
        private const string EventMouseRight1   = "MOUSE_RIGHT1";
        private const string EventMouseRight2   = "MOUSE_RIGHT2";
        private const string EventMouseRight3   = "MOUSE_RIGHT3";

        private const string EndpointRegisterGame   = "game_metadata";
        private const string EndpointBindEvent      = "bind_game_event";
        private const string EndpointRegisterEvent  = "register_game_event";
        private const string EndpointGameEvent      = "multiple_game_events";
        // private const string EndpointGameEvent      = "game_event";

        internal const string LogFile = "GameSense.log";

        private static readonly Timer UpdateTimer = new Timer(50);

        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/Controller",
            LogDebug = false,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        private static string gameName;
        private static string gameDisplayName;
        private static string developer;
        private static List<GenericFrameManager> genericFrameManagers = new List<GenericFrameManager>();
        private static bool started = false;

        /// <summary>
        /// Gets or sets the <see cref="KeyboardAnimator"/> used for the keyboard background.
        /// </summary>
        public static KeyboardAnimator KeyboardBackground
        {
            set
            {
                KeyboardFrameManager.Background = value;
                Logger.Log("Keyboard background set.", LogType.Info);
            }
            get
            {
                return KeyboardFrameManager.Background;
            }

        }

        /// <summary>
        /// Gets or sets the default <see cref="KeyAnimator"/> used when a key gets pressed.
        /// </summary>
        public static KeyAnimator DefaultKeyAnimation
        {
            set
            {
                InputManager.DefaultKeyAnimation = value;
                Logger.Log("Default key animation set.", LogType.Info);

            }
            get
            {
                return InputManager.DefaultKeyAnimation;
            }
        }

        public static MouseAnimator MouseBackground
        {
            set
            {
                MouseFrameManager.Background = value;
                Logger.Log("Mouse background set.", LogType.Info);
            }
            get
            {
                return MouseFrameManager.Background;
            }
        }

        /// <summary>
        /// Gets or sets the game name for the game sense engine.
        /// </summary>
        public static string GameName
        {
            set
            {   
                Logger.Log("Name set: " + value, LogType.Info);
                gameName = value;
                if (ReadyForInitialization())
                {
                    Start();
                }
            }
            get
            {
                return gameName;
            }
        }

        /// <summary>
        /// Gets or sets the name that is displayed in the game sense engine.
        /// </summary>
        public static string GameDisplayName
        {
            set
            {
                Logger.Log("Display name set: " + value, LogType.Info);
                gameDisplayName = value;
                if (ReadyForInitialization())
                {
                    Start();
                }
            }
            get
            {
                return gameDisplayName;
            }
        }

        /// <summary>
        /// Gets or sets the developer of the project.
        /// </summary>
        public static string Developer
        {
            set
            {
                Logger.Log("Developer set: " + value, LogType.Info);
                developer = value;
                if (ReadyForInitialization())
                {
                    Start();
                }
            }
            get
            {
                return developer;
            }
        }

        /// <summary>
        /// Gets or sets the update interval in milliseconds.
        /// </summary>
        public static double UpdateInterval
        {
            get
            {
                return UpdateTimer.Interval;
            }
            set
            {
                Logger.Log("Update interval changed from " + UpdateTimer.Interval + "ms to " + value + "ms", LogType.Info);
                UpdateTimer.Interval = value;
            }
        }

        

        /// <summary>
        /// Initialize the <see cref="GameSense.Controller"/> and start game sense.
        /// </summary>
        private static void Start()
        {
            Logger.Log("Starting...", LogType.Info);

            RegisterGame();
            StartHeartbeat();
            BindEvents();
            StartUpdate();

            started = true;

            Logger.Log("Ready!", LogType.Info);
        }

        /// <summary>
        /// Stops game sense. Should be called at the end of the program.
        /// </summary>
        public static void Stop()
        {
            Logger.Log("Stopping...", LogType.Info);
            InputManager.Stop();
        }

        private static bool ReadyForInitialization()
        {
            return
                GameDisplayName != null &&
                Developer != null &&
                GameName != null;
        }

        private static void RegisterGame()
        {
            Logger.Log("Registering game...", LogType.Info);
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    GameDisplayName = GameDisplayName,
                    Developer = Developer
                },
                EndpointRegisterGame);
        }

        private static void BindEvents()
        {
            Logger.Log("Binding events...", LogType.Info);
            BindKeyboardEvent();
            BindMouseEvents();
            BindGenericEvents();
        }

        private static void BindKeyboardEvent()
        {

            // Full keyboard effect
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventKeyboard,
                    Handlers = new Handler[]
                    {
                        new Handler
                        {
                            DeviceType = "rgb-per-key-zones",
                            Mode = "bitmap"
                        }
                    }
                },
                EndpointBindEvent);
            Logger.Log("Keyboard event binned!", LogType.Info);
        }

        private static void BindMouseEvents()
        {
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseWheel,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseLogo,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseLeft1,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseLeft2,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseLeft3,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseRight1,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseRight2,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseRight3,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Logger.Log("Mouse events binned!", LogType.Info);
        }

        private static void BindGenericEvents()
        {
            genericFrameManagers.ForEach(frameManager =>
            {
                BindGenericEvent(frameManager.Prefix, frameManager.NumberOfZones);
            });
        }

        private static void BindGenericEvent(string prefix, int numberOfZones)
        {
            for (int i = 0; i < numberOfZones; i++)
            {
                Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = prefix + i,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent,
                important: true);
            }

            Logger.Log("Events of generic frame manager with prefix " + prefix + " binned!", LogType.Info);
        }

        public static void AddGenericFrameManager(GenericFrameManager frameManager)
        {
            if(started)
            {
                BindGenericEvent(frameManager.Prefix, frameManager.NumberOfZones);
            }

            genericFrameManagers.Add(frameManager);
        }

        private static void StartHeartbeat()
        {
            Timer timer = new Timer(10000);
            timer.Elapsed += Heartbeat;
            timer.AutoReset = true;
            timer.Enabled = true;
            Logger.Log("Heartbeat started.", LogType.Info);
        }

        private static void StartUpdate()
        {
            UpdateTimer.Elapsed += Update;
            UpdateTimer.AutoReset = true;
            UpdateTimer.Enabled = true;
            Logger.Log("UpdateTimer ready.", LogType.Info);
        }

        private static void Heartbeat(object source, ElapsedEventArgs e)
        {
            //Logger.Log("Heartbeat...", LogType.Info);
            Transmitter.Send(new BaseRequest { Game = GameName }, "game_heartbeat", false);
        }

        private static bool on = false;

        private static void Update(object source, ElapsedEventArgs e)
        {

            List<EventBinder> events = new List<EventBinder>();


            Logger.Log("Keyboard-Effect...", LogType.Debug);


            // KeyboardFrame keyboardFrame = KeyboardFrameManager.Generate();
            KeyboardFrame keyboardFrame = on ? new KeyboardColor(new int[] { 0, 0, 0 }).NextFrame(null) : new KeyboardColor(new int[] { 255, 255, 255 }).NextFrame(null);
            if(keyboardFrame != null)
            {
                events.Add(new EventBinder
                {
                    Event = EventKeyboard,
                    Data = new EventData
                    {
                        Frame = keyboardFrame
                    }
                });
            }
            

            Logger.Log("Mouse-Effect...");

            //Dictionary<MouseZone, int> mouseFrame = MouseFrameManager.Generate();

            Dictionary<MouseZone, int> mouseFrame = on ? new MouseValue(0).NextFrame(null) : new MouseValue(100).NextFrame(null);
            on = !on;

            /*
            Random random = new Random();
            new Dictionary<MouseZone, int>()
            {
                { MouseZone.Wheel , random.Next(0, 101) },
                { MouseZone.Left1 , random.Next(0, 101) },
                { MouseZone.Right1 , random.Next(0, 101) },
                { MouseZone.Left2 , random.Next(0, 101) },
                { MouseZone.Right2 , random.Next(0, 101) },
                { MouseZone.Left3 , random.Next(0, 101) },
                { MouseZone.Right3 , random.Next(0, 101) },
                { MouseZone.Logo , random.Next(0, 101) },
            };
            */


            events.Add(new EventBinder
            {
                Event = EventMouseWheel,
                Data = new EventData
                {
                    Value = mouseFrame[MouseZone.Wheel]
                }
            });
            events.Add(new EventBinder
            {
                Event = EventMouseLeft3,
                Data = new EventData
                {
                    Value = mouseFrame[MouseZone.Left1]
                }
            });
            events.Add(new EventBinder
            {
                Event = EventMouseRight3,
                Data = new EventData
                {
                    Value = mouseFrame[MouseZone.Right1]
                }
            });
            events.Add(new EventBinder
            {
                Event = EventMouseLeft2,
                Data = new EventData
                {
                    Value = mouseFrame[MouseZone.Left2]
                }
            });
            events.Add(new EventBinder
            {
                Event = EventMouseRight2,
                Data = new EventData
                {
                    Value = mouseFrame[MouseZone.Right2]
                }
            });
            events.Add(new EventBinder
            {
                Event = EventMouseLeft1,
                Data = new EventData
                {
                    Value = mouseFrame[MouseZone.Left3]
                }
            });
            events.Add(new EventBinder
            {
                Event = EventMouseRight1,
                Data = new EventData
                {
                    Value = mouseFrame[MouseZone.Right3]
                }
            });
            events.Add(new EventBinder
            {
                Event = EventMouseLogo,
                Data = new EventData
                {
                    Value = mouseFrame[MouseZone.Logo]
                }
            });


            // Single event per request
            /*
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseWheel,
                    Data = new EventData
                    {
                        Value = mouseFrame[MouseZone.Wheel]
                    }
                },
                EndpointGameEvent,
                important: false);
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseLeft3,
                    Data = new EventData
                    {
                        Value = mouseFrame[MouseZone.Left3]
                    }
                },
                EndpointGameEvent,
                important: false);
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseLeft2,
                    Data = new EventData
                    {
                        Value = mouseFrame[MouseZone.Left2]
                    }
                },
                EndpointGameEvent,
                important: false);
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseLeft1,
                    Data = new EventData
                    {
                        Value = mouseFrame[MouseZone.Left1]
                    }
                },
                EndpointGameEvent,
                important: false);
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseRight1,
                    Data = new EventData
                    {
                        Value = mouseFrame[MouseZone.Right1]
                    }
                },
                EndpointGameEvent,
                important: false);
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseRight2,
                    Data = new EventData
                    {
                        Value = mouseFrame[MouseZone.Right2]
                    }
                },
                EndpointGameEvent,
                important: false);
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseRight3,
                    Data = new EventData
                    {
                        Value = mouseFrame[MouseZone.Right3]
                    }
                },
                EndpointGameEvent,
                important: false);
            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Event = EventMouseLogo,
                    Data = new EventData
                    {
                        Value = mouseFrame[MouseZone.Logo]
                    }
                },
                EndpointGameEvent,
                important: false);
            */

            Logger.Log("Generic effects...");
            genericFrameManagers.ForEach(frameManager =>
            {
                events.AddRange(frameManager.Generate());
            });

            Transmitter.Send(
                new BaseRequest
                {
                    Game = GameName,
                    Events = events.ToArray()
                },
                EndpointGameEvent,
                important: false);
            
        }
    }
}
