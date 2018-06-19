using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyrosORM.DataAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public  class IsKeyAttribute : Attribute
    {
        public bool Status { get; }

        public IsKeyAttribute(bool status = true)
        {
            Status = status;
        }
    }
}
