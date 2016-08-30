using Newtonsoft.Json;

namespace Destiny.Net.Core.Model
{
    public class MobileWorldContentPaths
    {
        public string En { get; set; }
        public string Fr { get; set; }
        public string Es { get; set; }
        public string De { get; set; }
        public string Ja { get; set; }

        [JsonProperty("pt-br")]
        public string PtBr { get; set; }
    }
}