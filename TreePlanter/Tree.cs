using System;
using System.Collections.Generic;
using System.Text;

namespace TreePlanter
{
    // WorkItem implicitly inherits from the Object class.
    public class Tree
    {
        /// <summary>
        /// Soil types as per https://www.arborday.org
        /// </summary>
        public enum SoilType
        {
            Acidic=0,
            Clay,
            Loamy,
            Moist,
            Rich,
            Sandy,
            SiltyLoam,
            WellDrained,
            Wet
        }
        /// <summary>
        /// Sun exposure quantities as per https://www.arborday.org
        /// </summary>
        public enum SunExposure
        {
            FullSun=0,
            PartialShade,
            Shade
        }

        /// <summary>
        /// USDA Hardiness zones. Other systems may have more than 11 zones.
        /// See https://www.gardeningknowhow.com/planting-zones/hardiness-zone-converter.htm
        /// </summary>
        public enum HardinessZone
        {
            Zone1=1,
            Zone2,
            Zone3,
            Zone4,
            Zone5,
            Zone6,
            Zone7,
            Zone8,
            Zone9,
            Zone10,
            Zone11
        }
        
        // Default constructor. If a derived class does not invoke a base-
        // class constructor explicitly, the default constructor is called
        // implicitly. 
        public Tree()
        {
            this.Name = "Undefined Tree";
        }
        // Instance constructor with minimum definition
        public Tree(string name, int height, int roots, int canopy)
        {
            this.Name = name;
            this.Height = height;
            this.Roots = roots;
            this.Canopy = canopy;
        }
        // Instance constructor with full definition
        public Tree(string name, int height, int roots, int canopy, List<HardinessZone>climate, int durability,
            List<string>characteristics, List<SoilType>soilType, List<SunExposure>sunexposure, int growthrate)
        {
            this.Name = name;
            this.Height = height;
            this.Roots = roots;
            this.Canopy = canopy;
            this.Climate = climate;
            this.Durability = durability;
            this.Characteristics = characteristics;
            this.Soiltype = soilType;
            this.Sunexposure = sunexposure;
            this.Growthrate = growthrate;
        }
        //Properties.
        protected string Name { get; set; }
        protected int Height { get; set; }
        protected int Roots { get; set; }
        protected int Canopy { get; set; }
        protected List<HardinessZone> Climate { get; set; }
        protected int Durability { get; set; }
        protected List<string> Characteristics { get; set; }
        protected List<SoilType> Soiltype { get; set; }
        protected List<SunExposure> Sunexposure { get; set; }
        protected int Growthrate { get; set; }
        
        /// <summary>
        /// Allows to update the defintion of an
        /// existing object. Caller defaults not needed parameters</summary>
        /// <param name="name"></param>
        /// <param name="height"></param>
        /// <param name="roots"></param>
        /// <param name="canopy"></param>
        /// <param name="climate"></param>
        /// <param name="durability"></param>
        /// <param name="characteristics"></param>
        /// <param name="soilType"></param>
        /// <param name="sunExposure"></param>
        /// <param name="growthRate"></param>
        public void Update(string name, int height, int roots, int canopy, List<HardinessZone> climate, int durability,
            List<string> characteristics, List<SoilType> soilType, List<SunExposure> sunExposure, int growthRate)
        {
            this.Name = name;
            this.Height = height;
            this.Roots = roots;
            this.Canopy = canopy;
            this.Climate = climate;
            this.Durability = durability;
            this.Characteristics = characteristics;
            this.Soiltype = soilType;
            this.Sunexposure = sunExposure;
            this.Growthrate = growthRate;
        }

        // Virtual method override of the ToString method that is inherited
        // from System.Object.
        /// <summary>
        /// Returns the name property of the tree
        /// </summary>
        /// <returns>tree.name</returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Formats all property values as string
        /// </summary>
        /// <returns></returns>
        public string FormatDetailed()
        {
            return String.Format("Name: {0}\nHeight: {1} ft.\nRoot Width: {2} ft.\nCanopy Width: {3} ft.\n" +
                                 "Durability Rating: {4}/10\nAnnual Growth Rate: {5} in.\n" +
                                 FormatCharacteristics() + FormatClimateTypes() + FormatSoilTypes()
                                 ,Name,Height,Roots,Canopy,Durability,Growthrate);
        }

        public string FormatCharacteristics()
        {
            StringBuilder sb = new StringBuilder("Characteristic(s):\n");
            if (Characteristics == null || Characteristics.Count == 0)
            {
                sb.Append("-" + "none\n");
                return sb.ToString();
            }
            else
            {
                foreach (var characteristic in Characteristics)
                {
                    sb.Append("-" + characteristic + "\n");
                }
                return sb.ToString();
            }
        }

        public string FormatSoilTypes()
        {
            StringBuilder sb = new StringBuilder("Soil Type(s):\n");
            if (Soiltype == null || Soiltype.Count == 0)
            {
                sb.Append("-" + "none\n");
                return sb.ToString();
            }
            else
            {
                foreach (var type in Soiltype)
                {
                    sb.Append("-" + type.ToString() + "\n");
                }
                return sb.ToString();
            }
        }

        public string FormatClimateTypes()
        {
            StringBuilder sb = new StringBuilder("Hardiness Zone(s):\n");
            if (Climate == null || Climate.Count == 0)
            {
                sb.Append("-" + "none\n");
                return sb.ToString();
            }
            else
            {
                foreach (var type in Climate)
                {
                    sb.Append("-" + type.ToString() + "\n");
                }
                return sb.ToString();
            }
        }
    }
}