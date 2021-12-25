using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDTreasureGenerator.DataClasses
{
    class Enums
    {
        
    }
    public enum ItemTier
    {
        Minor, Medium, Major
    }

    public enum ArmorShieldRoll
    {
        OneShield, OneArmor, TwoShield, TwoArmor, ThreeShield, ThreeArmor, FourShield, FourArmor, FiveShield, FiveArmor,
        SpecificArmor, SpecificShield, SpecialAndRollAgain,
    }
}
