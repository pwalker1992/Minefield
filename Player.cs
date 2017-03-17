using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player : Lives
    {
        public int yPosition = 0;//Initial starting positions of the Player
        public int xPosition = 2;
        public int moves = 0;

        //To create the illusion of a chessboard type grid, the Player may not move any further left than...
        //...x=0 and no further right than x=4, as well as no further down than y=0.
        public void SetPosY(int PosY)
        {
            if (PosY < 0)
            {
                Console.WriteLine("You cant move further down");
            }
            else
            {
                this.yPosition = PosY;
            }
        }

        public int GetPosY()
        {
            return this.yPosition;
        }

        public void SetPosX(int PosX)
        {
            if (PosX < 0)
            {
                Console.WriteLine("You cant move further left");
            }
            else if (PosX > 4)
            {
                Console.WriteLine("You cant move further right");
            }
            else
            {
                this.xPosition = PosX;
            }
        }

        public int GetPosX()
        {
            return this.xPosition;
        }

        public void SetMoves(int moves)
        {
            this.moves = moves;
        }

        public int GetMoves()
        {
            return this.moves;
        }
    }
}
