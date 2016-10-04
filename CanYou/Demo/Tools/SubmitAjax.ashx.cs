using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Tools
{
    /// <summary>
    /// SubmitAjax 的摘要说明
    /// </summary>
    public class SubmitAjax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];//获取get传过来的数据

            switch(action)
            {
                case "add1":
                    Add1(context);
                    break;
            }
            
        }

        private void Add1(HttpContext context)
        {
            string name = context.Request.Form["name"];//获取表单提交过来的数据
            string phone = context.Request.Form["phone"];
            DemoBll bll = new DemoBll();
            DemoModel model = new DemoModel();
            model.Name = name;
            model.Phone = phone;
           if(bll.AddDemo(model))
           {
               context.Response.Write("{\"status\": 1, \"msg\": \"添加成功\"}");
            return;
           }
           else
           {
            context.Response.Write("{\"status\": 0, \"msg\": \"添加失败\"}");
            return;
           }
     
              
            
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