using Bll;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace Demo.Tools
{
    /// <summary>
    /// AjaxPage 的摘要说明
    /// </summary>
    public class AjaxPage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DemoBll bll = new DemoBll();
            List<DemoModel> list = new List<DemoModel>();
            Criteria c=new Criteria();
            int pageIndex = Convert.ToInt32(context.Request.QueryString["page"]);
            int pageSize = Convert.ToInt32(context.Request.QueryString["pageSize"]);
            int totalCount=0;
            c.AddOrderBy(DemoModel._Id, OrderByDirection.Desc);
            list = bll.DemoList(c, pageIndex,pageSize, out totalCount);
            DataContractJsonSerializer json = new DataContractJsonSerializer(list.GetType());
            string szJson = "";
            using (MemoryStream stream = new MemoryStream())
            {

                json.WriteObject(stream, list);

                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }
            int status = 0;
            if(list.Count>0)
            {
                status = 1;
            }
            context.Response.Write("{\"list\": " + szJson + ", \"totalCount\": \"" + totalCount + "\", \"status\": \"" + status + "\"}");
            
            return;

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