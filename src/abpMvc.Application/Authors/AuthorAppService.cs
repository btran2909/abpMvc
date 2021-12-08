using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using AbpMvc.Permissions;
using AbpMvc.Authors;

namespace AbpMvc.Authors
{

    [Authorize(AbpMvcPermissions.Authors.Default)]
    public class AuthorsAppService : ApplicationService, IAuthorsAppService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsAppService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public virtual async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorsInput input)
        {
            var totalCount = await _authorRepository.GetCountAsync(input.FilterText, input.Name, input.BirthDateMin, input.BirthDateMax, input.ShortBio);
            var items = await _authorRepository.GetListAsync(input.FilterText, input.Name, input.BirthDateMin, input.BirthDateMax, input.ShortBio, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AuthorDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Author>, List<AuthorDto>>(items)
            };
        }

        public virtual async Task<AuthorDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Author, AuthorDto>(await _authorRepository.GetAsync(id));
        }

        [Authorize(AbpMvcPermissions.Authors.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        [Authorize(AbpMvcPermissions.Authors.Create)]
        public virtual async Task<AuthorDto> CreateAsync(AuthorCreateDto input)
        {

            var author = ObjectMapper.Map<AuthorCreateDto, Author>(input);

            author = await _authorRepository.InsertAsync(author, autoSave: true);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        [Authorize(AbpMvcPermissions.Authors.Edit)]
        public virtual async Task<AuthorDto> UpdateAsync(Guid id, AuthorUpdateDto input)
        {

            var author = await _authorRepository.GetAsync(id);
            ObjectMapper.Map(input, author);
            author = await _authorRepository.UpdateAsync(author, autoSave: true);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }
    }
}