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
        public static void CreateConfigFile(int fieldWidth, int fieldHeight, char wormSymbol, char foodSymbol, int timeStamp)
        {
            XDocument doc = new XDocument(
                new XElement("config",
                    new XElement("field",
                        new XAttribute("width", fieldWidth),
                        new XAttribute("height", fieldHeight)),
                    new XElement("symbols",
                        new XElement("worm", wormSymbol),
                        new XElement("food", foodSymbol)),
                    new XElement("timestamp", timeStamp)));
            doc.Save("config.xml");
        }

        public static void CreateConfigFileDefault()
        {
            CreateConfigFile(100, 30, '0', '*', 1000);
        }
    }
    class Config
    {
        public readonly char _WORM_SYMBOL, _FOOD_SYMBOL;
        public readonly int _FIELD_WIDTH, _FIELD_HEIGHT, _TIME_STAMP;

        public Config()
        {
            XElement conf = XDocument.Load("config.xml").Root;
            XElement field = conf.Element("field");
            XElement syms = conf.Element("symbols");
            _FIELD_WIDTH = Convert.ToInt32(field.Attribute("width").Value);
            _FIELD_HEIGHT = Convert.ToInt32(field.Attribute("height").Value);
            _WORM_SYMBOL = syms.Element("worm").Value[0];
            _FOOD_SYMBOL = syms.Element("food").Value[0];
            _TIME_STAMP = Convert.ToInt32(conf.Element("timestamp").Value);
        }
    }
}
