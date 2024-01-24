using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Common.Responses
{
    public abstract class BaseResponseDto
    {
        public virtual string? Error { get; set; } = null;
        public virtual bool Succeeded { get { return Error == null; } }
    }
}
