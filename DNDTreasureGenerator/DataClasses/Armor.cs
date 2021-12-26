using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDTreasureGenerator.DataClasses
{
    class Armor
    {
        //TODO consider if enum is better
        public string BaseArmor { get; set; }
        public List<Enchantment> Enchantments { get; set; }
        public List<string> SpecialEnchantments { get; set; }

        public string GetStringRepresentation()
        {
            StringBuilder rep = new StringBuilder();

            foreach(var enc in Enchantments)
            {
                if (enc != Enchantment.Special)
                {
                    rep.Append(enc.ToString() + " ");
                }
            }
            foreach(var specEnc in SpecialEnchantments)
            {
                rep.Append(specEnc + " ");
            }
            rep.Append(BaseArmor);

            return rep.ToString();
        }
    }
}
