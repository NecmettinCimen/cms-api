using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cms_api.Helper
{
    public static class JsonHelper
    {
        public static bool ValidateJSON(this string s)
        {
            var response = false;
            try
            {
                JToken.Parse(s);
                response = true;
            }
            catch (JsonReaderException)
            {
                response = false;
            }
            return response;
        }
    }
}