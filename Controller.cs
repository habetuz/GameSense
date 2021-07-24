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

        private static readonly Timer UpdateTimer = new Timer(50);

        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/Controller",
        };

        private static string gameName;
        private static string gameDisplayName;
        private static string developer;

        /// <summary>
        /// Sets the <see cref="IKeyboardAnimator"/> used for the keyboard background.
        /// </summary>
        public static IKeyboardAnimator KeyboardBackground
        {
            set
            {
                KeyboardFrameManager.Background = value;
                UpdateTimer.Enabled = true;
                Logger.Log("Keyboard background set.", LoggerType.Info);
            }
        }

        /// <summary>
        /// Sets the default <see cref="IKeyAnimator"/> used when a key gets pressed.
        /// </summary>
        public static IKeyAnimator DefaultKeyAnimation
        {
            set
            {
                InputManager.DefaultKeyAnimation = value;
            }
        }

        public static IMouseAnimator MouseBackground
        {
            set
            {
                MouseFrameManager.Animator = value;
                UpdateTimer.Enabled = true;
                Logger.Log("Mouse background set.", LoggerType.Info);
            }
        }

        /// <summary>
        /// Sets the game name for the game sense engine.
        /// </summary>
        public static string GameName
        {
            set
            {
                Logger.Log("Name set: " + value, LoggerType.Info);
                gameName = value;
                if (ReadyForInitialization())
                {
                    Start();
                }
            }
        }

        /// <summary>
        /// Sets the name that is displayed in the game sense engine.
        /// </summary>
        public static string GameDisplayName
        {
            set
            {
                Logger.Log("Display name set: " + value, LoggerType.Info);
                gameDisplayName = value;
                if (ReadyForInitialization())
                {
                    Start();
                }
            }
        }

        /// <summary>
        /// Sets the developer of the project.
        /// </summary>
        public static string Developer
        {
            set
            {
                Logger.Log("Developer set: " + value, LoggerType.Info);
                developer = value;
                if (ReadyForInitialization())
                {
                    Start();
                }
            }
        }

        /// <summary>
        /// Initialize the <see cref="GameSense.Controller"/> and start game sense.
        /// </summary>
        private static void Start()
        {
            Logger.Log("Starting...", LoggerType.Info);

            RegisterGame();
            StartHeartbeat();
            BindEvents();
            StartUpdate();

            Logger.Log("Ready!", LoggerType.Info);
        }

        /// <summary>
        /// Stops game sense. Should be called at the end of the program.
        /// </summary>
        public static void Stop()
        {
            InputManager.Stop();
        }

        private static bool ReadyForInitialization()
        {
            return
                gameDisplayName != null &&
                developer != null &&
                gameName != null;
        }

        private static void RegisterGame()
        {
            Logger.Log("Registering game...", LoggerType.Info);
            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
                    GameDisplayName = gameDisplayName,
                    Developer = developer
                },
                EndpointRegisterGame);
        }

        private static void BindEvents()
        {
            Logger.Log("Binding events...", LoggerType.Info);
            BindKeyboardEvent();
            BindMouseEvents();
            
        }

        private static void BindKeyboardEvent()
        {

            // Full keyboard effect
            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
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
            Logger.Log("Keyboard event binned!", LoggerType.Info);
        }

        private static void BindMouseEvents()
        {
            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
                    Event = EventMouseWheel,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
                    Event = EventMouseLogo,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
                    Event = EventMouseLeft1,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
                    Event = EventMouseLeft2,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
                    Event = EventMouseLeft3,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
                    Event = EventMouseRight1,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
                    Event = EventMouseRight2,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
                    Event = EventMouseRight3,
                    MinValue = 0,
                    MaxValue = 100,
                    ValueOptional = false,
                },
                EndpointRegisterEvent);

            Logger.Log("Mouse events binned!", LoggerType.Info);
        }

        private static void StartHeartbeat()
        {
            Timer timer = new System.Timers.Timer(10000);
            timer.Elapsed += Heartbeat;
            timer.AutoReset = true;
            timer.Enabled = true;
            Logger.Log("Heartbeat started.", LoggerType.Info);
        }

        private static void StartUpdate()
        {
            UpdateTimer.Elapsed += Update;
            UpdateTimer.AutoReset = true;
            Logger.Log("UpdateTimer ready.", LoggerType.Info);
        }

        private static void Heartbeat(object source, System.Timers.ElapsedEventArgs e)
        {
            ////Logger.Log("Heartbeat...", LoggerType.Info);
            Transmitter.Send(new BaseRequest { Game = gameName }, "game_heartbeat");
        }

        private static void Update(object source, System.Timers.ElapsedEventArgs e)
        {
            Logger.Log("Keyboard-Effect...", LoggerType.Debug);

            List<EventBinder> events = new List<EventBinder>();

            KeyboardFrame keyboardFrame = KeyboardFrameManager.Generate();
            if(keyboardFrame != null)
            {
                events.Add(new EventBinder
                {
                    Event = EventKeyboard,
                    Data = new RequestData
                    {
                        Frame = keyboardFrame
                    }
                });
            }


            //// Dictionary<MouseZone, int> mouseFrame = MouseFrameManager.Generate();
            /*
            Random random = new Random();
            Dictionary<MouseZone, int> mouseFrame = new Dictionary<MouseZone, int>()
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

            /*
            if (mouseFrame != null)
            {
                events.Add(new EventBinder
                {
                    Event = EventMouseWheel,
                    Data = new RequestData
                    {
                        Value = mouseFrame[MouseZone.Wheel]
                    }
                });
                events.Add(new EventBinder
                {
                    Event = EventMouseLeft1,
                    Data = new RequestData
                    {
                        Value = mouseFrame[MouseZone.Left1]
                    }
                });
                events.Add(new EventBinder
                {
                    Event = EventMouseRight1,
                    Data = new RequestData
                    {
                        Value = mouseFrame[MouseZone.Right1]
                    }
                });
                events.Add(new EventBinder
                {
                    Event = EventMouseLeft2,
                    Data = new RequestData
                    {
                        Value = mouseFrame[MouseZone.Left2]
                    }
                });
                events.Add(new EventBinder
                {
                    Event = EventMouseRight2,
                    Data = new RequestData
                    {
                        Value = mouseFrame[MouseZone.Right2]
                    }
                });
                events.Add(new EventBinder
                {
                    Event = EventMouseLeft3,
                    Data = new RequestData
                    {
                        Value = mouseFrame[MouseZone.Left3]
                    }
                });
                events.Add(new EventBinder
                {
                    Event = EventMouseRight3,
                    Data = new RequestData
                    {
                        Value = mouseFrame[MouseZone.Right3]
                    }
                });
                events.Add(new EventBinder
                {
                    Event = EventMouseLogo,
                    Data = new RequestData
                    {
                        Value = mouseFrame[MouseZone.Logo]
                    }
                });
            }
            */

            Transmitter.Send(
                new BaseRequest
                {
                    Game = gameName,
                    Events = events.ToArray()
                },
                "multiple_game_events") ;
        }
    }
}
