using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyAlka2
{
    class MyBall : ImageObject
    {
        public MyBall()
        {
            this.Load("ball.png");
        }

        public System.Drawing.Point velo = new System.Drawing.Point(0, 0);

        public void Move()
        {
            pos.Offset(velo);
        }

        public void Go()
        {
            velo.X = 2;
            velo.Y = -2;
        }
    }
}
