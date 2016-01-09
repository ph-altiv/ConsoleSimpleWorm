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
            Console.SetWindowSize(Conf.FieldWidth, Conf.FieldHeight);
            Console.SetBufferSize(Conf.FieldWidth, Conf.FieldHeight);
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

        static void GameStart()
        {
            AutoSetting();
            Console.WriteLine("Configs: {0} {1} {2}",
                Conf.WormSymbol,
                Conf.FoodSymbol,
                Conf.TimeStamp);
            Worm worm = new Worm(WormLen, (byte)((Conf.FieldWidth - WormLen) / 2), (byte)(Conf.FieldHeight / 2));
            PrintWorm(worm);
            while (true)
            {
                worm.Go(Direction.Right);
                PrintAction(worm[0], worm.DeletedElement);
                Thread.Sleep(200);
            }
        }

        static void Main(string[] args)
        {
            GameStart();
        }
    }
}
