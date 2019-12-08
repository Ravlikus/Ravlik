using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_3
{
    public static class NullableExtentions
    {
        public static bool IsNull<T>(this T obj)
        {
            return /*(default(T).Equals(null) && obj.Equals(default(T))) || */(object)obj is null;
        }
    }
}
