using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem
    {
        public Item Details { get; set; }
        public int DropChance { get; set; }
        public bool isDefaultItem { get; set; }
        public LootItem (Item _details, int _dropChance, bool _isDefaultItem)
        {
            Details = _details;
            DropChance = _dropChance;
            isDefaultItem = _isDefaultItem;
        }
    }
}
