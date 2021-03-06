﻿using Newtonsoft.Json;

namespace EricBach.CQRS.QueryRepository.Response
{
    public class ElasticSearchResponse
    {
        [JsonProperty("_index")]
        public string Index { get; set; }
        [JsonProperty("_type")]
        public string Type { get; set; }
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("_version")]
        public int Version { get; set; }
        [JsonProperty("result")]
        public string Result { get; set; }
        [JsonProperty("_shards")]
        public Shard Shards { get; set; }
        [JsonProperty("_seq_no")]
        public int SequenceNumber { get; set; }
        [JsonProperty("_primary_term")]
        public int PrimaryTerm { get; set; }
    }
}
