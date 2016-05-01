using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private string userInput;
        private int progress;

        private readonly List<string[]> dialog;

        // Any character can be used since Courier New is monospace.
        private int MaxInputChars => Screen.Width/(int)font.MeasureString(" ").X - Prompt.Length;

        private enum InputMode
        {
            User,
            Override
        }

        private InputMode inputMode;

        public Console()
        {
            outputLines = new List<string>();
            userInput = "";

            progress = 0;

            timer = new DelayedTimer(() => { }, () =>
            {
                WelcomeToTheFruitBowlGame.DrawActions.Enqueue(spriteBatch =>
                {
                    var inputLines = userInput.Split('\n');
                    spriteBatch.DrawString(font, "_",
                        new Vector2(font.MeasureString(Prompt + inputLines[inputLines.Length - 1]).X,
                            Screen.Height - font.MeasureString(Prompt).Y), Color.White);

                });
            }, TimeSpan.FromMilliseconds(500));

            inputMode = InputMode.Override;

            dialog = new List<string[]>
            {
                new[] {"Hello!", "You're new here, aren't you?"},
                new[] {"What?", "What's your name?"},
                new[] {"Dolor.", "I love your creativity!\nWhat Race are you?"},
                new[] {"Human.", "Really, not even an Elf?"},
                new[] {"Yeah.", "So you decide to be a Human!\nWhere will you begin your journey?"},
                new[] {"At a much better place\nthan where I was....", "*screen cracks*"}
            };

            outputLines.Add("Welcome to Defined Destiny!");
            outputLines.Add("A Text Based RPG Classic!");
        }

        public void Update(GameTime gameTime)
        {
            switch (inputMode)
            {
                case InputMode.User:
                    foreach (var key in DelayedKeyboard.PressedKeys)
                    {
                        switch (key)
                        {
                            case Keys.Back:
                                if (userInput.Length > 0)
                                {
                                    userInput = userInput.Substring(0, userInput.Length - 1);
                                }
                                break;
                            case Keys.Tab:
                                userInput += "\t";
                                break;
                            case Keys.Enter:
                                userInput = "";
                                break;
                            case Keys.Space:
                                userInput += " ";
                                break;
                            case Keys.A:
                                userInput += "A";
                                break;
                            case Keys.B:
                                userInput += "B";
                                break;
                            case Keys.C:
                                userInput += "C";
                                break;
                            case Keys.D:
                                userInput += "D";
                                break;
                            case Keys.E:
                                userInput += "E";
                                break;
                            case Keys.F:
                                userInput += "F";
                                break;
                            case Keys.G:
                                userInput += "G";
                                break;
                            case Keys.H:
                                userInput += "H";
                                break;
                            case Keys.I:
                                userInput += "I";
                                break;
                            case Keys.J:
                                userInput += "J";
                                break;
                            case Keys.K:
                                userInput += "K";
                                break;
                            case Keys.L:
                                userInput += "L";
                                break;
                            case Keys.M:
                                userInput += "M";
                                break;
                            case Keys.N:
                                userInput += "N";
                                break;
                            case Keys.O:
                                userInput += "O";
                                break;
                            case Keys.P:
                                userInput += "P";
                                break;
                            case Keys.Q:
                                userInput += "Q";
                                break;
                            case Keys.R:
                                userInput += "R";
                                break;
                            case Keys.S:
                                userInput += "S";
                                break;
                            case Keys.T:
                                userInput += "T";
                                break;
                            case Keys.U:
                                userInput += "U";
                                break;
                            case Keys.V:
                                userInput += "V";
                                break;
                            case Keys.W:
                                userInput += "W";
                                break;
                            case Keys.X:
                                userInput += "X";
                                break;
                            case Keys.Y:
                                userInput += "Y";
                                break;
                            case Keys.Z:
                                userInput += "Z";
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
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        if (userInput.Length >= MaxInputChars)
                        {
                            userInput = userInput.Substring(0, userInput.Length - 2);
                        }
                    }
                    break;
                case InputMode.Override:
                    if (DelayedKeyboard.IsAnyKeyDown() && progress < dialog.Count)
                    {
                        ContinueWrite(dialog[progress]);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            timer.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var userInputLines = userInput.Split('\n').ReverseInPlace().ToList();
            var outputLineNum = 0;
            
            foreach (var line in outputLines.ReverseInPlace())
            {
                spriteBatch.DrawString(font, line, new Vector2(0, Screen.Height - (2 + outputLineNum + userInputLines.Count - 1)*font.MeasureString(Prompt).Y), Color.White);
                ++outputLineNum;
            }

            spriteBatch.DrawString(font, Prompt, new Vector2(0, Screen.Height - font.MeasureString(Prompt).Y*userInputLines.Count), Color.White);

            for (var i = 0; i < userInputLines.Count; ++i)
            {
                spriteBatch.DrawString(font, userInputLines[i],
                    new Vector2(font.MeasureString(Prompt).X, Screen.Height - font.MeasureString(Prompt).Y*(i + 1)), Color.White);
            }
        }

        private void ContinueWrite(IList<string> currentDialogue)
        {
            var forcedInput = currentDialogue[0];
            var npcResponse = currentDialogue[1];

            if (userInput.Length < forcedInput.Length)
            {
                userInput += forcedInput[userInput.Length];
            }
            else if (Keyboards.Keyboard.IsKeyDown(Keys.Enter))
            {
                ++progress;
                
                // Move previous user input up.
                var inputLines = userInput.Split('\n');
                outputLines.Add($"> {inputLines[0]}");
                if (inputLines.Length > 1)
                {
                    for (var i = 1; i < inputLines.Length; ++i)
                    {
                        outputLines.Add(inputLines[i]);
                    }
                }

                userInput = "";

                foreach (var line in npcResponse.Split('\n'))
                {
                    outputLines.Add(line);
                }
            }
        }
    }
}
