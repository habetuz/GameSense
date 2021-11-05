// <copyright file="Controller.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace GameSense
{
    using System.Collections.Generic;
    using System.Timers;
    using GameSense.Animation;
    using GameSense.Struct.Request;
    using SharpLog;
    using SharpLog.Output;

    /// <summary>
    /// Controls communication with the game sense API and the animation cycle. It starts automatically when <see cref="GradientColor1"/>, <see cref="GradientColor2"/>, <see cref="GameName"/>, <see cref="GameDisplayName"/> and <see cref="Developer"/> are set.
    /// </summary>
    public static class Controller
    {
        /// <summary>
        /// Name of the file all logger of game sense log to.
        /// </summary>
        internal const string LogFile = "GameSense.log";

        /// <summary>
        /// Event name of the keyboard event.
        /// </summary>
        private const string EventKeyboard = "KEYBOARD_BITMAP";

        /// <summary>
        /// Event name of the mouse wheel event.
        /// </summary>
        private const string EventMouseWheel = "MOUSE_WHEEL";

        /// <summary>
        /// Event name of the mouse logo event.
        /// </summary>
        private const string EventMouseLogo = "MOUSE_LOGO";

        /// <summary>
        /// Event name of the first left mouse event.
        /// </summary>
        private const string EventMouseLeft1 = "MOUSE_LEFT1";

        /// <summary>
        /// Event name of the second left mouse event.
        /// </summary>
        private const string EventMouseLeft2 = "MOUSE_LEFT2";

        /// <summary>
        /// Event name of the third left mouse event.
        /// </summary>
        private const string EventMouseLeft3 = "MOUSE_LEFT3";

        /// <summary>
        /// Event name of the first right mouse event.
        /// </summary>
        private const string EventMouseRight1 = "MOUSE_RIGHT1";

        /// <summary>
        /// Event name of the second right mouse event.
        /// </summary>
        private const string EventMouseRight2 = "MOUSE_RIGHT2";

        /// <summary>
        /// Event name of the third right mouse event.
        /// </summary>
        private const string EventMouseRight3 = "MOUSE_RIGHT3";

        /// <summary>
        /// Endpoint for registering the game.
        /// </summary>
        private const string EndpointRegisterGame = "game_metadata";
        
        /// <summary>
        /// Endpoint for binding an event.
        /// </summary>
        private const string EndpointBindEvent = "bind_game_event";

        /// <summary>
        /// Endpoint for registering an event.
        /// </summary>
        private const string EndpointRegisterEvent = "register_game_event";

        /// <summary>
        /// Endpoint for events.
        /// </summary>
        private const string EndpointGameEvent = "multiple_game_events";
        //// private const string EndpointGameEvent      = "game_event";

        /// <summary>
        /// The timer responsible for the update loop.
        /// </summary>
        private static readonly Timer UpdateTimer = new Timer(50);

        /// <summary>
        /// The logger for the <see cref="Controller"/> class.
        /// </summary>
        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/Controller",
            LogDebug = false,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        /// <summary>
        /// The name of the game used for requests.
        /// </summary>
        private static string gameName;

        /// <summary>
        /// The name of the game as shown in the game sense engine.
        /// </summary>
        private static string gameDisplayName;

        /// <summary>
        /// The name of the developer.
        /// </summary>
        private static string developer;

        /// <summary>
        /// List with all <see cref="GenericFrameManager"/>s
        /// </summary>
        private static List<GenericFrameManager> genericFrameManagers = new List<GenericFrameManager>();
        
        /// <summary>
        /// Indicates whether <see cref="Start"/> was called or not.
        /// </summary>
        private static bool started = false;

        /// <summary>
        /// Only for testing. Will be removed for release!
        /// </summary>
        private static bool on = false;

        /// <summary>
        /// Gets or sets the <see cref="KeyboardAnimator"/> used for the keyboard background.
        /// </summary>
        public static KeyboardAnimator KeyboardBackground
        {
            get
            {
                return KeyboardFrameManager.Background;
            }

            set
            {
                KeyboardFrameManager.Background = value;
                Logger.Log("Keyboard background set.", LogType.Info);
            }
        }

        /// <summary>
        /// Gets or sets the default <see cref="KeyAnimator"/> used when a key gets pressed.
        /// </summary>
        public static KeyAnimator DefaultKeyAnimation
        {
            get
            {
                return InputManager.DefaultKeyAnimation;
            }

            set
            {
                InputManager.DefaultKeyAnimation = value;
                Logger.Log("Default key animation set.", LogType.Info);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MouseAnimator"/> used for the mouse background.
        /// </summary>
        public static MouseAnimator MouseBackground
        {
            get
            {
                return MouseFrameManager.Background;
            }

            set
            {
                MouseFrameManager.Background = value;
                Logger.Log("Mouse background set.", LogType.Info);
            }
        }

        /// <summary>
        /// Gets or sets the game name for the game sense engine.
        /// </summary>
        public static string GameName
        {
            get
            {
                return gameName;
            }

            set
            {
                Logger.Log("Name set: " + value, LogType.Info);
                gameName = value;
                if (ReadyForInitialization())
                {
                    Start();
                }
            }
        }

        /// <summary>
        /// Gets or sets the name that is displayed in the game sense engine.
        /// </summary>
        public static string GameDisplayName
        {
            get
            {
                return gameDisplayName;
            }

            set
            {
                Logger.Log("Display name set: " + value, LogType.Info);
                gameDisplayName = value;
                if (ReadyForInitialization())
                {
                    Start();
                }
            }
        }

        /// <summary>
        /// Gets or sets the developer of the project.
        /// </summary>
        public static string Developer
        {
            get
            {
                return developer;
            }

            set
            {
                Logger.Log("Developer set: " + value, LogType.Info);
                developer = value;
                if (ReadyForInitialization())
                {
                    Start();
                }
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
        /// Adds a <see cref="GenericFrameManager"/> to game sense.
        /// </summary>
        /// <param name="frameManager">The <see cref="GenericFrameManager"/> to be added</param>
        public static void AddGenericFrameManager(GenericFrameManager frameManager)
        {
            if (started)
            {
                BindGenericEvent(frameManager.Prefix, frameManager.NumberOfZones);
            }

            genericFrameManagers.Add(frameManager);
        }

        /// <summary>
        /// Stops game sense. Should be called at the end of the program.
        /// </summary>
        public static void Stop()
        {
            Logger.Log("Stopping...", LogType.Info);
            InputManager.Stop();
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
        /// Checks if the controller is ready for initialization.
        /// </summary>
        /// <returns>If the controller is ready for initialization</returns>
        private static bool ReadyForInitialization()
        {
            return
                GameDisplayName != null &&
                Developer != null &&
                GameName != null;
        }

        /// <summary>
        /// Registers the game to the game sense engine.
        /// </summary>
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

        /// <summary>
        /// Calls the bind methods for the specific events.
        /// </summary>
        private static void BindEvents()
        {
            Logger.Log("Binding events...", LogType.Info);
            BindKeyboardEvent();
            BindMouseEvents();
            BindGenericEvents();
        }

        /// <summary>
        /// Binds the keyboard event.
        /// </summary>
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

        /// <summary>
        /// Binds the mouse events.
        /// </summary>
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

        /// <summary>
        /// Binds the generic events that were added before initialization.
        /// </summary>
        private static void BindGenericEvents()
        {
            genericFrameManagers.ForEach(frameManager =>
            {
                BindGenericEvent(frameManager.Prefix, frameManager.NumberOfZones);
            });
        }

        /// <summary>
        /// Binds the events used by a <see cref="GenericFrameManager"/>
        /// </summary>
        /// <param name="prefix">The prefix used for the events. The events will be named "[prefix][number]".</param>
        /// <param name="numberOfZones">The number of zones or the number of events that will be binned</param>
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

        /// <summary>
        /// Starts a timer that will fire a heartbeat event every 10 seconds.
        /// </summary>
        private static void StartHeartbeat()
        {
            Timer timer = new Timer(10000);
            timer.Elapsed += Heartbeat;
            timer.AutoReset = true;
            timer.Enabled = true;
            Logger.Log("Heartbeat started.", LogType.Info);
        }

        /// <summary>
        /// Activates the update timer and starts the update loop.
        /// </summary>
        private static void StartUpdate()
        {
            UpdateTimer.Elapsed += Update;
            UpdateTimer.AutoReset = true;
            UpdateTimer.Enabled = true;
            Logger.Log("UpdateTimer ready.", LogType.Info);
        }

        /// <summary>
        /// The heartbeat event.
        /// </summary>
        /// <param name="source">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private static void Heartbeat(object source, ElapsedEventArgs e)
        {
            // Logger.Log("Heartbeat...", LogType.Info);
            Transmitter.Send(new BaseRequest { Game = GameName }, "game_heartbeat", false);
        }

        /// <summary>
        /// The update event.
        /// </summary>
        /// <param name="source">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private static void Update(object source, ElapsedEventArgs e)
        {
            List<EventBinder> events = new List<EventBinder>();

            Logger.Log("Keyboard-Effect...", LogType.Debug);

            // KeyboardFrame keyboardFrame = KeyboardFrameManager.Generate();
            KeyboardFrame keyboardFrame = on ? new KeyboardColor(new int[] { 0, 0, 0 }).NextFrame(null) : new KeyboardColor(new int[] { 255, 255, 255 }).NextFrame(null);
            if (keyboardFrame != null)
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

            ////Dictionary<MouseZone, int> mouseFrame = MouseFrameManager.Generate();

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
                        value = mouseFrame[MouseZone.Wheel]
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
                        value = mouseFrame[MouseZone.Left3]
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
                        value = mouseFrame[MouseZone.Left2]
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
                        value = mouseFrame[MouseZone.Left1]
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
                        value = mouseFrame[MouseZone.Right1]
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
                        value = mouseFrame[MouseZone.Right2]
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
                        value = mouseFrame[MouseZone.Right3]
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
                        value = mouseFrame[MouseZone.Logo]
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