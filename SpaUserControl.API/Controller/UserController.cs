using SpaUserControl.Api.Attributes;
using SpaUserControl.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace SpaUserControl.API.Controller
{
    [RoutePrefix("api/customers")]
    public class UserController : ApiController
    {
        private IUserServices _service;

        public UserController(IUserServices service)
        {
            _service = service;
        }


        // GET: User
        [HttpGet]
        [Route("")]
        [DeflateCompression]
        public Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result =  _service.GetByRange(0, 25);
                response = Request.CreateResponse(HttpStatusCode.OK, result);


            }catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsk = new TaskCompletionSource<HttpResponseMessage>();
            tsk.SetResult(response);
            return tsk.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }

    }
}