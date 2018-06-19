using System;

namespace SpyrosORM.DataAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DbColumnAttribute : Attribute
    {
        public string Name { get; private set; }

        public DbColumnAttribute(string name)
        {
            this.Name = name;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DataRelationAttribute : Attribute
    {


    }
}