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
    public class FeedbackController : ApiController
    {
        [HttpGet]
        [Route("api/Feedback")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = FeedbackService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Feedback/{id:int}")]
        public HttpResponseMessage GetM(int id)
        {
            try
            {
                var data = FeedbackService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);



            }
        }



        [HttpPost]
        [Route("api/Feedback/add")]
        public HttpResponseMessage AddMembers(FeedbackDTO feedback)
        {
            try
            {
                var res = FeedbackService.Add(feedback);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/Feedback/update")]
        public HttpResponseMessage UpdateFeedback(FeedbackDTO feedback)
        {
            try
            {
                var res = FeedbackService.Update(feedback);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        [HttpDelete]
        [Route("api/Feedback/delete/{id:int}")]
        public HttpResponseMessage DeleteFeedback(int id)
        {
            try
            {
                var res = FeedbackService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }



        }
    }
}
