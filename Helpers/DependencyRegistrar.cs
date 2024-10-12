using HumanResource.Services;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hrm.Helpers
{
    public static class DependencyRegistrar
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection>(provider =>new SqlConnection(AppSettings.GlobalConfiguration.GetConnectionString("DatabaseConnectionString")));
            services.AddScoped<IUserQueryExecutor, UserQueryExecutor>();
            services.AddScoped<IMetaUpdate, MetaUpdate>();
            services.AddScoped<IContactServiceRules, ContactServiceRules>();
            services.AddScoped<IContactService,ContactService>();
        }
    }
}
