using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalag
{
    class MyBullet : ImageObject
    {
        public MyBullet()
        {
            this.Load("mybullet.png");
        }

        public void Move()
        {
            this.pos.Y -= 2;
        }
    }
}
