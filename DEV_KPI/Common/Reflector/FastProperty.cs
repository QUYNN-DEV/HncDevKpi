using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DEV_KPI.Common.Reflector
{
    public class FastProperty
    {
        private static readonly GenericCache<Type, Dictionary<string, FastProperty>> _fastPropertyCache = new GenericCache<Type, Dictionary<string, FastProperty>>(InitCacheForType);

        private static readonly GenericCache<Type, List<FastProperty>> _fastPropertyByListCache = new GenericCache<Type, List<FastProperty>>((Func<Type, List<FastProperty>>)null);

        public Func<object, object> GetDelegate;

        public Action<object, object> SetDelegate;

        public PropertyInfo Property
        {
            get;
            set;
        }

        public Type PropertyType => (Property == (PropertyInfo)null) ? null : Property.PropertyType;

        private static string GetIgnoreProperty(string propName)
        {
            return "@" + propName.ToLower();
        }

        private static Dictionary<string, FastProperty> InitCacheForType(Type type)
        {
            Dictionary<string, FastProperty> dictionary = new Dictionary<string, FastProperty>();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                if ((propertyInfo.CanRead || !propertyInfo.CanWrite) && (!propertyInfo.CanRead || (!propertyInfo.GetMethod.IsStatic && propertyInfo.GetMethod.IsPublic)) && (!propertyInfo.CanWrite || (!propertyInfo.SetMethod.IsStatic && propertyInfo.SetMethod.IsPublic)))
                {
                    ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
                    if (indexParameters == null || indexParameters.Length == 0)
                    {
                        string name = propertyInfo.Name;
                        string ignoreProperty = GetIgnoreProperty(propertyInfo.Name);
                        if (!dictionary.ContainsKey(name) && !dictionary.ContainsKey(ignoreProperty))
                        {
                            FastProperty value = new FastProperty(propertyInfo);
                            dictionary.Add(propertyInfo.Name, value);
                            dictionary.Add(GetIgnoreProperty(propertyInfo.Name), value);
                        }
                    }
                }
            }
            _fastPropertyByListCache[type] = (from x in dictionary
                                              where !x.Key.StartsWith("@")
                                              select x.Value).ToList();
            return dictionary;
        }

        public static List<FastProperty> GetProperties(Type type)
        {
            if (type == (Type)null)
            {
                return new List<FastProperty>();
            }
            Dictionary<string, FastProperty> dictionary = _fastPropertyCache[type];
            if (dictionary == null)
            {
                return new List<FastProperty>();
            }
            return _fastPropertyByListCache[type];
        }

        public static FastProperty GetProperty(Type type, string propName, bool ignoreCase = true)
        {
            if (string.IsNullOrWhiteSpace(propName))
            {
                return null;
            }
            Dictionary<string, FastProperty> dictionary = _fastPropertyCache[type];
            if (dictionary == null)
            {
                return null;
            }
            FastProperty result = null;
            string key = ignoreCase ? GetIgnoreProperty(propName) : propName;
            if (dictionary.TryGetValue(key, out result))
            {
                return result;
            }
            return null;
        }

        public static void SetValue(object target, string propName, object value, bool ignoreCase = true)
        {
            FastProperty property = GetProperty(target.GetType(), propName, ignoreCase);
            property?.Set(target, value);
        }

        public static object GetValue(object target, string propName, bool ignoreCase = true)
        {
            FastProperty property = GetProperty(target.GetType(), propName, ignoreCase);
            return property?.Get(target);
        }

        public FastProperty(PropertyInfo property)
        {
            Property = property;
            InitializeGet();
            InitializeSet();
        }

        private void InitializeSet()
        {
            if (Property.CanWrite)
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
                ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "value");
                UnaryExpression instance = (!Property.DeclaringType.IsValueType) ? Expression.TypeAs(parameterExpression, Property.DeclaringType) : Expression.Convert(parameterExpression, Property.DeclaringType);
                UnaryExpression unaryExpression = (!Property.PropertyType.IsValueType) ? Expression.TypeAs(parameterExpression2, Property.PropertyType) : Expression.Convert(parameterExpression2, Property.PropertyType);
                SetDelegate = Expression.Lambda<Action<object, object>>((Expression)Expression.Call(instance, Property.GetSetMethod(), unaryExpression), new ParameterExpression[2]
                {
                    parameterExpression,
                    parameterExpression2
                }).Compile();
            }
        }

        private void InitializeGet()
        {
            if (Property.CanRead)
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
                UnaryExpression instance = (!Property.DeclaringType.IsValueType) ? Expression.TypeAs(parameterExpression, Property.DeclaringType) : Expression.Convert(parameterExpression, Property.DeclaringType);
                GetDelegate = Expression.Lambda<Func<object, object>>((Expression)Expression.TypeAs(Expression.Call(instance, Property.GetGetMethod()), typeof(object)), new ParameterExpression[1]
                {
                    parameterExpression
                }).Compile();
            }
        }

        public object Get(object instance)
        {
            if (GetDelegate != null)
            {
                return GetDelegate(instance);
            }
            return null;
        }

        public void Set(object instance, object value)
        {
            if (SetDelegate != null)
            {
                SetDelegate(instance, value);
            }
        }
    }
}
