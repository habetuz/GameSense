// <copyright file="Key.cs">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Keyboard keys and their <see cref="GameSense.KeyboardFrame"/> index.
    /// </summary>
    public enum Key
    {
        /// <summary>
        /// The escape key.
        /// </summary>
        Escape = 1,

        /// <summary>
        /// The F1 key.
        /// </summary>
        F1 = 2,

        /// <summary>
        /// The F2 key.
        /// </summary>
        F2 = 3,

        /// <summary>
        /// The F3 key.
        /// </summary>
        F3 = 4,

        /// <summary>
        /// The F4 key.
        /// </summary>
        F4 = 5,

        /// <summary>
        /// The F5 key.
        /// </summary>
        F5 = 6,

        /// <summary>
        /// The F6 key.
        /// </summary>
        F6 = 7,

        /// <summary>
        /// The F7 key.
        /// </summary>
        F7 = 8,

        /// <summary>
        /// The F8 key.
        /// </summary>
        F8 = 9,

        /// <summary>
        /// The F9 key.
        /// </summary>
        F9 = 10,

        /// <summary>
        /// The F10 key.
        /// </summary>
        F10 = 11,

        /// <summary>
        /// The F11 key.
        /// </summary>
        F11 = 12,

        /// <summary>
        /// The F12 key.
        /// </summary>
        F12 = 13,

        /// <summary>
        /// The print screen key.
        /// </summary>
        PrintScreen = 15,

        /// <summary>
        /// The scroll key.
        /// </summary>
        Scroll = 16,

        /// <summary>
        /// The pause key.
        /// </summary>
        Pause = 17,

        /// <summary>
        /// The oem5 key.
        /// </summary>D2
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        Oem5 = 22,

        /// <summary>
        /// The D1 key.
        /// </summary>
        D1 = 23,

        /// <summary>
        /// The D2 key.
        /// </summary>
        D2 = 24,

        /// <summary>
        /// The D3 key.
        /// </summary>
        D3 = 25,

        /// <summary>
        /// The D4 key.
        /// </summary>
        D4 = 26,

        /// <summary>
        /// The D5 key.
        /// </summary>
        D5 = 27,

        /// <summary>
        /// The D6 key.
        /// </summary>
        D6 = 28,

        /// <summary>
        /// The D7 key.
        /// </summary>
        D7 = 29,

        /// <summary>
        /// The D8 key.
        /// </summary>
        D8 = 30,

        /// <summary>
        /// The D9 key.
        /// </summary>
        D9 = 31,

        /// <summary>
        /// The D0 key.
        /// </summary>
        D0 = 32,

        /// <summary>
        /// The open brackets key.
        /// </summary>
        OemOpenBrackets = 33,

        /// <summary>
        /// The oem6 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        Oem6 = 34,

        /// <summary>
        /// The back key.
        /// </summary>
        Back = 35,

        /// <summary>
        /// The insert key.
        /// </summary>
        Insert = 37,

        /// <summary>
        /// The home key.
        /// </summary>
        Home = 38,

        /// <summary>
        /// The page up key.
        /// </summary>
        PageUp = 39,

        /// <summary>
        /// The num lock key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumLock = 40,

        /// <summary>
        /// The divide key.
        /// </summary>
        Divide = 41,

        /// <summary>
        /// The multiply key.
        /// </summary>
        Multiply = 42,

        /// <summary>
        /// The subtract key.
        /// </summary>
        Subtract = 43,

        /// <summary>
        /// The tab key.
        /// </summary>
        Tab = 44,

        /// <summary>
        /// The q key.
        /// </summary>
        Q = 45,

        /// <summary>
        /// The w key.
        /// </summary>
        W = 46,

        /// <summary>
        /// The e key.
        /// </summary>
        E = 47,

        /// <summary>
        /// The r key.
        /// </summary>
        R = 48,

        /// <summary>
        /// The t key.
        /// </summary>
        T = 49,

        /// <summary>
        /// The z key.
        /// </summary>
        Z = 50,

        /// <summary>
        /// The u key.
        /// </summary>
        U = 51,

        /// <summary>
        /// The i key.
        /// </summary>
        I = 52,

        /// <summary>
        /// The o key.
        /// </summary>
        O = 53,

        /// <summary>
        /// The p key.
        /// </summary>
        P = 54,

        /// <summary>
        /// The oem1 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        Oem1 = 55,

        /// <summary>
        /// The plus key.
        /// </summary>
        OemPlus = 56,

        /// <summary>
        /// The delete key.
        /// </summary>
        Delete = 59,

        /// <summary>
        /// The end key.
        /// </summary>
        End = 60,

        /// <summary>
        /// The next key.
        /// </summary>
        Next = 61,

        /// <summary>
        /// The num pad 7 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumPad7 = 62,

        /// <summary>
        /// The num pad 8 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumPad8 = 63,

        /// <summary>
        /// The num pad 9 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumPad9 = 64,

        /// <summary>
        /// The add key.
        /// </summary>
        Add = 65,

        /// <summary>
        /// The capital key.
        /// </summary>
        Capital = 66,

        /// <summary>
        /// The a key.
        /// </summary>
        A = 67,

        /// <summary>
        /// The s key.
        /// </summary>
        S = 68,

        /// <summary>
        /// The d key.
        /// </summary>
        D = 69,

        /// <summary>
        /// The f key.
        /// </summary>
        F = 70,

        /// <summary>
        /// The g key.
        /// </summary>
        G = 71,

        /// <summary>
        /// The h key.
        /// </summary>
        H = 72,

        /// <summary>
        /// The j key.
        /// </summary>
        J = 73,

        /// <summary>
        /// The k key.
        /// </summary>
        K = 74,

        /// <summary>
        /// The l key.
        /// </summary>
        L = 75,

        /// <summary>
        /// The tilde key.
        /// </summary>
        Oemtilde = 76,

        /// <summary>
        /// The oem7 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        Oem7 = 77,

        /// <summary>
        /// The question key.
        /// </summary>
        OemQuestion = 78,

        /// <summary>
        /// The return key.
        /// </summary>
        Return = 79,

        /// <summary>
        /// The num pad 4 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumPad4 = 84,

        /// <summary>
        /// The num pad 5 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumPad5 = 85,

        /// <summary>
        /// The num pad 6 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumPad6 = 86,

        /// <summary>
        /// The left shift key.
        /// </summary>
        LShiftKey = 88,

        /// <summary>
        /// The backslash key.
        /// </summary>
        OemBackslash = 89,

        /// <summary>
        /// The y key.
        /// </summary>
        Y = 90,

        /// <summary>
        /// The x key.
        /// </summary>
        X = 91,

        /// <summary>
        /// The c key.
        /// </summary>
        C = 92,

        /// <summary>
        /// The v key.
        /// </summary>
        V = 93,

        /// <summary>
        /// The b key.
        /// </summary>
        B = 94,

        /// <summary>
        /// The n key.
        /// </summary>
        N = 95,

        /// <summary>
        /// The m key.
        /// </summary>
        M = 96,

        /// <summary>
        /// The comma key.
        /// </summary>
        Oemcomma = 97,

        /// <summary>
        /// The period key.
        /// </summary>
        OemPeriod = 98,

        /// <summary>
        /// The minus key.
        /// </summary>
        OemMinus = 99,

        /// <summary>
        /// The right shift key.
        /// </summary>
        RShiftKey = 100,

        /// <summary>
        /// The up key.
        /// </summary>
        Up = 104,

        /// <summary>
        /// The num pad 1 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumPad1 = 106,

        /// <summary>
        /// The num pad 2 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumPad2 = 107,

        /// <summary>
        /// The num pad 3 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumPad3 = 108,

        /// <summary>
        /// The left control key key.
        /// </summary>
        LControlKey = 110,

        /// <summary>
        /// The left windows key.
        /// </summary>
        LWin = 111,

        /// <summary>
        /// The left menu key.
        /// </summary>
        LMenu = 112,

        /// <summary>
        /// The space key.
        /// </summary>
        Space = 116,

        /// <summary>
        /// The right menu key.
        /// </summary>
        RMenu = 120,

        /// <summary>
        /// The right windows key.
        /// </summary>
        RWin = 121,

        /// <summary>
        /// The steel series key.
        /// </summary>
        Steelseries = 122,

        /// <summary>
        /// The right control key.
        /// </summary>
        RControlKey = 123,

        /// <summary>
        /// The left key.
        /// </summary>
        Left = 125,

        /// <summary>
        /// The down key.
        /// </summary>
        Down = 126,

        /// <summary>
        /// The right key.
        /// </summary>
        Right = 127,

        /// <summary>
        /// The num pad 0 key.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        NumPad0 = 129,

        /// <summary>
        /// The decimal key.
        /// </summary>
        Decimal = 130,
    }
}