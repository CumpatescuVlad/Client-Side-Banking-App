using Newtonsoft.Json;

namespace Token.BackEndComponents
{
    public static class JsonConversion
    {
        public static string SerializeData(object data)
        {
            string serialized = JsonConvert.SerializeObject(data, Formatting.Indented);

            return serialized;
        }


    }
}
