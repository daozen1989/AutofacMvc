using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Core.Extentions
{
    public static class ObjectExtensions
    {
        public static T ToDataObject<T>(this object e)
        {
            return e != null ? (T)Activator.CreateInstance(typeof(T), e, '_') : default(T);
        }

        public static bool IsNullOrEmpty(this object obj)
            => obj.GetType().GetProperties()
                .Where(pi => pi.GetValue(obj) is string)
                .Select(pi => (string)pi.GetValue(obj))
                .All(string.IsNullOrEmpty);
    }
}
