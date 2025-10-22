using AccesPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesPoint.Inferfaces
{
    public interface IUserData
    {
        Task<IEnumerable<User>> GetUsers(int top);
        Task<User> GetUser(int id);
        Task<User> GetSingleUser(string id);
        Task CreateUser(User user);
        Task UpdateMember(User user);
        Task DeleteMember(int id);
    }
}
