using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace AngularPoc.Feedbacks
{
    public abstract class FeedbacksAppServiceTests<TStartupModule> : AngularPocApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IFeedbacksAppService _feedbacksAppService;
        private readonly IRepository<Feedback, Guid> _feedbackRepository;

        public FeedbacksAppServiceTests()
        {
            _feedbacksAppService = GetRequiredService<IFeedbacksAppService>();
            _feedbackRepository = GetRequiredService<IRepository<Feedback, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _feedbacksAppService.GetListAsync(new GetFeedbacksInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("3f2257c3-a3ec-48e6-94a9-3d45c1d7acc8")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("fa935e81-5f21-44f3-b57b-ec738a517a0f")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _feedbacksAppService.GetAsync(Guid.Parse("3f2257c3-a3ec-48e6-94a9-3d45c1d7acc8"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("3f2257c3-a3ec-48e6-94a9-3d45c1d7acc8"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new FeedbackCreateDto
            {
                Name = "bd039fc6cc0b410eb13a23b53250fa9",
                Number = 165140880
            };

            // Act
            var serviceResult = await _feedbacksAppService.CreateAsync(input);

            // Assert
            var result = await _feedbackRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("bd039fc6cc0b410eb13a23b53250fa9");
            result.Number.ShouldBe(165140880);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new FeedbackUpdateDto()
            {
                Name = "ca4e9b89ed3b4e39bdd5bc7118e05e99fd205bab0510444c8fff6d07b3308decab1785",
                Number = 1550151251
            };

            // Act
            var serviceResult = await _feedbacksAppService.UpdateAsync(Guid.Parse("3f2257c3-a3ec-48e6-94a9-3d45c1d7acc8"), input);

            // Assert
            var result = await _feedbackRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("ca4e9b89ed3b4e39bdd5bc7118e05e99fd205bab0510444c8fff6d07b3308decab1785");
            result.Number.ShouldBe(1550151251);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _feedbacksAppService.DeleteAsync(Guid.Parse("3f2257c3-a3ec-48e6-94a9-3d45c1d7acc8"));

            // Assert
            var result = await _feedbackRepository.FindAsync(c => c.Id == Guid.Parse("3f2257c3-a3ec-48e6-94a9-3d45c1d7acc8"));

            result.ShouldBeNull();
        }
    }
}