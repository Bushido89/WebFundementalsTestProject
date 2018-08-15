using Newtonsoft.Json;
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
    /// Summary description for LeagueTable
    /// </summary>
    public class LeagueTable : IHttpHandler
    {
        Dictionary<string, Func<HttpContext, object>> logicCollection = new Dictionary<string, Func<HttpContext, object>>();
        private string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"];

        public LeagueTable()
        {
            logicCollection.Add("GetLeagueTableEntries", GetLeagueTableEntries);
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

        private List<LeagueTableEntry> GetLeagueTableEntries(HttpContext context)
        {
            return new LeagueTableGate(connectionString).GetCurrentLeagueTable(Convert.ToInt32(context.Request.QueryString["position"]));
        }
    }
}