using Dapper;

namespace Hrm
{
    public interface IQuery
    {
        Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null);
        Task<IEnumerable<object>> QueryAsync(string query, object param = null);
        Task<T> QueryFirstAsync<T>(string query, object param = null);
        Task<object> QueryFirstAsync(string query, object param = null);
        Task<SqlMapper.GridReader> QueryMultipleAsync(string query, object param = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string query, object param = null);
        Task<object> QueryFirstOrDefaultAsync(string query, object param = null);
        Task<T> ExecuteScalarAsync<T>(string query, object param = null);
        Task<T> ExecuteSprocAsync<T>(string query, object param = null);
        Task ExecuteSprocAsync(string query, object param = null);
        Task<T> ExecuteScalarAsyncWithTran<T>(string query, object param = null);
        Task ExecuteAsync(string query, object param = null);
        Task ExecuteAsyncWithTran(string query, object param = null);
        Task<int> InsertAsyncWithIdentity(string query, object param = null);
        Task InsertAsync(string query, object param = null);
        Task UpdateAsync(string query, object param = null);
        Task DeleteAsync(string query, object param = null);
        Task CommitAsync();
        Task<DateTime> GetServerDateTimeAsync();
    }
}
