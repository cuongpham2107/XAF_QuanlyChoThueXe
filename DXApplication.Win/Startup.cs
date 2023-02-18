using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.ApplicationBuilder;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.XtraEditors;
using DXApplication.Blazor;
using DXApplication.Blazor.BusinessObjects;
using System.Configuration;

namespace DXApplication.Win;

public class ApplicationBuilder : IDesignTimeApplicationFactory
{
    public static WinApplication BuildApplication(string connectionString)
    {
        var builder = WinApplication.CreateBuilder();
        builder.UseApplication<DXApplicationWindowsFormsApplication>();
        builder.Modules
            .AddAuditTrailXpo()
            .AddCloningXpo()
            .AddConditionalAppearance()
            .AddDashboards(options =>
            {
                options.DashboardDataType = typeof(DevExpress.Persistent.BaseImpl.DashboardData);
                options.DesignerFormStyle = DevExpress.XtraBars.Ribbon.RibbonFormStyle.Ribbon;
            })
            .AddOffice()
            .AddReports(options =>
            {
                options.EnableInplaceReports = true;
                options.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
                options.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
            })
            .AddScheduler()
            .AddStateMachine(options =>
            {
                options.StateMachineStorageType = typeof(DevExpress.ExpressApp.StateMachine.Xpo.XpoStateMachine);
            })
            .AddTreeListEditors()
            .AddValidation(options =>
            {
                options.AllowValidationDetailsAccess = false;
            })
            .AddViewVariants()
            .Add<DXApplicationModule>()
            .Add<DXApplicationWinModule>();
        builder.ObjectSpaceProviders
            .AddSecuredXpo((application, options) =>
            {
                options.ConnectionString = connectionString;
            })
            .AddNonPersistent();
        builder.Security
            .UseIntegratedMode(options =>
            {
                options.RoleType = typeof(PermissionPolicyRole);
                options.UserType = typeof(ApplicationUser);
                options.UserLoginInfoType = typeof(ApplicationUserLoginInfo);
                options.UseXpoPermissionsCaching();
            })
            .UsePasswordAuthentication();
        builder.AddBuildStep(application =>
        {
            application.ConnectionString = connectionString;
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached && application.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema)
            {
                application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            }
#endif
        });
        var winApplication = builder.Build();
        return winApplication;
    }

    XafApplication IDesignTimeApplicationFactory.Create()
        => BuildApplication(XafApplication.DesignTimeConnectionString);
}
