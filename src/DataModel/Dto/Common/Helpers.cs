using Newtonsoft.Json;

namespace Dto.Common
{
    public static class Helpers
    {
        public static string ToJsonNS(object obj, bool handleRefLoop = true)
        {
            try
            {
                if (handleRefLoop)
                return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                else
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
