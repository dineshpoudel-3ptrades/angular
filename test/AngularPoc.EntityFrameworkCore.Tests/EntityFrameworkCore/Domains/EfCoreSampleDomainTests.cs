using AngularPoc.Samples;
using Xunit;

namespace AngularPoc.EntityFrameworkCore.Domains;

[Collection(AngularPocTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AngularPocEntityFrameworkCoreTestModule>
{

}
