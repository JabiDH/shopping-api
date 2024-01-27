using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Models.DataModels
{
    public class ItemImage
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public long ItemId { get; set; }
        public Item Item { get; set; }
    }
}
