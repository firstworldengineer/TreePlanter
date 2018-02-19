using System;
using System.Collections.Generic;
using System.Text;

namespace TreePlanter
{
    // WorkItem implicitly inherits from the Object class.
    public class Tree
    {
        #region Enums
        /// <summary>
        /// Soil types as per https://www.arborday.org
        /// </summary>
        public enum SoilType
        {
            Acidic = 0,
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
            FullSun = 0,
            PartialShade,
            Shade
        }

        /// <summary>
        /// USDA Hardiness zones. Other systems may have more than 11 zones.
        /// See https://www.gardeningknowhow.com/planting-zones/hardiness-zone-converter.htm
        /// </summary>
        public enum HardinessZone
        {
            Zone1 = 1,
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

        public struct MinimumDistance
        {
            /// <summary>
            /// Minimum distances tree should be planted away from objects.
            /// </summary>
            /// <param name="fromPlants">from trees, bushes, foliage</param>
            /// <param name="fromStructures">from buildings, septic, swimming pools</param>
            /// <param name="fromWalks">from sidewalks, underground piping, wiring</param>
            /// <param name="fromPower">from power lines</param>
            public MinimumDistance(int fromPlants, int fromStructures, int fromWalks, int fromPower)
            {
                FromPlants = fromPlants;
                FromStructures = fromStructures;
                FromWalks = fromWalks;
                FromPower = fromPower;
            }

            public int FromPlants        { get; private set; }
            public int FromStructures   { get; private set; }
            public int FromWalks        { get; private set; }
            public int FromPower        { get; private set; }
        }

        #endregion
        #region Tree Constructors
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
            this.MinPlantDistance = new MinimumDistance((canopy/2), (canopy / 2), (canopy / 2), (canopy / 2));

        }

        // Instance constructor with full definition
        public Tree(string name, int height, int roots, int canopy, List<HardinessZone>climate, int durability,
            List<string>characteristics, List<SoilType>soilType, List<SunExposure>sunexposure, int growthrate, MinimumDistance minDistance)
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
            this.MinPlantDistance = minDistance;
        }
        #endregion
        #region Tree Properties
        //Properties.
        public string Name { get; set; }
        public int Height { get; set; }
        public int Roots { get; set; }
        public int Canopy { get; set; }
        public List<HardinessZone> Climate { get; set; }
        public int Durability { get; set; }
        public List<string> Characteristics { get; set; }
        public List<SoilType> Soiltype { get; set; }
        public List<SunExposure> Sunexposure { get; set; }
        public int Growthrate { get; set; }
        public MinimumDistance MinPlantDistance { get; set; }
        #endregion
        #region Tree Methods
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
            List<string> characteristics, List<SoilType> soilType, List<SunExposure> sunExposure, int growthRate, MinimumDistance minPlantDistance)
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
            this.MinPlantDistance = minPlantDistance;
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
                                 "Must be planted a minimum distance of {6} feet away from other structures." +
                                 FormatCharacteristics() + FormatClimateTypes() + FormatSoilTypes()
                , Name, Height, Roots, Canopy, Durability, Growthrate, MinPlantDistance);
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
        #endregion
        #region Tree Internal Classes
        // In ordinary use, this would most likely
        // pull from a db using a species name as key.
        // For simplicity, I am defining them en classe.
        internal class RedSunset : Tree
        {
            // Constructors. Because neither constructor, derived nor base, calls a base-class 
            // constructor explicitly, the default constructor in the base class
            // is called implicitly. The base class must contain a default 
            // constructor.

            // Default constructor for the derived class.
            public RedSunset()
            {
                Name = "Red Sunset";
                Height = 50;
                Roots = 0;
                Canopy = 40;
                Growthrate = 24;
                MinPlantDistance = new MinimumDistance(20,15,8,30);
                Climate = new List<HardinessZone>()
                {
                    HardinessZone.Zone4,
                    HardinessZone.Zone5,
                    HardinessZone.Zone6,
                    HardinessZone.Zone7,
                    HardinessZone.Zone8
                };
                Characteristics = new List<string>()
                {
                    "Colorful",
                    "Rounded Shape",
                    "Small Fruits",
                    "First to Color in Autumn",
                    "Small Flowers in Winter",
                    "Strong Wood",
                    "Good Branch Structure"
                };
                Soiltype = new List<SoilType>()
                {
                    SoilType.Acidic,
                    SoilType.Clay,
                    SoilType.Loamy,
                    SoilType.Moist,
                    SoilType.Sandy,
                    SoilType.SiltyLoam,
                    SoilType.WellDrained,
                    SoilType.Wet
                };
                Sunexposure = new List<SunExposure>()
                {
                    SunExposure.FullSun,
                    SunExposure.PartialShade
                };
            }
        }
        internal class OctoberGlory : Tree
        {
            // Constructors. Because neither constructor, derived nor base, calls a base-class 
            // constructor explicitly, the default constructor in the base class
            // is called implicitly. The base class must contain a default 
            // constructor.

            // Default constructor for the derived class.
            public OctoberGlory()
            {
                Name = "October Glory";
                Height = 40;
                Roots = 0;
                Canopy = 35;
                Growthrate = 24;
                MinPlantDistance = new MinimumDistance(20, 15, 8, 30);
                Climate = new List<HardinessZone>()
                {
                    HardinessZone.Zone4,HardinessZone.Zone5,HardinessZone.Zone6,
                    HardinessZone.Zone7,HardinessZone.Zone8,HardinessZone.Zone9
                };
                Characteristics = new List<string>() { "Colorful", "Rounded Shape", "Small Fruits" };
                Soiltype = new List<SoilType>()
                {
                    SoilType.Acidic,SoilType.Clay,SoilType.Loamy,SoilType.Moist,
                    SoilType.Rich,SoilType.Sandy,SoilType.SiltyLoam,
                    SoilType.WellDrained,SoilType.Wet
                };
                Sunexposure = new List<SunExposure>()
                {
                    SunExposure.FullSun,SunExposure.PartialShade
                };
            }
        }
        internal class LittleGem : Tree
        {
            // Constructors. Because neither constructor, derived nor base, calls a base-class 
            // constructor explicitly, the default constructor in the base class
            // is called implicitly. The base class must contain a default 
            // constructor.

            // Default constructor for the derived class.
            public LittleGem()
            {
                Name = "Little Gem";
                Height = 20;
                Roots = 4;
                Canopy = 10;
                Growthrate = 24;
                MinPlantDistance = new MinimumDistance(8,4,4,15);
                Climate = new List<HardinessZone>()
                {
                    HardinessZone.Zone7,
                    HardinessZone.Zone8,
                    HardinessZone.Zone9
                };
                Characteristics = new List<string>()
                {
                    "Winterproof",
                    "Can produces blooms in winter",
                    "Considered ornate shrub"
                };
                Soiltype = new List<SoilType>()
                {
                    SoilType.Acidic,
                    SoilType.Clay,
                    SoilType.Loamy,
                    SoilType.Moist,
                    SoilType.Rich,
                    SoilType.Sandy,
                    SoilType.SiltyLoam,
                    SoilType.WellDrained,
                    SoilType.Wet
                };
                Sunexposure = new List<SunExposure>()
                {
                    SunExposure.FullSun,
                    SunExposure.PartialShade
                };
            }
        }
        internal class SaucerMagnolia : Tree
            {
                // Constructors. Because neither constructor, derived nor base, calls a base-class 
                // constructor explicitly, the default constructor in the base class
                // is called implicitly. The base class must contain a default 
                // constructor.

                // Default constructor for the derived class.
                public SaucerMagnolia()
                {
                    Name = "Saucer Magnolia";
                    Height = 30;
                    Roots = 0;
                    Canopy = 25;
                    Growthrate = 24;
                    MinPlantDistance = new MinimumDistance(8,4,4,15);
                    Climate = new List<HardinessZone>()

                    {
                        HardinessZone.Zone4,
                        HardinessZone.Zone5,
                        HardinessZone.Zone6,
                        HardinessZone.Zone7,
                        HardinessZone.Zone8,
                        HardinessZone.Zone9
                    };
                    Durability = int.MaxValue;
                    Characteristics = new List<string>() {"Can be trained to grow as a shrub or single-trunk tree",
                        "Ornate pink flowers", "Spring blooms colorful", "Will bloom in Summer",
                        "Less colorful each bloom of season", "Rounded shape", "Thin bark easily damaged by mowers, etc." };
                    Soiltype = new List<SoilType>()
                    {
                        SoilType.Acidic,
                        SoilType.Clay,
                        SoilType.Loamy,
                        SoilType.Moist,
                        SoilType.Rich,
                        SoilType.Sandy
                    };
                    Sunexposure = new List<SunExposure>()
                    {
                        SunExposure.FullSun,
                    };
                }
            }
        

        #endregion
    }
}