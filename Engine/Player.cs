﻿using System;
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
            Quests = new List<PlayerQuest>();
        }
        public void MoveTo(Location _newLocation)
        {
            CurrentLocation = _newLocation;
        }

        public bool checkIfThereIsQuest(Quest q)
        {
            bool isQuestHere = false;
            if (q != null)
            {
                isQuestHere = true;
            }
            return isQuestHere;
        }
        public bool checkIfThereIsQuestInLog(Quest q)
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
        public void pickUpQuest(Quest q)
        {
            if (checkIfThereIsQuest(q))
            {
                if (!checkIfThereIsQuestInLog(q))
                {
                    PlayerQuest quest = new PlayerQuest(q);
                    Quests.Add(quest);
                }
            }
        }
    }
}
