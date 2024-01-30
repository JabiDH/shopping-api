using ShoppingCart.Dtos.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Categories
{
    public class DeleteCategoryResponseDto : BaseResponseDto
    {
        public CategoryDto Category { get; set; }
    }
}
