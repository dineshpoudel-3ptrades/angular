using Volo.Abp.Application.Dtos;
using System;

namespace AngularPoc.Feedbacks
{
    public abstract class GetFeedbacksInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public int? NumberMin { get; set; }
        public int? NumberMax { get; set; }

        public GetFeedbacksInputBase()
        {

        }
    }
}