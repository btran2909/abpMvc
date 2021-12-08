using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using AbpMvc.Books;

namespace AbpMvc.Books
{
    public class BooksDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IBookRepository _bookRepository;

        public BooksDataSeedContributor(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _bookRepository.InsertAsync(new Book
            (
                id: Guid.Parse("ea136109-c547-48b0-bcb7-bfd7f5364fbf"),
                name: "22931850a90e4c02a0e08e15db325a392ca5",
                type: 1,
                publishDate: new DateTime(2017, 11, 25),
                price: 144359571
            ));

            await _bookRepository.InsertAsync(new Book
            (
                id: Guid.Parse("ef678172-c459-40c5-9e91-5195c115caa9"),
                name: "c00bba317d744913b719cf9f5f0b78b6983b",
                type: 1,
                publishDate: new DateTime(2007, 10, 27),
                price: 1198679933
            ));
        }
    }
}