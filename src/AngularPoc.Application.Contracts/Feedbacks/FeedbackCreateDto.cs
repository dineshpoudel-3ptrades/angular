using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AngularPoc.Feedbacks
{
    public abstract class FeedbackCreateDtoBase
    {
        public string? Name { get; set; }
        public int Number { get; set; }
    }
}