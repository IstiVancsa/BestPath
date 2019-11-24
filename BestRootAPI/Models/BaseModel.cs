using System;
using System.Collections;
using System.Collections.Generic;

namespace Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }

        public object this[string propertyName]
        {
            get
            {
                System.Reflection.PropertyInfo property = GetType().GetProperty(propertyName);
                return property.GetValue(this, null);
            }
            set
            {
                System.Reflection.PropertyInfo property = GetType().GetProperty(propertyName);
                property.SetValue(this, value, null);
            }
        }

        public abstract IList<BaseModel> CreateSeeds(int numberOfSeeds);
    }
}