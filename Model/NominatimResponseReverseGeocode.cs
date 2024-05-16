using Newtonsoft.Json;

namespace Instrukcja.Model
{
    public class NominatimResponseReverseGeocode
    {
        //Rondo Romana Dmowskiego, Śródmieście Południowe, Śródmieście,
        //Warszawa, województwo mazowieckie, 00-510, Polska

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
