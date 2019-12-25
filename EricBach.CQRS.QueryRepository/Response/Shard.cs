using Newtonsoft.Json;

namespace EricBach.CQRS.QueryRepository.Response
{
    public class Shard
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("successful")]
        public int Successful { get; set; }
        [JsonProperty("failed")]
        public int Failed { get; set; }
    }
}