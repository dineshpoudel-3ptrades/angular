./build-image.ps1 -ProjectPath "../../src/AngularPoc.DbMigrator/AngularPoc.DbMigrator.csproj" -ImageName angularpoc/dbmigrator
./build-image.ps1 -ProjectPath "../../src/AngularPoc.HttpApi.Host/AngularPoc.HttpApi.Host.csproj" -ImageName angularpoc/httpapihost
./build-image.ps1 -ProjectPath "../../angular" -ImageName angularpoc/angular -ProjectType "angular"
