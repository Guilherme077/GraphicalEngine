using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SDL2;

namespace GraphicalEngine.Figures.D2
{
    class RectangleFig
    {
        private nint Render;
        public int X, Y, Width, Height; //Pos
        public byte R, G, B, A; //Color
        private bool filled; //Fill the rectangle



        public RectangleFig(nint render, int x, int y, int width, int height, byte r, byte g, byte b, byte a, bool filled)
        {
            Render = render;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            R = r;
            G = g;
            B = b;
            A = a;
            this.filled = filled;
        }

        public RectangleFig()
        {
        }

        public void Draw()
        {
            SDL.SDL_SetRenderDrawColor(Render, R, G, B, A);

            
            SDL.SDL_Rect rect = new SDL.SDL_Rect
            {
                x = X,
                y = Y,
                w = Width,
                h = Height
            };

            if(filled)
            {
                SDL.SDL_RenderFillRect(Render, ref rect);
            }
            else
            {
                SDL.SDL_RenderDrawRect(Render, ref rect);
            }
            /*
            //Another way to draw a rectangle
            for(int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    SDL.SDL_RenderDrawPoint(Render, i + X, j +Y);
                }
            }
            */

        }
    }
}
