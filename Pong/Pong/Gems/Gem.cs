using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Pong.Gems
{
    abstract class Gem : Element
    {
        private int _xSpeed;
        private int _ySpeed;
        private SolidColorBrush color;
        private bool influenceOn = false;


        public bool InfluenceOn
        {
            get
            {
                return influenceOn;
            }
            set
            {
                influenceOn = value;
            }
        }

        public SolidColorBrush Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

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

        








        public abstract void Changer(Element paddle);
    }
}
