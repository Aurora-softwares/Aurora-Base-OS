using Variables;

namespace Interface.Constructor {
	public class Wallpaper {
		public static void Init() {
            // Here you can create the Wallpape Layer
            // This is the image you have at the background of the desktop.

            Screen.Canvas.DrawImage(Resources.Wallpaper, 0, 0);
        }
	}
}