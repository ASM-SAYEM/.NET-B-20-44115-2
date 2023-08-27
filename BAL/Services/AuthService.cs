using AutoMapper;
using BAL.DTOs;
using DAL;
using DAL.EF.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using DAL.Interface;

namespace BAL.Services
{
    public class AuthService 
    {
        public static TokenDTO Login(string uname, string pass)
        {
            var user = DataAccessFactory.AuthData().Authenticate(uname, pass);
            if (user != null)
            {
                var token = new Token();
                token.TokenKey = Guid.NewGuid().ToString();
                token.Username = user.UserName;
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;
                var tk = DataAccessFactory.TokensData().Add(token);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(config);
                var data = mapper.Map<TokenDTO>(tk);
                return data;
            }
            return null;
        }
        public static bool IsTokenValid(string token)
        {
            var r = DataAccessFactory.TokensData().Get(token);
            //var tk = (from t in DataAccessFactory.TokensData().Get()
            //          where t.TokenKey.Equals(token)
            //          && t.ExpiredAt == null
            //          select t).SingleOrDefault();

            if (r != null)
            {
                return true;
            }
            return false;
        }



        public static bool Logout(string tkey)
        {
            var extk = DataAccessFactory.TokensData().Get(tkey);
            extk.ExpiredAt = DateTime.Now;
            if (DataAccessFactory.TokensData().Update(extk) != null)
            {
                return true;
            }
            return false;

        }



        public static bool IsAdmin(string tkey)
        {
            var extk = DataAccessFactory.TokensData().Get(tkey);
            if (IsTokenValid(tkey) && extk.Admin.Type.Equals("Admin"))
            {
                return true;
            }
            return false;
        }

       


        public static OTPresetDTO ResetPass(string gmail)
        {
            var res = DataAccessFactory.AdminData().ForgetPass(gmail);

            if (res != null)
            {
                Random r = new Random();
                var otp = new OTPreset();
                otp.OTP = r.Next(1000, 9999).ToString();
                otp.CreateTime = DateTime.Now;
                otp.DeleteTime = otp.CreateTime.AddHours(2);
                otp.UserName = res.UserName;
                var ret = DataAccessFactory.OTPresetData().Add(otp);
                if (ret)
                {
                    var retotp = DataAccessFactory.OTPresetData().Get(otp.OTP);

                    var client = new SmtpClient();

                    client.Host = "smtp.mail.yahoo.com";
                    client.Port = 587;//465;//587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                   // client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential("asmsayem72@yahoo.com", "bypclvhnfsatqtzz");
                    using (var message = new MailMessage(
                        from: new MailAddress("asmsayem72@yahoo.com", "TerraceGardenManagement"),
                        to: new MailAddress(res.Gmail, res.Name)
                        ))
                    {

                        message.Subject = "terracegarden-Reset Your Password";
                        message.Body = "Your OTP: " + retotp.OTP +".If this is not you,Change your password to secure your account. Don not share it with anyone. Thank You....";

                        client.Send(message);
                    }

                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<OTPreset, OTPresetDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var mapped = mapper.Map<OTPresetDTO>(retotp);
                    return mapped;
                }

            }
            return null;

        }


        public static bool SetPassword(string id, string otp, string password)
        {
            var ret = DataAccessFactory.OTPresetData().SetOTP(id, otp);

            if (ret != null && DateTime.Compare(ret.DeleteTime, DateTime.Now) >= 0)
            {
                var user = DataAccessFactory.AdminData().ResetPass(id, password);
                return true;
            }
            return false;
        }

    }
}