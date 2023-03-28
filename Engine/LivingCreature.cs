﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LivingCreature
    {
        public int CurrentHitPoints { get; set; }
        public int MaximumHitPoints { get; set; }

        public LivingCreature(int _currentHitPoints, int _maxHitPoints)
        {
            CurrentHitPoints = _currentHitPoints;
            MaximumHitPoints = _maxHitPoints;
        }

        public virtual void Attack(LivingCreature defender, Weapon equippedWeapon = null) { }
        public bool IsAlive()
        {
            if (CurrentHitPoints <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
