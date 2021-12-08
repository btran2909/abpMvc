using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AbpMvc.Books;
using AbpMvc.EntityFrameworkCore;
using Xunit;

namespace AbpMvc.Books
{
    public class BookRepositoryTests : AbpMvcEntityFrameworkCoreTestBase
    {
        private readonly IBookRepository _bookRepository;

        public BookRepositoryTests()
        {
            _bookRepository = GetRequiredService<IBookRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _bookRepository.GetListAsync(
                    name: "d381898264f748e79c6805bc2f256ef287b3"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("78d7f7de-3b06-45f1-b174-a06293ea771f"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _bookRepository.GetCountAsync(
                    name: "e8310c2c05af43a9b6b017e9a708a6444cdb"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}