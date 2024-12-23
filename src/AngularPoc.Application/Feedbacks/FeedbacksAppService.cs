using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using AngularPoc.Permissions;
using AngularPoc.Feedbacks;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using AngularPoc.Shared;

namespace AngularPoc.Feedbacks
{
    [RemoteService(IsEnabled = false)]
    [Authorize(AngularPocPermissions.Feedbacks.Default)]
    public abstract class FeedbacksAppServiceBase : AngularPocAppService
    {
        protected IDistributedCache<FeedbackDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IFeedbackRepository _feedbackRepository;
        protected FeedbackManager _feedbackManager;

        public FeedbacksAppServiceBase(IFeedbackRepository feedbackRepository, FeedbackManager feedbackManager, IDistributedCache<FeedbackDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _feedbackRepository = feedbackRepository;
            _feedbackManager = feedbackManager;

        }

        public virtual async Task<PagedResultDto<FeedbackDto>> GetListAsync(GetFeedbacksInput input)
        {
            var totalCount = await _feedbackRepository.GetCountAsync(input.FilterText, input.Name, input.NumberMin, input.NumberMax);
            var items = await _feedbackRepository.GetListAsync(input.FilterText, input.Name, input.NumberMin, input.NumberMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<FeedbackDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Feedback>, List<FeedbackDto>>(items)
            };
        }

        public virtual async Task<FeedbackDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Feedback, FeedbackDto>(await _feedbackRepository.GetAsync(id));
        }

        [Authorize(AngularPocPermissions.Feedbacks.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _feedbackRepository.DeleteAsync(id);
        }

        [Authorize(AngularPocPermissions.Feedbacks.Create)]
        public virtual async Task<FeedbackDto> CreateAsync(FeedbackCreateDto input)
        {

            var feedback = await _feedbackManager.CreateAsync(
            input.Number, input.Name
            );

            return ObjectMapper.Map<Feedback, FeedbackDto>(feedback);
        }

        [Authorize(AngularPocPermissions.Feedbacks.Edit)]
        public virtual async Task<FeedbackDto> UpdateAsync(Guid id, FeedbackUpdateDto input)
        {

            var feedback = await _feedbackManager.UpdateAsync(
            id,
            input.Number, input.Name, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Feedback, FeedbackDto>(feedback);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(FeedbackExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _feedbackRepository.GetListAsync(input.FilterText, input.Name, input.NumberMin, input.NumberMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Feedback>, List<FeedbackExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Feedbacks.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(AngularPocPermissions.Feedbacks.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> feedbackIds)
        {
            await _feedbackRepository.DeleteManyAsync(feedbackIds);
        }

        [Authorize(AngularPocPermissions.Feedbacks.Delete)]
        public virtual async Task DeleteAllAsync(GetFeedbacksInput input)
        {
            await _feedbackRepository.DeleteAllAsync(input.FilterText, input.Name, input.NumberMin, input.NumberMax);
        }
        public virtual async Task<AngularPoc.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new FeedbackDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new AngularPoc.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}