using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSubTypes;
using System.IO;
using System.Diagnostics;

namespace Engine
{
    // Static world class, this holds all the information about monsters, items, quests and locations
    public static class World
    {
        public static readonly List<Item> Items = new();
        public static readonly List<Monster> Monsters = new();
        public static readonly List<Quest> Quests = new();
        public static readonly List<Location> Locations = new();
        static World()
        {
            Items = PopulateItems();
            Monsters = PopulateMonsters();
            Quests = PopulateQuests();
            Locations = PopulateLocations();
        }
        // Items are loaded from a json file
        public static List<Item> PopulateItems()
        {
            using (StreamReader file = File.OpenText(@"C:\Users\danut\source\repos\Simple_Adventure_RPG_Game\data\Items.json"))
            {
                try
                {
                    string json = file.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<List<Item>>(json);
                    return items;
                } catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                    return null;
                }
            }
        }
        // Monsters are loaded from a json file
        public static List<Monster> PopulateMonsters()
        {
            using (StreamReader file = File.OpenText(@"C:\Users\danut\source\repos\Simple_Adventure_RPG_Game\data\Monsters.json"))
            {
                try
                {
                    string json = file.ReadToEnd();
                    var monsters = JsonConvert.DeserializeObject<List<Monster>>(json);
                    foreach (Monster m in monsters)
                    {
                        foreach (LootItem it in m.LootTable)
                        {
                            it.Details = ObjectMapper.ReturnItemByID(it.ItemId);
                        }
                        Trace.WriteLine(m.LootTable[0].Details.Name);
                    }
                    return monsters;
                } catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                    return null;
                }
            }
        }
        // Quests are loaded from a json file
       public static List<Quest> PopulateQuests()
        {
            using (StreamReader file = File.OpenText(@"C:\Users\danut\source\repos\Simple_Adventure_RPG_Game\data\Quests.json"))
            {
                try
                {
                    string json = file.ReadToEnd();
                    var quests = JsonConvert.DeserializeObject<List<Quest>>(json);
                    foreach (Quest q in quests)
                    {
                        foreach (QuestCompletionItem it in q.QuestCompletionItems)
                        {
                            it.Details = ObjectMapper.ReturnItemByID(it.ItemID);
                        }
                        q.RewardItem = ObjectMapper.ReturnItemByID(q.RewardItemID);
                        Trace.WriteLine(q);
                    }
                    return quests;
                } catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                    return null;
                }
            }
        }
        // Locations are loaded from a json file
        public static List<Location> PopulateLocations()
        {
            using (StreamReader file = File.OpenText(@"C:\Users\danut\source\repos\Simple_Adventure_RPG_Game\data\Locations.json"))
            {
                try
                {
                    string json = file.ReadToEnd();
                    var locations = JsonConvert.DeserializeObject<List<Location>>(json);
                    foreach(Location l in locations)
                    {
                        l.ItemRequiredToEnter = ObjectMapper.ReturnItemByID(l.ItemRequiredToEnterID);
                        l.MonsterLivingHere = ObjectMapper.ReturnMonsterByID(l.MonsterLivingHereID);
                        l.QuestAvailableHere = ObjectMapper.ReturnQuestByID(l.QuestAvailableHereID);
                        l.AdjacentLocations = ObjectMapper.MapLocationsToDirectionID(l.AdjacentLocations, locations);
                    }
                    return locations;
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                    return null;
                }
            }
        }


    }
}
