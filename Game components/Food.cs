using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSimpleWorm.Game_components
{
    class Food
    {
        private Element pos;

        private readonly int maxX, maxY, fieldSize;

        private Random rand;

        public Food(int FieldHeight, int FieldWidth)
        {
            maxX = FieldWidth;
            maxY = FieldHeight;
            fieldSize = maxX * maxY;
            rand = new Random();
            pos = new Element();
        }

        public void GenerateNewPos(ref Worm worm)
        {
            pos.X = 0;
            pos.Y = 0;
            bool b = false;
            for(int i=0; i< rand.Next(fieldSize - worm.Length); i = (b) ? i : i+1)
            {
                pos.X++;
                if(pos.X >= maxX)
                {
                    pos.X = 0;
                    pos.Y++;
                }
                int j = 0;
                b = false;
                while(!b && j < worm.Length)
                {
                    b = (pos.X == worm[j].X) && (pos.Y == worm[j].Y);
                    j++;
                }
            }
        }

        public Element Element
        {
            get { return pos; }
        }
    }
}
