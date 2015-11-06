using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        static void Main(string[] args)
        {
            AutoSetting();
            Console.WriteLine("Configs: {0} {1} {2}", 
                Conf.WormSymbol, 
                Conf.FoodSymbol, 
                Conf.TimeStamp);
            Worm worm = new Worm(WormLen, (byte)((Conf.FieldWidth - WormLen) / 2), (byte)(Conf.FieldHeight / 2));
            PrintWormText(worm);
            worm.Go(Direction.Right);
            PrintWormText(worm);
            worm.Go(Direction.Left);
            PrintWormText(worm);
            worm.Go(Direction.Up);
            PrintWormText(worm);
            for (int i = 0; i < 16; i++)
                worm.Go(Direction.Up);
            PrintWormText(worm);
        }
    }
}
