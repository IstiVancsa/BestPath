using Entities;
using System;

namespace Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public abstract BaseEntity GetEntity();
    }
}