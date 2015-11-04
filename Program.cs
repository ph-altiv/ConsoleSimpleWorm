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
            Config conf = new Config();
            Console.WriteLine("Configs: {0} {1} {2}", 
                conf._WORM_SYMBOL, 
                conf._FOOD_SYMBOL, 
                conf._TIME_STAMP);
            ConfigFile.CreateConfigFileDefault();
        }
    }
}
