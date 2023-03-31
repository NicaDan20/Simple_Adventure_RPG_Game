using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Engine
{
    public enum CombatState { 
        [XmlEnum("PlayerTurn")]
        PlayerTurn, 
        [XmlEnum("EnemyTurn")]
        EnemyTurn,
        [XmlEnum("PlayerIsDead")]
        PlayerIsDead, 
        [XmlEnum("EnemyIsDead")]
        EnemyIsDead, 
        [XmlEnum("EnemyIsLooted")]
        EnemyIsLooted, 
        [XmlEnum("NotInCombat")]
        NotInCombat
    };
    public class Player : LivingCreature
    {
        public CombatState _curState;
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int ExpToNextLevel { get; set; }
        public int Level { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
        public Location CurrentLocation { get; set; }
        private Player(int _currentHitPoints, int _maxHitPoints, int _gold, int _experiencePoints, int _level) : base(_currentHitPoints, _maxHitPoints)
        {
            Gold = _gold;
            ExperiencePoints = _experiencePoints;
            Level = _level;
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        public static Player CreateDefaultPlayer()
        {
            Player player = new Player(15, 15, 10, 0, 1);
            player.Inventory.Add(new InventoryItem(ObjectMapper.ReturnItemByID(1), 1));
            player.Inventory.Add(new InventoryItem(ObjectMapper.ReturnItemByID(10), 3));
            player.CurrentLocation = ObjectMapper.ReturnLocationByID(1);
            player._curState = CombatState.NotInCombat;
            player.SetExpToNextLevel();
            return player;
        }

        public static Player CreatePlayerFromXMLString (string _xmlPlayerData)
        {
            try
            {
                XmlDocument playerData = new();
                playerData.LoadXml(_xmlPlayerData);
                int currentHitPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentHitPoints").InnerText);
                int maximumHitPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/MaximumHitPoints").InnerText);
                int gold = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Gold").InnerText);
                int experiencePoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/ExperiencePoints").InnerText);
                int level = Convert.ToInt32(playerData.SelectSingleNode("Player/Stats/Level").InnerText);
                int currentLocationID = Convert.ToInt32(playerData.SelectSingleNode("Player/Stats/CurrentLocation").InnerText);

                Player player = new Player(currentHitPoints, maximumHitPoints, gold, experiencePoints, level);
                player.CurrentLocation = ObjectMapper.ReturnLocationByID(currentLocationID);

                foreach (XmlNode node in playerData.SelectNodes("/Player/InventoryItems/InventoryItem"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    int quantity = Convert.ToInt32(node.Attributes["Quantity"].Value);
                    player.AddItemToInventory(ObjectMapper.ReturnItemByID(id), quantity);
                }

                foreach (XmlNode node in playerData.SelectNodes("/Player/PlayerQuests/PlayerQuest"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    bool isCompleted = Convert.ToBoolean(node.Attributes["IsCompleted"].Value);
                    PlayerQuest quest = new PlayerQuest(ObjectMapper.ReturnQuestByID(id));
                    quest.IsCompleted = isCompleted;
                    player.Quests.Add(quest);
                }

                player._curState = (CombatState)Enum.Parse(typeof(CombatState), playerData.SelectSingleNode("Player/PlayerCombatState").InnerText);

                player.SetExpToNextLevel();
                return player;
            }
            catch
            {
                return CreateDefaultPlayer();
            }
        }

        public void MoveTo(Location _newLocation)
        {
            CurrentLocation = _newLocation;
        }

        public bool CheckIfYouCanEnterLocation (Location _newLocation)
        {
            if (_newLocation.ItemRequiredToEnter == null)
            {
                return true;
            }
            return Inventory.Exists(item => item.Details.ID == _newLocation.ItemRequiredToEnterID);
        }

        public bool CheckIfThereIsQuest(Quest q)
        {
            bool isQuestHere = false;
            if (q != null)
            {
                isQuestHere = true;
            }
            return isQuestHere;
        }
        public bool CheckIfThereIsQuestInLog(Quest q)
        {
            return Quests.Exists(pq => pq.Details.ID == q.ID);
        }
        public void PickUpQuest(Quest q)
        {
            if (CheckIfThereIsQuest(q))
            {
                if (!CheckIfThereIsQuestInLog(q))
                {
                    PlayerQuest quest = new (q);
                    Quests.Add(quest);
                }
            }
        }

        public void UsePotion(HealingPotion potion)
        {
            foreach(InventoryItem item in Inventory.ToList())
            {
                if (item.Details == potion)
                {
                    item.Quantity--;
                    HealPlayer(potion.AmountToHeal);
                    RemoveFromInventory(item);
                }
            }
        }

        private void RemoveFromInventory(InventoryItem item)
        {
            if (item.Quantity == 0)
            {
                Inventory.Remove(item);
            }
        }

        public void HealPlayer (int quantity)
        {
            if (CurrentHitPoints + quantity >= MaximumHitPoints)
            {
                CurrentHitPoints = MaximumHitPoints;
            } else
            {
                CurrentHitPoints += quantity;
            }
        }

        public override int Attack(LivingCreature defender, Weapon equippedWeapon)
        {
            int damage = RandomNumberGenerator.GenerateNumber(equippedWeapon.MinimumDamage, equippedWeapon.MaximumDamage);
            if (defender.CurrentHitPoints - damage <= 0)
            {
                defender.CurrentHitPoints = 0;
            } else
            {
                defender.CurrentHitPoints -= damage;
            }
            return damage;
        }

        public void AddItemToInventory(Item itemToAdd, int quantity)
        {
            InventoryItem item = Inventory.SingleOrDefault(i => i.Details.ID == itemToAdd.ID);
            if (item == null)
            {
                Inventory.Add(new InventoryItem(itemToAdd, quantity));
            } else
            {
                item.Quantity += quantity;
            }
        }

        private void SetExpToNextLevel()
        {
            ExpToNextLevel = (5 * Level + 5) / 2;
        }

        public bool LevelUp()
        {
            if (ExperiencePoints >= ExpToNextLevel)
            {
                Level++;
                MaximumHitPoints += 8;
                CurrentHitPoints = MaximumHitPoints;
                ExperiencePoints = 0;
                SetExpToNextLevel();
                return true;
            }
            return false;
        }

        private bool HasQuestCompletionItems(Quest q)
        {

            var itemsExistQuery = from qci in q.QuestCompletionItems
                                  join item in Inventory
                                  on qci.Details.ID equals item.Details.ID
                                  where qci.Quantity <= item.Quantity
                                  select item;
           if (!itemsExistQuery.Any())
           {
                return false;
           }
           return true;
            
        }

        private void RemoveQuestCompletionItems(Quest q)
        {                        
            foreach (QuestCompletionItem qci in q.QuestCompletionItems)
            {

                foreach (InventoryItem item in Inventory)
                {
                    if (item.Details.ID == qci.Details.ID)
                    {
                        item.Quantity -= qci.Quantity;
                        RemoveFromInventory(item);
                        break;
                    }
                }
            }
        }

        public bool CheckIfQuestIsCompleted(Quest q)
        {
            return Quests.Exists(pq => pq.Details.ID == q.ID && pq.IsCompleted == true);
        }

        public bool CompleteQuest(Quest q)
        {
            if (!CheckIfQuestIsCompleted(q))
            {
                if (HasQuestCompletionItems(q))
                {
                    AddItemToInventory(q.RewardItem, 1);
                    Gold += q.RewardGold;
                    GainExperience(q.RewardExperience);
                    RemoveQuestCompletionItems(q);
                    Quests = Quests.Where(pq => q.ID == pq.Details.ID).Select(pq =>
                    {
                        pq.IsCompleted = true;
                        return pq;

                    }).ToList();
                    return true;
                }
            }
            return false;
        }

        public void GainExperience(int experience)
        {
            ExperiencePoints += experience;
            LevelUp();
        }

        public int ReturnQuantity (Item item)
        {
            return Inventory.Where(it => it.Details.ID == item.ID).Select(it => it.Quantity).FirstOrDefault();
        }

    }
}
