using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;
using Point = Cosmos.System.Graphics.Point;
using Console = System.Console;
using System.Collections.Generic;
using Cosmos.System;
using Boot.Systems;

namespace Boot {
	public class Kernel : Sys.Kernel {
		public static Canvas Canvas;
		public class Screen {
			public static int X;
			public static int Y;
			public static int W;
			public static int H;
			public static int PPI;
			public static int ScaleFactor;
			public static PCScreenFont Font = PCScreenFont.Default;
		}
		public class Colors {
            public static ColorDepth Depth = ColorDepth.ColorDepth32;

			//

            public static Color Primary = Color.FromArgb(255, 251, 222, 130);

			public static Color Background = Color.FromArgb(255, 051, 077, 092);
			public static Color Foreground = Color.FromArgb(255, 243, 156, 015);
			public static Color UserInput = Color.FromArgb(255, 138, 193, 200);

			public static Color Warn = Color.FromArgb(255, 255, 154, 102);
			public static Color Error = Color.FromArgb(255, 205, 51, 1);
			public static Color Info = Color.FromArgb(255, 31, 99, 180);
			public static Color Success = Color.FromArgb(255, 153, 204, 51);
		}
		public class Grid { 
			public static int Columns;
			public static int Rows;
			public class Cell {
				public static int Width;
				public static int Height;
			}
		}
		public class Cursor {
			public static int MinX;
			public class Pos{
				public static int X = 1;
				public static int Y = 1;
			}
		}
		public class Keyboard {
			public static ConsoleKey[] Letters = {
				ConsoleKey.A, ConsoleKey.B, ConsoleKey.C, ConsoleKey.D, ConsoleKey.E, ConsoleKey.F,
                ConsoleKey.G, ConsoleKey.H, ConsoleKey.I, ConsoleKey.J, ConsoleKey.K, ConsoleKey.L,
                ConsoleKey.M, ConsoleKey.N, ConsoleKey.O, ConsoleKey.P, ConsoleKey.Q, ConsoleKey.R,
                ConsoleKey.S, ConsoleKey.T, ConsoleKey.U, ConsoleKey.V, ConsoleKey.W, ConsoleKey.X,
                ConsoleKey.Y, ConsoleKey.X
            };
			public static ConsoleKey[] Numbers = {
				ConsoleKey.D1,
				ConsoleKey.D2,
				ConsoleKey.D3,
				ConsoleKey.D4,
				ConsoleKey.D5,
				ConsoleKey.D6,
				ConsoleKey.D7,
				ConsoleKey.D8,
				ConsoleKey.D9,
				ConsoleKey.D0,
				ConsoleKey.NumPad1,
				ConsoleKey.NumPad2,
				ConsoleKey.NumPad3,
				ConsoleKey.NumPad4,
				ConsoleKey.NumPad5,
				ConsoleKey.NumPad6,
				ConsoleKey.NumPad7,
				ConsoleKey.NumPad8,
				ConsoleKey.NumPad9,
				ConsoleKey.NumPad0
			};
            public static ConsoleKey[] Symbols = {
                ConsoleKey.Add,
                ConsoleKey.Subtract,
                ConsoleKey.Decimal,
                ConsoleKey.Divide,
                ConsoleKey.Multiply,
                ConsoleKey.Spacebar,
                ConsoleKey.OemComma,
                ConsoleKey.OemMinus,
                ConsoleKey.OemPeriod,
                ConsoleKey.OemPlus

            };
            public static ConsoleKey[] Modifiers = {
                ConsoleKey.Escape,
                ConsoleKey.Delete,
                ConsoleKey.Tab,
                ConsoleKey.PageDown,
                ConsoleKey.PageUp,
                ConsoleKey.PrintScreen,
                ConsoleKey.Home,
                ConsoleKey.BrowserHome,
                ConsoleKey.End,
                ConsoleKey.UpArrow,
                ConsoleKey.DownArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.LeftArrow,
                ConsoleKey.LeftWindows,
                ConsoleKey.RightWindows

            };
        }
		private static int Subtractable = 0;
		public static bool EnableUI = false;
		string[] ErrStrings = { }; 

        protected override void BeforeRun() {
			if(EnableUI) {
				try {
					GUI.Kernel.BeforeRun();
				} catch (Exception e) {
					ErrStr[ErrStr.Length] = e.Message;

				}
			}
			GetScreenInfo();
			// To calculate screen PPI we need the Width/Heigth of the screen in inches and the Width/Height of the screen in pixels (X/Y Divided by Width/Height)
			if (Screen.PPI == null && ((Screen.W != null && Screen.X != null) || (Screen.H != null && Screen.Y != null))) CalculateScreenPPI();
			// To calculate the screen size we need the screen size in pixels and the screen PPI (X/Y divided by PPI)
			if (Screen.PPI != null &&  (Screen.W != null || Screen.H != null) && (Screen.X != null && Screen.Y != null) ) CalculateScreenSize();
			// Calculate how many cells will be on the screen
			CalculateCells();

			Canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(Screen.X, Screen.Y, Colors.Depth));
			Canvas.Clear(Colors.Background);
			Write("Welcome to the Aurora Basic Operation System Project.", Screen.Font, Colors.Primary, true);
			WriteLine("Successfully booted.", Screen.Font, Colors.Success, true);
			WriteLine("ABOS> ", Screen.Font, Colors.Foreground, true);
		}

		protected override void Run() {
			if(EnableUI) {
				try {
					GUI.Kernel.Run();
				} catch (Exception e) {
					ErrStr[ErrStr.Length] = e.Message
					EnableUI = false;
				}
			} 
			if(!EnableUI) {
				try {
					Canvas.Display();
					var input = Console.ReadKey();
					if (input.Key == ConsoleKey.Backspace && Subtractable > 0) { 
						Subtractable--;
						if (Cursor.Pos.X == 1) {
							Cursor.Pos.X = Grid.Columns;
							Cursor.Pos.Y--;
						} else { 
							Cursor.Pos.X--;
						}
						Canvas.DrawFilledRectangle(new Pen(Colors.Background), GetCellPos(Cursor.Pos.X, Cursor.Pos.Y), Grid.Cell.Width, Grid.Cell.Height);
					} else if (input.Key == ConsoleKey.Enter) {
						
					} else if(	Array.Exists(Keyboard.Letters, element => element == input.Key) ||
								Array.Exists(Keyboard.Numbers, element => element == input.Key) ||
								Array.Exists(Keyboard.Symbols, element => element == input.Key) ||
								input.Key == ConsoleKey.Spacebar) {
						Write(input.KeyChar.ToString(), Screen.Font, Colors.UserInput);
					}
				} catch (Exception e) {
					mDebugger.Send("Exception occurred: " + e.Message);
					Sys.Power.Shutdown();
                }
            }
        }
	}
}