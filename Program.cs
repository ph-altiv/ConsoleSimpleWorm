using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleSimpleWorm.Game_components;

namespace ConsoleSimpleWorm
{
    class Program
    {
        static public Config Conf;
        public const byte WormLen = 3;

        static void AutoSetting()
        {
            Conf = null;
            do
            {
                try
                {
                    Conf = new Config();
                }
                catch (Exception)
                {
                    ConfigFile.CreateConfigFileDefault();
                }
            } while (Conf == null);
            
            Console.SetWindowSize(Conf.FieldWidth, Conf.FieldHeight + 2);
            Console.SetBufferSize(Conf.FieldWidth, Conf.FieldHeight + 2);
            Console.SetCursorPosition(0, Conf.FieldHeight+1);
            for (int i = 0; i < Conf.FieldWidth; i++) Console.Write("█");
        }

        static void PrintWormText(Worm worm)
        {
            for (int i = 0; i < worm.Length; i++)
            {
                Console.WriteLine("\t{0}: {1} x {2}", i, worm[i].X, worm[i].Y);
            }
            Console.WriteLine();
        }

        static void PrintWorm(Worm worm)
        {
            for (int i = 0; i < worm.Length; i++)
            {
                Console.SetCursorPosition(worm[i].X, worm[i].Y);
                Console.WriteLine(Conf.WormSymbol);
            }
        }

        static void PrintAction(WormElement newhead, WormElement oldend)
        {
            Console.SetCursorPosition(newhead.X, newhead.Y);
            Console.WriteLine(Conf.WormSymbol);
            if (oldend.Food)
                return;
            Console.SetCursorPosition(oldend.X, oldend.Y);
            Console.WriteLine(" ");
        }

        static void PrintFood(Element pos)
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(Conf.FoodSymbol);
        }

        static void GameStart()
        {
            AutoSetting();
            Direction dir = Direction.Right;
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            Worm worm = new Worm(WormLen, (byte)((Conf.FieldWidth - WormLen) / 2), (byte)(Conf.FieldHeight / 2));
            Food food = new Food(Conf.FieldHeight, Conf.FieldWidth);
            food.GenerateNewPos(worm);
            PrintWorm(worm);
            PrintFood(food.Element);
            while (true)
            {
                if (Console.KeyAvailable == true)
                {
                    cki = Console.ReadKey(true);
                    KeyToDir(cki.Key, ref dir);
                }
                worm.Go(dir);
                PrintAction(worm[0], worm.DeletedElement);
                Thread.Sleep(200);
            }
        }

        static void KeyToDir(ConsoleKey key, ref Direction dir)
        {
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    if(dir != Direction.Down)
                        dir = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    if (dir != Direction.Up)
                        dir = Direction.Down;
                    break;
                case ConsoleKey.RightArrow:
                    if (dir != Direction.Left)
                        dir = Direction.Right;
                    break;
                case ConsoleKey.LeftArrow:
                    if (dir != Direction.Right)
                        dir = Direction.Left;
                    break;
            }
        }

        static void Main(string[] args)
        {
            GameStart();
        }
    }
}
