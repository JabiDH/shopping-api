﻿using ShoppingCart.Dtos.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Items
{
    public class GetItemResponseDto : BaseResponseDto
    {
        public ItemDto? Item { get; set; }
    }
}
