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
    public class Search : ISearch
    {
        private readonly ISqlDataAccess _db;
        private readonly ILogger<User> _logger;

        public Search(ISqlDataAccess db, ILogger<User> logger)
        {
            this._db = db;
            this._logger = logger;
        }
        public void AddSearch(string search)
        {
            _db.SaveData("EXEC dbo.dspAddSearch @search", new { search = search }, "DefaultConnection");
        }

        public Task<IEnumerable<string>> GetPopularSearches(int top) => _db.LoadData<string, dynamic>("SELECT TOP 5 search FROM dbo.vPopularSearches ORDER BY count DESC", null, "DefaultConnection");
    }
}
