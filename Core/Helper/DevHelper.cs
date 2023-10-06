using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Core.Helper
{
    public class DevHelper
    {
        public static object Inject(object source, object coppy)
        {
            Type typeSourec = source.GetType();
            var lstPropSource = typeSourec.GetProperties();

            Type typeCopy = coppy.GetType();
            var lstPropCoppy = typeCopy.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var dicPropCoppy = new Dictionary<string, PropertyInfo>();
            foreach (var propCoppy in lstPropCoppy)
            {
                if (!dicPropCoppy.ContainsKey(propCoppy.Name))
                {
                    dicPropCoppy.Add(propCoppy.Name, propCoppy);
                }
            }

            foreach (var propSource in lstPropSource)
            {
                if (dicPropCoppy.ContainsKey(propSource.Name))
                {
                    dicPropCoppy[propSource.Name].SetValue(coppy, propSource.GetValue(source), null);
                }
            }
            return coppy;
        }
    }
}
