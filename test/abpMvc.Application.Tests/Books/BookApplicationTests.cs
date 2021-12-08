using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AbpMvc.Books
{
    public class BooksAppServiceTests : AbpMvcApplicationTestBase
    {
        private readonly IBooksAppService _booksAppService;
        private readonly IRepository<Book, Guid> _bookRepository;

        public BooksAppServiceTests()
        {
            _booksAppService = GetRequiredService<IBooksAppService>();
            _bookRepository = GetRequiredService<IRepository<Book, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _booksAppService.GetListAsync(new GetBooksInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Book.Id == Guid.Parse("78d7f7de-3b06-45f1-b174-a06293ea771f")).ShouldBe(true);
            result.Items.Any(x => x.Book.Id == Guid.Parse("f5d88395-abd1-4072-9254-04fadf54ce51")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _booksAppService.GetAsync(Guid.Parse("78d7f7de-3b06-45f1-b174-a06293ea771f"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("78d7f7de-3b06-45f1-b174-a06293ea771f"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new BookCreateDto
            {
                Name = "5d825b9893234c7f8c87ddeb976073647ccc",
                Type = 0,
                PublishDate = new DateTime(2020, 5, 9),
                Price = 2032273159
            };

            // Act
            var serviceResult = await _booksAppService.CreateAsync(input);

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("5d825b9893234c7f8c87ddeb976073647ccc");
            result.Type.ShouldBe(0);
            result.PublishDate.ShouldBe(new DateTime(2020, 5, 9));
            result.Price.ShouldBe(2032273159);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new BookUpdateDto()
            {
                Name = "9d9ba95d2f0a4e65baa11d69fd36fd616dd6",
                Type = 0,
                PublishDate = new DateTime(2020, 2, 7),
                Price = 1158746639
            };

            // Act
            var serviceResult = await _booksAppService.UpdateAsync(Guid.Parse("78d7f7de-3b06-45f1-b174-a06293ea771f"), input);

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("9d9ba95d2f0a4e65baa11d69fd36fd616dd6");
            result.Type.ShouldBe(0);
            result.PublishDate.ShouldBe(new DateTime(2020, 2, 7));
            result.Price.ShouldBe(1158746639);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _booksAppService.DeleteAsync(Guid.Parse("78d7f7de-3b06-45f1-b174-a06293ea771f"));

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == Guid.Parse("78d7f7de-3b06-45f1-b174-a06293ea771f"));

            result.ShouldBeNull();
        }
    }
}