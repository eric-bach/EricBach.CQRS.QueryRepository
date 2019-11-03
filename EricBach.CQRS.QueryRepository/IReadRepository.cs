using System;
using System.Threading.Tasks;
using EricBach.CQRS.QueryRepository.Response;

namespace EricBach.CQRS.QueryRepository
{
    public interface IReadRepository<T> where T : class
    {
        Task<string> GetByIdAsync(Guid id);
        Task<ElasticSearchResponse> AddAsync(string index, string id, string message);
        Task<ElasticSearchResponse> UpdateAsync(string index, string id, string message);
    }
}