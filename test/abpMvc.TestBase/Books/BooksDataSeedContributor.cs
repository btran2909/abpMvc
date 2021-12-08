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
                id: Guid.Parse("78d7f7de-3b06-45f1-b174-a06293ea771f"),
                name: "d381898264f748e79c6805bc2f256ef287b3",
                type: 1,
                publishDate: new DateTime(2008, 4, 10),
                price: 1164505867
            ));

            await _bookRepository.InsertAsync(new Book
            (
                id: Guid.Parse("f5d88395-abd1-4072-9254-04fadf54ce51"),
                name: "e8310c2c05af43a9b6b017e9a708a6444cdb",
                type: 0,
                publishDate: new DateTime(2016, 6, 7),
                price: 103302306
            ));
        }
    }
}