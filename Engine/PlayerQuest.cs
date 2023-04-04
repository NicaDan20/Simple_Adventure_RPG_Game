using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class PlayerQuest : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private Quest _details;
        public Quest Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged("Details");
            }
        }

        public string Description
        {
            get { return Details.Description; }
        }

        private bool _isCompleted;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged("IsCompleted");
                OnPropertyChanged("Description");
                OnPropertyChanged("Name");
            }
        }

        public string Name
        {
            get { return Details.Name; }
        }

        public PlayerQuest (Quest _details)
        {
            Details = _details;
            IsCompleted = false;
        }

    }
}
