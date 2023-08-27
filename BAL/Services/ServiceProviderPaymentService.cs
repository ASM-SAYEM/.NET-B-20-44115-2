using AutoMapper;
using BAL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Migrations;
using System.Net.Mail;
using System.Net;

namespace BAL.Services
{
    public class ServiceProviderPaymentService
    {
        public static List<ServiceProviderPaymentDTO> Get()
        {
            var data = DataAccessFactory.ServiceProviderPaymentData().Get();
            var cfg = new MapperConfiguration(c =>
            {

                c.CreateMap<ServiceProviderPayment, ServiceProviderPaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ServiceProviderPaymentDTO>>(data);
            return mapped;
        }

        public static ServiceProviderPaymentDTO Get(int id)
        {
            var data = DataAccessFactory.ServiceProviderPaymentData().Get();

            var cfg = new MapperConfiguration(c => {
                //c.CreateMap<FeedbackDTO, Feedback>();
                c.CreateMap<ServiceProviderPayment, ServiceProviderPaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ServiceProviderPaymentDTO>(data);
            return mapped;
        }

        public static ServiceProviderPayment Add(ServiceProviderPaymentDTO sp)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ServiceProviderPaymentDTO, ServiceProviderPayment>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ServiceProviderPayment>(sp);
            var data = DataAccessFactory.ServiceProviderPaymentData().Add(mapped);

            return data;

        }

        public static ServiceProviderPayment Update(ServiceProviderPaymentDTO sp)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ServiceProviderPaymentDTO, ServiceProviderPayment>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ServiceProviderPayment>(sp);
            var data = DataAccessFactory.ServiceProviderPaymentData().Update(mapped);

            return data;

        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.FeedbackData().Delete(id);

            return data;

        }


        //////////////////////////////
        public static ServiceProviderPayment AddPaymentTo(ServiceProviderPaymentDTO payment)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProviderPaymentDTO, ServiceProviderPayment>();
            });
            var mapper = new Mapper(cfg);
            var paymentEntity = mapper.Map<ServiceProviderPayment>(payment);

            var addedPayment = DataAccessFactory.ServiceProviderPaymentData().Add(paymentEntity);

            // Send notifications to the associated service provider
            var serviceProvider = ServiceProviderService.Get(addedPayment.ServiceProviderId); // Assuming you have a ServiceProviderService
            //var notificationMessage = $"Payment of {payment.Amount} added on {payment.PaymentDate}";
           // NotificationService.SendNotification(serviceProvider.Name, notificationMessage, "Admin"); // Use appropriate admin username
                                                                                                      //Eail
            //var data = DataAccessFactory.ClientData().Get();
            var client = new SmtpClient();

            client.Host = "smtp.mail.yahoo.com";//"smtp.yahoo.com";
            client.Port = 587;//465;//587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            // client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential("asmsayem72@yahoo.com", "bypclvhnfsatqtzz");
            using (var message1 = new MailMessage(
                from: new MailAddress("asmsayem72@yahoo.com", "TerraceGardenManagement"),
                to: new MailAddress(serviceProvider.Gmail, serviceProvider.Name)
                ))
            {

                message1.Subject = "TerraceGarden";
                message1.Body = "Payment Done . Please check your account. Thank you.";

                client.Send(message1);
            }


            //var resultDTO = mapper.Map<ServiceProviderPaymentDTO>(addedPayment);
            return addedPayment;
        }
    }
}