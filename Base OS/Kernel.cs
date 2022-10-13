using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;
using Point = Cosmos.System.Graphics.Point;

namespace Base_OS {
    public class Kernel : Sys.Kernel {
        public static Canvas Canvas;
        public static int ScreenX = 1920;
        public static int ScreenY = 1080;
        public static int ScreenPPI = 267;
        public static Color ScreenBG = Color.FromArgb(255, 051, 077, 092);
        public static Color ScreenFG = Color.FromArgb(255, 243, 156, 015);
        public static Color UserInput = Color.FromArgb(255, 138, 193, 200);
        public static int LineNo = 0;
        public static int LineHeight = 10;
        public static double ScaleFactor;
        public static PCScreenFont Font = PCScreenFont.Default;

        public static int CellW;
        public static int CellH;
        public static int Cols;
        public static int Rows;

        public static int cursorPosX;
        public static int cursorPosY;
        public static int cursorMinX;

        protected override void BeforeRun() {
            Canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(ScreenX, ScreenY, ColorDepth.ColorDepth32));
            Canvas.Clear(ScreenBG);
        }

        protected override void Run() {
            try {
                Canvas.DrawString("ABOS > ", Font, new Pen(ScreenFG), new Point(0, (LineNo * LineHeight)));
                //CalculateCells(ScreenX, ScreenY, ScreenPPI);
                Canvas.Display();
            } catch (Exception e) {
                mDebugger.Send("Exception occurred: " + e.Message);
                Sys.Power.Shutdown();
            }
        }

        private static void CalculateCells(int ResX, int ResY, int Ppi) {

        }
        private void GetCellPos(int CellX, int CellY) {

        }
    }
}