using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace AbpMvc.Authors
{
    public class AuthorStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorStoreDataSeederContributor(
            IAuthorRepository authorRepository
        )
        {
            _authorRepository = authorRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _authorRepository.GetCountAsync() <= 0)
            {
                await _authorRepository.InsertAsync(
                    new Author
                    {
                        Name = "George Orwell",
                        BirthDate = new DateTime(1903, 06, 25),
                        ShortBio = "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
                    },
                    autoSave: true
                );

                await _authorRepository.InsertAsync(
                    new Author
                    {
                        Name = "Douglas Adams",
                        BirthDate = new DateTime(1952, 03, 11),
                        ShortBio = "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                    },
                    autoSave: true
                );
            }
        }
    }
}
