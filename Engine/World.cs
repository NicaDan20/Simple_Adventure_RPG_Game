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
        }
        public static List<Item> PopulateItems()
        {
            System.Console.WriteLine("Hi");
            using (StreamReader file = File.OpenText(@"C:\Users\danut\source\repos\Simple_Adventure_RPG_Game\data\Items.json"))
            {
                try
                {
                    string json = file.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<List<Item>>(json) ;
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
                    foreach(Monster m in monsters)
                    {
                        foreach (LootItem it in m.LootTable)
                        {
                            it.MapItemToID(it.ItemId);
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


    }
}
