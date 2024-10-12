
using System.Data;

namespace Hrm
{
    public sealed class UserQueryExecutor : DataBaseFactory, IUserQueryExecutor
    {
        public UserQueryExecutor(IDbConnection connection) :base(connection)
        {
        }
    }
}
