using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesPoint.Inferfaces
{
    public interface ISearch
    {
        void AddSearch(string search);
        Task<IEnumerable<string>> GetPopularSearches(int top);
        Task<IEnumerable<(string, int)>> GetPopularSearchesByDate(int top, DateTime fromDate, DateTime toDate);
    }
}
