using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalEngine.Figures.D3
{
    class CubeFig
    {
        
        public nint Render;
        public float Distance; // Z
        public int PosX, PosY; // X, Y (Position)
        public int Width, Height, Length; // Measures
        public byte R, G, B, A; //Color
        public float RotX, RotY; // Rotation  (0 to 360)

        public float[,] Vertices { get; private set; }


        public CubeFig(nint render, float distance, int posX, int posY, int width, int height, int length, byte r, byte g, byte b, byte a, float rotX, float rotY)
        {
            Render = render;
            Distance = distance;
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            Length = length;
            R = r;
            G = g;
            B = b;
            A = a;
            RotX = rotX;
            RotY = rotY;

            Initialize();
        }

        public CubeFig()
        {
            Initialize();
        }


        private void Initialize()
        {
            int halfWidth = Width / 2;
            int halfHeight = Height / 2;
            int halfLength = Length / 2;
            Vertices = new float[,]
            {
                { -halfWidth, -halfHeight, -halfLength },
                {  halfWidth, -halfHeight, -halfLength },
                {  halfWidth,  halfHeight, -halfLength },
                { -halfWidth,  halfHeight, -halfLength },
                { -halfWidth, -halfHeight,  halfLength },
                {  halfWidth, -halfHeight,  halfLength },
                {  halfWidth,  halfHeight,  halfLength },
                { -halfWidth,  halfHeight,  halfLength }
            };
        }

        // Arestas do cubo (pares de índices dos vértices)
        int[,] edges = {
            { 0, 1 }, { 1, 2 }, { 2, 3 }, { 3, 0 }, // Base inferior
            { 4, 5 }, { 5, 6 }, { 6, 7 }, { 7, 4 }, // Base superior
            { 0, 4 }, { 1, 5 }, { 2, 6 }, { 3, 7 }  // Conexões entre bases
        };

        // Ângulos de rotação
        float angleX = 0, angleY = 0;

        // Função para projetar os pontos 3D no plano 2D
        public (int x, int y) project(float x, float y, float z)
        {
            float scale = Distance / (z + Distance); // Simulação de perspectiva
            int screenX = (int)(x * scale) + PosX; // Ajuste para centralizar na tela
            int screenY = (int)(y * scale) + PosY;
            return (screenX, screenY);
        }



        // Função para aplicar rotação nos vértices
        float[] Rotate(float x, float y, float z, float angleX, float angleY)
        {
            // Rotação em torno do eixo X
            float sinX = (float)Math.Sin(angleX);
            float cosX = (float)Math.Cos(angleX);
            float y1 = cosX * y - sinX * z;
            float z1 = sinX * y + cosX * z;

            // Rotação em torno do eixo Y
            float sinY = (float)Math.Sin(angleY);
            float cosY = (float)Math.Cos(angleY);
            float x1 = cosY * x + sinY * z1;
            float z2 = -sinY * x + cosY * z1;

            return new float[] { x1, y1, z2 };
        }
        
        float ConvertAngle(float angle)
        {
            return angle / 360;
        }

        public void Draw()
        {
            // Desenhar cubo
            SDL.SDL_SetRenderDrawColor(Render, R, G, B, A);
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int v1 = edges[i, 0];
                int v2 = edges[i, 1];
                
                // Aplicar rotação nos vértices
                var rotatedV1 = Rotate(Vertices[v1, 0], Vertices[v1, 1], Vertices[v1, 2], ConvertAngle(RotX), ConvertAngle(RotY));
                var rotatedV2 = Rotate(Vertices[v2, 0], Vertices[v2, 1], Vertices[v2, 2], ConvertAngle(RotX), ConvertAngle(RotY));

                // Projeção 2D
                var (x1, y1) = project(rotatedV1[0], rotatedV1[1], rotatedV1[2]);
                var (x2, y2) = project(rotatedV2[0], rotatedV2[1], rotatedV2[2]);

                // Desenhar linha
                SDL.SDL_RenderDrawLine(Render, x1, y1, x2, y2);
            }
        }
    }
}
