using Newtonsoft.Json;
using System.Xml.Linq;

namespace Countries_Server.ViewModels
{

    public class CountryResponse
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("tld")]
        public List<string> TopLevelDomain { get; set; }

        [JsonProperty("cca2")]
        public string Cca2 { get; set; }

        [JsonProperty("ccn3")]
        public string Ccn3 { get; set; }

        [JsonProperty("cca3")]
        public string Cca3 { get; set; }

        [JsonProperty("cioc")]
        public string Cioc { get; set; }

        [JsonProperty("independent")]
        public bool? Independent { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("unMember")]
        public bool UnMember { get; set; }

        [JsonProperty("currencies")]
        public Dictionary<string, Currency> Currencies { get; set; }

        [JsonProperty("idd")]
        public Idd Idd { get; set; }

        [JsonProperty("capital")]
        public List<string> Capital { get; set; }

        [JsonProperty("altSpellings")]
        public List<string> AltSpellings { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("subregion")]
        public string Subregion { get; set; }

        [JsonProperty("languages")]
        public Dictionary<string, string> Languages { get; set; }

        [JsonProperty("translations")]
        public Dictionary<string, Translation> Translations { get; set; }

        [JsonProperty("latlng")]
        public List<double> Latlng { get; set; }

        [JsonProperty("landlocked")]
        public bool Landlocked { get; set; }

        [JsonProperty("borders")]
        public List<string> Borders { get; set; }

        [JsonProperty("area")]
        public double Area { get; set; }

        [JsonProperty("demonyms")]
        public Demonyms Demonyms { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("maps")]
        public Maps Maps { get; set; }

        [JsonProperty("population")]
        public long Population { get; set; }

        [JsonProperty("gini")]
        public Dictionary<string, double> Gini { get; set; }

        [JsonProperty("fifa")]
        public string Fifa { get; set; }

        [JsonProperty("car")]
        public Car Car { get; set; }

        [JsonProperty("timezones")]
        public List<string> Timezones { get; set; }

        [JsonProperty("continents")]
        public List<string> Continents { get; set; }

        [JsonProperty("flags")]
        public Flags Flags { get; set; }

        [JsonProperty("coatOfArms")]
        public CoatOfArms CoatOfArms { get; set; }

        [JsonProperty("startOfWeek")]
        public string StartOfWeek { get; set; }

        [JsonProperty("capitalInfo")]
        public CapitalInfo CapitalInfo { get; set; }

        [JsonProperty("postalCode")]
        public PostalCode PostalCode { get; set; }
    }

    public class Name
    {
        [JsonProperty("common")]
        public string Common { get; set; }

        [JsonProperty("official")]
        public string Official { get; set; }

        [JsonProperty("nativeName")]
        public Dictionary<string, NativeName> NativeName { get; set; }
    }

    public class NativeName
    {
        [JsonProperty("official")]
        public string Official { get; set; }

        [JsonProperty("common")]
        public string Common { get; set; }
    }

    public class Currency
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }

    public class Idd
    {
        [JsonProperty("root")]
        public string Root { get; set; }

        [JsonProperty("suffixes")]
        public List<string> Suffixes { get; set; }
    }

    public class Translation
    {
        [JsonProperty("official")]
        public string Official { get; set; }

        [JsonProperty("common")]
        public string Common { get; set; }
    }

    public class Demonyms
    {
        [JsonProperty("eng")]
        public Gender Eng { get; set; }

        [JsonProperty("fra")]
        public Gender Fra { get; set; }
    }

    public class Gender
    {
        [JsonProperty("f")]
        public string Female { get; set; }

        [JsonProperty("m")]
        public string Male { get; set; }
    }

    public class Maps
    {
        [JsonProperty("googleMaps")]
        public string GoogleMaps { get; set; }

        [JsonProperty("openStreetMaps")]
        public string OpenStreetMaps { get; set; }
    }

    public class Car
    {
        [JsonProperty("signs")]
        public List<string> Signs { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }
    }

    public class Flags
    {
        [JsonProperty("png")]
        public string Png { get; set; }

        [JsonProperty("svg")]
        public string Svg { get; set; }

        [JsonProperty("alt")]
        public string Alt { get; set; }
    }

    public class CoatOfArms
    {
        [JsonProperty("png")]
        public string Png { get; set; }

        [JsonProperty("svg")]
        public string Svg { get; set; }
    }

    public class CapitalInfo
    {
        [JsonProperty("latlng")]
        public List<double> Latlng { get; set; }
    }

    public class PostalCode
    {
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("regex")]
        public string Regex { get; set; }
    }

}
