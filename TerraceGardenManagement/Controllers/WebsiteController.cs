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
    public class WebsiteController : ApiController
    {
        [HttpGet]
        [Route("api/Website/All")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = WebsiteService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Website/{id:int}")]
        public HttpResponseMessage GetFeedback(int id)
        {
            try
            {
                var data = WebsiteService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);



            }
        }



        [HttpPost]
        [Route("api/Website/add")]
        public HttpResponseMessage Add(WebsiteDTO sp)
        {
            try
            {
                var res = WebsiteService.Create(sp);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        //[HttpPost]
        //[Route("api/Website/update")]
        //public HttpResponseMessage UpdateFeedback(ClientDTO sp)
        //{
        //    try
        //    {
        //        var res = ClientService.Update(sp);
        //        return Request.CreateResponse(HttpStatusCode.OK, res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}




        [HttpDelete]
        [Route("api/Client/delete/{id:int}")]
        public HttpResponseMessage DeleteFeedback(int id)
        {
            try
            {
                var res = WebsiteService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }



        }
    }
}
