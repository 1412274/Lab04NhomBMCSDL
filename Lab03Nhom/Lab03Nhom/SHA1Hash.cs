using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Lab03Nhom
{
    class SHA1Hash
    {
        public static String Hash(String pass)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            StringBuilder build = new StringBuilder();

            byte[] bs = Encoding.UTF8.GetBytes(pass);
            bs = sha1.ComputeHash(bs);

            for (int i = 0; i < bs.Length; i++)
            {
                build.Append(bs[i].ToString("X2"));
            }

            return build.ToString();
        }
    }
}
