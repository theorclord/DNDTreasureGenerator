using DNDTreasureGenerator.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DNDTreasureGenerator
{
    public class ArmorFactory
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

        static readonly List<ArmorEnchantmentChanceObject> MinorArmorEnchantmentRolls = new()
        {
            new ArmorEnchantmentChanceObject() { RollResult = ArmorEnchantmentRoll.Glamered, EndChance = 25 },
            new ArmorEnchantmentChanceObject() { RollResult = ArmorEnchantmentRoll.FortificationLight, EndChance = 32 },
            new ArmorEnchantmentChanceObject() { RollResult = ArmorEnchantmentRoll.Slick, EndChance = 52 },
            new ArmorEnchantmentChanceObject() { RollResult = ArmorEnchantmentRoll.Shadow, EndChance = 72 },
            new ArmorEnchantmentChanceObject() { RollResult = ArmorEnchantmentRoll.SilentMoves, EndChance = 92},
            new ArmorEnchantmentChanceObject() { RollResult = ArmorEnchantmentRoll.SpellResistanceThirteen, EndChance = 96},
            new ArmorEnchantmentChanceObject() { RollResult = ArmorEnchantmentRoll.SlickImproved, EndChance = 97},
            new ArmorEnchantmentChanceObject() { RollResult = ArmorEnchantmentRoll.ShadowImproved, EndChance = 98},
            new ArmorEnchantmentChanceObject() { RollResult = ArmorEnchantmentRoll.SilentMovesImproved, EndChance = 99},
            new ArmorEnchantmentChanceObject() { RollResult = ArmorEnchantmentRoll.RollTwice, EndChance = 100},
        };

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

        public static ArmorEnchantmentRoll GetArmorEnchantmentChanceElement(int roll, List<ArmorEnchantmentChanceObject> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                var itemObject = collection[i];
                if (itemObject.EndChance >= roll)
                {
                    return itemObject.RollResult;
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

        private static Armor GetArmorEnchantmentLevel(ItemTier tier, Armor armorItem)
        {
            var ran = new Random();
            var roll = ran.Next() % 100 + 1;
            var tempArmor = armorItem;

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

            switch (currentRoll)
            {
                case ArmorShieldRoll.OneShield:
                    tempArmor.BaseArmor = GetChanceElement(itemRoll, ShieldTypes);
                    tempArmor.Enchantments.Add(Enchantment.PlusOne);
                    break;
                case ArmorShieldRoll.OneArmor:
                    tempArmor.BaseArmor = GetChanceElement(itemRoll, ArmorTypes);
                    tempArmor.Enchantments.Add(Enchantment.PlusOne);
                    break;
                case ArmorShieldRoll.TwoShield:
                    tempArmor.BaseArmor = GetChanceElement(itemRoll, ShieldTypes);
                    tempArmor.Enchantments.Add(Enchantment.PlusTwo);
                    break;
                case ArmorShieldRoll.TwoArmor:
                    tempArmor.BaseArmor = GetChanceElement(itemRoll, ArmorTypes);
                    tempArmor.Enchantments.Add(Enchantment.PlusTwo);
                    break;
                case ArmorShieldRoll.ThreeShield:
                    tempArmor.BaseArmor = GetChanceElement(itemRoll, ShieldTypes);
                    tempArmor.Enchantments.Add(Enchantment.PlusThree);
                    break;
                case ArmorShieldRoll.ThreeArmor:
                    tempArmor.BaseArmor = GetChanceElement(itemRoll, ArmorTypes);
                    tempArmor.Enchantments.Add(Enchantment.PlusThree);
                    break;
                case ArmorShieldRoll.FourShield:
                    tempArmor.BaseArmor = GetChanceElement(itemRoll, ShieldTypes);
                    tempArmor.Enchantments.Add(Enchantment.PlusFour);
                    break;
                case ArmorShieldRoll.FourArmor:
                    tempArmor.BaseArmor = GetChanceElement(itemRoll, ArmorTypes);
                    tempArmor.Enchantments.Add(Enchantment.PlusFour);
                    break;
                case ArmorShieldRoll.FiveShield:
                    tempArmor.BaseArmor = GetChanceElement(itemRoll, ShieldTypes);
                    tempArmor.Enchantments.Add(Enchantment.PlusFive);
                    break;
                case ArmorShieldRoll.FiveArmor:
                    tempArmor.BaseArmor = GetChanceElement(itemRoll, ArmorTypes);
                    tempArmor.Enchantments.Add(Enchantment.PlusFive);
                    break;
                case ArmorShieldRoll.SpecificArmor:
                    tempArmor.BaseArmor = "SpecialArmor";
                    break;
                case ArmorShieldRoll.SpecificShield:
                    tempArmor.BaseArmor = "SpecialShield";
                    break;
                case ArmorShieldRoll.SpecialAndRollAgain:
                    // Add a temp enchantment to the temp armor and roll again
                    tempArmor.BaseArmor = "SpecialAgain";
                    tempArmor.Enchantments.Add(Enchantment.Special);
                    tempArmor = GetArmorEnchantmentLevel(tier, tempArmor);
                    break;
                default:
                    break;
            }
            return tempArmor;
        }

        private static Armor GetSpecialEnchantments(Armor armor, List<ArmorEnchantmentChanceObject> rollCollection)
        {
            var ran = new Random();
            var roll = ran.Next(100) + 1;
            var rollResult = GetArmorEnchantmentChanceElement(roll, rollCollection);

            switch (rollResult)
            {
                case ArmorEnchantmentRoll.RollTwice:
                    ArmorEnchantmentRoll twiceCheck = ArmorEnchantmentRoll.RollTwice;
                    while(twiceCheck == ArmorEnchantmentRoll.RollTwice)
                    {
                        twiceCheck = GetArmorEnchantmentChanceElement(roll, rollCollection);
                    }
                    armor.SpecialEnchantments.Add(twiceCheck.ToString());
                    ArmorEnchantmentRoll twiceCheckTwo = ArmorEnchantmentRoll.RollTwice;
                    while (twiceCheckTwo == ArmorEnchantmentRoll.RollTwice)
                    {
                        twiceCheckTwo = GetArmorEnchantmentChanceElement(roll, rollCollection);
                    }
                    armor.SpecialEnchantments.Add(twiceCheckTwo.ToString());
                    break;
                default:
                    armor.SpecialEnchantments.Add(rollResult.ToString());
                    break;
            }
            return armor;
        }

        internal static Armor GetArmor(ItemTier tier)
        {
            Armor armorItem = new Armor()
            {
                Enchantments = new List<Enchantment>(),
                SpecialEnchantments = new List<string>(),
            };
            armorItem = GetArmorEnchantmentLevel(tier, armorItem);

            // Fill out the special enchantments
            // Switch on the type given the base item
            if (ShieldTypes.Any(st => st.Name == armorItem.BaseArmor))
            {
                // Check shield enchantments
            }
            else
            {
                // Check armor enchantments
                foreach (var enc in armorItem.Enchantments)
                {
                    if (enc == Enchantment.Special)
                    {
                        var rollCollection = (tier) switch
                        {
                            ItemTier.Minor => MinorArmorEnchantmentRolls,
                            _ => throw new NotImplementedException()
                        };
                        armorItem = GetSpecialEnchantments(armorItem, rollCollection);
                    }
                }
            }

            return armorItem;
        }
    }
}
