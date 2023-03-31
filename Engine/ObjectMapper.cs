using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    // ObjectMapper class returns items, monsters, quests or locations based on their ID
    public static class ObjectMapper
    {
        public static Item ReturnItemByID(int _itemId)
        {
            foreach (Item item in World.Items)
            {
                if (item.ID == _itemId)
                {
                    return item;
                }
            }
            return null;
        }

        public static Quest ReturnQuestByID (int _questId)
        {
            foreach (Quest quest in World.Quests)
            {
                if (quest.ID == _questId)
                {
                    return quest;
                }
            }
            return null;
        }

        public static Monster ReturnMonsterByID (int _monsterID)
        {
            foreach (Monster monster in World.Monsters)
            {
                if (monster.ID == _monsterID)
                {
                    return monster;
                }
            }
            return null;
        }

        public static AdjacentLocation MapLocationsToDirectionID (AdjacentLocation adjacent, List<Location> locations)
        {
            AdjacentLocation y = adjacent;
            foreach (Location location in locations)
            {
                if (location.ID == adjacent.EastID)
                {
                    y.LocationToEast = location;
                }
                if (location.ID == adjacent.NorthID)
                {
                    y.LocationToNorth = location;
                }
                if (location.ID == adjacent.WestID)
                {
                    y.LocationToWest = location;
                }
                if (location.ID == adjacent.SouthID)
                {
                    y.LocationToSouth = location;
                }
            }
            return y;
        }

        public static Location ReturnLocationByID(int id)
        {
            foreach(Location location in World.Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }
            return null;
        }

    }
}
