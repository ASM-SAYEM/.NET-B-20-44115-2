using BAL.DTOs;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TerraceGardenManagement.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        [Route("api/Client/All")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ClientService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Client/name/{name}")]
        public HttpResponseMessage GetClient(string name)
        {
            try
            {
                var data = ClientService.Get(name);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);



            }
        }



        [HttpPost]
        [Route("api/Client/add")]
        public HttpResponseMessage AddClients(ClientDTO sp)
        {
            try
            {
                var res = ClientService.Create(sp);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/Client/update")]
        public HttpResponseMessage UpdateFeedback(ClientDTO sp)
        {
            try
            {
                var res = ClientService.Update(sp);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        [HttpDelete]
        [Route("api/Client/delete/{uname}")]
        public HttpResponseMessage Delete(string uname)
        {
            try
            {
                var res = ClientService.Delete(uname);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }



        }
    }
}
