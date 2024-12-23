using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace AngularPoc.Feedbacks
{
    public abstract class FeedbackBase : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string? Name { get; set; }

        public virtual int Number { get; set; }

        protected FeedbackBase()
        {

        }

        public FeedbackBase(Guid id, int number, string? name = null)
        {

            Id = id;
            Number = number;
            Name = name;
        }

    }
}