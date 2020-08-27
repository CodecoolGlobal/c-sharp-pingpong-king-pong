using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Gems
{
    class ShortenerGem : Gem
    {
        int shortenerValue = 4;
        public override void Changer(Element paddle)
        {
            paddle.Width = paddle.Width - shortenerValue ;
        }
    }
}
