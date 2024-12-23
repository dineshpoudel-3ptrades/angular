using AngularPoc.Samples;
using Xunit;

namespace AngularPoc.EntityFrameworkCore.Applications;

[Collection(AngularPocTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AngularPocEntityFrameworkCoreTestModule>
{

}
