using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreePlanter
{
    public class Yard
    {
        /// <summary>
        /// Finds most trees of a given type that will fit along a single line segment
        /// without imposing upon one another.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="spaceInFeet"></param>
        /// <returns></returns>
        public int FindMaxTrees(Tree tree, int spaceInFeet, out double remainder, out string details)
        {
            //assume that spaceInFeet is a ray
            //spaceInFeet starts at 0 and extends to [spaceInFeet]

            //coordinate location along the ray
            double plantLocation = 0;
            //string to return summarizing our actions
            StringBuilder log = new StringBuilder();
            //distance of the remaining gap left
            var gap = 0;
            //List to maintain all of our plant coordinates
            List<double> plantLocations = new List<double>();

            //trees cannot be planted within range of their canopy width or root width,
            //use whichever is larger
            var minimumSpacing = Math.Max(tree.Canopy, tree.Roots);

            //string of the plant locations for the log
            StringBuilder plantLocationsString = new StringBuilder();

            //canopy and roots are radius values, line segment starts at 0, with (-)values
            //being the neighbors' yard. We want the very edge of the tree at maturity to
            //reach this border. Therefore, shift center of the tree away from the border by its radius
            plantLocation = minimumSpacing;
            plantLocations.Add(plantLocation);
            plantLocationsString.Append(plantLocation.ToString() + " ft.");

            //now that we have our first tree in the ground, we want to plant them at the
            //minimum required distance until we are too close to [spaceInFeet]
            //this distance is 1 diameter of the tree, which is 2 * our radius
            while (plantLocation < spaceInFeet)
            {
                //determine where to plant the next one
                plantLocation += (2*minimumSpacing);
                //if our current location won't go over our space, plant it!
                if ((plantLocation + minimumSpacing) < spaceInFeet)
                {
                    plantLocations.Add(plantLocation);
                    if (plantLocationsString.ToString() != String.Empty)
                        plantLocationsString.Append(", " + plantLocation.ToString() + " ft. ");
                    else
                    {
                        plantLocationsString.Append(plantLocation.ToString());
                    }
                }
                //otherwise, we're done planting

                //find how much gap there is between [spaceInFeet] and our final tree's outer edge
                else
                {
                    if (plantLocations.Count > 1)
                        //gap remaining is from the previous plant location to [spaceInFeet]
                        //our plant locations are tree centers, find the outer edge by adding its radius
                        gap = spaceInFeet - ((int) plantLocations[plantLocations.Count - 1] + minimumSpacing);
                    else
                        //We couldn't fit a single tree... what a shame.
                        gap = spaceInFeet;
                    break;
                }
            }

            //we have planted all of the trees that we can fit, now let's summarize what we did
            if (plantLocations.Count != 0)
            {
                log.Append("A total of " + plantLocations.Count + " trees were planted.\n" +
                           "Trees were planted at " + plantLocationsString.ToString() + "\n" +
                    "There is a gap of " + gap + " feet between the end of our space and the last tree.\n");

            }
            else
            {
                log.Append("No " + tree.Name + " trees were able to fit in this space.\n" +
                                        "Get a real yard, ya' bum!\n");
            }
            //add our final values to our outs, in case we would like the extra information
            remainder = gap;
            details = log.ToString(); 

            return plantLocations.Count;
        }
        /// <summary>
        /// Finds most trees of a given type that will fit along a single line segment
        /// without imposing upon one another.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="spaceInFeet"></param>
        /// <returns></returns>
        public int FindMaxTrees(Tree tree, int spaceInFeet)
        {
            double remainder;
            string details;
            return FindMaxTrees(tree, spaceInFeet, out remainder, out details);
        }
    }
}