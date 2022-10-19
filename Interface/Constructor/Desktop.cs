using Sys = Cosmos.System;

namespace Interface.Constructor {
	public class Desktop {
		public static void Init() {
			// Here you can create the Desktop environment
			// This includes the Wallpaper, Dock, Taskbar and icons!

			Wallpaper.Init();
            Dock.Init();
            Taskbar.Init();
		}
	}
}