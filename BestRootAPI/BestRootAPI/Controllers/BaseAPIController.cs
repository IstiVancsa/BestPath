using BestRootAPI.Attributes;
using Entities;
using Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.DTO;
using Models.IFilterModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Utils;

namespace BestRootAPI.Controllers
{
    [APITokenGeneratorActionFilter]
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class BaseApiController<TModel, TEntity, TRepository, TFilterModel> : ControllerBase, IBaseApiController
        where TModel : BaseModel, new()
        where TEntity : BaseEntity, new()
        where TRepository : class, IGenericRepository<TEntity>
        where TFilterModel : class, IFilterModel<TEntity>
    {
        protected readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;
        public string APIPath => Configuration["APIPaths:BestPathAPI"];
        public IConfiguration Configuration { get; }

        //public int LoggedUserId => Convert.ToInt32(System.Web.HttpContext.Current.Session["EmployeeId"].ToString()); TODO same goes here
        public Expression<Func<TEntity, TModel>> GetByFilterSelector = null;

        public TRepository GenericRepository { get; }
        public string NewToken { get; set; }

        public BaseApiController(TRepository genericRepository, IConfiguration configuration, Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager)
        {
            GenericRepository = genericRepository;
            Configuration = configuration;
            _userManager = userManager;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetDefault")]
        public IActionResult GetDefault()
        {
            var result = new GetDefaultResult<TModel> 
            { 
                Items = GenericRepository.GetItems(q => true).Select(GetByFilterSelector).ToList()
            };
            result.AddToken(this.HttpContext);
            return new JsonResult(result);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetByFilter")]
        public IActionResult GetByFilter([FromQuery]TFilterModel filter)
        {
            Expression<Func<TEntity, bool>> predicate = x => true;
            if (filter != null)
                predicate = filter.GetFilter();

            var result = new GetByFilterResult<TModel>
            {
                Items = GenericRepository
                        .GetItems(predicate)
                        .Select(GetByFilterSelector)
                        .ToList()
            };
            result.AddToken(this.HttpContext);

            return new JsonResult(result);
        }

    }
}