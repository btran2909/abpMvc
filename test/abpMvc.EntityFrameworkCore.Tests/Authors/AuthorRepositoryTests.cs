using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AbpMvc.Authors;
using AbpMvc.EntityFrameworkCore;
using Xunit;

namespace AbpMvc.Authors
{
    public class AuthorRepositoryTests : AbpMvcEntityFrameworkCoreTestBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorRepositoryTests()
        {
            _authorRepository = GetRequiredService<IAuthorRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _authorRepository.GetListAsync(
                    name: "d7358980feb948d68ab44706029cfdc8eb0c",
                    shortBio: "2e7f25e3420147d99e1dbec8d6613bdc6053f2fb"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("c69ea9ef-bcbc-4859-ac6b-63ccc47a92de"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _authorRepository.GetCountAsync(
                    name: "9b40d0ba578744629953ad13f8f6500408f3",
                    shortBio: "7e9803024a7a4ca09b5cbcb15ad299c0dd1230d7877d4d96971d72b879ca5402ef84c1df1cb34cbab3273f"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}