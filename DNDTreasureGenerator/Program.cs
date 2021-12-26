using System;
using System.Collections.Generic;

namespace DNDTreasureGenerator
{
    class Program
    {
		

		

		static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


			// Section for generating gems
			if (false)
			{
				Console.Write("To calculate value and type of gems, enter number of gems:");
				int gemNum = int.Parse(Console.ReadLine());

				List<string> gemList = Gems.GenerateGemList(gemNum);

				for (int i = 0; i < gemList.Count; i++)
				{
					Console.WriteLine(gemList[i]);
				}
			}

			// armor section
			for(int i = 0; i < 100; i++)
            {
				var armor = ArmorFactory.GetArmor(DataClasses.ItemTier.Minor);
				Console.WriteLine(armor.GetStringRepresentation());
			}
		}
    }
}
