using System;

namespace SpyrosORM.DataAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class AllowNullAttribute : Attribute
    {
        public bool Status { get; private set; }

        public AllowNullAttribute(bool status = true)
        {
            this.Status = status;
        }
    }

   
}