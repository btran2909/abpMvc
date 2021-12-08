using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AbpMvc.Authors
{
    public class AuthorsAppServiceTests : AbpMvcApplicationTestBase
    {
        private readonly IAuthorsAppService _authorsAppService;
        private readonly IRepository<Author, Guid> _authorRepository;

        public AuthorsAppServiceTests()
        {
            _authorsAppService = GetRequiredService<IAuthorsAppService>();
            _authorRepository = GetRequiredService<IRepository<Author, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _authorsAppService.GetListAsync(new GetAuthorsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("c69ea9ef-bcbc-4859-ac6b-63ccc47a92de")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("c6ef3893-7966-43b6-a560-88f7274b9002")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _authorsAppService.GetAsync(Guid.Parse("c69ea9ef-bcbc-4859-ac6b-63ccc47a92de"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("c69ea9ef-bcbc-4859-ac6b-63ccc47a92de"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new AuthorCreateDto
            {
                Name = "761180ba3f4947c880c4c7185c423b28b634",
                BirthDate = new DateTime(2003, 7, 25),
                ShortBio = "90390ec9629d4fa9a6db91e19a06dc18b10ea9b"
            };

            // Act
            var serviceResult = await _authorsAppService.CreateAsync(input);

            // Assert
            var result = await _authorRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("761180ba3f4947c880c4c7185c423b28b634");
            result.BirthDate.ShouldBe(new DateTime(2003, 7, 25));
            result.ShortBio.ShouldBe("90390ec9629d4fa9a6db91e19a06dc18b10ea9b");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new AuthorUpdateDto()
            {
                Name = "ffc1bf8ad61d4b04afadc8a57b662c93475d",
                BirthDate = new DateTime(2020, 10, 23),
                ShortBio = "06a1d1c217ac41f684a3d3c6b4158c8abe3b4e6177e14cd8bc2b0c0f97c8f2a"
            };

            // Act
            var serviceResult = await _authorsAppService.UpdateAsync(Guid.Parse("c69ea9ef-bcbc-4859-ac6b-63ccc47a92de"), input);

            // Assert
            var result = await _authorRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("ffc1bf8ad61d4b04afadc8a57b662c93475d");
            result.BirthDate.ShouldBe(new DateTime(2020, 10, 23));
            result.ShortBio.ShouldBe("06a1d1c217ac41f684a3d3c6b4158c8abe3b4e6177e14cd8bc2b0c0f97c8f2a");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _authorsAppService.DeleteAsync(Guid.Parse("c69ea9ef-bcbc-4859-ac6b-63ccc47a92de"));

            // Assert
            var result = await _authorRepository.FindAsync(c => c.Id == Guid.Parse("c69ea9ef-bcbc-4859-ac6b-63ccc47a92de"));

            result.ShouldBeNull();
        }
    }
}