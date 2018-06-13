using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Lab03Nhom
{
    class MD5Hash
    {
        public static String Hash(String src)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            StringBuilder build = new StringBuilder();

            // Chuyển chuỗi cần hash thành chuỗi các byte
            byte[] buffer = Encoding.UTF8.GetBytes(src);
            // Tính toan hash
            buffer = md5.ComputeHash(buffer);

            // Chuyển từng byte thành chuỗi dạng hexa 
            for (int i = 0; i < buffer.Length; i++)
            {
                build.Append(buffer[i].ToString("X2"));
            }
            return build.ToString();
        }

    }
}
