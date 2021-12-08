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
                    name: "22931850a90e4c02a0e08e15db325a392ca5"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("ea136109-c547-48b0-bcb7-bfd7f5364fbf"));
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
                    name: "c00bba317d744913b719cf9f5f0b78b6983b"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}