using Xunit;

namespace AngularPoc.EntityFrameworkCore;

[CollectionDefinition(AngularPocTestConsts.CollectionDefinitionName)]
public class AngularPocEntityFrameworkCoreCollection : ICollectionFixture<AngularPocEntityFrameworkCoreFixture>
{

}
