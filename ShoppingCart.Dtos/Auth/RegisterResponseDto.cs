using ShoppingCart.Dtos.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Auth
{
    public class RegisterResponseDto : BaseResponseDto
    {        
        public string Email { get; set; }
    }
}
