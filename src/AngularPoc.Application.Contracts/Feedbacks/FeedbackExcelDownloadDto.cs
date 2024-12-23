using Volo.Abp.Application.Dtos;
using System;

namespace AngularPoc.Feedbacks
{
    public abstract class FeedbackExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public int? NumberMin { get; set; }
        public int? NumberMax { get; set; }

        public FeedbackExcelDownloadDtoBase()
        {

        }
    }
}