using Hrm;
using Hrm.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotCode.WebAPI.Helpers
{
    public static class DependencyRegistrar
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection>(provider =>new SqlConnection(AppSettings.GlobalConfiguration.GetConnectionString("DbConnectionString")));
            services.AddScoped<IUserQueryExecutor,UserQueryExecutor>();

        }
    }
}
