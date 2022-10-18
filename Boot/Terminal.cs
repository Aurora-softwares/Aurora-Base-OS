using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;
using Point = Cosmos.System.Graphics.Point;
using Console = System.Console;
using System.Collections.Generic;
using Cosmos.System;

namespace Systems {
	public class Terminal {
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