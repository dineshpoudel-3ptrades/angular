using AngularPoc.Books;
using Xunit;

namespace AngularPoc.EntityFrameworkCore.Applications.Books;

[Collection(AngularPocTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<AngularPocEntityFrameworkCoreTestModule>
{

}