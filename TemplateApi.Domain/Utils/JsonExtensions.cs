using System.Text.Json;

namespace TemplateApi.Domain.Utils
{
    public static class JsonExtensions
    {
        public static JsonSerializerOptions GetJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DateOnlyJsonConverter());

            return options;
        }
    }
}
