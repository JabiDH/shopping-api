using ShoppingCart.Dtos.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Categories
{
    public class GetAllCategoriesResponseDto : BaseResponseDto
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
