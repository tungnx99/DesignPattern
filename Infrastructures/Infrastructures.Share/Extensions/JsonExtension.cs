using Newtonsoft.Json;

namespace Infrastructures.Share.Extensions
{
    public static class JsonExtension
    {
        public static T Clone<T>(this T obj) where T : class
        {
            if (obj != null)
            {
                var jsonString = JsonConvert.SerializeObject(obj);

                return JsonConvert.DeserializeObject<T>(jsonString);
            }

            return null;
        }
    }
}
