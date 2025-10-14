using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesPoint
{
    internal interface IDbHandler
    {
        public IDataReader ExecuteReader(string query);
        public object ExecuteScalar(string query, object param = null);
        public object Execute(string query, object param = null);
    }
}
