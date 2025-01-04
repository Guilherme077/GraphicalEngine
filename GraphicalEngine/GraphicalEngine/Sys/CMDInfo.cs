using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalEngine.Sys
{
    internal static class CMDInfo
    {

        //Graphics and video Control variables
        static int frameInSecond = 0;
        static int totalFrames = 0;
        static DateTime time = DateTime.Now;
        static DateTime Now = DateTime.Now;

        public static void Load()
        {
            totalFrames++;
            frameInSecond++;

            Now = DateTime.Now;
            if (Now >= time.AddSeconds(1))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(" GRAPHICAL ENGINE");
                Console.WriteLine(" FPS: " + frameInSecond);
                Console.WriteLine(" Total Frames: " + totalFrames);
                Console.WriteLine(" CONTROLS:");
                Console.WriteLine();
                Console.WriteLine(" Cube:");
                Console.WriteLine(" W A S D  -> Rotation");
                Console.WriteLine("  Arrows  -> Movement");
                Console.WriteLine("       Z  -> Default Rotation");
                Console.WriteLine("     R T  -> Width (+ -)");
                Console.WriteLine("     F G  -> Height (+ -)");
                Console.WriteLine("     V B  -> Length (+ -)");
                Console.WriteLine();
                Console.WriteLine(" Application:");
                Console.WriteLine("       X  -> Change Max FPS (30/60)");
                Console.WriteLine("     ESC  -> Exit");

                frameInSecond = 0;
                time = DateTime.Now;
            }
        }
    }
}
