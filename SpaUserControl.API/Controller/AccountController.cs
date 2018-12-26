using SpaUserControl.API.Models;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace SpaUserControl.API.Controller
{
    [RoutePrefix("api/account")]

    public class AccountController : ApiController
    {
        private IUserServices _services;

        public AccountController(IUserServices services)
        {
            _services = services;
        }

        //api/account - post
        [Route("")]
        [HttpPost]
        public Task<HttpResponseMessage> Register(RegisteruserModel model)
        {

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _services.Register(model.Name, model.Email, model.Password, model.ConfirmPassword);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Name, email = model.Email });
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
      
        }

        [Route("")]
        [HttpPut]
        [Authorize]
        public Task<HttpResponseMessage> ChangeInformation(ChangeInformationModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _services.ChangeInformation(User.Identity.Name, model.Name);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Name });
            }catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
           
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [Route("changepassword")]
        [HttpPost]
        [Authorize]
        public Task<HttpResponseMessage> ChangePassword(ChangePasswordModel model)
        {

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
            _services.ChangePassword(User.Identity.Name, model.Password, model.NewPassword, model.ConfirmPassword);

                response = Request.CreateResponse(HttpStatusCode.OK, new { Password = model.Password, NewPassword = model.NewPassword });

            }catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }


        [Route("resetpassword")]
        [HttpPost]
        public Task<HttpResponseMessage> ResetPassword(ResetPasswordModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _services.Resetpassword(model.Email);
                response = Request.CreateResponse(HttpStatusCode.OK, "Resetado");
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }


        protected override void Dispose(bool disposing)
        {
            _services.Dispose();
        }
    }
}