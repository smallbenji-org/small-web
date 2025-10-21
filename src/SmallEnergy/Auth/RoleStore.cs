using AccesPoint.Inferfaces;
using AccesPoint.Models;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace SmallEnergy.Auth
{
    public class RoleStore : IRoleStore<UserRole>
    {
        private readonly ISqlDataAccess _db;

        public RoleStore(ISqlDataAccess db)
        {
            this._db = db;
        }

        public async Task<IdentityResult> CreateAsync(UserRole role, CancellationToken cancellationToken)
        {
            const string sql = @"
            INSERT INTO roles (id, name, normalized_name, description)
            VALUES (@Id, @Name, @NormalizedName, @Description)";
            await _db.SaveData(sql, new { role }, "DefaultConnection");
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(UserRole role, CancellationToken cancellationToken)
        {
            const string sql = @"
            UPDATE roles
            SET name = @Name,
                normalized_name = @NormalizedName,
                description = @Description
            WHERE id = @Id";
            await _db.SaveData(sql, new { role }, "DefaultConnection");
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(UserRole role, CancellationToken cancellationToken)
        {
            const string sql = "DELETE FROM roles WHERE id = @Id";
            await _db.SaveData(sql, new { role.Id }, "DefaultConnection");
            return IdentityResult.Success;
        }

        public async Task<UserRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            const string sql = "SELECT * FROM roles WHERE id = @Id";
            return (UserRole)await _db.LoadData<UserRole, dynamic>(sql, new { Id = roleId }, "DefaultConnection");
        }

        public async Task<UserRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            const string sql = "SELECT * FROM roles WHERE normalized_name = @NormalizedName";
            return (UserRole)await _db.LoadData<UserRole, dynamic>(sql, new { NormalizedName = normalizedRoleName }, "DefaultConnection");
        }

        public Task<string> GetRoleIdAsync(UserRole role, CancellationToken cancellationToken)
            => throw new NotImplementedException(); //Task.FromResult(role.Id);

        public Task<string> GetRoleNameAsync(UserRole role, CancellationToken cancellationToken)
            => Task.FromResult(role.userName);

        public Task SetRoleNameAsync(UserRole role, string roleName, CancellationToken cancellationToken)
        {
            role.userName = roleName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedRoleNameAsync(UserRole role, CancellationToken cancellationToken)
            => Task.FromResult(role.userName);

        public Task SetNormalizedRoleNameAsync(UserRole role, string normalizedName, CancellationToken cancellationToken)
        {
            role.userName = normalizedName;
            return Task.CompletedTask;
        }

        public void Dispose() { }
    }
}