using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public Item ItemRequiredToEnter { get; set; }
        public Monster MonsterLivingHere { get; set; }
        public Quest QuestAvailableHere { get; set; }

        public Location LocationToNorth { get; set; }
        public Location LocationToWest { get; set; }
        public Location LocationToEast { get; set; }

        public Location LocationToSouth { get; set; }
        
        public Location(int _id, string _name, string _description, Item _itemRequiredToEnter = null, Quest _questAvailableHere = null, Monster _monsterLivingHere = null)
        {
            ID = _id;
            Name = _name;
            Description = _description;
            ItemRequiredToEnter = _itemRequiredToEnter;
            QuestAvailableHere = _questAvailableHere;
            MonsterLivingHere = _monsterLivingHere;
        }
    }
}

