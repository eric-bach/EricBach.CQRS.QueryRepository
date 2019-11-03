using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EricBach.CQRS.QueryRepository.Response;
using Newtonsoft.Json;

namespace EricBach.CQRS.QueryRepository
{
    public class ElasticSearchRepository<T> : IReadRepository<T> where T : class
    {
        public HttpClient HttpClient { get; set; }
        public string ElasticSearchDomain { get; set; }

        public ElasticSearchRepository(string elasticSearchDomain)
        {
            HttpClient = new HttpClient();
            ElasticSearchDomain = elasticSearchDomain;
        }

        public async Task<string> GetByIdAsync(Guid id)
        {
            var model = Regex.Matches(typeof(T).Name, @"([A-Z][a-z]+)").Cast<Match>().Select(m => m.Value).First().ToLower();
            var url = $"https://{ElasticSearchDomain}/{model}/_doc/{id}";
            
            var response = await HttpClient.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<ElasticSearchResponse> AddAsync(string index, string id, string message)
        {
            var url = $"https://{ElasticSearchDomain}/{index}/_doc/{id}";
            var content = new StringContent(message, Encoding.UTF8, "application/json");

            var response = await HttpClient.PutAsync(url, content);

            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ElasticSearchResponse>(body);
        }

        public async Task<ElasticSearchResponse> UpdateAsync(string index, string id, string message)
        {
            var url = $"https://{ElasticSearchDomain}/{index}/_doc/{id}/_update";
            var content = new StringContent(message, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync(url, content);

            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ElasticSearchResponse>(body);
        }
    }
}
