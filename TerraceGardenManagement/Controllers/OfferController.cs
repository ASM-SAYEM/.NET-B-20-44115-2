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
    public class OfferController : ApiController
    {
        [HttpGet]
        [Route("api/Offer")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = OfferService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Offer/{id:int}")]
        public HttpResponseMessage Getoffers(int id)
        {
            try
            {
                var data = OfferService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);



            }
        }



        [HttpPost]
        [Route("api/Offer/add")]
        public HttpResponseMessage AddOffers(OfferDTO offer)
        {
            try
            {
                var res = OfferService.Create(offer);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/Offer/update")]
        public HttpResponseMessage UpdateOffer(OfferDTO os)
        {
            try
            {
                var res = OfferService.Update(os);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        [HttpDelete]
        [Route("api/OfferService/delete/{id:int}")]
        public HttpResponseMessage DeleteOffer(int id)
        {
            try
            {
                var res = OfferService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        /////////////////////////////////////
        //[HttpPost]
        //[Route("api/Offer/Create")]
        //public HttpResponseMessage CreateOffer(OfferDTO offer)
        //{
        //    try
        //    {
        //        var res = OfferService.CreateOffer(offer);
        //        return Request.CreateResponse(HttpStatusCode.OK, res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}
    }
}
