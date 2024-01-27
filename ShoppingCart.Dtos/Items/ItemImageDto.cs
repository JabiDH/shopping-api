using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Items
{
    public class ItemImageDto
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public long ItemId { get; set; }
    }
}
