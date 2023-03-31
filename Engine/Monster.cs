using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        // Monster attack function
        public override int Attack(LivingCreature defender, Weapon equippedWeapon = null)
        {
                int damage = RandomNumberGenerator.GenerateNumber(MinimumDamage, MaximumDamage);
                if (defender.CurrentHitPoints - damage <= 0)
                {
                    defender.CurrentHitPoints = 0;
                }
                else
                {
                    defender.CurrentHitPoints -= damage;
                }
            return damage;
        }
        // If the player is in combat at the moment of saving the game
        // when the player loads the game, we will load the monster
        // from the XML file
        public static Monster GetMonsterFromXML(string _xmlPlayerData)
        {
            try
            {
                XmlDocument playerData = new();
                playerData.LoadXml(_xmlPlayerData);
                XmlNode node = playerData.SelectSingleNode("/Player/Monster");
                int id = Convert.ToInt32(node.Attributes["ID"].Value);
                int currentHitPoints = Convert.ToInt32(node.Attributes["CurrentHitPoints"].Value);
                int maximumHitPoints = Convert.ToInt32(node.Attributes["MaximumHitPoints"].Value);

                Monster monster = (ObjectMapper.ReturnMonsterByID(id));
                Monster _loadedMonster = new Monster(monster.ID, monster.CurrentHitPoints, monster.MaximumHitPoints, monster.Name, monster.RewardExperience, monster.RewardGold, monster.MaximumDamage, monster.MinimumDamage);
                _loadedMonster.CurrentHitPoints = currentHitPoints;
                _loadedMonster.MaximumHitPoints = maximumHitPoints;

                return _loadedMonster;
            } catch
            {
                return null;
            }
        }


    }
}
