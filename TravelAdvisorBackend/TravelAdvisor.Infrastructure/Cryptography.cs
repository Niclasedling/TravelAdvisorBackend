using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure
{
    class Cryptography
    {
        public static string EncryptData(string dataEncrypt) 
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(dataEncrypt);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hashDataResult = Encoding.ASCII.GetString(data);

            return hashDataResult;
        }
       
    }
}

