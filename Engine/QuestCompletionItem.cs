using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestCompletionItem
    {
        public int ItemID { get; set; }
        public Item Details { get; set; }
        public int Quantity { get; set; }
        public QuestCompletionItem(int _itemId, int _quantity)
        {
            ItemID = _itemId;
            Quantity = _quantity;
        }
    }
}
