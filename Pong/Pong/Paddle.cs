using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Pong
{
    class Paddle
    {
       
        public UIElement UiElement{get;set;}
        public Point Position { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }
        //public Position Pos { get; set; }



    }
}
