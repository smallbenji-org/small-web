using AccesPoint.Inferfaces;
using AccesPoint.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesPoint.Users
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;
        private readonly ILogger<User> _logger;

        public UserData(ISqlDataAccess db, ILogger<User> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public Task CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMember(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string id) => _db.LoadData<User, dynamic>("SELECT * FROM public.\"vGetAllUsers\" WHERE \"Id\" = @Id LIMIT 1", new {Id = id}, "DefaultConnection").ContinueWith(t => t.Result.FirstOrDefault());

        public Task<IEnumerable<User>> GetUsers() => _db.LoadData<User, dynamic>("SELECT * FROM public.\"vGetAllUsers\" LIMIT 50", null, "DefaultConnection");

        public Task UpdateMember(User user)
        {
            throw new NotImplementedException();
        }
    }
}
