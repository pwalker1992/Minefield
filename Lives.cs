using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Lives
    {
        public int lives = 3;   //Starting lives

        public void SetLives(int lives)
        {
            this.lives = lives;
        }

        public int GetLives()
        {
            return this.lives;
        }
    }
}
