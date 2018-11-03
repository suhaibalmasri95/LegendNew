using Infrastructure.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Infrastructure.DB
{
    public static class DBMapper
    {
        public static List<T> Map<T>
         (this IDataReader dr)
        where T : new()
        {
            Type businessEntityType = typeof(T);
            List<T> entitys = new List<T>();
            Hashtable hashtable = new Hashtable();
            PropertyInfo[] properties = businessEntityType.GetProperties();
            foreach (PropertyInfo info in properties)
            {
                hashtable[info.GetCustomAttribute<DBFiledName>().Name] = info;
            }
            while (dr.Read())
            {
                T newObject = new T();
                for (int index = 0; index < dr.FieldCount; index++)
                {
                    PropertyInfo info = (PropertyInfo)
                    hashtable[dr.GetName(index)];
                    if ((info != null) && info.CanWrite)
                    {
                        if (dr.GetValue(index) == DBNull.Value)
                            info.SetValue(newObject, null, null);
                        else
                            info.SetValue(newObject, dr.GetValue(index), null);
                    }
                }
                entitys.Add(newObject);
            }
            dr.Close();
            return entitys;
        }
    }
}