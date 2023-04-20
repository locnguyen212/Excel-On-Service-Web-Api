using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CallCenter.Utils.Helpers
{
    public class DateTextConverter : JsonConverter<DateTime>
    {
        private string dateFormat = "yyyy-MM-dd HH:mm:ss";
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                Console.WriteLine(reader.GetString());
                return DateTime.ParseExact(reader.GetString(), dateFormat, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception();
            }

        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(dateFormat));
        }
    }
}
