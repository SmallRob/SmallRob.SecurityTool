using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace SmallRob.SecuretUtil
{
    public class SignUtil
    {
        public static string MarkSign(string signType, Dictionary<string, string> paramDic)
        {
            if (paramDic == null || paramDic.Count == 0)
            {
                throw new Exception("签名参数不能为空");
            }

            StringBuilder sbStr = new StringBuilder();
            foreach (var param in paramDic)
            {
                sbStr.Append(param.Value);
            }

            string beforeSignStr = sbStr.Append(signType).ToString();

            if (signType == "MD5")
            {
                return MD5Utils.Md5Hex(beforeSignStr);
            }

            throw new Exception("未实现加密方式");
        }

        /**
        * 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
         * @return 时间戳
        */
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 验证时间戳是否超过指定时间
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static bool ValidTimeSpan(string timestamp)
        {
            double ts = 0;
            bool timespanvalidate = double.TryParse(timestamp, out ts);

            bool falg = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds - ts > 60 * 1000;

            if (falg || (!timespanvalidate))
                throw new SecurityException();

            return falg;
        }
    }
}
