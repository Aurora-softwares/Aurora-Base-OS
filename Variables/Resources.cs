using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;

namespace Variables {
	public class Resources {
        //.bmp
        [ManifestResourceStream(ResourceName = "Variables.Resources.Wallpapers.Wallpaper-1920x1080.bmp")]
        public static byte[] Wallpaper_Byte;
        public static Bitmap Wallpaper = new(Wallpaper_Byte);
    }
}