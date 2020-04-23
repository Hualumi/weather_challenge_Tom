using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace weather.Model
{
    public partial class Weather
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }

        [JsonProperty("alert")]
        public Alert Alert { get; set; }
    }

    public partial class Alert
    {
    }

    public partial class Current
    {
        //[JsonProperty("last_updated_epoch")]
        //public long LastUpdatedEpoch { get; set; }

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }

        [JsonProperty("temp_c")]
        public long TempC { get; set; }

        //[JsonProperty("temp_f")]
        //public long TempF { get; set; }

        //[JsonProperty("is_day")]
        //public long IsDay { get; set; }

        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        //[JsonProperty("wind_mph")]
        //public long WindMph { get; set; }

        //[JsonProperty("wind_kph")]
        //public long WindKph { get; set; }

        //[JsonProperty("wind_degree")]
        //public long WindDegree { get; set; }

        //[JsonProperty("wind_dir")]
        //public string WindDir { get; set; }

        //[JsonProperty("pressure_mb")]
        //public long PressureMb { get; set; }

        //[JsonProperty("pressure_in")]
        //public double PressureIn { get; set; }

        //[JsonProperty("precip_mm")]
        //public long PrecipMm { get; set; }

        //[JsonProperty("precip_in")]
        //public long PrecipIn { get; set; }

        //[JsonProperty("humidity")]
        //public long Humidity { get; set; }

        //[JsonProperty("cloud")]
        //public long Cloud { get; set; }

        [JsonProperty("feelslike_c")]
        public long FeelslikeC { get; set; }

        //[JsonProperty("feelslike_f")]
        //public long FeelslikeF { get; set; }

        //[JsonProperty("vis_km")]
        //public long VisKm { get; set; }

        //[JsonProperty("vis_miles")]
        //public long VisMiles { get; set; }

        //[JsonProperty("uv")]
        //public long Uv { get; set; }

        //[JsonProperty("gust_mph")]
        //public double GustMph { get; set; }

        //[JsonProperty("gust_kph")]
        //public double GustKph { get; set; }
    }

    public partial class Condition
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }
    }

    public partial class Forecast
    {
        [JsonProperty("forecastday")]
        public Forecastday[] Forecastday { get; set; }
    }

    public partial class Forecastday
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("date_epoch")]
        public long DateEpoch { get; set; }

        [JsonProperty("day")]
        public Day Day { get; set; }

        [JsonProperty("astro")]
        public Astro Astro { get; set; }
    }

    public partial class Astro
    {
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        [JsonProperty("moonrise")]
        public string Moonrise { get; set; }

        [JsonProperty("moonset")]
        public string Moonset { get; set; }
    }

    public partial class Day
    {
        [JsonProperty("maxtemp_c")]
        public double MaxtempC { get; set; }

        //[JsonProperty("maxtemp_f")]
        //public double MaxtempF { get; set; }

        [JsonProperty("mintemp_c")]
        public double MintempC { get; set; }

        //[JsonProperty("mintemp_f")]
        //public double MintempF { get; set; }

        //[JsonProperty("avgtemp_c")]
        //public double AvgtempC { get; set; }

        //[JsonProperty("avgtemp_f")]
        //public double AvgtempF { get; set; }

        //[JsonProperty("maxwind_mph")]
        //public double MaxwindMph { get; set; }

        //[JsonProperty("maxwind_kph")]
        //public double MaxwindKph { get; set; }

        //[JsonProperty("totalprecip_mm")]
        //public double TotalprecipMm { get; set; }

        //[JsonProperty("totalprecip_in")]
        //public double TotalprecipIn { get; set; }

        //[JsonProperty("avgvis_km")]
        //public double AvgvisKm { get; set; }

        //[JsonProperty("avgvis_miles")]
        //public long AvgvisMiles { get; set; }

        //[JsonProperty("avghumidity")]
        //public long Avghumidity { get; set; }

        //[JsonProperty("condition")]
        //public Condition Condition { get; set; }

        //[JsonProperty("uv")]
        //public double Uv { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("tz_id")]
        public string TzId { get; set; }

        [JsonProperty("localtime_epoch")]
        public long LocaltimeEpoch { get; set; }

        [JsonProperty("localtime")]
        public string Localtime { get; set; }
    }

    public partial class Weather
    {
        public static Weather FromJson(string json) => JsonConvert.DeserializeObject<Weather>(json, weather.Model.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Weather self) => JsonConvert.SerializeObject(self, weather.Model.Converter.Settings);
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
}

