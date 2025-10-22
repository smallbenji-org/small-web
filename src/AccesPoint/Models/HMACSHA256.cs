using AccesPoint.Inferfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;
using System.Security.Cryptography;

namespace AccesPoint.Models
{
    public class HMACSHA256 : ICrypt
    {
        string ICrypt.Decrypt(string text)
        {
            throw new NotImplementedException();
        }

        string ICrypt.Encrypt(string text)
        {
            //using (HMACSHA256 hmac = new HMACSHA256(key))
            //{
            //    
            //}
            throw new NotImplementedException();
        }
    }
}
