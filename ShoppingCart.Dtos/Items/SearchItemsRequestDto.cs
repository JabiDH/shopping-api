using ShoppingCart.Dtos.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Items
{
    public class SearchItemsRequestDto
    {
        public string? FilterOn { get; set; }
        public string? FilterQuery { get; set; }
        public string? SortBy { get; set; }
        public bool? IsAscending { get; set; }
        public int PageNo { set; get; }
        public int PageSize { set; get; }
    }
}
