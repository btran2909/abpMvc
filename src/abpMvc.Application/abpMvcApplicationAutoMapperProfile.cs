using AbpMvc.Authors;
using System;
using AbpMvc.Shared;
using Volo.Abp.AutoMapper;
using AbpMvc.Books;
using AutoMapper;

namespace AbpMvc
{
    public class AbpMvcApplicationAutoMapperProfile : Profile
    {
        public AbpMvcApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<BookCreateDto, Book>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<BookUpdateDto, Book>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Book, BookDto>();

            CreateMap<AuthorCreateDto, Author>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<AuthorUpdateDto, Author>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Author, AuthorDto>();

            CreateMap<BookWithNavigationProperties, BookWithNavigationPropertiesDto>();
            CreateMap<Author, LookupDto<Guid?>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
        }
    }
}