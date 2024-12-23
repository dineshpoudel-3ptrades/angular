namespace AngularPoc.Feedbacks
{
    public static class FeedbackConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Feedback." : string.Empty);
        }

    }
}