using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreePlanter
{
    class Program
    {
        static void Main(string[] args)
        {
            OctoberGlory og = new OctoberGlory();
            Console.WriteLine(og.FormatDetailed());
            //Console.WriteLine(og.FormatCharacteristics());
            //Console.WriteLine(og.FormatSoilTypes());
            //Console.WriteLine(og.FormatClimateTypes());
            Console.ReadKey();
        }
    }
}
