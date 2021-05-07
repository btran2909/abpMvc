using AutoMapper;
using abpMvc.Users;
using Volo.Abp.AutoMapper;

namespace abpMvc
{
    public class abpMvcApplicationAutoMapperProfile : Profile
    {
        public abpMvcApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<AppUser, AppUserDto>().Ignore(x => x.ExtraProperties);
        }
    }
}