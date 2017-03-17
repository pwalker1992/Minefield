using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Mines
    {
        public int yPosition = 0;
        public int xPosition = 0;

        public void SetPosY(int PosY)
        {
            this.yPosition = PosY;
        }

        public int GetPosY()
        {
            return this.yPosition;
        }

        public void SetPosX(int PosX)
        {
            this.xPosition = PosX;
        }

        public int GetPosX()
        {
            return this.xPosition;
        }
    }
}
