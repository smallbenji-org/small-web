using AccesPoint.Inferfaces;
using AccesPoint.Models;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace SmallEnergy.Auth
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>
    {
        private readonly ISqlDataAccess _db;
        private readonly IUserData userData;
        public UserStore(ISqlDataAccess db, IUserData userData)
        {
            this._db = db;
            this.userData = userData;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            await userData.CreateUser(user);
            return IdentityResult.Success;
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var sql = "SELECT * FROM dbo.vUmbracoUsers WHERE userName = @NormalizedUserName";
            var users = await _db.LoadData<User, dynamic>(sql, new { NormalizedUserName = normalizedUserName.ToUpper() }, "DefaultConnection");
            return users.FirstOrDefault();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user.Id.ToString());

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user.userName);

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.userName = userName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user.userName);

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.userName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.userPassword = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user.userPassword);

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(!string.IsNullOrWhiteSpace(user.userPassword));

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            var sql = "DELETE FROM dbo.umbracoUser WHERE id = @Id";
            _db.SaveData(sql, new { user.Id }, "DefaultConnection");
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            userData.UpdateMember(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var sql = "SELECT * FROM dbo.vUmbracoUsers WHERE id = @Id";
            var users = await _db.LoadData<User, dynamic>(sql, new { Id = int.Parse(userId) }, "DefaultConnection");
            return users.FirstOrDefault();
        }

        public void Dispose() { }
    }
}