using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Variables;

namespace Boot {
    public class Kernel : Sys.Kernel {
		protected override void BeforeRun() {
			// Get screen info
				Screen.GetScreenInfo();
				// To calculate screen PPI we need the Width/Heigth of the screen in inches and the Width/Height of the screen in pixels (X/Y Divided by Width/Height)
				if (Screen.PPI == 0 && ((Screen.W != 0 && Screen.X != 0) || (Screen.H != 0 && Screen.Y != 0))) Screen.CalculateScreenPPI();
				// To calculate the screen size we need the screen size in pixels and the screen PPI (X/Y divided by PPI)
				if (Screen.PPI != 0 &&  (Screen.W != 0 || Screen.H != 0) && (Screen.X != 0 && Screen.Y != 0) ) Screen.CalculateScreenSize();
			// Set canvas
				Screen.Canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(Screen.X, Screen.Y, Colors.Depth));
				//Screen.Canvas.Clear(Colors.Default.Black);
			// Execute Interface BeforeRun Command
				Interface.Kernel.BeforeRun();
        }

		protected override void Run() {
			try {
				Screen.Canvas.Display();
				Interface.Kernel.Run();
			} catch (Exception e) {
				mDebugger.Send("Exception occurred: " + e.Message);
				Sys.Power.Shutdown();
            }
        }
    }
}