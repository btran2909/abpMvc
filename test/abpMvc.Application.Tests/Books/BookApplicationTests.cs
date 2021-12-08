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
            result.Items.Any(x => x.Id == Guid.Parse("ea136109-c547-48b0-bcb7-bfd7f5364fbf")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("ef678172-c459-40c5-9e91-5195c115caa9")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _booksAppService.GetAsync(Guid.Parse("ea136109-c547-48b0-bcb7-bfd7f5364fbf"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("ea136109-c547-48b0-bcb7-bfd7f5364fbf"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new BookCreateDto
            {
                Name = "708d61eb14384fc4a6ab5eb3d4bcf7beb7a8",
                Type = 1,
                PublishDate = new DateTime(2005, 7, 10),
                Price = 1699715234
            };

            // Act
            var serviceResult = await _booksAppService.CreateAsync(input);

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("708d61eb14384fc4a6ab5eb3d4bcf7beb7a8");
            result.Type.ShouldBe(1);
            result.PublishDate.ShouldBe(new DateTime(2005, 7, 10));
            result.Price.ShouldBe(1699715234);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new BookUpdateDto()
            {
                Name = "618a04498d7a4d92ad3c76f55e13a6cb1223",
                Type = 0,
                PublishDate = new DateTime(2007, 10, 26),
                Price = 1319701992
            };

            // Act
            var serviceResult = await _booksAppService.UpdateAsync(Guid.Parse("ea136109-c547-48b0-bcb7-bfd7f5364fbf"), input);

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("618a04498d7a4d92ad3c76f55e13a6cb1223");
            result.Type.ShouldBe(0);
            result.PublishDate.ShouldBe(new DateTime(2007, 10, 26));
            result.Price.ShouldBe(1319701992);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _booksAppService.DeleteAsync(Guid.Parse("ea136109-c547-48b0-bcb7-bfd7f5364fbf"));

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == Guid.Parse("ea136109-c547-48b0-bcb7-bfd7f5364fbf"));

            result.ShouldBeNull();
        }
    }
}