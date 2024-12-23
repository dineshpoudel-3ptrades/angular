using System;
using AngularPoc.Shared;
using Volo.Abp.AutoMapper;
using AngularPoc.Feedbacks;
using AutoMapper;
using AngularPoc.Books;

namespace AngularPoc;

public class AngularPocApplicationAutoMapperProfile : Profile
{
    public AngularPocApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Feedback, FeedbackDto>();
        CreateMap<Feedback, FeedbackExcelDto>();
    }
}