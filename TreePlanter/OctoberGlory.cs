using System.Collections.Generic;

namespace TreePlanter
{
    // In ordinary use, this would most likely
    // pull from a db using a species name as key.
    // For simplicity, I am defining them en classe.
    public class OctoberGlory : Tree
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
            Climate = new List<HardinessZone>()
            {
                HardinessZone.Zone4,HardinessZone.Zone5,HardinessZone.Zone6,
                HardinessZone.Zone7,HardinessZone.Zone8,HardinessZone.Zone9
            };
            Durability = int.MaxValue;
            Characteristics = new List<string>(){ "Colorful", "Rounded Shape", "Small Fruits" };
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
            Growthrate = 24;
        }
        
    }
}