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
            Console.SetWindowSize(Conf._FIELD_WIDTH, Conf._FIELD_HEIGHT);
            Console.SetBufferSize(Conf._FIELD_WIDTH, Conf._FIELD_HEIGHT);
        }

        static void Main(string[] args)
        {
            AutoSetting();
            Console.WriteLine("Configs: {0} {1} {2}", 
                Conf._WORM_SYMBOL, 
                Conf._FOOD_SYMBOL, 
                Conf._TIME_STAMP);
            Worm worm = new Worm(WormLen, (byte)((Conf._FIELD_WIDTH - WormLen) / 2), (byte)(Conf._FIELD_HEIGHT / 2));
            for(int i = 0; i<worm.Length; i++)
            {
                Console.WriteLine("\t{0}: {1} x {2}", i, worm[i].X, worm[i].Y); 
            }
        }
    }
}
