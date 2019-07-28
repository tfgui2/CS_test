using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalag
{
    class MyEnemy : ImageObject
    {
        public MyEnemy()
        {
            this.Load("myenemy.png");
        }
        int velo = 2;
        public void Move()
        {
            if (this.pos.X > 400)
            {
                velo = -2;
            }
            if (this.pos.X < 10)
            {
                velo = 2;
            }
            this.pos.X += velo;

        }
    }
}
