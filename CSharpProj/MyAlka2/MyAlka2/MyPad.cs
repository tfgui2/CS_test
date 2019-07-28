using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlka2
{
    class MyPad : ImageObject
    {
        public MyPad()
        {
            this.Load("pad.png");
        }

        public int padsize = 100;

        public void Move()
        {
            if (leftGo)
            {
                this.MoveLeft();
            }
            else if (rightGo)
            {
                this.MoveRight();
            }
        }
        public void MoveLeft()
        {
            this.pos.X -= 5;
        }

        public void MoveRight()
        {
            this.pos.X += 5;
        }

        bool leftGo = false;
        bool rightGo = false;

        public void LeftGo()
        {
            leftGo = true;
        }
        public void LeftStop()
        {
            leftGo = false;
        }

        public void RightGo()
        {
            rightGo = true;
        }
        public void RightStop()
        {
            rightGo = false;
        }
    }
}
