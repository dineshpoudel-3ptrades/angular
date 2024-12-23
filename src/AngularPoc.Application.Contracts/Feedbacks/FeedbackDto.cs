using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace AngularPoc.Feedbacks
{
    public abstract class FeedbackDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string? Name { get; set; }
        public int Number { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}