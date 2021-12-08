using AbpMvc.Books;
using AutoMapper;

namespace AbpMvc.Web
{
    public class AbpMvcWebAutoMapperProfile : Profile
    {
        public AbpMvcWebAutoMapperProfile()
        {
            //Define your object mappings here, for the Web project

            CreateMap<BookDto, BookUpdateDto>();
        }
    }
}