using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Models;

namespace Interfaces
{
    public interface IBaseDataContext<TModel>
    where TModel: BaseModel, new()
    {
        IDbSet<TModel> Items { get; set; }

    }
}
