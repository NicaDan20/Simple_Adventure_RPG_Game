using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class LivingCreature : INotifyPropertyChanged
    {
        private int _currentHitPoints;
        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            set { 
                _currentHitPoints = value;
                OnPropertyChanged("CurrentHitPoints");
                OnPropertyChanged("HitPoints");
            }
        }
        private int _maximumHitPoints;
        public int MaximumHitPoints
        {
            get { return _maximumHitPoints; }
            set
            {
                _maximumHitPoints = value;
                OnPropertyChanged("MaximumHitPoints");
                OnPropertyChanged("HitPoints");
            }
        }

        public string HitPoints
        {
            get { return CurrentHitPoints.ToString() + "/" + MaximumHitPoints.ToString(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged (string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public LivingCreature(int _currentHitPoints, int _maxHitPoints)
        {
            CurrentHitPoints = _currentHitPoints;
            MaximumHitPoints = _maxHitPoints;
        }

        public LivingCreature(LivingCreature _creature)
        {
            CurrentHitPoints = _creature.CurrentHitPoints;
            MaximumHitPoints = _creature.MaximumHitPoints;
        }

        public virtual int Attack(LivingCreature defender, Weapon equippedWeapon = null) { return 0; }
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
