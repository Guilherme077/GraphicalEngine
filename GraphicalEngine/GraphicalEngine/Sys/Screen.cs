using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalEngine.Sys
{
    internal static class Screen
    {
        public static IntPtr window;

        public static void Init()
        {
            //SDL Init
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine("SDL could not initialize! SDL_Error: " + SDL.SDL_GetError());
                return;
            }

            //Window init
            window = SDL.SDL_CreateWindow("GraphicalEngine BETA",
                SDL.SDL_WINDOWPOS_UNDEFINED,
                SDL.SDL_WINDOWPOS_UNDEFINED,
                1000, 700,  //Resolution
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE); //Window Mode

            if (window == IntPtr.Zero)
            {
                Console.WriteLine("Window could not be created! SDL_Error: " + SDL.SDL_GetError());
                return;
            }
        }
    }
}
