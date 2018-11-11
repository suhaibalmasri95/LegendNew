using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DB
{
    public class MultiDeleteFormater
    {
        private static string _deleteStatment = "Delete from {0} where {1} in {2}";
        public static string Format(Type type, long[] IDs)
        {
            var tableName = (type.GetCustomAttributes(typeof(DBTableName), false)[0] as DBTableName).Name;
            var primaryKeyFieldName = type.GetProperties().Where(prop => prop.GetCustomAttributes(typeof(DBPrimaryKey), false).FirstOrDefault() != null).First().Name;
            var values = string.Join(',', IDs);
            var sqlResult = string.Format(_deleteStatment, tableName, primaryKeyFieldName, values);
            return sqlResult;
        }
    }
}
