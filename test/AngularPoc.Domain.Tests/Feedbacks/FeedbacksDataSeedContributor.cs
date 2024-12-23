using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AngularPoc.Feedbacks;

namespace AngularPoc.Feedbacks
{
    public class FeedbacksDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public FeedbacksDataSeedContributor(IFeedbackRepository feedbackRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _feedbackRepository = feedbackRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _feedbackRepository.InsertAsync(new Feedback
            (
                id: Guid.Parse("3f2257c3-a3ec-48e6-94a9-3d45c1d7acc8"),
                name: "729b0f",
                number: 433617516
            ));

            await _feedbackRepository.InsertAsync(new Feedback
            (
                id: Guid.Parse("fa935e81-5f21-44f3-b57b-ec738a517a0f"),
                name: "faeb3ac965ca473ab38f9db28791d77166159d47ee304eeeb7ca8f0",
                number: 1147843726
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}