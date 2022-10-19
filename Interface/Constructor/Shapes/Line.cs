using System.Drawing;
using Variables;
using Cosmos.System.Graphics;

namespace Interface.Constructor.Shapes {
    public class Line {
		#region Defaults
			private static Color DefaultCol = Color.FromArgb(255, 255, 255, 255);
			private static bool DefaultFil = false;
		#endregion
		///	<summary>
		///		
		///	</summary>
		public static void Draw(int X1, int Y1, int X2, int Y2) {
			Draw(X1, Y1, X2, Y2, DefaultCol);
		}

		
		public static void Draw(int X1, int Y1, int X2, int Y2, Color Color) {
            Screen.Canvas.DrawLine(new Pen(Color), X1, Y1, X2, Y2);
		}

    }
}