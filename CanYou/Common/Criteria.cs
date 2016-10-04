using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 运算符
    /// </summary>
    public enum OrderByDirection
    {
        Asc,
        Desc
    }

    class WhereData
    {
        public string _WhereField;
        public object _WhereValue;
        public OperatorWhere _OperatorWhere;
        public ComparisonWhere _ComparisonWhere;
        public WhereData(OperatorWhere pOperatorWhere, ComparisonWhere pComparisonWhere, string pWhereField, object pWhereValue)
        {
            _OperatorWhere = pOperatorWhere;
            _ComparisonWhere = pComparisonWhere;
            _WhereField = pWhereField;
            _WhereValue = pWhereValue;
        }
    }



    /// <summary>
    /// 运算符
    /// </summary>
    public enum OperatorWhere
    {
        And,
        Or
    }
    /// <summary>
    /// 比较运算符
    /// </summary>
    public enum ComparisonWhere
    {
        BetweenAnd,//在两者之间
        Equals,//等于
        GreaterOrEquals,//大于等于
        GreaterThan,//大于
        IsNull,//空
        IsNotNull,//非空
        LessOrEquals,//小于等于
        LessThan,//小于
        Like,//模糊查询
        NotEquals//不等于
    }

    public class Criteria
    {

        private string whereString = string.Empty;
        List<OrderBy> listOrderBy = new List<OrderBy>();
        List<WhereData> list = new List<WhereData>();
        class OrderBy
        {
            public string _OrderByField;
            public OrderByDirection _OrderByDirection;
            public OrderBy(string pOrderByField, OrderByDirection pOrderByDirection)
            {
                _OrderByField = pOrderByField;
                _OrderByDirection = pOrderByDirection;
            }
        }



        public Criteria()
        {
            whereString = "1=1";
        }

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <returns></returns>
        public Criteria AddOrderBy(string pKey, OrderByDirection pOrderBy)
        {
            listOrderBy.Add(new OrderBy(pKey, pOrderBy));
            return this;
        }


        /// <summary>
        /// and
        /// </summary>
        /// <returns></returns>
        public Criteria AddWhere(string pKey, object pValue)
        {
            return AddWhere(pKey, ComparisonWhere.Equals, pValue);
        }

        public Criteria AddOrWhere(string pKey, object pValue)
        {
            return OrWhere(pKey, ComparisonWhere.Equals, pValue);
        }

        public Criteria AddWhere(string pKey, ComparisonWhere comparisonWhere, object pValue)
        {
            return AddWhere(OperatorWhere.And, pKey, comparisonWhere, pValue);
        }

        public Criteria OrWhere(string pKey, ComparisonWhere comparisonWhere, object pValue)
        {
            return AddWhere(OperatorWhere.Or, pKey, comparisonWhere, pValue);

        }

        public Criteria AddWhere(OperatorWhere pOperatorWhere, string pKey, ComparisonWhere comparisonWhere, object pValue)
        {
            WhereData wd = new WhereData(pOperatorWhere, comparisonWhere, pKey, pValue);
            list.Add(wd);
            return this;
        }

        public String GetWhere()
        {
            string whereString = "1=1";
            for (int i = 0; i < list.Count; i++)
            {
                whereString += " " + list[i]._OperatorWhere;
                whereString += " " + GetString(list[i]._WhereField, list[i]._ComparisonWhere, i);
            }
            return whereString;
        }


        public String GetOrderByString()
        {
            string orderByString = String.Empty;
            for (int i = 0; i < this.listOrderBy.Count; i++)
            {
                orderByString += " " + listOrderBy[i]._OrderByField;
                orderByString += " " + listOrderBy[i]._OrderByDirection + ",";
            }
            if (orderByString.EndsWith(","))
            {
                orderByString = orderByString.Remove(orderByString.LastIndexOf(","), 1);
            }
            return orderByString;
        }


        public object[] GetWhereValue()
        {
            int count = list.Count;
            object[] objs = new object[count];
            for (int i = 0; i < list.Count; i++)
            {
                objs[i] = (object)list[i]._WhereValue;
            }
            return objs;
        }

        private string GetString(string whereField, ComparisonWhere comparisonWhere, int pIndex)
        {
            switch (comparisonWhere)
            {
                case ComparisonWhere.BetweenAnd:
                    break;
                case ComparisonWhere.Equals:
                    return whereField + "=@" + pIndex;
                case ComparisonWhere.GreaterOrEquals:
                    return whereField + ">=@" + pIndex;
                case ComparisonWhere.GreaterThan:
                    return whereField + ">@" + pIndex;
                case ComparisonWhere.IsNull:
                    return whereField + "is null";
                case ComparisonWhere.IsNotNull:
                    return whereField + "!=null";
                case ComparisonWhere.LessOrEquals:
                    return whereField + "<=@" + pIndex;
                case ComparisonWhere.LessThan:
                    return whereField + "<@" + pIndex;
                case ComparisonWhere.Like:
                    return whereField + ".contains(@" + pIndex + ")";
                case ComparisonWhere.NotEquals:
                    return whereField + "!=@" + pIndex;
            }
            return "";
        }
    }
}
