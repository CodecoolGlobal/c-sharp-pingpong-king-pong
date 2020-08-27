using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Gems
{
    class ExtenderGem : Gem
    {
        int extenderValue = 5;
        public override void Changer(Element paddle)
        {
            paddle.Width = paddle.Width +extenderValue;
        }
    }
}
