using Sys = Cosmos.System;

namespace Variables {
	public class Keyboard {
		public static ConsoleKey[] Letters = {
			ConsoleKey.A, ConsoleKey.B, ConsoleKey.C, ConsoleKey.D, ConsoleKey.E, ConsoleKey.F,
			ConsoleKey.G, ConsoleKey.H, ConsoleKey.I, ConsoleKey.J, ConsoleKey.K, ConsoleKey.L,
			ConsoleKey.M, ConsoleKey.N, ConsoleKey.O, ConsoleKey.P, ConsoleKey.Q, ConsoleKey.R,
			ConsoleKey.S, ConsoleKey.T, ConsoleKey.U, ConsoleKey.V, ConsoleKey.W, ConsoleKey.X,
			ConsoleKey.Y, ConsoleKey.X
		};
		public static ConsoleKey[] Numbers = {
			ConsoleKey.D1,
			ConsoleKey.D2,
			ConsoleKey.D3,
			ConsoleKey.D4,
			ConsoleKey.D5,
			ConsoleKey.D6,
			ConsoleKey.D7,
			ConsoleKey.D8,
			ConsoleKey.D9,
			ConsoleKey.D0,
			ConsoleKey.NumPad1,
			ConsoleKey.NumPad2,
			ConsoleKey.NumPad3,
			ConsoleKey.NumPad4,
			ConsoleKey.NumPad5,
			ConsoleKey.NumPad6,
			ConsoleKey.NumPad7,
			ConsoleKey.NumPad8,
			ConsoleKey.NumPad9,
			ConsoleKey.NumPad0
		};
		public static ConsoleKey[] Symbols = {
			ConsoleKey.Add,
			ConsoleKey.Subtract,
			ConsoleKey.Decimal,
			ConsoleKey.Divide,
			ConsoleKey.Multiply,
			ConsoleKey.Spacebar,
			ConsoleKey.OemComma,
			ConsoleKey.OemMinus,
			ConsoleKey.OemPeriod,
			ConsoleKey.OemPlus

		};
		public static ConsoleKey[] Modifiers = {
			ConsoleKey.Escape,
			ConsoleKey.Delete,
			ConsoleKey.Tab,
			ConsoleKey.PageDown,
			ConsoleKey.PageUp,
			ConsoleKey.PrintScreen,
			ConsoleKey.Home,
			ConsoleKey.BrowserHome,
			ConsoleKey.End,
			ConsoleKey.UpArrow,
			ConsoleKey.DownArrow,
			ConsoleKey.RightArrow,
			ConsoleKey.LeftArrow,
			ConsoleKey.LeftWindows,
			ConsoleKey.RightWindows

		};
	}
}