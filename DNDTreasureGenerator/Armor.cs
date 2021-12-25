using DNDTreasureGenerator.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDTreasureGenerator
{
    public class Armor
    {
        static readonly List<Item> ArmorTypes = new () { new Item() {Name = "Padded", EndChance = 1 }, new Item() {Name =  "Leather", EndChance= 2 },
            new Item() {Name = "Studded leather", EndChance = 17 }, new Item() {Name = "Chain shirt", EndChance= 32 },
            new Item() {Name = "Hide", EndChance = 42 }, new Item() {Name = "Scale mail", EndChance = 43 }, new Item() {Name = "Chainmail", EndChance = 44 },
            new Item() {Name =  "Breastplate", EndChance = 57 }, new Item() {Name =  "Splint mail", EndChance = 58 },
            new Item() {Name =  "Banded mail", EndChance = 59 }, new Item() {Name =  "Half-plate", EndChance = 60 }, new Item() {Name =  "Full plate", EndChance = 100 }};

        static readonly List<Item> ShieldTypes = new () { new Item() {Name = "Buckler", EndChance = 10 }, new Item() {Name =  "Shield, light, wooden", EndChance= 15 },
            new Item() {Name = "Shield, light, steel", EndChance = 20 }, new Item() {Name = "Shield, heavy, wooden", EndChance= 30 },
            new Item() {Name = "Shield, heavy, steel", EndChance = 95 }, new Item() {Name = "Shield, tower", EndChance = 100 },};

        static readonly List<ArmorChanceObject> MinorRolls = new () { new ArmorChanceObject() { RollResult = ArmorShieldRoll.OneShield, EndChance = 60 }, 
            new ArmorChanceObject() { RollResult = ArmorShieldRoll.OneArmor, EndChance = 80 }, new ArmorChanceObject() { RollResult = ArmorShieldRoll.TwoShield, EndChance = 85 }, 
            new ArmorChanceObject() { RollResult = ArmorShieldRoll.TwoArmor, EndChance = 87 }, new ArmorChanceObject() { RollResult = ArmorShieldRoll.SpecificArmor, EndChance = 89 },
            new ArmorChanceObject() { RollResult = ArmorShieldRoll.SpecificShield, EndChance = 91 }, new ArmorChanceObject() { RollResult = ArmorShieldRoll.SpecialAndRollAgain, EndChance = 100 }, };


        public static string GetChanceElement(int roll, List<Item> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                var itemObject = collection[i];
                if (itemObject.EndChance >= roll)
                {
                    return itemObject.Name;
                }
            }
            throw new Exception("The collection is missing items in range");
        }

        public static ArmorShieldRoll GetChanceRollElement(int roll, List<ArmorChanceObject> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                var chanceObject = collection[i];
                if (chanceObject.EndChance >= roll)
                {
                    return chanceObject.RollResult;
                }
            }
            throw new Exception("The collection is missing items in range");
        }

        internal static string GetArmor(ItemTier tier)
        {
            Random ran = new Random();
            var roll = ran.Next() % 100 + 1;

            ArmorShieldRoll currentRoll = ArmorShieldRoll.OneShield;
            switch (tier)
            {
                case ItemTier.Minor:
                    currentRoll = GetChanceRollElement(roll, MinorRolls);
                    break;
                case ItemTier.Medium:
                    break;
                case ItemTier.Major:
                    break;
                default:
                    break;
            }

            var itemRoll = ran.Next() % 100 + 1;
            string armorItem = null;
            switch (currentRoll)
            {
                case ArmorShieldRoll.OneShield:
                    armorItem = "+1 " + GetChanceElement(itemRoll, ShieldTypes);
                    break;
                case ArmorShieldRoll.OneArmor:
                    armorItem = "+1 " + GetChanceElement(itemRoll, ArmorTypes);
                    break;
                case ArmorShieldRoll.TwoShield:
                    armorItem = "+2 " + GetChanceElement(itemRoll, ShieldTypes);
                    break;
                case ArmorShieldRoll.TwoArmor:
                    armorItem = "+2 " + GetChanceElement(itemRoll, ArmorTypes);
                    break;
                case ArmorShieldRoll.ThreeShield:
                    armorItem = "+3 " + GetChanceElement(itemRoll, ShieldTypes);
                    break;
                case ArmorShieldRoll.ThreeArmor:
                    armorItem = "+3 " + GetChanceElement(itemRoll, ArmorTypes);
                    break;
                case ArmorShieldRoll.FourShield:
                    armorItem = "+4 " + GetChanceElement(itemRoll, ShieldTypes);
                    break;
                case ArmorShieldRoll.FourArmor:
                    armorItem = "+4 " + GetChanceElement(itemRoll, ArmorTypes);
                    break;
                case ArmorShieldRoll.FiveShield:
                    armorItem = "+5 " + GetChanceElement(itemRoll, ShieldTypes);
                    break;
                case ArmorShieldRoll.FiveArmor:
                    armorItem = "+5 " + GetChanceElement(itemRoll, ArmorTypes);
                    break;
                case ArmorShieldRoll.SpecificArmor:
                    armorItem = "SpecialArmor";
                    break;
                case ArmorShieldRoll.SpecificShield:
                    armorItem = "SpecialShield";
                    break;
                case ArmorShieldRoll.SpecialAndRollAgain:
                    armorItem = "SpecialAgain";
                    break;
                default:
                    break;
            }

            return armorItem;
        }
    }
}
