using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ConsoleSimpleWorm
{
    static class ConfigFile 
    {
        public static void CreateConfigFile(char wormSymbol, char foodSymbol, int timeStamp)
        {
            XDocument doc = new XDocument(
                new XElement("config",
                    new XElement("symbols",
                        new XElement("worm", wormSymbol),
                        new XElement("food", foodSymbol)),
                    new XElement("timestamp", timeStamp)));
            doc.Save("config.xml");
        }

        public static void CreateConfigFileDefault()
        {
            CreateConfigFile('0', '*', 1000);
        }
    }
    class Config
    {
        public readonly char _WORM_SYMBOL, _FOOD_SYMBOL;
        public readonly int _TIME_STAMP;

        public Config()
        {
            XElement conf = XDocument.Load("config.xml").Root;
            XElement syms = conf.Element("symbols");
            _WORM_SYMBOL = syms.Element("worm").Value[0];
            _FOOD_SYMBOL = syms.Element("food").Value[0];
            _TIME_STAMP = Convert.ToInt32(conf.Element("timestamp").Value);
        }
    }
}
