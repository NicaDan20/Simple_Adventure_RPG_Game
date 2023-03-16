using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public Item (int _id, string _name, string _namePlural)
        {
            ID = _id;
            Name = _name;
            NamePlural = _namePlural;
        }
    }
}
