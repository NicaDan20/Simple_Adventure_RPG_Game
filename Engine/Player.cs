using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int ExpToNextLevel { get; set; }
        public int Level { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
        public Location CurrentLocation { get; set; }
        public Player(int _currentHitPoints, int _maxHitPoints, int _gold, int _experiencePoints, int _level) : base(_currentHitPoints, _maxHitPoints)
        {
            Gold = _gold;
            ExperiencePoints = _experiencePoints;
            Level = _level;
            Inventory = new List<InventoryItem>();
            InventoryItem _startingWeapon = new (ObjectMapper.ReturnItemByID(1), 1);
            //InventoryItem _startingWeapon2 = new InventoryItem(ObjectMapper.ReturnItemByID(6), 1);
            InventoryItem _startingPotion1 = new (ObjectMapper.ReturnItemByID(10), 3);
            //InventoryItem _startingPotion2 = new InventoryItem(ObjectMapper.ReturnItemByID(13), 2);
            Inventory.Add(_startingWeapon);
            //Inventory.Add(_startingWeapon2);
            Inventory.Add(_startingPotion1);
            //Inventory.Add(_startingPotion2);
            InventoryItem _adventurerPass = new(ObjectMapper.ReturnItemByID(11), 1);
            Inventory.Add(_adventurerPass);
            Quests = new List<PlayerQuest>();
            SetExpToNextLevel();
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
            foreach(InventoryItem item in Inventory)
            {
                if (item.Details.ID == itemToAdd.ID)
                {
                    item.Quantity += quantity;
                    return;

                }
            }
            Inventory.Add(new InventoryItem(itemToAdd, quantity));
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
