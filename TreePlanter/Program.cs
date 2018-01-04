using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TreePlanter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tree> trees = new List<Tree>();

            //trees = ReflectiveEnumerator.GetEnumerableOfTypeTree();
            //List<Tree> objects = new List<Tree>();
            //foreach (Type type in
            //    Assembly.GetAssembly(typeof(Tree)).GetTypes()
            //        .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Tree))))
            //{
            //    objects.Add((Tree)Activator.CreateInstance(type));
            //}
            //Console.Write("Via Reflection:");
            //foreach (var tree in trees)
            //{
            //    string val = tree.ToString();
            //    Type type = Type.GetType(val);
            //    object instance = Activator.CreateInstance(type);
            //
            //    Console.WriteLine(tree.ToString());
            //}
            Tree.SaucerMagnolia sm = new Tree.SaucerMagnolia();
            Tree.LittleGem lg = new Tree.LittleGem();
            Tree.OctoberGlory og = new Tree.OctoberGlory();
            Tree.RedSunset rs = new Tree.RedSunset();

            trees.Add(sm);
            trees.Add(lg);
            trees.Add(og);
            trees.Add(rs);

            string details;
            double remainder;
            Yard yard = new Yard();
            foreach (var tree in trees)
            {
                Console.WriteLine(tree.FormatDetailed());
                //Console.WriteLine(yard.FindMaxTrees(tree, 200));
                Console.WriteLine(yard.FindMaxTrees(tree, 200, out remainder, out details));
                if (details != null || details != string.Empty)
                    Console.WriteLine(details);
            }
            //Console.WriteLine(og.FormatCharacteristics());
            //Console.WriteLine(og.FormatSoilTypes());
            //Console.WriteLine(og.FormatClimateTypes());
            Console.ReadKey();
        }
    }
}
