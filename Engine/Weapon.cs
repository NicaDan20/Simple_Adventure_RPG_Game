using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public Weapon(int _id, string _name, string _namePlural, int _minDamage, int _maxDamage) : base(_id, _name, _namePlural)
        {
            MinimumDamage = _minDamage;
            MaximumDamage = _maxDamage;
        }

    }
}
