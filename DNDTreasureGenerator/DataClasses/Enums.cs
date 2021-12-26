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

    public enum Enchantment
    {
        PlusOne,PlusTwo,PlusThree,PlusFour,PlusFive,
        Special,
    }

    public enum ArmorEnchantmentRoll
    {
        Glamered, FortificationLight, Slick, Shadow, SilentMoves, SpellResistanceThirteen, SlickImproved, ShadowImproved, SilentMovesImproved, AcidResistance,
        ColdResistance, ElectricityResistance, FireResistance, SonicResistance, GhostTouch, Invulnerability, FortificationModerate, SpellResistanceFifteen,
        Wild, SlickGreater, ShadowGreater, SilentMovesGreater, AcidResistanceImproved, ColdResistanceImproved, ElectricityResistanceImproved, FireResistanceImproved,
        SonicResistanceImproved, SpellResistanceSeventeen, Etheralness, UndeadControlling, FortificationHeavy, SpellResistanceNineteen, AcidResistanceGreater,
        ColdResistanceGreater, ElectricityResistanceGreater, FireResistanceGreater, SonicResistanceGreater, RollTwice
    }

    public enum ShieldEnchantment
    {
        PlusOne, PlusTwo, PlusThree, PlusFour, PlusFive,
    }
}
