using Dapper;
using System.Data;

namespace Hrm
{
    public abstract class DataBaseFactory
    {
        protected readonly IDbConnection _connection;
        protected IDbTransaction _transaction;
        private bool _disposed = false;

        protected DataBaseFactory(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }

        private void EnsureTransaction()
        {
            if (_transaction == null)
            {
                _transaction = _connection.BeginTransaction();
            }
        }




        public async Task<IEnumerable<object>> QueryAsync(string query, object param = null)
        {
            return _transaction is null ? await _connection.QueryAsync(query, param) : await _connection.QueryAsync(query, param, transaction: _transaction);
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null)
        {
            return _transaction is null ? await _connection.QueryAsync<T>(query, param) : await _connection.QueryAsync<T>(query, param, transaction: _transaction);
        }

        public async Task<T> QueryFirstAsync<T>(string query, object param = null)
        {
            return _transaction is null ? await _connection.QueryFirstAsync<T>(query, param) : await _connection.QueryFirstAsync<T>(query, param, transaction: _transaction);
        }
        public async Task<object> QueryFirstAsync(string query, object param = null)
        {
            return _transaction is null ? await _connection.QueryFirstAsync(query, param) : await _connection.QueryFirstAsync(query, param, transaction: _transaction);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string query, object param = null)
        {
            return _transaction is null ? await _connection.QueryMultipleAsync(query, param) : await _connection.QueryMultipleAsync(query, param, transaction: _transaction);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object param = null)
        {
            return _transaction is null ? await _connection.QueryFirstOrDefaultAsync<T>(query, param) : await _connection.QueryFirstOrDefaultAsync<T>(query, param, transaction: _transaction);
        }


        public async Task<object> QueryFirstOrDefaultAsync(string query, object param = null)
        {
            return _transaction is null ? await _connection.QueryFirstOrDefaultAsync(query, param) : await _connection.QueryFirstOrDefaultAsync(query, param, transaction: _transaction);
        }

        public async Task<T> ExecuteScalarAsync<T>(string query, object param = null)
        {
            return _transaction is null ? await _connection.ExecuteScalarAsync<T>(query, param) : await _connection.ExecuteScalarAsync<T>(query, param, transaction: _transaction);
        }

        public async Task<T> ExecuteSprocAsync<T>(string query, object param = null)
        {
            if (_transaction is null)
            {
                return await _connection.ExecuteScalarAsync<T>(query, param, commandType: CommandType.StoredProcedure);
            }
            else
            {
                return await _connection.ExecuteScalarAsync<T>(query, param, transaction: _transaction, commandType: CommandType.StoredProcedure);

            }
        }
        public async Task ExecuteSprocAsync(string query, object param = null)
        {
            if (_transaction is null)
            {
                await _connection.ExecuteScalarAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            else
            {
                await _connection.ExecuteScalarAsync(query, param, transaction: _transaction, commandType: CommandType.StoredProcedure);

            }
        }
        public async Task<T> ExecuteScalarAsyncWithTran<T>(string query, object param = null)
        {
            EnsureTransaction();
            return await _connection.ExecuteScalarAsync<T>(query, param, transaction: _transaction);
        }

        public async Task ExecuteAsync(string query, object param = null)
        {
            if (_transaction is null)
            {
                await _connection.ExecuteAsync(query, param);
            }
            else
            {
                await _connection.ExecuteAsync(query, param, transaction: _transaction);
            }
        }

        public async Task ExecuteAsyncWithTran(string query, object param = null)
        {
            EnsureTransaction();
            await _connection.ExecuteAsync(query, param, transaction: _transaction);
        }
        public async Task InsertAsync(string query, object param = null)
        {
            EnsureTransaction();
            await _connection.ExecuteAsync(query, param, transaction: _transaction);
        }

        public async Task<int> InsertAsyncWithIdentity(string query, object param = null)
        {
            EnsureTransaction();
            return await _connection.ExecuteScalarAsync<int>(query + "; SELECT SCOPE_IDENTITY();", param, transaction: _transaction);
        }

        public async Task UpdateAsync(string query, object param = null)
        {
            EnsureTransaction();
            await _connection.ExecuteAsync(query, param, transaction: _transaction);
        }

        public async Task DeleteAsync(string query, object param = null)
        {
            EnsureTransaction();
            await _connection.ExecuteAsync(query, param, transaction: _transaction);
        }

        // Implement IDisposable to handle resource cleanup

        public async Task CommitAsync()
        {
            if (_transaction == null) throw new InvalidOperationException("No transaction started.");

            try
            {
                await Task.Run(() => _transaction.Commit());
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                DisposeTransaction();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null) throw new InvalidOperationException("No transaction started.");
            await Task.Run(() => _transaction.Rollback());
            DisposeTransaction();
        }

        private void DisposeTransaction()
        {
            _transaction?.Dispose();
            _transaction = null;
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DisposeTransaction();
                    _connection?.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task<DateTime> GetServerDateTimeAsync()
        {
            EnsureTransaction();
            return await _connection.ExecuteScalarAsync<DateTime>("select getutcdate()", transaction: _transaction);
        }
    }


    public static class QueryExtension
    {
        public static async Task<List<T>> ListAsync<T>(this Task<IEnumerable<T>> obj)
        {
            return (await obj).ToList();
        }
    }

}
