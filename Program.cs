using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSimpleWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            Config conf = null;
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
            Console.WriteLine("Configs: {0} {1} {2}", 
                conf._WORM_SYMBOL, 
                conf._FOOD_SYMBOL, 
                conf._TIME_STAMP);
        }
    }
}
