using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.CustomValidation
{
    public class CustomTimeJsonConverter : JsonConverter<DateTime>
    {
        private const string TimeFormat = "HH:mm";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (DateTime.TryParseExact(reader.GetString(), TimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                return DateTime.Today.Add(time.TimeOfDay); // Gán ngày mặc định là hôm nay
            }
            throw new JsonException("Invalid time format. Expected format: HH:mm");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(TimeFormat));
        }
    }
 
}
