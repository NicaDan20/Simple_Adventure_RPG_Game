﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSubTypes;


namespace Engine
{
    public class HealingPotion : Item
    {
        private int _amountToHeal;
        public int AmountToHeal
        {
            get { return _amountToHeal; }
            set
            {
                _amountToHeal = value;
                OnPropertyChanged("AmountToHeal");
                OnPropertyChanged("AmountHealed");
            }
        }

        public string AmountHealed
        {
            get { return "Heals for: " + AmountToHeal.ToString(); }
        }

        public override string Type
        {
            get { return "HEALING_POTION"; }
        }
        public HealingPotion(int _id, string _name, string _namePlural, int _amountToHeal) : base(_id, _name, _namePlural)
        {
            AmountToHeal = _amountToHeal;
        }
    }
}
