using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.DocumentSynthesis
{
    /// <summary>
    /// Summary description for DocumentSynthesis
    /// </summary>
    public class DocumentSynthesis : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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