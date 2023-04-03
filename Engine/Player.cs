﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Engine
{
    // The game's combat is turn based, where the player and the monster take turns each. The monster will always attack
    // the player during its turn, but the player can either heal or attack the monster
    // The enum tracks the different states of combat, such as when it's the player's turn, or the monster's turn
    // or the player/monster are dead
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
        public Weapon EquippedWeapon { get; set; }
        public HealingPotion EquippedPotion { get; set; }
        private Player(int _currentHitPoints, int _maxHitPoints, int _gold, int _experiencePoints, int _level) : base(_currentHitPoints, _maxHitPoints)
        {
            Gold = _gold;
            ExperiencePoints = _experiencePoints;
            Level = _level;
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }
        // Default player factory; this function is loaded when we start a new game
        // we create a new player and move him to the location specified
        public static Player CreateDefaultPlayer()
        {
            Player player = new Player(15, 15, 10, 0, 1);
            player.Inventory.Add(new InventoryItem(ObjectMapper.ReturnItemByID(1), 1));
            player.Inventory.Add(new InventoryItem(ObjectMapper.ReturnItemByID(9), 1));
            player.Inventory.Add(new InventoryItem(ObjectMapper.ReturnItemByID(10), 3));
            player.Inventory.Add(new InventoryItem(ObjectMapper.ReturnItemByID(13), 3));
            player.CurrentLocation = ObjectMapper.ReturnLocationByID(1);
            player._curState = CombatState.NotInCombat;
            player.SetExpToNextLevel();
            return player;
        }

        // PlayerFactory for when the player loads the game from XML
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

                if (playerData.SelectSingleNode("/Player/Stats/EquippedWeapon") != null)
                {
                    int equippedWeaponID = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/EquippedWeapon").InnerText);
                    player.EquippedWeapon = (Weapon)ObjectMapper.ReturnItemByID(equippedWeaponID);
                }

                if (playerData.SelectSingleNode("/Player/Stats/EquippedPotion") != null)
                {
                    int equippedPotionID = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/EquippedPotion").InnerText);
                    player.EquippedPotion = (HealingPotion)ObjectMapper.ReturnItemByID(equippedPotionID);
                }

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

        // Move function
        public void MoveTo(Location _newLocation)
        {
            CurrentLocation = _newLocation;
        }

        // Boolean function which checks whether a player can enter the new location
        public bool CheckIfYouCanEnterLocation (Location _newLocation)
        {
            if (_newLocation.ItemRequiredToEnter == null)
            {
                return true;
            }
            return Inventory.Exists(item => item.Details.ID == _newLocation.ItemRequiredToEnterID);
        }

        // Checks whether there is a quest in the area
        public bool CheckIfThereIsQuest(Quest q)
        {
            bool isQuestHere = false;
            if (q != null)
            {
                isQuestHere = true;
            }
            return isQuestHere;
        }
        // Checks whether there is a quest in the quest log
        public bool CheckIfThereIsQuestInLog(Quest q)
        {
            return Quests.Exists(pq => pq.Details.ID == q.ID);
        }
        // Pick up quest function
        public void PickUpQuest(Quest q)
        {
            // We check if the quest exists
            if (CheckIfThereIsQuest(q))
            {
                // We check if the quest is in the quest log or not
                if (!CheckIfThereIsQuestInLog(q))
                {
                    // If not, we add the quest in the quest log
                    PlayerQuest quest = new (q);
                    Quests.Add(quest);
                }
            }
        }

        // Function which is responsible with the scenario when the player is drinking a healing potion
        public void UsePotion(HealingPotion potion)
        {
            foreach(InventoryItem item in Inventory.ToList())
            {
                if (item.Details == potion)
                {
                    // We decrease the item quantity
                    item.Quantity--;
                    // We heal the player
                    HealPlayer(potion.AmountToHeal);
                    RemoveFromInventory(item);
                }
            }
        }

        // We check if the item quantity is 0, if so we remove the item
        private void RemoveFromInventory(InventoryItem item)
        {
            if (item.Quantity == 0)
            {
                Inventory.Remove(item);
            }
        }

        // Heal player function
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

        // Player attack function, the difference from the monster attack function is that the player's damage is derived from
        // the equipped weapon, whereas the monster's damage values are hard coded
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

        // Add item to inventory function
        public void AddItemToInventory(Item itemToAdd, int quantity)
        {
            InventoryItem item = Inventory.SingleOrDefault(i => i.Details.ID == itemToAdd.ID);
            if (item == null)
            {
                // If the item is not found in the inventory, we add it
                Inventory.Add(new InventoryItem(itemToAdd, quantity));
            } else
            {
                // If the item is already found in the inventory, we will increase it's quantity with the quantity specified as 
                // parameter
                item.Quantity += quantity;
            }
        }

        // Function which is called whenever the player levels up, this determines the amount of experience a player needs
        // until the next level;
        private void SetExpToNextLevel()
        {
            ExpToNextLevel = (5 * Level + 5) / 2;
        }

        // Level up function
        public bool LevelUp()
        {
            if (ExperiencePoints >= ExpToNextLevel)
            {
                // If the current experience points exceed the experience required to next level
                // we increase the level, we heal the player and increase the HP values, we reset
                // the Experience points back to 0
                Level++;
                MaximumHitPoints += 8;
                CurrentHitPoints = MaximumHitPoints;
                ExperiencePoints = 0;
                // And we calculate the next ExpToNextLevel
                SetExpToNextLevel();
                // and return a boolean value which the UI part will deal with later
                return true;
            }
            return false;
        }

        // Check if there we have the items required to complete the quest Q
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
        // Removes the items needed to complete the quest from the player's inventory
        // basically handing in the quest items
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

        //Check if the player has already completed the quest
        public bool CheckIfQuestIsCompleted(Quest q)
        {
            return Quests.Exists(pq => pq.Details.ID == q.ID && pq.IsCompleted == true);
        }

        // Complete quest function
        public bool CompleteQuest(Quest q)
        {
            // We first check if the quest hasn't been completed already
            if (!CheckIfQuestIsCompleted(q))
            {
                // We check if the player has the required items
                if (HasQuestCompletionItems(q))
                {
                    // We give the rewards (Items, gold, experience points)
                    AddItemToInventory(q.RewardItem, 1);
                    Gold += q.RewardGold;
                    GainExperience(q.RewardExperience);
                    RemoveQuestCompletionItems(q);
                    // And mark the quest as complete
                    Quests = Quests.Where(pq => q.ID == pq.Details.ID).Select(pq =>
                    {
                        pq.IsCompleted = true;
                        return pq;

                    }).ToList();
                    // And return a boolean value which the UI will deal with later 
                    return true;
                }
            }
            return false;
        }

        // When we gain experience, we check whether or not the player can Level Up
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
