using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ConsoleSimpleWorm
{
    class Configs
    {
        public readonly char _WORM_SYMBOL, _FOOD_SYMBOL;
        public readonly int _TIME_STAMP;

        public Configs()
        {
            string str;
            string[] ln;
            StreamReader sr = new StreamReader("config");
            Dictionary<String, String> dict = new Dictionary<String, String>();
            while (!sr.EndOfStream)
            {
                str = sr.ReadLine();
                if (str.Length <= 0)
                    continue;
                ln = str.Split('=');
                if (ln.Length != 2)
                    throw new ApplicationException("Error: incorrect file.");
                dict.Add(ln[0], ln[1]);
            }
            try
            {
                _WORM_SYMBOL = dict["WormSymbol"][0];
                _FOOD_SYMBOL = dict["FoodSymbol"][0];
                _TIME_STAMP = Convert.ToInt32(dict["TimeStamp"]);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error: incorrect file.");
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Configs conf = new Configs();
            Console.WriteLine("Configs: {0} {1} {2}", 
                conf._WORM_SYMBOL, 
                conf._FOOD_SYMBOL, 
                conf._TIME_STAMP);
        }
    }
}
