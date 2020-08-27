using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Gems
{
    class SlowerGem : Gem
    {
        public override void Changer(Element ball)
        {
            ball.XSpeed++;
            ball.YSpeed++;
        }
    }
}
