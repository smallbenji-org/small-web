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
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string id);
        Task CreateUser(User user);
        Task UpdateMember(User user);
        Task DeleteMember(int id);
    }
}
