using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;
using Point = Cosmos.System.Graphics.Point;
using Console = System.Console;
using System.Collections.Generic;
using Cosmos.System;

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
			if(!EnableUI) {
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
						
					} else if (input.Key == ConsoleKey.Escape) {
						// 
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
        /// <summary>
        /// Writes a string from the current cursor position
        /// </summary>
        private static void Write(string str, PCScreenFont font, Color color, bool system = false) {
			for (int i = 0; i < str.Length; i++) {
				Canvas.DrawString(str[i].ToString(), font, new Pen(color), GetCellPos(Cursor.Pos.X, Cursor.Pos.Y));
				Subtractable++;
				if (Cursor.Pos.X == Grid.Columns) {
					Cursor.Pos.X = 1;
					Cursor.Pos.Y++;
				} else {
					Cursor.Pos.X++;
				}
			}
			if(system) {
				Subtractable = 0;
            }
        }
        /// <summary>
		/// Writes a string from a new line 
        /// </summary>
        private static void WriteLine(string str, PCScreenFont font, Color color, bool system = false) {
			Cursor.Pos.Y++;
			Cursor.Pos.X=1;
			Write(str, font, color, system);
		}
		/// <summary>
		/// Gets the screen size and Pixels Per Inch if the information is available.
		/// TODO: Build function to actually get the size of the screen
		/// </summary>
		private static void GetScreenInfo() {
            // HD
            //Screen.X = 1280;
            //Screen.Y = 720;
            //Screen.PPI = 183;
            // FHD
            Screen.X = 1920;
            Screen.Y = 1080;
            Screen.PPI = 165;
            // 4K
            //Screen.X = 4096;
            //Screen.Y = 2560;
            //Screen.PPI = 150;
        }
        /// <summary>
		/// Calculates the screen size in Inches
        /// </summary>
        private static void CalculateScreenSize() {
			//(X/Y divided by PPI)
			if(Screen.X != null && Screen.Y != null && Screen.PPI != null) {
				Screen.W = Screen.Y / Screen.PPI;
				Screen.H = Screen.Y / Screen.PPI;
			} else {
				// Unable to get screen size
			}
        }
        /// <summary>
		/// Calculates the screens Pixels Per Inch
        /// </summary>
        private static void CalculateScreenPPI() {
			// (X/Y Divided by Width/Height)
			if(Screen.X != null && Screen.W != null) {
				Screen.PPI = Screen.X / Screen.W;
			} else if(Screen.Y != null && Screen.H != null) {
				Screen.PPI = Screen.Y / Screen.H;
			} else {
				// Unable to get screen PPI
			}
        }
        /// <summary>
        /// Calculates the quantity and size of cells for the user's screen
		/// TODO: Add Scaling functionality
        /// </summary>
        private static void CalculateCells() {
			var CM = (int)Math.Floor(Screen.PPI/2.54);
			Grid.Cell.Width = CM/8;
			Grid.Cell.Height = CM/4;
			Grid.Columns = Screen.X/Grid.Cell.Width;
			Grid.Rows = Screen.Y/Grid.Cell.Height;
        }
        /// <summary>
        /// Converts cell coordinates to PX coordinates
        /// </summary>
        private static Point GetCellPos(int CellX, int CellY) {
			return new Point((CellX-1)* Grid.Cell.Width, (CellY-1)* Grid.Cell.Height);
		}
	}
}