using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesPoint.Inferfaces
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters, string connectionId);
        Task SaveData<T>(string sql, T parameters, string connectionId);

    }
}
