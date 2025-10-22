using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesPoint.Inferfaces
{
    public interface ICrypt
    {
        public string Encrypt(string text);
        public string Decrypt(string text);
    }
}
