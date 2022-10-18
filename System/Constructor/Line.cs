using Cosmos.System.Graphics;

namespace Interface.Constructor.Shapes {
    public class Line {
		#region Defaults
			Color DefaultCol = Color.fromArgb(255, 255, 255, 255);
			Color DefaultFil = false;
		#endregion
		///	<summary>
		///		
		///	</summary>
		public void Line(int X1, int Y1, int X2, int Y2) {
			Line(X1, Y1, X2, Y2, DefaultCol);
		}
		public void Line(int X1, int Y1, int X2, int Y2, Color Color) {
			canvas.DrawLine(new Pen(Color), X1, Y1, X2, Y2);
		}
    }
}