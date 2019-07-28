using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalag
{
    class MyShip : ImageObject
    {
        public MyShip()
        {
            this.Load("myship.png");
        }

        public bool leftGo = false;
        public bool rightGo = false;

        public void Move()
        {
            if (leftGo)
            {
                this.pos.X -= 2;
            }
            else if (rightGo)
            {
                this.pos.X += 2;
            }
        }
    }
}
