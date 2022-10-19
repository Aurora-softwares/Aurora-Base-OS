using Sys = Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;

namespace Variables {
	public class Screen
    {
        public static Canvas Canvas;
        public static int X;
        public static int Y;
        public static int W;
        public static int H;
        public static int PPI;
        public static PCScreenFont Font;

        /// <summary>
        /// Gets the screen size and Pixels Per Inch if the information is available.
        /// TODO: Build function to actually get the size of the screen
        /// </summary>
        public static void GetScreenInfo() {
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
        public static void CalculateScreenSize() {
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
        public static void CalculateScreenPPI() {
			// (X/Y Divided by Width/Height)
			if(Screen.X != null && Screen.W != null) {
				Screen.PPI = Screen.X / Screen.W;
			} else if(Screen.Y != null && Screen.H != null) {
				Screen.PPI = Screen.Y / Screen.H;
			} else {
				// Unable to get screen PPI
			}
        }
    }
}