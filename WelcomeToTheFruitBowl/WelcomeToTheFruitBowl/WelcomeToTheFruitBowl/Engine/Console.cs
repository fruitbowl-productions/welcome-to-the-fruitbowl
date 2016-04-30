using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WelcomeToTheFruitBowl.Engine.Keyboards;
using WelcomeToTheFruitBowl.Utilities;
using WelcomeToTheFruitBowl.Utilities.Timers;

namespace WelcomeToTheFruitBowl.Engine
{
    public class Console
    {
        private const string Prompt = "> ";
        private readonly SpriteFont font = Assets.Fonts.ConsoleFont;
        private readonly List<string> outputLines;
        private readonly DelayedTimer timer;
        private string inputLine;

        public Console()
        {
            outputLines = new List<string>();
            inputLine = "";

            timer = new DelayedTimer(() => { }, () =>
            {
                WelcomeToTheFruitBowlGame.DrawActions.Enqueue(spriteBatch =>
                {
                    spriteBatch.DrawString(font, "_",
                        new Vector2(font.MeasureString(Prompt + inputLine).X,
                            Screen.Height - font.MeasureString(Prompt).Y), Color.White);
                });
            }, TimeSpan.FromMilliseconds(500));
            outputLines.Add("Welcome to Defined Destiny!");
            outputLines.Add("A Text Based RPG Classic!");
        }

        public void Update(GameTime gameTime)
        {
            timer.Update(gameTime);

            foreach (var key in DelayedKeyboard.PressedKeys)
            {
                switch (key)
                {
                    case Keys.Back:
                        if (inputLine.Length > 0)
                        {
                            inputLine = inputLine.Substring(0, inputLine.Length - 1);
                        }
                        break;
                    case Keys.Tab:
                        inputLine += "\t";
                        break;
                    case Keys.Enter:
                        inputLine = "";
                        break;
                    case Keys.Space:
                        inputLine += " ";
                        break;
                    case Keys.A:
                        inputLine += "A";
                        break;
                    case Keys.B:
                        inputLine += "B";
                        break;
                    case Keys.C:
                        inputLine += "C";
                        break;
                    case Keys.D:
                        inputLine += "D";
                        break;
                    case Keys.E:
                        inputLine += "E";
                        break;
                    case Keys.F:
                        inputLine += "F";
                        break;
                    case Keys.G:
                        inputLine += "G";
                        break;
                    case Keys.H:
                        inputLine += "H";
                        break;
                    case Keys.I:
                        inputLine += "I";
                        break;
                    case Keys.J:
                        inputLine += "J";
                        break;
                    case Keys.K:
                        inputLine += "K";
                        break;
                    case Keys.L:
                        inputLine += "L";
                        break;
                    case Keys.M:
                        inputLine += "M";
                        break;
                    case Keys.N:
                        inputLine += "N";
                        break;
                    case Keys.O:
                        inputLine += "O";
                        break;
                    case Keys.P:
                        inputLine += "P";
                        break;
                    case Keys.Q:
                        inputLine += "Q";
                        break;
                    case Keys.R:
                        inputLine += "R";
                        break;
                    case Keys.S:
                        inputLine += "S";
                        break;
                    case Keys.T:
                        inputLine += "T";
                        break;
                    case Keys.U:
                        inputLine += "U";
                        break;
                    case Keys.V:
                        inputLine += "V";
                        break;
                    case Keys.W:
                        inputLine += "W";
                        break;
                    case Keys.X:
                        inputLine += "X";
                        break;
                    case Keys.Y:
                        inputLine += "Y";
                        break;
                    case Keys.Z:
                        inputLine += "Z";
                        break;
                    case Keys.NumPad0:
                    case Keys.NumPad1:
                    case Keys.NumPad2:
                    case Keys.NumPad3:
                    case Keys.NumPad4:
                    case Keys.NumPad5:
                    case Keys.NumPad6:
                    case Keys.NumPad7:
                    case Keys.NumPad8:
                    case Keys.NumPad9:
                    case Keys.Multiply:
                    case Keys.Add:
                    case Keys.Separator:
                    case Keys.Subtract:
                    case Keys.Decimal:
                    case Keys.Divide:
                    case Keys.F1:
                    case Keys.F2:
                    case Keys.F3:
                    case Keys.F4:
                    case Keys.F5:
                    case Keys.F6:
                    case Keys.F7:
                    case Keys.F8:
                    case Keys.F9:
                    case Keys.F10:
                    case Keys.F11:
                    case Keys.F12:
                    case Keys.F13:
                    case Keys.F14:
                    case Keys.F15:
                    case Keys.F16:
                    case Keys.F17:
                    case Keys.F18:
                    case Keys.F19:
                    case Keys.F20:
                    case Keys.F21:
                    case Keys.F22:
                    case Keys.F23:
                    case Keys.F24:
                    case Keys.NumLock:
                    case Keys.Scroll:
                    case Keys.LeftShift:
                    case Keys.RightShift:
                    case Keys.LeftControl:
                    case Keys.RightControl:
                    case Keys.LeftAlt:
                    case Keys.RightAlt:
                    case Keys.BrowserBack:
                    case Keys.BrowserForward:
                    case Keys.BrowserRefresh:
                    case Keys.BrowserStop:
                    case Keys.BrowserSearch:
                    case Keys.BrowserFavorites:
                    case Keys.BrowserHome:
                    case Keys.VolumeMute:
                    case Keys.VolumeDown:
                    case Keys.VolumeUp:
                    case Keys.MediaNextTrack:
                    case Keys.MediaPreviousTrack:
                    case Keys.MediaStop:
                    case Keys.MediaPlayPause:
                    case Keys.LaunchMail:
                    case Keys.SelectMedia:
                    case Keys.LaunchApplication1:
                    case Keys.LaunchApplication2:
                    case Keys.OemSemicolon:
                    case Keys.OemComma:
                    case Keys.OemPlus:
                    case Keys.OemMinus:
                    case Keys.OemPeriod:
                    case Keys.OemQuestion:
                    case Keys.OemTilde:
                    case Keys.ChatPadGreen:
                    case Keys.ChatPadOrange:
                    case Keys.OemOpenBrackets:
                    case Keys.OemPipe:
                    case Keys.OemCloseBrackets:
                    case Keys.OemQuotes:
                    case Keys.Oem8:
                    case Keys.OemBackslash:
                    case Keys.ProcessKey:
                    case Keys.OemCopy:
                    case Keys.OemAuto:
                    case Keys.OemEnlW:
                    case Keys.Attn:
                    case Keys.Crsel:
                    case Keys.Exsel:
                    case Keys.EraseEof:
                    case Keys.Play:
                    case Keys.Zoom:
                    case Keys.Pa1:
                    case Keys.OemClear:
                    case Keys.LeftWindows:
                    case Keys.RightWindows:
                    case Keys.Apps:
                    case Keys.Sleep:
                    case Keys.End:
                    case Keys.Home:
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Right:
                    case Keys.Down:
                    case Keys.Select:
                    case Keys.Print:
                    case Keys.Execute:
                    case Keys.PrintScreen:
                    case Keys.Insert:
                    case Keys.Delete:
                    case Keys.Help:
                    case Keys.D0:
                    case Keys.D1:
                    case Keys.D2:
                    case Keys.D3:
                    case Keys.D4:
                    case Keys.D5:
                    case Keys.D6:
                    case Keys.D7:
                    case Keys.D8:
                    case Keys.D9:
                    case Keys.PageUp:
                    case Keys.PageDown:
                    case Keys.Pause:
                    case Keys.CapsLock:
                    case Keys.Kana:
                    case Keys.Kanji:
                    case Keys.ImeConvert:
                    case Keys.ImeNoConvert:
                    case Keys.Escape:
                    case Keys.None:
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var counter = 0;
            foreach (var line in outputLines.ReverseInPlace())
            {
                spriteBatch.DrawString(font, line,
                    new Vector2(0, Screen.Height - (2 + counter)*font.MeasureString(Prompt).Y), Color.White);
                ++counter;
            }

            spriteBatch.DrawString(font, Prompt, new Vector2(0, Screen.Height - font.MeasureString(Prompt).Y),
                Color.White);
            spriteBatch.DrawString(font, inputLine,
                new Vector2(font.MeasureString(Prompt).X, Screen.Height - font.MeasureString(Prompt).Y),
                Color.White);
        }
    }
}