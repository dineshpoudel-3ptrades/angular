using System;

namespace AngularPoc.Feedbacks;

public abstract class FeedbackDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}