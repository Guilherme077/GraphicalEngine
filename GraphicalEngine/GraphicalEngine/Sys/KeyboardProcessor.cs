using GraphicalEngine.Figures.D3;
using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalEngine.Sys
{
    static class KeyboardProcessor
    {
        const int SDL_NUM_SCANCODES = 512; //Number of scancodes
        public static Dictionary<string, bool> KeysState = new Dictionary<string, bool>();
        private static void SetKeysFalse()
        {
            KeysState.Clear(); //Clear the dictionary

            //Add letters
            for (char c = 'A'; c <= 'Z'; c++)
            {
                KeysState.Add(c.ToString(), false);
            }

            //Add special keys 
            KeysState.Add("ESC", false);
            KeysState.Add("ENTER", false);
            KeysState.Add("UP", false);
            KeysState.Add("DOWN", false);
            KeysState.Add("RIGHT", false);
            KeysState.Add("LEFT", false);

        }

        public static void UpdateState()
        {
            SetKeysFalse(); //Set all keys to false
            IntPtr keyStatePtr = SDL.SDL_GetKeyboardState(out _);
            byte[] keyState = new byte[SDL_NUM_SCANCODES];
            Marshal.Copy(keyStatePtr, keyState, 0, keyState.Length);

            //Read all alphabet keys
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (keyState[(int)(SDL.SDL_Scancode)((int)SDL.SDL_Scancode.SDL_SCANCODE_A + (c - 'A'))] != 0)
                {
                    KeysState[c.ToString()] = true;
                }
            }

            //Read special keys
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_ESCAPE] != 0)
            {
                KeysState["ESC"] = true;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] != 0)
            {
                KeysState["ENTER"] = true;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_UP] != 0)
            {
                KeysState["UP"] = true;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_DOWN] != 0)
            {
                KeysState["DOWN"] = true;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_RIGHT] != 0)
            {
                KeysState["RIGHT"] = true;
            }
            if (keyState[(int)SDL.SDL_Scancode.SDL_SCANCODE_LEFT] != 0)
            {
                KeysState["LEFT"] = true;
            }

        }

    }
}
