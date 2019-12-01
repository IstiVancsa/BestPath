using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.IFilterModels;

namespace BestRootAPI.Controllers
{
    //[KeyAPIAuthorize] TODO to be activated when finished to implement KeyApiAuthorize
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class BaseApiController<TModel, TEntity, TRepository, TFilterModel> : ControllerBase
        where TModel : BaseModel, new()
        where TEntity : BaseEntity, new()
        where TRepository : class, IGenericRepository<TEntity>
        where TFilterModel : class, IFilterModel<TEntity>
    {
        //public int LoggedUserId => Convert.ToInt32(System.Web.HttpContext.Current.Session["EmployeeId"].ToString()); TODO same goes here
        public Expression<Func<TEntity, TModel>> GetByFilterSelector = null;

        public TRepository GenericRepository { get; }

        public BaseApiController(TRepository genericRepository)
        {
            GenericRepository = genericRepository;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetDefault")]
        public IActionResult GetDefault()
        {
            return new JsonResult(GenericRepository.GetItems(q => true).ToList());
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetByFilter")]
        public IActionResult GetByFilter([Microsoft.AspNetCore.Mvc.FromBody]TFilterModel filter)
        {
            Expression<Func<TEntity, bool>> predicate = x => true;
            if (filter != null)
                predicate = filter.GetFilter();

            return new JsonResult(GenericRepository
                        .GetItems(predicate)
                        .Select(GetByFilterSelector)
                        .ToList());
        }
    }

}