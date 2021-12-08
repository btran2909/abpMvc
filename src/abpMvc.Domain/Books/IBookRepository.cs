using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpMvc.Books
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
        Task<BookWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<BookWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string name = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? publishDateMin = null,
            DateTime? publishDateMax = null,
            float? priceMin = null,
            float? priceMax = null,
            Guid? authorId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Book>> GetListAsync(
                    string filterText = null,
                    string name = null,
                    int? typeMin = null,
                    int? typeMax = null,
                    DateTime? publishDateMin = null,
                    DateTime? publishDateMax = null,
                    float? priceMin = null,
                    float? priceMax = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? publishDateMin = null,
            DateTime? publishDateMax = null,
            float? priceMin = null,
            float? priceMax = null,
            Guid? authorId = null,
            CancellationToken cancellationToken = default);
    }
}