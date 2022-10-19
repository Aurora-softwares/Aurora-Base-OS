using System;
using Sys = Cosmos.System;

namespace Interface {
    public class Kernel {
        public static void BeforeRun() {
            // Any functions you would like to have executed before the system is running
        }
        public static void Run() {
            Constructor.Desktop.Init();
        }
    }
}