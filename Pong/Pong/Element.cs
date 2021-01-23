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
    class Element
    {
        private int _xSpeed;
        private int _ySpeed;
        public Rectangle UiElement{get;set;}
        public Point Position { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int XSpeed
        {
            get
            {
                return _xSpeed;
            }
            set
            {
                _xSpeed = value;
            }
        }

        public int YSpeed
        {
            get
            {
                return _ySpeed;
            }
            set
            {
                _ySpeed = value;
            }
        }
    }
}
