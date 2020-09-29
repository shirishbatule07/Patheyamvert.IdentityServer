using Dapper;
using IdentityServer.Storage.Data;
using IdentityServer.Storage.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityServer.Storage
{
    public class UserStore<TUser, TUserClaim> : IUserStore<TUser>, IUserPasswordStore<TUser>
        where TUser : ApplicationUser
        where TUserClaim : IdentityUserClaim<string>
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserStore(
            IConnectionFactory connectionFactory
            )
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken)
        {
            using(IDbConnection conn = _connectionFactory.GetDbConnection())
            {
                await conn.ExecuteAsync("[dbo].[spIdentityUsers_Upsert]",
                    new
                    {
                        user.SubjectId,
                        user.UserName,
                        user.Email,
                        user.PasswordHash,
                        user.Role,
                        user.Name,
                        user.UserId
                    }, commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);
            }
            return IdentityResult.Success;
        }

        public async Task<bool> ValidateCredentials(string username, string password)
        {
            var user = await FindByNameAsync(username, new CancellationToken()).ConfigureAwait(false);
            if (user != null && user.PasswordHash.Equals(password))
            {
                return true;
            }
            return false;
        }
        public async Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken)
        {
            using(IDbConnection conn = _connectionFactory.GetDbConnection())
            {
                await conn.ExecuteAsync("[dbo].[spIdentityUsers_DeleteUser]",
                    new { user.SubjectId }, commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);
            }
            return IdentityResult.Success;
        }

        public void Dispose()
        {
        }

        public async Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using(IDbConnection conn = _connectionFactory.GetDbConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<TUser>("[dbo].[spIdentityUsers_GetUserById]",
                    new { SubjectId = userId }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        public async Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using (IDbConnection conn = _connectionFactory.GetDbConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<TUser>("[dbo].[spIdentityUsers_GetByUserName]",
                    new { UserName = normalizedUserName }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        public Task<string> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.SubjectId);
        }

        public Task<string> GetUserNameAsync(TUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken)
        {
            using (IDbConnection conn = _connectionFactory.GetDbConnection())
            {
                await conn.ExecuteAsync("[dbo].[spIdentityUsers_UpdateUser]",
                    new { 
                        user.SubjectId,
                        user.UserName,
                        user.PasswordHash,
                        user.Email
                    }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
            return IdentityResult.Success;
        }

        public async Task<ApplicationUser> FindBySubjectIdAsync(string subjectId)
        {
            using (IDbConnection conn = _connectionFactory.GetDbConnection())
            {
                return await conn.QueryFirstAsync<ApplicationUser>("[dbo].[spIdentityUsers_GetBySubjectId]",
                    new { subjectId }, commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);
            }
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash)? true : false);
        }

    }
}
