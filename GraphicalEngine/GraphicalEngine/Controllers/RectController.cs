using GraphicalEngine.Figures.D2;
using GraphicalEngine.Sys;
using SDL2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraphicalEngine.Controllers
{
    static class RectController
    {

        private static int direction;
        private static int wScreen = 0;
        private static int hScreen = 0;

        public static void GoArroundScreen(RectangleFig rect)
        {

            SDL.SDL_GetWindowSize(Screen.window, out wScreen, out hScreen);

            switch (direction)
            {
                case 0:
                    rect.X++;
                    break;
                case 1:

                    rect.Y++;
                    break;
                case 2:

                    rect.X--;
                    break;
                case 3:

                    rect.Y--;
                    break;
            }


            if (direction == 0 && rect.X >= wScreen - rect.Width - 50)
            {
                direction = 1;
            }
            if (direction == 1 && rect.Y >= hScreen - rect.Height - 50)
            {
                direction = 2;
            }
            if (direction == 2 && rect.X <= 50)
            {
                direction = 3;
            }
            if (direction == 3 && rect.Y <= 50)
            {
                direction = 0;
            }

            rect.Draw();

        }


    }
}
