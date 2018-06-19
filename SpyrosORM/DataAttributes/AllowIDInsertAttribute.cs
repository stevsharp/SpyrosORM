using System;

namespace SpyrosORM.DataAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class AllowIDInsertAttribute : Attribute
    {
        public bool Status { get; private set; }

        public AllowIDInsertAttribute(bool status = true)
        {
            this.Status = status;
        }
    }
}