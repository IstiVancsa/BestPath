using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Models;

namespace Interfaces.IFilterModels
{
    public interface IFilterModel<TModel>
        where TModel : BaseModel, new()
    {
        Expression<Func<TModel, bool>> GetFilter();
    }
}
