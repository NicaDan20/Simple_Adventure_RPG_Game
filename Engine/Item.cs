﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSubTypes;

namespace Engine
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(Weapon), "WEAPON")]
    [JsonSubtypes.KnownSubType(typeof(HealingPotion), "HEALING_POTION")]
    [JsonSubtypes.KnownSubType(typeof(MiscItem), "MISC")]
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public virtual string Type
        {
            get;
        }

        public Item (int _id, string _name, string _namePlural)
        {
            ID = _id;
            Name = _name;
            NamePlural = _namePlural;
        }
    }
}
