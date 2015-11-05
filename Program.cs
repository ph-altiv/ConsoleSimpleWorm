using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSimpleWorm
{
    class Program
    {
        static public Config conf;

        static void AutoSetting()
        {
            conf = null;
            do
            {
                try
                {
                    conf = new Config();
                }
                catch (Exception)
                {
                    ConfigFile.CreateConfigFileDefault();
                }
            } while (conf == null);
            Console.SetWindowSize(conf._FIELD_WIDTH, conf._FIELD_HEIGHT);
            Console.SetBufferSize(conf._FIELD_WIDTH, conf._FIELD_HEIGHT);
        }

        static void Main(string[] args)
        {
            AutoSetting();
            Console.WriteLine("Configs: {0} {1} {2}", 
                conf._WORM_SYMBOL, 
                conf._FOOD_SYMBOL, 
                conf._TIME_STAMP);
        }
    }
}
