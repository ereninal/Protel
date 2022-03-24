using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Protel.Service.TCMB.Model.Response
{
    public partial class Welcome3
    {
        [JsonProperty("Tarih_Date")]
        public TarihDate TarihDate { get; set; }
    }

    public partial class TarihDate
    {
        [JsonProperty("Currency")]
        public Currency[] Currency { get; set; }

        [JsonProperty("_Tarih")]
        public string Tarih { get; set; }

        [JsonProperty("_Date")]
        public string Date { get; set; }

        [JsonProperty("_Bulten_No")]
        public string BultenNo { get; set; }
    }

    public partial class Currency
    {
        [JsonProperty("Unit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Unit { get; set; }

        [JsonProperty("Isim")]
        public string Isim { get; set; }

        [JsonProperty("CurrencyName")]
        public string CurrencyName { get; set; }

        [JsonProperty("ForexBuying")]
        public string ForexBuying { get; set; }

        [JsonProperty("ForexSelling")]
        public string ForexSelling { get; set; }

        [JsonProperty("BanknoteBuying")]
        public string BanknoteBuying { get; set; }

        [JsonProperty("BanknoteSelling")]
        public string BanknoteSelling { get; set; }

        [JsonProperty("CrossRateUSD")]
        public string CrossRateUsd { get; set; }

        [JsonProperty("CrossRateOther")]
        public string CrossRateOther { get; set; }

        [JsonProperty("_CrossOrder")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CrossOrder { get; set; }

        [JsonProperty("_Kod")]
        public string Kod { get; set; }

        [JsonProperty("_CurrencyCode")]
        public string CurrencyCode { get; set; }
    }

    public partial class Welcome3
    {
        public static Welcome3 FromJson(string json) => JsonConvert.DeserializeObject<Welcome3>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome3 self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
