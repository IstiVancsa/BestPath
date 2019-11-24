using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Interfaces;
using Interfaces.IFilterModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BestRootAPI.Controllers
{
    //[KeyAPIAuthorize] TODO to be activated when finished to implemed KeyApiAuthorize
    public class BaseApiController<TModel, TRepository, TFilterModel> : ControllerBase
        where TModel : BaseModel, new()
        where TRepository : class, IGenericRepository<TModel>
        where TFilterModel : class, IFilterModel<TModel>
    {
        //public int LoggedUserId => Convert.ToInt32(System.Web.HttpContext.Current.Session["EmployeeId"].ToString()); TODO same goes here
        public Expression<Func<TModel, TModel>> GetByFilterSelector = null;
        public TRepository EntityRepository { get; }

        public BaseApiController(TRepository entityRepository)
        {
            EntityRepository = entityRepository;
        }

        [System.Web.Http.Route("GetDefault")]
        public IEnumerable<TModel> GetDefault()
        {
            return EntityRepository.GetItems(q => true).ToList();
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Http.Route("GetByFilter")]
        public virtual IEnumerable<TModel> GetByFilter([FromUri]TFilterModel filter)
        {
            Expression<Func<TModel, bool>> predicate = x => true;
            if (filter != null)
                predicate = filter.GetFilter();

            return EntityRepository
                        .GetItems(predicate)
                        .Select(GetByFilterSelector)
                        .ToList();
        }
    }

}