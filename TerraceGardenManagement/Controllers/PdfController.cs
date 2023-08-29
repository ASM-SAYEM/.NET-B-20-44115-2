using BLL.Services;
using iText.Html2pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.DTOs;


namespace ClickCart.Controllers
{
    /*[LoggedIn]*/
    public class PdfController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/pdf")]
        public HttpResponseMessage Pdf()
        {
            var pdf = GeneratePdf();
            return Request.CreateErrorResponse(HttpStatusCode.OK, pdf);
        }

        public string GeneratePdf()
        {
            try
            {
                var product = ProductService.GetProduct().Last();

                var html = $@"
                        <!DOCTYPE html>
                        <html lang='en'>
                        <head>
                            <meta charset='UTF-8'>
                            <title>Title</title>
                        </head>
                        <body>
                        <h1 style='text-align: center'>ClickCart</h1>
                        <h2>Product Details</h2>
                        
                        </body>
                        </html>";

                var mapPath = HostingEnvironment.MapPath("~\\PDF\\");
                /*var filename = System.Guid.NewGuid().ToString().Substring(0, 5);*/
                var filename = product.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                var pdfPath = mapPath + filename + ".pdf";
                var serverPdfPath = "https://localhost:44366/PDF/" + filename + ".pdf";

                CreatePdf("https://localhost:44366", html, pdfPath);

                return serverPdfPath;
            }
            catch
            {
                return null;
            }
        }

        public void CreatePdf(string baseUri, string html, string destination)
        {
            try
            {
                var prop = new ConverterProperties();
                prop.SetBaseUri(baseUri);
                HtmlConverter.ConvertToPdf(html, new FileStream(destination, FileMode.Create), prop);
            }
            catch
            {
                // ignored
            }
        }
    }
}