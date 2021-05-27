using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SmallRob.SecuretUtil
{
    public static class MD5Utils
    {
        /// <summary>
        /// MD5转码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Md5Hex(string data)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dataHash = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in dataHash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 用MD5给文件签名
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>System.String.</returns>
        public static string Md5FileCode(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs = File.OpenRead(filePath))
                {
                    using (MD5 md5 = MD5.Create())
                    {
                        Byte[] buffer = md5.ComputeHash(fs);
                        md5.Clear();

                        StringBuilder stringBuilder = new StringBuilder();
                        for (int i = 0; i < buffer.Length; i++)
                        {
                            stringBuilder.Append(buffer[i].ToString("x2"));
                        }
                        return stringBuilder.ToString();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 用MD5给字符串签名
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string Md5StringCode(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] buffer = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                md5.Clear();

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < buffer.Length; i++)
                {
                    stringBuilder.Append(buffer[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        /// <summary>
        /// MD5转Base64位字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5ToBase64String(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] buffer = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                md5.Clear();

                return Convert.ToBase64String(buffer);
            }
        }
        /// <summary>
        /// MD5签名字符串.
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="signKey">密钥</param>
        /// <returns>签名后结果</returns>
        public static string Md5SignString(string input, string signKey, string defaultSeparator = "^")
        {
            string signString = signKey + defaultSeparator + input + defaultSeparator + signKey;
            return Md5StringCode(signString);
        }
    }
}
