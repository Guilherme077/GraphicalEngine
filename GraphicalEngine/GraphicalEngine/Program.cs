using GraphicalEngine.Controllers;
using GraphicalEngine.Sys;
using SDL2;
using System;
using static SDL2.SDL;

class Program
{
    static void Main(string[] args)
    {
        //Init Process
        Screen.Init();

        //Render init
        IntPtr renderer = SDL.SDL_CreateRenderer(Screen.window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

        //Config Controllers
        Controller2D.defautRender = renderer;
        

        //LOOP 
        bool quit = false;
        SDL.SDL_Event e;
        while (!quit)
        {
            CMDInfo.Load();

            //Clean the previous screen
            SDL.SDL_SetRenderDrawColor(renderer, 0, 255, 0, 255);
            SDL.SDL_RenderClear(renderer);

            //Call the "exit" if necessary
            while (SDL.SDL_PollEvent(out e) != 0)
            {
                if (e.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    quit = true;
                }
            }

            Controller2D.LoadDefautAnimation();
           
            SDL.SDL_RenderPresent(renderer);
            SDL.SDL_Delay(16); //60 FPS
        }

        

        SDL.SDL_DestroyRenderer(renderer);
        SDL.SDL_DestroyWindow(Screen.window);
        SDL.SDL_Quit();
    }
}