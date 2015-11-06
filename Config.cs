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
        private readonly char wormsymbol, foodsymbol;
        private readonly int fieldwidth, fieldheight, timestamp;

        public Config()
        {
            XElement conf = XDocument.Load("config.xml").Root;
            XElement field = conf.Element("field");
            XElement syms = conf.Element("symbols");
            fieldwidth = Convert.ToInt32(field.Attribute("width").Value);
            fieldheight = Convert.ToInt32(field.Attribute("height").Value);
            wormsymbol = syms.Element("worm").Value[0];
            foodsymbol = syms.Element("food").Value[0];
            timestamp = Convert.ToInt32(conf.Element("timestamp").Value);
        }

        public char WormSymbol
        {
            get
            {
                return wormsymbol;
            }
        }

        public char FoodSymbol
        {
            get
            {
                return foodsymbol;
            }
        }

        public int FieldWidth
        {
            get
            {
                return fieldwidth;
            }
        }

        public int FieldHeight
        {
            get
            {
                return fieldheight;
            }
        }

        public int TimeStamp
        {
            get
            {
                return timestamp;
            }
        }
    }
}
