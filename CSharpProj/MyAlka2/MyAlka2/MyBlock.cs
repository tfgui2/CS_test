using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlka2
{
    class MyBlock : ImageObject
    {
        public MyBlock()
        {
            this.Load("block.png");
        }

        bool hide = false;

        public override void Draw(System.Drawing.Graphics g)
        {
            if (hide) return;
            base.Draw(g);
        }

        public void Check(MyBall ball)
        {
            if (hide) return;

            if (this.CheckInter(ball))
            {
                hide = true;
                ball.velo.X = -ball.velo.X;
                ball.velo.Y = -ball.velo.Y;
            }
        }
    }
}
