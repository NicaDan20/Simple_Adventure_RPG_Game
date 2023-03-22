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
        public AdjacentLocation AdjacentLocations { get; set; }
        public int ItemRequiredToEnterID { get; set; }
        public int MonsterLivingHereID { get; set; }
        public int QuestAvailableHereID { get; set; }

        public Location(int _id, string _name, string _description, int _itemRequiredToEnterID = 0, int _questAvailableHereID = 0, int _monsterLivingHereID = 0, int _northID = 0, int _southID = 0, int _eastID = 0, int _westID = 0)
        {
            ID = _id;
            Name = _name;
            Description = _description;
            ItemRequiredToEnterID = _itemRequiredToEnterID;
            QuestAvailableHereID = _questAvailableHereID;
            MonsterLivingHereID = _monsterLivingHereID;
            AdjacentLocations = new();
        }
    }
}

