using System;
using AngularPoc.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AngularPoc.Books;

public class BookAppService :
    CrudAppService<
        Book, //The Book entity
        BookDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto>, //Used to create/update a book
    IBookAppService //implement the IBookAppService
{
    public BookAppService(IRepository<Book, Guid> repository)
        : base(repository)
    {
        GetPolicyName = AngularPocPermissions.Books.Default;
        GetListPolicyName = AngularPocPermissions.Books.Default;
        CreatePolicyName = AngularPocPermissions.Books.Create;
        UpdatePolicyName = AngularPocPermissions.Books.Edit;
        DeletePolicyName = AngularPocPermissions.Books.Delete;
    }
}