using System;

namespace Core.Helper
{
    public static class InstanceHelper
    {
        public static object CreateInstance(Type t, params object[] pars)
        {
            return Activator.CreateInstance(t, pars);
        }
    }
}
