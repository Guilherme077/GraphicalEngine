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
        const int SDL_NUM_SCANCODES = 512;
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

            //Keyboard Control
            IntPtr keyStatePtr = SDL.SDL_GetKeyboardState(out _);
            byte[] keyState = new byte[SDL_NUM_SCANCODES];
            Marshal.Copy(keyStatePtr, keyState, 0, keyState.Length);

            //Read of Keyboard keys
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_UP] != 0)
            {
                cubeFig.PosY--;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_DOWN] != 0)
            {
                cubeFig.PosY++;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_LEFT] != 0)
            {
                cubeFig.PosX--;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_RIGHT] != 0)
            {
                cubeFig.PosX++;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_W] != 0)
            {
                cubeFig.RotX--;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_A] != 0)
            {
                cubeFig.RotY++;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_S] != 0)
            {
                cubeFig.RotX++;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_D] != 0)
            {
                cubeFig.RotY--;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_Z] != 0)
            {
                cubeFig.RotY = 0;
                cubeFig.RotX = 0;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_X] != 0)
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


            cubeFig.Draw(); //Draw the cube in the new frame

            SDL.SDL_RenderPresent(renderer); //Load the frame
            SDL.SDL_Delay(delay_frame); //delay to try keep 60 FPS
        }

        

        SDL.SDL_DestroyRenderer(renderer);
        SDL.SDL_DestroyWindow(Screen.window);
        SDL.SDL_Quit();
    }
}