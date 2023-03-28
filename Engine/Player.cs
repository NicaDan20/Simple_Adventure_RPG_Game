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
            } else
            {
                foreach (InventoryItem item in Inventory)
                {
                    if (item.Details == _newLocation.ItemRequiredToEnter)
                    {
                        return true;
                    }
                }
                return false;
            }
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
            bool isQuestHere = false;
            foreach (PlayerQuest pq in Quests)
            {
                if (pq.Details == q)
                {
                    isQuestHere = true;
                    break;
                }
            }
            return isQuestHere;
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
                    if (item.Quantity == 0)
                    {
                        Inventory.Remove(item);
                    }
                }
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

        public override void Attack(LivingCreature defender, Weapon equippedWeapon)
        {
            int damage = RandomNumberGenerator.GenerateNumber(equippedWeapon.MinimumDamage, equippedWeapon.MaximumDamage);
            if (defender.CurrentHitPoints - damage <= 0)
            {
                defender.CurrentHitPoints = 0;
            } else
            {
                defender.CurrentHitPoints -= damage;
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            foreach(InventoryItem item in Inventory)
            {
                if (item.Details.ID == itemToAdd.ID)
                {
                    item.Quantity++;
                    return;

                }
            }
            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

    }
}
