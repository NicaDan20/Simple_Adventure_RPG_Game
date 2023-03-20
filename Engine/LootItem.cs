using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem
    {
        public int ItemId { get; set; }
        public int DropChance { get; set; }
        public bool IsDefaultItem { get; set; }
        public Item Details { get; set; }
        public void MapItemToID(int _itemId)
        {
            foreach (Item item in World.Items)
            {
                if (item.ID == _itemId)
                {
                    Details = item;
                    break;
                }
            }
        }
        public LootItem (int _itemId, int _dropChance, bool _isDefaultItem)
        {
            ItemId = _itemId;
            DropChance = _dropChance;
            IsDefaultItem = _isDefaultItem;
        }
    }
}
