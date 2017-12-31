using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TreePlanter
{
    public static class ReflectiveEnumerator
    {
        public static List<Tree> GetEnumerableOfTypeTree()
        {
            List<Tree> objects = new List<Tree>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(Tree)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Tree))))
            {
                objects.Add((Tree)Activator.CreateInstance(type));
            }
            //objects.Sort();
            return objects;
        }
    }
}