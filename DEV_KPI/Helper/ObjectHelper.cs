using DEV_KPI.Common.Reflector;
using System;
using System.Reflection;

namespace DEV_KPI.Helper
{
    public static class ObjectHelper
    {
        public static PropertyInfo GetProperty(object src, string propName)
        {
            FastProperty fastProperty = GetFastProperty(src, propName);
            return fastProperty?.Property;
        }

        public static PropertyInfo GetProperty(Type type, string propName)
        {
            FastProperty property = FastProperty.GetProperty(type, propName, true);
            return property?.Property;
        }

        public static FastProperty GetFastProperty(object src, string propName)
        {
            Type type = src.GetType();
            return GetFastProperty(type, propName);
        }

        public static FastProperty GetFastProperty(Type type, string propName)
        {
            return FastProperty.GetProperty(type, propName, true);
        }

        public static bool HasProperty(object src, string propName)
        {
            return HasProperty(src.GetType(), propName);
        }

        public static bool HasProperty(Type t, string propName)
        {
            FastProperty fastProperty = GetFastProperty(t, propName);
            return fastProperty != null;
        }

        public static bool HasProperty(Type t, string propName, out FastProperty prop)
        {
            prop = GetFastProperty(t, propName);
            return prop != null;
        }

        public static object GetPropValue(object src, string propName)
        {
            FastProperty fastProperty = GetFastProperty(src, propName);
            return GetFastPropValue(src, fastProperty);
        }

        public static object GetFastPropValue(object src, FastProperty prop)
        {
            if (prop?.Property.CanRead ?? false)
            {
                return prop.Get(src);
            }
            return null;
        }

        public static void SetPropValue(object target, string propName, object value)
        {
            FastProperty fastProperty = GetFastProperty(target, propName);
            if (fastProperty?.Property.CanWrite ?? false)
            {
                fastProperty.Set(target, value);
            }
        }
    }
}
