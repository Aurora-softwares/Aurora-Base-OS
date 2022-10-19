using System.Drawing;
using Variables;
using Cosmos.System.Graphics;

namespace Interface.Constructor.Shapes {
    public class Triangle {
        #region Defaults
			private static Color DefaultCol = Color.FromArgb(255, 255, 255, 255);
			private static bool DefaultFil = false;
		#endregion
		///	<summary>
		///		
		///	</summary>
		//
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
		//  	  /b\
		//		 / | \
		//		/  |  \
		//	   Z   Y   Z
		//	  /    |    \
		//	 /     |     \
		//	/a_____X__x__c\
		// Triangle Display
		public void Draw(int X, int Y, int W, int H, Color Color, bool Filled) {
			var tri_X = W; var tri_x = tri_X / 2; 
			var tri_Y = H;

			var tri_Z = Math.Sqrt((tri_x*tri_x)+(tri_Y*tri_Y));
			var tri_a = ((((tri_Y*tri_Y)+(tri_x*tri_x))-(tri_Z*tri_Z))/(2*(tri_x*tri_Z)));
			var tri_b = ((((tri_Y*tri_Y)+(tri_Z*tri_Z))-(tri_x*tri_x))/(2*(tri_Y+tri_x)))*2;
			var tri_c = tri_a;

			for(var i=0; i<H; i++) {
				var layer_wid = (int)(i * Math.Tan(tri_b / 2))*2;
				var layer_X = (int)X + ((W - layer_wid)/2);

				if(Filled || i == 0  || i == H) {
					Line.Draw(layer_X, Y+i, layer_X+layer_wid, Y+i, Color); // Top and bottom line or full shape if its filled
				} else {
					Line.Draw(layer_X, Y+i, layer_X, Y+i, Color); // Leftmost line
					Line.Draw(layer_X+W, Y+i, layer_X+W, Y+i, Color); // Rightmost line
				}
			}
		}
    }
}