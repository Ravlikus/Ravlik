using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_3
{
    public class Solution
    {
        public static string AddOrChangeURLParameters(string url, string parameters)
        {
            var haveSomeParams = url.Contains('?');
            var urlPart = haveSomeParams ? url.Split('?')[0] : url;
            var paramsPart = haveSomeParams ? url.Split('?')[1] : "";
            var oldParams = ParseParams(paramsPart);
            var newParams = ParseParams(parameters);
            foreach(var pair in newParams)
            {
                if (oldParams.ContainsKey(pair.Key)) oldParams[pair.Key] = pair.Value;
                else oldParams.Add(pair.Key, pair.Value);
            }
            paramsPart = ParamsToString(oldParams);
            if (paramsPart.Length > 0) paramsPart = $"?{paramsPart}";
            return $"{urlPart}{paramsPart}";
        }

        public static string ParamsToString(Dictionary<string,string> data)
        {
            var result = new StringBuilder();
            int i = 0;
            foreach(var pair in data)
            {
                if (i == 0) result.Append($"{pair.Key}={pair.Value}");
                else result.Append($"&{pair.Key}={pair.Value}");
                i++;
            }
            return result.ToString();
        }

        public static Dictionary<string, string> ParseParams(string paramsStr)
        {
            var result = new Dictionary<string, string>();
            if (paramsStr == "") return result;
            var splitedParams = paramsStr.Contains('&') ? paramsStr.Split('&') : new[] { paramsStr};
            foreach(var str in splitedParams)
            {
                var pSplit = str.Split('=');
                result.Add(pSplit[0], pSplit[1]);
            }
            return result;
        }
    }
}
