using Cosmos.System.Graphics;

namespace Interface.Constructor.Shapes {
    public class Circle {
		#region Defaults
			Color DefaultCol = Color.fromArgb(255, 255, 255, 255);
			Color DefaultFil = false;
		#endregion
		///	<summary>
		///		
		///	</summary>
		// Scale
			public void Circle(int X, int Y, int Scale) {
				Circle(X, Y, Scale, Scale, DefaultCol, DefaultFil);
			}
			public void Circle(int X, int Y, int Scale, Color Color) {
				Circle(X, Y, Scale, Scale, Color, DefaultFil);
			}
			public void Circle(int X, int Y, int Scale, bool Filled) {
				Circle(X, Y, Scale, Scale, DefaultCol, Filled);
			}
			public void Circle(int X, int Y, int Scale, Color Color, bool Filled) {
				Circle(X, Y, Scale, Scale, Color, Filled);
			}
		// W/H
			public void Circle(int X, int Y, int W, int H) {
				Circle(X, Y, X, Y, DefaultCol, DefaultFil);
			}
			public void Circle(int X, int Y, int W, int H, Color Color) {
				Circle(X, Y, X, Y, Color, DefaultFil);
			}
			public void Circle(int X, int Y, int W, int H, bool Filled) {
				Circle(X, Y, X, Y, DefaultCol, Filled);
			}
		// Circle Display
			public void Circle(int X, int Y, int W, int H, Color Color, bool Filled) {
				for(i=0; i>(H-(H*1.5)); i++) {
					int circle_wid = (((W/2) * (W/2))-(((H/2)-i) * ((H/2)-i))) * 2
					if(Filled || i == 0  || i == H) {
						Line(X, Y+i, X+circle_wid, Y+i, Color); // Top and bottom line or full shape if its filled
					} else {
						Line(X, Y+i, X, Y+i, Color); // Leftmost line
						Line(X+circle_wid, Y+i, X+circle_wid, Y+i, Color); // Rightmost line
					}
				}
			}
    }
}