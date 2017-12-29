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
            Tree.OctoberGlory og = new Tree.OctoberGlory();
            Tree.RedSunset rs = new Tree.RedSunset();

            Yard yard = new Yard();
            Console.WriteLine(yard.FindMaxTrees(og, 200));
            //Console.WriteLine(og.FormatDetailed());
            //Console.WriteLine(og.FormatCharacteristics());
            //Console.WriteLine(og.FormatSoilTypes());
            //Console.WriteLine(og.FormatClimateTypes());
            Console.ReadKey();
        }
    }
}
