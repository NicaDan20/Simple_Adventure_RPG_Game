﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExperience { get; set; }
        public int RewardGold { get; set; }
        public Item RewardItem { get; set; }
        public List<QuestCompletionItem> QuestCompletionItems { get; set; }

        public Quest(int _id, string _name, string _description, int _rewardExperience, int _rewardGold, Item _rewardItem = null)
        {
            ID = _id;
            Name = _name;
            Description = _description;
            RewardExperience = _rewardExperience;
            RewardGold = _rewardGold;
            RewardItem = _rewardItem;
            QuestCompletionItems = new List<QuestCompletionItem>();

        }
    }
}
