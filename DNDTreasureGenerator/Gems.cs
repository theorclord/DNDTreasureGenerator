using System;
using System.Collections.Generic;
using System.Linq;

namespace DNDTreasureGenerator
{
    // TODO create a gem class to hold the information rather than a string
    public class Gems
    {
        // String list of the names of the different gems
        static string[] gemFirst = { "Banded agate", "agate eye", "moss agate", "azurite",
        "blue quartz", "hematite", "lapis lazuli", "malachite", "obsidian",
        "rhodochrosite", "tiger eye turquoise", "freshwater (irregular) pearl" };

        static string[] gemSecond = { "Bloodstone", "carnelian", "chalcedony",
        "chrysoprase", "citrine", "iolite", "jasper", "moonstone",
        "onyx", "peridot", "rock crystal (clear quartz)", "sard",
        "sardonyx", "rose quartz", "smoky quartz", "star rose quartz", "zircon" };

        static string[] gemThird = { "Amber", "amethyst", "chrysoberyl", "coral", "red garnet", "brown-green garnet",
        "jade", "jet", "white pearl", "golden pearl", "pink pearl", "silver pearl",
        "red spinel", "red-brown spinel", "deep green spinel", "tourmaline" };

        static string[] gemFourth = { "Alexandrite", "aquamarine", "violet garnet",
        "black pearl", "deep blue spinel", "golden yellow topaz" };

        static string[] gemFifth = { "Emerald", "white opal", "black opal", "fire opal", "blue sapphire",
        "fiery yellow corundum", "rich purple corundum", "blue star sapphire", "black star sapphire", "star ruby" };

        static string[] gemSixth = { "Clearest bright green emerald", "blue-white diamond", "canary diamond", "pink diamond",
        "brown diamond", "blue diamond", "jacinth" };

        /// <summary>
        /// Fills a list with random percentage rolls
        /// </summary>
        /// <param name="gemNumber">The number of gems</param>
        /// <returns>List of percentage rolls</returns>
        internal static List<int> FillGemCollection(int gemNumber)
        {
            var ran = new Random();
            var gemRollList = new List<int>(gemNumber);

            for (int i = 0; i < gemNumber; i++)
            {
                int n = ran.Next() % 100 + 1;
                gemRollList.Add(n);
            }

            return gemRollList;
        }

        /// <summary>
        /// Combined Method which returns a list of gems with values given an amount to generate
        /// </summary>
        /// <param name="gemNumber">Number of gems to generate</param>
        /// <returns>String list wiht the value followed by the type of each gem</returns>
        internal static List<string> GenerateGemList(int gemNumber)
        {
            List<int> gemRollsCollection = FillGemCollection(gemNumber);
            List<int> gemSort = SortGems(gemRollsCollection);
            List<string> gemResult = FinalGemValue(gemSort);

            return gemResult;
        }

        /// <summary>
        /// Sorts a list of gem rolls into the 6 groups for generating their value
        /// </summary>
        /// <param name="gemRolls">The list of gem percentage rolls</param>
        /// <returns>A list of the amount of gems in each category</returns>
        internal static List<int> SortGems(List<int> gemRolls)
        {
            var gemTypeAmount = new int[6];

            //sort the gems into the 6 categories
            for (int i = 0; i < gemRolls.Count; i++)
            {
                int roll = gemRolls[i];
                if (roll < 71)
                {
                    if (roll < 51)
                    {
                        if (roll < 26)
                        {
                            gemTypeAmount[0]++;
                        }
                        else
                        {
                            gemTypeAmount[1]++;
                        }
                    }
                    else
                    {
                        gemTypeAmount[2]++;
                    }
                }
                else
                {
                    if (roll < 91)
                    {
                        gemTypeAmount[3]++;
                    }
                    else
                    {
                        if (roll < 100)
                        {
                            gemTypeAmount[4]++;
                        }
                        else
                        {
                            gemTypeAmount[5]++;
                        }
                    }
                }
            }
            return gemTypeAmount.ToList();
        }

        /// <summary>
        /// Generates a string list with gems and their value, given the amount to generate
        /// </summary>
        /// <param name="gemTypeAmount">The list of gem types with their amount</param>
        /// <returns>List of gems with their vales</returns>
        internal static List<string> FinalGemValue(List<int> gemTypeAmount)
        {
            var ran = new Random();
            var gemStringList = new List<string>();

            

            for (int i = 0; i < gemTypeAmount[0]; i++)
            {
                int size = 12;
                int select = ran.Next() % (size);
                int value = 0;
                for (int j = 0; j < 4; j++)
                {
                    value += ran.Next() % 4 + 1;
                }
                string gem = value + " " + gemFirst[select];
                gemStringList.Add(gem);
            }

            for (int i = 0; i < gemTypeAmount[1]; i++)
            {
                int size = 17;
                int select = ran.Next() % (size);
                int value = 0;
                for (int j = 0; j < 2; j++)
                {
                    value += ran.Next() % 4 + 1;
                }
                string gem = value * 10 + " " + gemSecond[select];
                gemStringList.Add(gem);
            }

            for (int i = 0; i < gemTypeAmount[2]; i++)
            {
                int size = 16;
                int select = ran.Next() % (size);
                int value = 0;
                for (int j = 0; j < 4; j++)
                {
                    value += ran.Next() % 4 + 1;
                }
                string gem = value * 10 + " " + gemThird[select];
                gemStringList.Add(gem);
            }

            for (int i = 0; i < gemTypeAmount[3]; i++)
            {
                int size = 6;
                int select = ran.Next() % (size);
                int value = 0;
                for (int j = 0; j < 2; j++)
                {
                    value += ran.Next() % 4 + 1;
                }
                string gem = value * 100 + " " + gemFourth[select];
                gemStringList.Add(gem);
            }

            for (int i = 0; i < gemTypeAmount[4]; i++)
            {
                int size = 10;
                int select = ran.Next() % (size);
                int value = 0;
                for (int j = 0; j < 4; j++)
                {
                    value += ran.Next() % 4 + 1;
                }
                string gem = value * 100 + " " + gemFifth[select];
                gemStringList.Add(gem);
            }

            for (int i = 0; i < gemTypeAmount[5]; i++)
            {
                int size = 7;
                int select = ran.Next() % (size);
                int value = 0;
                for (int j = 0; j < 2; j++)
                {
                    value += ran.Next() % 4 + 1;
                }
                string gem = value * 1000 + " " + gemSixth[select];
                gemStringList.Add(gem);
            }

            return gemStringList;
        }
    }
}
