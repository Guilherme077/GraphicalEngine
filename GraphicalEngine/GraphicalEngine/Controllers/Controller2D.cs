using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GraphicalEngine.Figures.D2;
using SDL2;

namespace GraphicalEngine.Controllers
{
    internal static class Controller2D
    {

        private static bool loaded;
        public static nint defautRender;
        private static RectangleFig rect = new RectangleFig();

        public static void LoadDefautAnimation()
        {
            if(!loaded)
            {
                rect = new RectangleFig(defautRender, 10, 10, 100, 50, 100, 0, 100, 255, false);
                loaded = true;
            }

            RectController.GoArroundScreen(rect);
            
        }

    }
}
