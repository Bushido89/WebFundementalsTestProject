using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TestProject.DAL;
using TestProject.Model;

namespace TestProject.DataCapture
{
    /// <summary>
    /// Summary description for DataCaptureHandler
    /// </summary>
    public class DataCaptureHandler : IHttpHandler
    {
        private IsoDateTimeConverter datetimeConverter = new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" };

        public void ProcessRequest(HttpContext context)
        {
            var clientGate = new ClientGate(ConfigurationManager.AppSettings["SqlConnectionString"]);
            

            var rows = clientGate.PutClient(JsonConvert.DeserializeObject<Client>(context.Request.Form[0], datetimeConverter));

            context.Response.ContentType = "text/plain";
            context.Response.Write($"{rows} rows affected");
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}