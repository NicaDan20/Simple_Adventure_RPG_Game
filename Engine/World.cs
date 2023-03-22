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
        public static List<Item> PopulateItems()
        {
            System.Console.WriteLine("Hi");
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
                            it.Details = ObjectMapper.MapItemToID(it.ItemId);
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
                            it.Details = ObjectMapper.MapItemToID(it.ItemID);
                        }
                        q.RewardItem = ObjectMapper.MapItemToID(q.RewardItemID);
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
                        l.ItemRequiredToEnter = ObjectMapper.MapItemToID(l.ItemRequiredToEnterID);
                        l.MonsterLivingHere = ObjectMapper.MapMonsterToID(l.MonsterLivingHereID);
                        l.QuestAvailableHere = ObjectMapper.MapQuestToID(l.QuestAvailableHereID);
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
