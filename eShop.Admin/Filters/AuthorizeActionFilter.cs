using eShop.DataTransferObject;
using eShop.DomainService.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Filters
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        IUserDomainService _auth;
        Guid _sessionID;
        public AuthorizeActionFilter(IUserDomainService auth)
        {
            _auth = auth;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                //if (context.HttpContext.Request.Headers.ContainsKey("x-SessionID"))
                //{
                //_sessionID = Guid.Parse(context.HttpContext.Request.Headers["x-SessionID"]);
                _sessionID = Guid.Parse(context.HttpContext.Session.GetString("SessionID"));
                    bool isAuthorized = _auth.ChekSessionIsValid(_sessionID);
                    if (!isAuthorized)
                    {
                        #region For Web API
                        // context.HttpContext.Response.StatusCode = 500;
                        // ExceptionDTO Responce = new ExceptionDTO();
                        // //Responce.BaseID = Guid.Empty;
                        // Responce.Messages.Add("SESSIONID_IS_INCORECT");
                        // //Responce.Add("SESSIONID_IS_INCORECT", ValidationResultEnum.SESSION_IS_WRONG, "SESSION_IS_INCORECT");
                        // JsonResult jsonResult = new JsonResult(Responce);
                        ////JsonResult jsinResult = new JsonResult(Responce.ListToValue());

                        //context.Result = jsonResult;
                        #endregion
                        context.Result = new RedirectResult("~/auth/login");

                    }
                #region For Web API

                //}
                //else
                //{
                //    #region For Web API
                //    // context.HttpContext.Response.StatusCode = 500;
                //    // ExceptionDTO Responce = new ExceptionDTO();
                //    // //Responce.BaseID = Guid.Empty;
                //    // Responce.Messages.Add("SESSIONID_IS_INCORECT");
                //    // //Responce.Add("SESSIONID_IS_INCORECT", ValidationResultEnum.SESSION_IS_WRONG, "SESSION_IS_INCORECT");
                //    // JsonResult jsonResult = new JsonResult(Responce);
                //    ////JsonResult jsinResult = new JsonResult(Responce.ListToValue());

                //    //context.Result = jsonResult;
                //    #endregion
                //    context.Result = new RedirectResult("~/auth/login");

                //}
                #endregion

            }
            catch
            {

                #region For Web API
                // context.HttpContext.Response.StatusCode = 500;
                // ExceptionDTO Responce = new ExceptionDTO();
                // //Responce.BaseID = Guid.Empty;
                // Responce.Messages.Add("SESSIONID_IS_INCORECT");
                // //Responce.Add("SESSIONID_IS_INCORECT", ValidationResultEnum.SESSION_IS_WRONG, "SESSION_IS_INCORECT");
                // JsonResult jsonResult = new JsonResult(Responce);
                ////JsonResult jsinResult = new JsonResult(Responce.ListToValue());

                //context.Result = jsonResult;
                #endregion
                context.Result = new RedirectResult("~/auth/login");

            }
        }
    }
}
