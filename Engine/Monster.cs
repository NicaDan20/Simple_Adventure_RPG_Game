using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : LivingCreature
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaximumDamage { get; set; }
        public int MinimumDamage { get; set; }
        public int RewardExperience { get; set; }
        public int RewardGold { get; set; }
        public List<LootItem> LootTable { get; set; }

        public Monster(int _id, int _currentHitPoints, int _maxHitPoints, string _name, int _rewardExperience, int _rewardGold, int _maxDamage, int _minDamage) : base(_currentHitPoints, _maxHitPoints)
        {
            ID = _id;
            Name = _name;
            RewardExperience = _rewardExperience;
            RewardGold = _rewardGold;
            MaximumDamage = _maxDamage;
            MinimumDamage = _minDamage;
            LootTable = new List<LootItem>();
        }
    }
}
