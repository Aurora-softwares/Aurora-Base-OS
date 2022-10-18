using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;
using Point = Cosmos.System.Graphics.Point;
using Console = System.Console;
using System.Collections.Generic;
using Cosmos.System;
using Systems;
using Variables

namespace Boot {
	public class Kernel : Sys.Kernel {
		public static Canvas Canvas;
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