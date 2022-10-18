using System;
using Sys = Cosmos.System;
using Constructor;

namespace Interface {
    public class Kernel {
        public static void Run() {
            Desktop.init();
            Dock.init();
            Taskbar.init();
        }
    }
}