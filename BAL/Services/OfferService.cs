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
    public class OfferService
    {
        public static List<OfferDTO> Get()
        {
            var data = DataAccessFactory.OfferData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                //c.CreateMap<ClientDTO, Client>();
                c.CreateMap<Offer, OfferDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OfferDTO>>(data);
            return mapped;
        }

        public static OfferDTO Get(int id)
        {
            var data = DataAccessFactory.OfferData().Get(id);

            var cfg = new MapperConfiguration(c => {
                //c.CreateMap<ClientDTO, Client>();
                c.CreateMap<Offer, OfferDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OfferDTO>(data);
            return mapped;
        }

        public static Offer Create(OfferDTO offer)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OfferDTO, Offer>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Offer>(offer);
            var data = DataAccessFactory.OfferData().Add(mapped);

            var data1 = DataAccessFactory.ClientData().Get();
            //var cfg1 = new MapperConfiguration(c =>
            //{
            //    //c.CreateMap<ClientDTO, Client>();
            //    c.CreateMap<Client, ClientDTO>();
            //});
            //var mapper1 = new Mapper(cfg);
            //var mapped1 = mapper.Map<List<ClientDTO>>(data1);
            //return mapped; // Assuming you have a ClientService
            foreach (var client in data1)
            {
                var notificationMessage = $"New offer uploaded: {data.offerName}";
                NotificationService.SendNotification(client.Name, notificationMessage, data.Assignby);
            }


            return data;

        }

        public static Offer Update(OfferDTO offer)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OfferDTO, Offer>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Offer>(offer);
            var data = DataAccessFactory.OfferData().Update(mapped);

            return data;

        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.OfferData().Delete(id);

            return data;

        }


        //For notification of every uploaded offer
        ////public static OfferDTO CreateOffer(OfferDTO offer)
        ////{
        ////    var addedOffer = DataAccessFactory.OfferData().Get(offer);

        ////    // Send notifications to clients about the new offer
        ////    var clients = ClientService.Get(); // Assuming you have a ClientService
        ////    foreach (var client in clients)
        ////    {
        ////        var notificationMessage = $"New offer uploaded: {offer.offerName}";
        ////        NotificationService.SendNotification(client.Name, notificationMessage, addedOffer.Assignby);
        ////    }

        ////    return addedOffer;
        ////}
        ///
        
        //public static Offer CreateOffer(OfferDTO offer)
        //{


        //    // Map OfferDTO to Offer entity
        //    //var offerEntity = Mapper.Map<Offer>(offer);


        //    var mapperConfig = new MapperConfiguration(cfg1 =>
        //    {
        //        cfg1.CreateMap<OfferDTO, Offer>();
        //    });
        //    var mapper1 = new Mapper(mapperConfig);
        //    var offerEntity = mapper1.Map<Offer>(offer);

        //    // Add the offer entity to the database
        //    var addedOffer = DataAccessFactory.OfferData().Add(offerEntity);

        //    // Send notifications to clients about the new offer
        //    var clients = ClientService.Get(); // Assuming you have a ClientService
        //    foreach (var client in clients)
        //    {
        //        var notificationMessage = $"New offer uploaded: {offer.offerName}";
        //        NotificationService.SendNotification(client.Name, notificationMessage, addedOffer.Assignby);
        //    }

        //    // Map the added offer entity back to DTO and return
        //    //var cfg = new MapperConfiguration(c =>
        //    //{
        //    //    c.CreateMap<Offer, OfferDTO>();
        //    //});

        //    //var mapper = new Mapper(cfg);
        //    //var mappedOffer = mapper.Map<OfferDTO>(addedOffer);

        //    return addedOffer;
        }
    }



