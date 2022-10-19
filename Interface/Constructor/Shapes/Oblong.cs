using System.Drawing;
using Variables;
using Cosmos.System.Graphics;

namespace Interface.Constructor.Shapes {
    public class Oblong {
        #region Defaults
			private static Color DefaultCol = Color.FromArgb(255, 255, 255, 255);
			private static bool DefaultFil = false;
        #endregion
        ///	<summary>
        ///		
        ///	</summary>
        // Scale
        public static void Draw(int X, int Y, int Scale) {
				Draw(X, Y, Scale, Scale, DefaultCol, DefaultFil);
			}
			public static void Draw(int X, int Y, int Scale, Color Color) {
				Draw(X, Y, Scale, Scale, Color, DefaultFil);
			}
			public static void Draw(int X, int Y, int Scale, bool Filled) {
				Draw(X, Y, Scale, Scale, DefaultCol, Filled);
			}
			public static void Draw(int X, int Y, int Scale, Color Color, bool Filled) {
				Draw(X, Y, Scale, Scale, Color, Filled);
			}
		// W/H
			public static void Draw(int X, int Y, int W, int H) {
				Draw(X, Y, X, Y, DefaultCol, DefaultFil);
			}
			public static void Draw(int X, int Y, int W, int H, Color Color) {
				Draw(X, Y, X, Y, Color, DefaultFil);
			}
			public static void Draw(int X, int Y, int W, int H, bool Filled) {
				Draw(X, Y, X, Y, DefaultCol, Filled);
			}
		// Oblong Display
		public static void Draw(int X, int Y, int W, int H, Color Color, bool Filled) {
			for(var i=0; i<H; i++) {
				if(Filled || i == 0  || i == H) {
					Line.Draw(X, Y+i, X+W, Y+i, Color); // Top and bottom line or full shape if its filled
				} else {
					Line.Draw(X, Y+i, X, Y+i, Color); // Leftmost line
					Line.Draw(X+W, Y+i, X+W, Y+i, Color); // Rightmost line
				}
			}
		}
    }
}