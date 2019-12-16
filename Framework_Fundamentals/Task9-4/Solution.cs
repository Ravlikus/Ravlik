using System;
using System.Collections.Generic;
using System.Linq;

namespace Task9_4
{
    public class  Solution<X> where X : IComparable
    {
        public static List<X> GetUniqueInOrder<T>(T data) where T : IEnumerable<X>
        {
            var result = new List<X>();
            X cacheObj = data.First();
            var flag = true;
            foreach(X obj in data)
            {
                if (flag|| cacheObj.CompareTo(obj) != 0)
                {
                    result.Add(obj);
                    cacheObj = obj;
                    flag = false;
                }
            }
            return result;
        }
    }
}
