using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class HealingPotion : Item
    {
        public int AmountToHeal { get; set; }

        public HealingPotion(int _id, string _name, string _namePlural, int _amountToHeal) : base(_id, _name, _namePlural)
        {
            AmountToHeal = _amountToHeal;
        }
    }
}
