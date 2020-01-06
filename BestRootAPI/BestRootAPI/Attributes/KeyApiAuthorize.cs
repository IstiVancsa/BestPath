using Interfaces;
using System.Web.Http.Controllers;

namespace BestRootAPI.Attributes
{
    public class KeyAPIAuthorize
    {
        protected IUserRepository UserRepository;
        public void OnActionExecuting(HttpActionContext actionContext)
        {
            //TODO Something like this - we need to see how to store UserId in session memory
            //System.Web.HttpContext.Current.Session["UserId"] = null;
            var controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = actionContext.ActionDescriptor.ActionName;

            //Exception when the request will be passed without checking authorization
            //if (controllerName.ToUpper() == "USER" && actionName.ToUpper() == "POSTLOGIN")
            //    return;

            //if (actionContext.Request.Headers.Authorization != null)
            //{
            //    var token = actionContext.Request.Headers.Authorization.Scheme;
            //    Entities.User user;
            //    using (var dbCtx = new BaseDataContext())
            //    {
            //        this.UserRepository = new UserRepository();
            //        user = this.UserRepository.GetItem(x => x.Token == new Guid(token));
            //    }

            //    if (user == null)
            //        actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            //    //else
            //    //    System.Web.HttpContext.Current.Session["UserId"] = user.Id;
            //}
            //else
            //    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

        }


    }
}