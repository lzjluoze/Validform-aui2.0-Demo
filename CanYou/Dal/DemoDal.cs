////////////////////////////////////////////////
// 生成时间: 2016-08-11 16:17:06
//作者：海南残友
//http://www.canyouhn.com/
////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Common;
using System.Data;
using Model;
namespace Dal
{
    public class DemoDal
    {
  
         /// <summary>
       /// 添加
       /// </summary>
       public bool AddDemo(DemoModel model)
       {

          
        
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Demo(");
            strSql.Append("Phone,Name)");
            strSql.Append(" values (");
            strSql.Append("@Phone,@Name)");
             SQLiteParameter[] parameters = {
                new  SQLiteParameter("@Phone", DBNull.Value),
                  new  SQLiteParameter("@Name", DBNull.Value)
              };
                    parameters[0].Value = model.Phone;
                    parameters[1].Value = model.Name;

              
            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
       }
       /// <summary>
       /// 修改
       /// </summary>
       public bool UpdataDemo(DemoModel model)
       {
 StringBuilder strSql = new StringBuilder();
           strSql.Append("update Demo set ");
                       strSql.Append("Phone=@Phone");
                      
                       strSql.Append("Name=@Name");
                      
                    strSql.Append(" where Id=@Id");
                      
          
                SQLiteParameter[] parameters = {
                new SQLiteParameter("@Phone", DBNull.Value),
                new SQLiteParameter("@Name", DBNull.Value),
                new SQLiteParameter("@Id", DBNull.Value)
              };
                     parameters[0].Value = model.Phone;
                     parameters[1].Value = model.Name;
                
                      parameters[2].Value = model.Id;
           

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }               
       }


         /// <summary>
       /// 分页列表
       /// </summary>
       public List<DemoModel> DemoList(Criteria c, int CurPage, int pageSize, out int OutCount)
       {
             string whereStr = c.GetWhere();
           object[] whereValueStr =c.GetWhereValue();
           string orderbyStr = c.GetOrderByString();
                if(!string.IsNullOrEmpty(orderbyStr))
           {
               orderbyStr = "order by " + orderbyStr;
           }
           List<DemoModel> list = new List<DemoModel>();

           StringBuilder str = new StringBuilder();
          
           SQLiteParameter[] paras = new SQLiteParameter[whereValueStr.Length+2];
           for (int i = 0; i < whereValueStr.Length;i++ )
           {
            paras[i] =  new SQLiteParameter("@"+i+"",whereValueStr[i].ToString());             
           }

           paras[whereValueStr.Length] = new SQLiteParameter("@start", (CurPage - 1) * pageSize);
           paras[whereValueStr.Length + 1] = new SQLiteParameter("@pageSize", pageSize);

           str.Append("select  * From Demo  where " + whereStr + " " + orderbyStr + " Limit @start,@pageSize");
           DataTable dt = new DataTable();
           dt = DbHelperSQLite.Query(str.ToString(), paras).Tables[0];
           list = ModelConvertHelper<DemoModel>.ConvertToModel(dt).ToList();

           StringBuilder getCountStr = new StringBuilder();
           getCountStr.Append("select  count(*) From Demo  where " + whereStr);
           OutCount = Convert.ToInt32(DbHelperSQLite.Query(getCountStr.ToString(), paras).Tables[0].Rows[0][0]);
           return list;
       }
           /// <summary>
        /// 列表,不分页
        /// </summary>
          public List<DemoModel> DemoList(Criteria c)
        {
             string whereStr = c.GetWhere();
            object[] whereValueStr = c.GetWhereValue();
            string orderbyStr = c.GetOrderByString();
            if (!string.IsNullOrEmpty(orderbyStr))
            {
                orderbyStr = "order by " + orderbyStr;
            }
            List<DemoModel> list = new List<DemoModel>();

            StringBuilder str = new StringBuilder();

            SQLiteParameter[] paras = new SQLiteParameter[whereValueStr.Length];
            for (int i = 0; i < whereValueStr.Length; i++)
            {
                paras[i] = new SQLiteParameter("@" + i + "", whereValueStr[i].ToString());
            }

            str.Append("select  * From Demo  where " + whereStr + " " + orderbyStr);
            DataTable dt = new DataTable();
            dt = DbHelperSQLite.Query(str.ToString(), paras).Tables[0];
            list = ModelConvertHelper<DemoModel>.ConvertToModel(dt).ToList();
            return list;
        }
            /// <summary>
        /// 取出总数
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int GetCount(Criteria c)
       {
          string whereStr = c.GetWhere();
           object[] whereValueStr = c.GetWhereValue();
           string orderbyStr = c.GetOrderByString();
           SQLiteParameter[] paras = new SQLiteParameter[whereValueStr.Length];
           for (int i = 0; i < whereValueStr.Length; i++)
           {
               paras[i] = new SQLiteParameter("@" + i + "", whereValueStr[i].ToString());
           }
           StringBuilder getCountStr = new StringBuilder();
           getCountStr.Append("select  count(*) From Demo  where " + whereStr);
           int count = Convert.ToInt32(DbHelperSQLite.Query(getCountStr.ToString(), paras).Tables[0].Rows[0][0]);
           return count;
           
       }
        /// <summary>
       /// 根据主键值取出数据
       /// </summary>
       public DemoModel DemoDetail(int? Id)
       {
         DemoModel model = new DemoModel();

           SQLiteParameter[] paras = {
                                     
            new SQLiteParameter("@Id",Id)
                                     };
           StringBuilder str = new StringBuilder();
           str.Append("select  * From Demo  where Id=@Id ");
           DataTable dt = new DataTable();
           dt = DbHelperSQLite.Query(str.ToString(), paras).Tables[0];
           model = ModelConvertHelper<DemoModel>.ConvertToModel(dt).ToList().FirstOrDefault();
           return model;
       }
        /// <summary>
       /// 删除
       /// </summary>
          public bool DeleteDemo(int? Id)
       {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Demo ");
            strSql.Append(" where Id=@Id");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@Id",Id)};
            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
          
       }
       }
}