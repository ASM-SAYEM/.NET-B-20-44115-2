using BAL.DTOs;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using TerraceGardenManagement.AuthFilters;
using TerraceGardenManagement.Models;

namespace TerraceGardenManagement.Controllers
{
    [AdminAccess]
    public class AdminController : ApiController
    {
        
        [Logged]
        [HttpGet]
        [Route("api/Admin/All")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [Logged]
        [HttpGet]
        [Route("api/Admin/UserName/{UserName}")]
        public HttpResponseMessage GetM(string UserName)
        {
            try
            {
                var data = AdminService.Get(UserName);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);



            }
        }


        [Logged]
        [HttpPost]
        [Route("api/Admin/add")]
        public HttpResponseMessage AddMembers(AdminDTO sp)
        {
            try
            {
                var res = AdminService.Create(sp);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Logged]
        [HttpPost]
        [Route("api/Admin/update")]
        public HttpResponseMessage Update(AdminDTO sp)
        {
            try
            {
                var res = AdminService.Update(sp);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [Logged]
        [HttpDelete]
        [Route("api/Admin/delete/{uname}")]
        public HttpResponseMessage DeleteAdmin(string uname)
        {
            try
            {
                var res = AdminService.Delete(uname);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }


        //For Notifications.............................

        [HttpPost]
        [Route("api/Admin/SendNotification")]
        public HttpResponseMessage SendNotification(NotificationDTO notification)
        {
            try
            {
                var res = NotificationService.SendNotification(notification.ServiceProviderName, notification.Message, notification.SentByAdminUserName);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/Notifiaction/All")]
        public HttpResponseMessage GetNotification()
        {
            try
            {
                var data = NotificationService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }



        [HttpGet]

        [Route("api/Admin/reset/{gmail}")]

        public HttpResponseMessage ResetPass(string gmail)

        {

            try

            {

                var data = AuthService.ResetPass(gmail);

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }

            catch (Exception ex)

            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }





        [HttpPost]

        [Route("api/Admin/set/{UserName}")]

        public HttpResponseMessage SetPassword(string UserName, SetPassModel spm)

        {

            try

            {

                var data = AuthService.SetPassword(UserName, spm.Otp, spm.Password);

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }

            catch (Exception ex)

            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }


    }
}
