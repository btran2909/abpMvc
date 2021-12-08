using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using AbpMvc.Authors;

namespace AbpMvc.Authors
{
    public class AuthorsDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsDataSeedContributor(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _authorRepository.InsertAsync(new Author
            (
                id: Guid.Parse("c69ea9ef-bcbc-4859-ac6b-63ccc47a92de"),
                name: "d7358980feb948d68ab44706029cfdc8eb0c",
                birthDate: new DateTime(2011, 5, 26),
                shortBio: "2e7f25e3420147d99e1dbec8d6613bdc6053f2fb"
            ));

            await _authorRepository.InsertAsync(new Author
            (
                id: Guid.Parse("c6ef3893-7966-43b6-a560-88f7274b9002"),
                name: "9b40d0ba578744629953ad13f8f6500408f3",
                birthDate: new DateTime(2001, 9, 13),
                shortBio: "7e9803024a7a4ca09b5cbcb15ad299c0dd1230d7877d4d96971d72b879ca5402ef84c1df1cb34cbab3273f"
            ));
        }
    }
}