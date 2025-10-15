using System;
using System.Data;

namespace EmilsAuto.Helper
{
    public class SqlLoader
    {
        //EKSEMPEL PÅ BRUG  Model model = SqlLoader.MapDataRowToObject<Model>(row, new());
        public static T MapDataRowToObject<T>(DataRow row, T obj) where T : new()
        {
            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                if (row.Table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                {
                    try
                    {                        
                        var value = Convert.ChangeType(row[prop.Name], prop.PropertyType);
                        prop.SetValue(obj, value);
                    }
                    catch
                    {
                        
                    }
                }
            }

            return obj;
        }

    }
}
