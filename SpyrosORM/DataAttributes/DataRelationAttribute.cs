using System;

namespace SpyrosORM.DataAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DataRelationAttribute : Attribute
    {
        public string Name { get; set; }

        public string ThisKey { get; set; }
    }

}