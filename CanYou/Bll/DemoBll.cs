////////////////////////////////////////////////
// 生成时间: 2016-08-10 09:14:12
//作者：海南残友
//http://www.canyouhn.com/
////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model;
using Common;
using Dal;

namespace Bll
{
 public class DemoBll
 {
DemoDal dal=new DemoDal();
        /// <summary>
       /// 添加
       /// </summary>
       public bool AddDemo(DemoModel model)
       {
         return  dal.AddDemo(model);
       }
         /// <summary>
       /// 修改
       /// </summary>
        public bool UpdataDemo(DemoModel model)
       {
          return  dal.UpdataDemo(model);
       }
         /// <summary>
       /// 分页列表
       /// </summary>
        
        public List<DemoModel> DemoList(Criteria c, int CurPage, int pageSize, out int OutCount)
       {
            return dal.DemoList(c,CurPage,pageSize,out OutCount);
         }
             
            /// <summary>
        /// 列表,不分页
        /// </summary>
          public List<DemoModel> DemoList(Criteria c)
        {
            return dal.DemoList(c);
        }
        
               /// <summary>
        /// 取出总数
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int GetCount(Criteria c)
       {
           return dal.GetCount(c);
       }
         
            /// <summary>
       /// 根据主键值取出数据
       /// </summary>
       public DemoModel DemoDetail(int? Id)
       {
             return dal.DemoDetail(Id);
       }
           /// <summary>
       /// 删除
       /// </summary>
          public bool DeleteDemo(int? Id)
       {
           return  dal.DeleteDemo(Id);
       }
       }
         
}