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

namespace AbpMvc.Authors
{
    public class EfCoreAuthorRepository : EfCoreRepository<AbpMvcDbContext, Author, Guid>, IAuthorRepository
    {
        public EfCoreAuthorRepository(IDbContextProvider<AbpMvcDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Author>> GetListAsync(
            string filterText = null,
            string name = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string shortBio = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, birthDateMin, birthDateMax, shortBio);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AuthorConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string shortBio = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, birthDateMin, birthDateMax, shortBio);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Author> ApplyFilter(
            IQueryable<Author> query,
            string filterText,
            string name = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string shortBio = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.ShortBio.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(birthDateMin.HasValue, e => e.BirthDate >= birthDateMin.Value)
                    .WhereIf(birthDateMax.HasValue, e => e.BirthDate <= birthDateMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(shortBio), e => e.ShortBio.Contains(shortBio));
        }
    }
}