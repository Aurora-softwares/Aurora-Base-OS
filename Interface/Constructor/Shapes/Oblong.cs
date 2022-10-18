using Cosmos.System.Graphics;

namespace Interface.Constructor.Shapes {
    public class Oblong {
		#region Defaults
			Color DefaultCol = Color.fromArgb(255, 255, 255, 255);
			Color DefaultFil = false;
		#endregion
		///	<summary>
		///		
		///	</summary>
		// Scale
		public void Oblong(int X, int Y, int Scale) {
			Oblong(X, Y, Scale, Scale, DefaultCol, DefaultFil);
		}
		public void Oblong(int X, int Y, int Scale, Color Color) {
			Oblong(X, Y, Scale, Scale, Color, DefaultFil);
		}
		public void Oblong(int X, int Y, int Scale, bool Filled) {
			Oblong(X, Y, Scale, Scale, DefaultCol, Filled);
		}
		public void Oblong(int X, int Y, int Scale, Color Color, bool Filled) {
			Oblong(X, Y, Scale, Scale, Color, Filled);
		}
		// W/H
		public void Oblong(int X, int Y, int W, int H) {
			Oblong(X, Y, X, Y, DefaultCol, DefaultFil);
		}
		public void Oblong(int X, int Y, int W, int H, Color Color) {
			Oblong(X, Y, X, Y, Color, DefaultFil);
		}
		public void Oblong(int X, int Y, int W, int H, bool Filled) {
			Oblong(X, Y, X, Y, DefaultCol, Filled);
		}
		// Oblong Display
		public void Oblong(int X, int Y, int W, int H, Color Color, bool Filled) {
			for(i=0; i<H; i++) {
				if(Filled || i == 0  || i == H) {
					Line(X, Y+i, X+W, Y+i, Color); // Top and bottom line or full shape if its filled
				} else {
					Line(X, Y+i, X, Y+i, Color); // Leftmost line
					Line(X+W, Y+i, X+W, Y+i, Color); // Rightmost line
				}
			}
		}
    }
}