using Newtonsoft.Json;

namespace ClientSideApp
{
    public static class JsonConversion
    {
        public static string SearializeData(object data)
        {
            string searialized = JsonConvert.SerializeObject(data, Formatting.Indented);

            return searialized;
        }

    }
}
