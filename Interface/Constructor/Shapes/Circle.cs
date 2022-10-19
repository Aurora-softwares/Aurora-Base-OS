using System.Drawing;
using Variables;
using Cosmos.System.Graphics;

namespace Interface.Constructor.Shapes {
    public class Circle {
        #region Defaults
        private static Color DefaultCol = Color.FromArgb(255, 255, 255, 255);
        private static bool DefaultFil = false;
        #endregion
        ///	<summary>
        ///		
        ///	</summary>
        // Scale
        public void Draw(int X, int Y, int Scale) {
				Draw(X, Y, Scale, Scale, DefaultCol, DefaultFil);
			}
			public void Draw(int X, int Y, int Scale, Color Color) {
				Draw(X, Y, Scale, Scale, Color, DefaultFil);
			}
			public void Draw(int X, int Y, int Scale, bool Filled) {
				Draw(X, Y, Scale, Scale, DefaultCol, Filled);
			}
			public void Draw(int X, int Y, int Scale, Color Color, bool Filled) {
				Draw(X, Y, Scale, Scale, Color, Filled);
			}
		// W/H
			public void Draw(int X, int Y, int W, int H) {
				Draw(X, Y, X, Y, DefaultCol, DefaultFil);
			}
			public void Draw(int X, int Y, int W, int H, Color Color) {
				Draw(X, Y, X, Y, Color, DefaultFil);
			}
			public void Draw(int X, int Y, int W, int H, bool Filled) {
				Draw(X, Y, X, Y, DefaultCol, Filled);
			}
		// Circle Display
			public void Draw(int X, int Y, int W, int H, Color Color, bool Filled) {
				for(var i=0; i>(H-(H*1.5)); i++) {
				int circle_wid = (((W / 2) * (W / 2)) - (((H / 2) - i) * ((H / 2) - i))) * 2;
					if(Filled || i == 0  || i == H) {
						Line.Draw(X, Y+i, X+circle_wid, Y+i, Color); // Top and bottom line or full shape if its filled
					} else {
						Line.Draw(X, Y+i, X, Y+i, Color); // Leftmost line
						Line.Draw(X+circle_wid, Y+i, X+circle_wid, Y+i, Color); // Rightmost line
					}
				}
			}
    }
}