using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallRob.SecuretTool
{
    public static class EncryptEnum
    {
        /// <summary>
        /// 加密类型
        /// </summary>
        public enum EncryptType
        {
            /// <summary>
            /// AES
            /// </summary>
            [Description("AES")]
            AES = 0,

            /// <summary>
            /// DES
            /// </summary>
            [Description("DES")]
            DES = 1,

            /// <summary>
            /// MD5
            /// </summary>
            [Description("MD5")]
            MD5 = 2,

            /// <summary>
            /// SM4
            /// </summary>
            [Description("SM4")]
            SM4 = 3,

            /// <summary>
            /// SM3
            /// </summary>
            [Description("SM3")]
            SM3 = 4,

            /// <summary>
            /// SM2
            /// </summary>
            [Description("SM2")]
            SM2 = 5
        }
    }
}
