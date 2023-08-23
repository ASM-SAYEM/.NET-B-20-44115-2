using AutoMapper;
using BAL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public static ServiceProviderPaymentDTO AddPaymentTo(ServiceProviderPaymentDTO payment)
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
            var notificationMessage = $"Payment of {payment.Amount} added on {payment.PaymentDate}";
            NotificationService.SendNotification(serviceProvider.Name, notificationMessage, "Admin"); // Use appropriate admin username

            var resultDTO = mapper.Map<ServiceProviderPaymentDTO>(addedPayment);
            return resultDTO;
        }
    }
}