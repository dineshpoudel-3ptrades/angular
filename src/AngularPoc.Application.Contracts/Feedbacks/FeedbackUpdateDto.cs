using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AngularPoc.Feedbacks
{
    public abstract class FeedbackUpdateDtoBase : IHasConcurrencyStamp
    {
        public string? Name { get; set; }
        public int Number { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}