using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TestProject.DAL;
using TestProject.Model;

namespace TestProject.Generic
{
    /// <summary>
    /// Summary description for CarRentalInformation
    /// </summary>
    public class CarRentalInformation : IHttpHandler
    {
        Dictionary<string, Func<HttpContext, object>> logicCollection = new Dictionary<string, Func<HttpContext, object>>();
        private string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"];

        public CarRentalInformation()
        {
            // Populate logic collection for post-init querying
            logicCollection.Add("GetVehicleManufacturers", GetVehicleManufacturers);
            logicCollection.Add("GetVehicleModels", GetVehicleModels);
        }


        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(JsonConvert.SerializeObject(logicCollection[context.Request.QueryString["req"]](context)));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private List<VehicleManufacturer> GetVehicleManufacturers(HttpContext context)
        {
            return new VehicleGate(connectionString)
                .GetVehicleManufacturer(context.Request.QueryString["pFilter"]);
        }

        private List<VehicleModel> GetVehicleModels(HttpContext context)
        {
            return new VehicleGate(connectionString)
                .GetVehicleModels(int.Parse(context.Request.QueryString["pVehicleManufacturerId"]));
        }
    }
}