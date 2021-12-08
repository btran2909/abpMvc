using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using AbpMvc.EntityFrameworkCore;

namespace AbpMvc.Books
{
    public class EfCoreBookRepository : EfCoreRepository<AbpMvcDbContext, Book, Guid>, IBookRepository
    {
        public EfCoreBookRepository(IDbContextProvider<AbpMvcDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<BookWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Book.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<BookWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, name, typeMin, typeMax, publishDateMin, publishDateMax, priceMin, priceMax, authorId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? BookConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<BookWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from book in (await GetDbSetAsync())
                   join author in (await GetDbContextAsync()).Authors on book.AuthorId equals author.Id into authors
                   from author in authors.DefaultIfEmpty()

                   select new BookWithNavigationProperties
                   {
                       Book = book,
                       Author = author
                   };
        }

        protected virtual IQueryable<BookWithNavigationProperties> ApplyFilter(
            IQueryable<BookWithNavigationProperties> query,
            string filterText,
            string name = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? publishDateMin = null,
            DateTime? publishDateMax = null,
            float? priceMin = null,
            float? priceMax = null,
            Guid? authorId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Book.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Book.Name.Contains(name))
                    .WhereIf(typeMin.HasValue, e => e.Book.Type >= typeMin.Value)
                    .WhereIf(typeMax.HasValue, e => e.Book.Type <= typeMax.Value)
                    .WhereIf(publishDateMin.HasValue, e => e.Book.PublishDate >= publishDateMin.Value)
                    .WhereIf(publishDateMax.HasValue, e => e.Book.PublishDate <= publishDateMax.Value)
                    .WhereIf(priceMin.HasValue, e => e.Book.Price >= priceMin.Value)
                    .WhereIf(priceMax.HasValue, e => e.Book.Price <= priceMax.Value)
                    .WhereIf(authorId != null && authorId != Guid.Empty, e => e.Author != null && e.Author.Id == authorId);
        }

        public async Task<List<Book>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, typeMin, typeMax, publishDateMin, publishDateMax, priceMin, priceMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? BookConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? publishDateMin = null,
            DateTime? publishDateMax = null,
            float? priceMin = null,
            float? priceMax = null,
            Guid? authorId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, name, typeMin, typeMax, publishDateMin, publishDateMax, priceMin, priceMax, authorId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Book> ApplyFilter(
            IQueryable<Book> query,
            string filterText,
            string name = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? publishDateMin = null,
            DateTime? publishDateMax = null,
            float? priceMin = null,
            float? priceMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(typeMin.HasValue, e => e.Type >= typeMin.Value)
                    .WhereIf(typeMax.HasValue, e => e.Type <= typeMax.Value)
                    .WhereIf(publishDateMin.HasValue, e => e.PublishDate >= publishDateMin.Value)
                    .WhereIf(publishDateMax.HasValue, e => e.PublishDate <= publishDateMax.Value)
                    .WhereIf(priceMin.HasValue, e => e.Price >= priceMin.Value)
                    .WhereIf(priceMax.HasValue, e => e.Price <= priceMax.Value);
        }
    }
}