﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Diagnostics.Contracts;

namespace HotkeyModel
{
    [Flags]
    public enum Keys
    {
        Modifiers = -65536,
        None = 0,
        LButton = 1,
        RButton = 2,
        Cancel = RButton | LButton,
        MButton = 4,
        XButton1 = MButton | LButton,
        XButton2 = MButton | RButton,
        Back = 8,
        Tab = Back | LButton,
        LineFeed = Back | RButton,
        Clear = Back | MButton,
        Enter = Clear | Tab,
        Return = Enter,
        ShiftKey = 16,
        ControlKey = ShiftKey | LButton,
        Menu = ShiftKey | RButton,
        Pause = Menu | ControlKey,
        Capital = ShiftKey | MButton,
        CapsLock = Capital,
        HanguelMode = CapsLock | ControlKey,
        HangulMode = HanguelMode,
        KanaMode = HangulMode,
        JunjaMode = KanaMode | Pause,
        FinalMode = ShiftKey | Back,
        HanjaMode = FinalMode | ControlKey,
        KanjiMode = HanjaMode,
        Escape = KanjiMode | Pause,
        IMEConvert = FinalMode | CapsLock,
        IMENonconvert = IMEConvert | KanjiMode,
        IMEAccept = IMEConvert | Menu,
        IMEAceept = IMEAccept,
        IMEModeChange = IMEAceept | IMENonconvert,
        Space = 32,
        PageUp = Space | LButton,
        Prior = PageUp,
        Next = Space | RButton,
        PageDown = Next,
        End = PageDown | Prior,
        Home = Space | MButton,
        Left = Home | Prior,
        Up = Home | PageDown,
        Right = Up | Left,
        Down = Space | Back,
        Select = Down | Prior,
        Print = Down | PageDown,
        Execute = Print | Select,
        PrintScreen = Down | Home,
        Snapshot = PrintScreen,
        Insert = Snapshot | Select,
        Delete = Snapshot | Print,
        Help = Delete | Insert,
        D0 = Space | ShiftKey,
        D1 = D0 | Prior,
        D2 = D0 | PageDown,
        D3 = D2 | D1,
        D4 = D0 | Home,
        D5 = D4 | D1,
        D6 = D4 | D2,
        D7 = D6 | D5,
        D8 = D0 | Down,
        D9 = D8 | D1,
        A = 65,
        B = 66,
        C = B | A,
        D = 68,
        E = D | A,
        F = D | B,
        G = F | E,
        H = 72,
        I = H | A,
        J = H | B,
        K = J | I,
        L = H | D,
        M = L | I,
        N = L | J,
        O = N | M,
        P = 80,
        Q = P | A,
        R = P | B,
        S = R | Q,
        T = P | D,
        U = T | Q,
        V = T | R,
        W = V | U,
        X = P | H,
        Y = X | Q,
        Z = X | R,
        LWin = Z | Y,
        RWin = X | T,
        Apps = RWin | Y,
        Sleep = Apps | LWin,
        NumPad0 = 96,
        NumPad1 = NumPad0 | A,
        NumPad2 = NumPad0 | B,
        NumPad3 = NumPad2 | NumPad1,
        NumPad4 = NumPad0 | D,
        NumPad5 = NumPad4 | NumPad1,
        NumPad6 = NumPad4 | NumPad2,
        NumPad7 = NumPad6 | NumPad5,
        NumPad8 = NumPad0 | H,
        NumPad9 = NumPad8 | NumPad1,
        Multiply = NumPad8 | NumPad2,
        Add = Multiply | NumPad9,
        Separator = NumPad8 | NumPad4,
        Subtract = Separator | NumPad9,
        Decimal = Separator | Multiply,
        Divide = Decimal | Subtract,
        F1 = NumPad0 | P,
        F2 = F1 | NumPad1,
        F3 = F1 | NumPad2,
        F4 = F3 | F2,
        F5 = F1 | NumPad4,
        F6 = F5 | F2,
        F7 = F5 | F3,
        F8 = F7 | F6,
        F9 = F1 | NumPad8,
        F10 = F9 | F2,
        F11 = F9 | F3,
        F12 = F11 | F10,
        F13 = F9 | F5,
        F14 = F13 | F10,
        F15 = F13 | F11,
        F16 = F15 | F14,
        F17 = 128,
        F18 = F17 | LButton,
        F19 = F17 | RButton,
        F20 = F19 | F18,
        F21 = F17 | MButton,
        F22 = F21 | F18,
        F23 = F21 | F19,
        F24 = F23 | F22,
        NumLock = F17 | ShiftKey,
        Scroll = NumLock | F18,
        LShiftKey = F17 | Space,
        RShiftKey = LShiftKey | F18,
        LControlKey = LShiftKey | F19,
        RControlKey = LControlKey | RShiftKey,
        LMenu = LShiftKey | F21,
        RMenu = LMenu | RShiftKey,
        BrowserBack = LMenu | LControlKey,
        BrowserForward = BrowserBack | RMenu,
        BrowserRefresh = LShiftKey | Down,
        BrowserStop = BrowserRefresh | RShiftKey,
        BrowserSearch = BrowserRefresh | LControlKey,
        BrowserFavorites = BrowserSearch | BrowserStop,
        BrowserHome = BrowserRefresh | LMenu,
        VolumeMute = BrowserHome | BrowserStop,
        VolumeDown = BrowserHome | BrowserSearch,
        VolumeUp = VolumeDown | VolumeMute,
        MediaNextTrack = LShiftKey | NumLock,
        MediaPreviousTrack = MediaNextTrack | RShiftKey,
        MediaStop = MediaNextTrack | LControlKey,
        MediaPlayPause = MediaStop | MediaPreviousTrack,
        LaunchMail = MediaNextTrack | LMenu,
        SelectMedia = LaunchMail | MediaPreviousTrack,
        LaunchApplication1 = LaunchMail | MediaStop,
        LaunchApplication2 = LaunchApplication1 | SelectMedia,
        Oem1 = MediaStop | BrowserSearch,
        OemSemicolon = Oem1,
        Oemplus = OemSemicolon | MediaPlayPause,
        Oemcomma = LaunchMail | BrowserHome,
        OemMinus = Oemcomma | SelectMedia,
        OemPeriod = Oemcomma | OemSemicolon,
        Oem2 = OemPeriod | OemMinus,
        OemQuestion = Oem2,
        Oem3 = 192,
        Oemtilde = Oem3,
        Oem4 = Oemtilde | Scroll | F20 | LWin,
        OemOpenBrackets = Oem4,
        Oem5 = Oemtilde | NumLock | F21 | RWin,
        OemPipe = Oem5,
        Oem6 = OemPipe | Scroll,
        OemCloseBrackets = Oem6,
        Oem7 = OemPipe | F23,
        OemQuotes = Oem7,
        Oem8 = OemQuotes | OemCloseBrackets,
        Oem102 = Oemtilde | LControlKey,
        OemBackslash = Oem102,
        ProcessKey = Oemtilde | RMenu,
        Packet = ProcessKey | OemBackslash,
        Attn = OemBackslash | LaunchApplication1,
        Crsel = Attn | Packet,
        Exsel = Oemtilde | MediaNextTrack | BrowserRefresh,
        EraseEof = Exsel | MediaPreviousTrack,
        Play = Exsel | OemBackslash,
        Zoom = Play | EraseEof,
        NoName = Exsel | OemPipe,
        Pa1 = NoName | EraseEof,
        OemClear = NoName | Play,
        KeyCode = 65535,
        Shift = 65536,
        Control = 131072,
        Alt = 262144,
    }

    internal class HotKeyWinApi
    {
        public const int WmHotKey = 0x0312;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, ModifierKeys fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    }

    public sealed class HotKey : IDisposable
    {
        public event Action<HotKey> HotKeyPressed;
        private readonly int _id;
        private bool _isKeyRegistered;
        readonly IntPtr _handle;

        public HotKey(ModifierKeys modifierKeys, Keys key, Window window)
            : this(modifierKeys, key, new WindowInteropHelper(window))
        {
            Contract.Requires(window != null);
        }

        public HotKey(ModifierKeys modifierKeys, Keys key, WindowInteropHelper window)
            : this(modifierKeys, key, window.Handle)
        {
            Contract.Requires(window != null);
        }

        public HotKey(ModifierKeys modifierKeys, Keys key, IntPtr windowHandle)
        {
            Contract.Requires(modifierKeys != ModifierKeys.None || key != Keys.None);
            Contract.Requires(windowHandle != IntPtr.Zero);

            Key = key;
            KeyModifier = modifierKeys;

            _id = GetHashCode();
            _handle = windowHandle;
            RegisterHotKey();
            ComponentDispatcher.ThreadPreprocessMessage += ThreadPreprocessMessageMethod;
        }

        ~HotKey()
        {
            Dispose();
        }

        public Keys Key { get; private set; }
        public ModifierKeys KeyModifier { get; private set; }

        public void RegisterHotKey()
        {
            if (Key == Keys.None)
                return;
            if (_isKeyRegistered)
                UnregisterHotKey();
            _isKeyRegistered = HotKeyWinApi.RegisterHotKey(_handle, _id, KeyModifier, Key);
            if (!_isKeyRegistered)
                throw new ApplicationException("Hotkey already in use");
        }

        public void UnregisterHotKey()
        {
            _isKeyRegistered = !HotKeyWinApi.UnregisterHotKey(_handle, _id);
        }

        public void Dispose()
        {
            try
            {
                ComponentDispatcher.ThreadPreprocessMessage -= ThreadPreprocessMessageMethod;
            }
            catch (InvalidOperationException) { }
            UnregisterHotKey();
        }

        private void ThreadPreprocessMessageMethod(ref MSG msg, ref bool handled)
        {
            if (!handled)
            {
                if (msg.message == HotKeyWinApi.WmHotKey && (int)(msg.wParam) == _id)
                {
                    OnHotKeyPressed();
                    handled = true;
                }
            }
        }

        private void OnHotKeyPressed()
        {
            if (HotKeyPressed != null) HotKeyPressed(this);
        }

    }
}