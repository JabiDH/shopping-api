using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.CustomAttributes
{
    public class EnumStringValueAttribute : Attribute
    {
        public string Value { get; }
        public EnumStringValueAttribute(string value) 
        {
            this.Value = value;
        }
    }
}
