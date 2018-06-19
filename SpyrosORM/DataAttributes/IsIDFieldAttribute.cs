using System;

namespace SpyrosORM.DataAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class IsIDFieldAttribute : Attribute
    {
        public bool Status { get; }

        public IsIDFieldAttribute(bool status = true)
        {
            this.Status = status;
        }
    }
}