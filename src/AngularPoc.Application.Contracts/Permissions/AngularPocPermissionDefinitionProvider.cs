using AngularPoc.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AngularPoc.Permissions;

public class AngularPocPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AngularPocPermissions.GroupName);

        myGroup.AddPermission(AngularPocPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(AngularPocPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        var booksPermission = myGroup.AddPermission(AngularPocPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AngularPocPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AngularPocPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AngularPocPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AngularPocPermissions.MyPermission1, L("Permission:MyPermission1"));

        var feedbackPermission = myGroup.AddPermission(AngularPocPermissions.Feedbacks.Default, L("Permission:Feedbacks"));
        feedbackPermission.AddChild(AngularPocPermissions.Feedbacks.Create, L("Permission:Create"));
        feedbackPermission.AddChild(AngularPocPermissions.Feedbacks.Edit, L("Permission:Edit"));
        feedbackPermission.AddChild(AngularPocPermissions.Feedbacks.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AngularPocResource>(name);
    }
}