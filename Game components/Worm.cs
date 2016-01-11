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
            DeletedElement = null;
        }
        
        public WormElement this[int index]
        {
            get { return Elements[index]; }
        }

        public WormElement DeletedElement
        { get; private set; }

        public int Length
        {
            get { return Elements.Count; }
        }

        public Direction HeadDirection { get; set; }

        public bool Go(Direction headdirection, ref Food food) // 'true' if alive
        {
            if (Math.Abs(headdirection - HeadDirection) == 2)
                return true;
            HeadDirection = headdirection;
            WormElement elem = Elements[0];
            int x = elem.X, 
                y = elem.Y;
            if ((int)headdirection % 2 == 0)
            {
                y += (int)headdirection - 1;
                if (y < 0)
                    y = Program.Conf.FieldHeight - 1;
                else if (y >= Program.Conf.FieldHeight)
                    y = 0;
            }
            else
            {
                x -= (int)headdirection - 2;
                if (x < 0)
                    x = Program.Conf.FieldWidth - 1;
                else if (x >= Program.Conf.FieldWidth)
                    x = 0;
            }
            foreach (WormElement e in Elements)
            {
                if ((e.X == x) && (e.Y == y))
                    return false;
            }
            bool bfood = (x == food.Element.X) && (y == food.Element.Y);
            Elements.Insert(0, new WormElement((byte)x, (byte)y, bfood));
            DeletedElement = Elements[Elements.Count - 1];
            Elements.Remove(DeletedElement);
            if (elem.Food)
            {
                Elements.Add(new WormElement(DeletedElement.X, DeletedElement.Y, false));
                DeletedElement = null;
            }
            return true;
        }
    }
}
