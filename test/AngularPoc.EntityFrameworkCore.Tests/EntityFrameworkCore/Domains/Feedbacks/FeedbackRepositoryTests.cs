using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AngularPoc.Feedbacks;
using AngularPoc.EntityFrameworkCore;
using Xunit;

namespace AngularPoc.EntityFrameworkCore.Domains.Feedbacks
{
    public class FeedbackRepositoryTests : AngularPocEntityFrameworkCoreTestBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackRepositoryTests()
        {
            _feedbackRepository = GetRequiredService<IFeedbackRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _feedbackRepository.GetListAsync(
                    name: "729b0f"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("3f2257c3-a3ec-48e6-94a9-3d45c1d7acc8"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _feedbackRepository.GetCountAsync(
                    name: "faeb3ac965ca473ab38f9db28791d77166159d47ee304eeeb7ca8f0"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}