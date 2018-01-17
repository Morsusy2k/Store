using System.Security.Cryptography;
using System.Text;

namespace Store.Utilities.Common.Helpers
{
    public static class Helpers
    {
        public static string GetMD5Hash(string value)
        {
            //calculate MD5 hash from input
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));

            //convert byte array to hex string
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

    }
}