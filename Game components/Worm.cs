using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleSimpleWorm.Game_components
{
    enum Direction
    {
        Up, Right, Down, Left
    }

    class WormElement : Element
    {
        public bool Food { get; protected set; }

        public WormElement(byte x, byte y, bool food)
        {
            X = x;
            Y = y;
            Food = food;
        }
    }

    class Worm
    {
        private List<WormElement> Elements;

        public Worm(byte length, byte headX, byte headY)
        {
            if (length >= Program.Conf.FieldWidth ||
                headX-length < 0 ||
                headY >= Program.Conf.FieldHeight)
                    throw new ApplicationException("Error: worm does not fit in the field.");
            Elements = new List<WormElement>();
            for(byte i = 0; i<length; i++)
            {
                WormElement elem = new WormElement((byte)(headX - i), headY, false);
                Elements.Add(elem);
            }
            HeadDirection = Direction.Right;
        }
        
        public WormElement this[int index]
        {
            get { return Elements[index]; }
        }

        public int Length
        {
            get { return Elements.Count; }
        }

        public Direction HeadDirection { get; set; }
    }
}
