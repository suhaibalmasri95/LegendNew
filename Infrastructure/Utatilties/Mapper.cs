using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Utatilties
{
    public static class Mapper
    {
        public static void Map<type>(dynamic from, type to)
        {
            
        var properties = to.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = from[property.Name].ToString();

                if (property.PropertyType == typeof(Int64?) )
                {
                    if(!string.IsNullOrEmpty(value))
                    {
                        value = Int64.Parse(value);
                    }
                    else
                    {
                    value = null;
                    }
                }
                if (property.PropertyType == typeof(Int64))
                {
                    value = Int64.Parse(value);
                }
                if (property.PropertyType == typeof(DateTime?) )
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        value = Int64.Parse(value);
                    }
                    else
                    {
                        value = null;
                    }
                }
                if ( property.PropertyType == typeof(DateTime))
                {
                    value = DateTime.Parse(value);
                }
                if (property.PropertyType == typeof(double))
                {
                    value = Double.Parse(value);
                }
                property.SetValue(to, value);
            }
        }
    }
}
