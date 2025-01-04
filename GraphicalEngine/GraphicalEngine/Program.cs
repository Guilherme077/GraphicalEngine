using GraphicalEngine.Controllers;
using GraphicalEngine.Figures.D3;
using GraphicalEngine.Sys;
using SDL2;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static SDL2.SDL;

class Program
{
    static void Main(string[] args)
    {

        uint delay_frame = 16;
        //Init Process
        Screen.Init();

        //Render init
        IntPtr renderer = SDL.SDL_CreateRenderer(Screen.window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

        //Config Controllers
        Controller2D.defautRender = renderer;

        CubeFig cubeFig = new CubeFig(renderer, 300, 400, 300, 100, 400, 100, 255, 0, 0, 255, 200, 0);

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

            KeyboardProcessor.UpdateState(); //Update the status of all the keys in KeyboardProcessor

            //All the functions to the keys
            if (KeyboardProcessor.KeysState["UP"])
            {
                cubeFig.PosY--;
            }
            
            if (KeyboardProcessor.KeysState["DOWN"])
            {
                cubeFig.PosY++;
            }
            if (KeyboardProcessor.KeysState["LEFT"])
            {
                cubeFig.PosX--;
            }
            if (KeyboardProcessor.KeysState["RIGHT"])
            {
                cubeFig.PosX++;
            }
            if (KeyboardProcessor.KeysState["W"])
            {
                cubeFig.RotX--;
            }
            if (KeyboardProcessor.KeysState["A"])
            {
                cubeFig.RotY++;
            }
            if (KeyboardProcessor.KeysState["S"])
            {
                cubeFig.RotX++;
            }
            if (KeyboardProcessor.KeysState["D"])
            {
                cubeFig.RotY--;
            }
            if (KeyboardProcessor.KeysState["R"])
            {
                cubeFig.Width--;
            }
            if (KeyboardProcessor.KeysState["T"])
            {
                cubeFig.Width++;
            }
            if (KeyboardProcessor.KeysState["F"])
            {
                cubeFig.Height--;
            }
            if (KeyboardProcessor.KeysState["G"])
            {
                cubeFig.Height++;
            }
            if (KeyboardProcessor.KeysState["V"])
            {
                cubeFig.Length--;
            }
            if (KeyboardProcessor.KeysState["B"])
            {
                cubeFig.Length++;
            }
            if (KeyboardProcessor.KeysState["Z"])
            {
                cubeFig.RotY = 0;
                cubeFig.RotX = 0;
            }
            if (KeyboardProcessor.KeysState["X"])
            {
                if(delay_frame == 16)
                {
                    delay_frame = 32;
                }
                else
                {
                    delay_frame = 16;
                }
                
            }
            if (KeyboardProcessor.KeysState["ESC"])
            {
                quit = true;
            }


            cubeFig.Draw(); //Draw the cube in the new frame

            SDL.SDL_RenderPresent(renderer); //Load the frame
            SDL.SDL_Delay(delay_frame); //delay to try keep 60 FPS
        }

        

        SDL.SDL_DestroyRenderer(renderer);
        SDL.SDL_DestroyWindow(Screen.window);
        SDL.SDL_Quit();
    }
}