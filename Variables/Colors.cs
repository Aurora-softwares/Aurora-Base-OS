using Sys = Cosmos.System;

namespace Variables {
	public class Colors {
		public static ColorDepth Depth = ColorDepth.ColorDepth32;

		public static Color Primary = Color.FromArgb(255, 251, 222, 130);

		public static Color Background = Color.FromArgb(255, 051, 077, 092);
		public static Color Foreground = Color.FromArgb(255, 243, 156, 015);
		public static Color UserInput = Color.FromArgb(255, 138, 193, 200);

		public static Color Warn = Color.FromArgb(255, 255, 154, 102);
		public static Color Error = Color.FromArgb(255, 205, 51, 1);
		public static Color Info = Color.FromArgb(255, 31, 99, 180);
		public static Color Success = Color.FromArgb(255, 153, 204, 51);
	}
}