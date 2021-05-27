using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.ComponentModel;
using System.Text;

namespace SmallRob.SecuretUtil
{
    /// <summary>
    /// SM4算法
    /// 对标国际的DES算法
    /// </summary>
    public class Sm4Crypto
    {
        public Sm4Crypto() { }

        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 秘钥
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 向量
        /// </summary>
        public string Iv { get; set; }
        /// <summary>
        /// 明文是否是十六进制
        /// </summary>
        public bool HexString { get; set; }
        /// <summary>
        /// 加密模式(默认ECB)
        /// </summary>
        public Sm4CryptoEnum CryptoMode { get; set; }
        /// <summary>
        /// 编码模式（默认UTF8）
        /// </summary>
        public EncodingEnum encoding { get; set; }

        #region 加密
        public string Encrypt(Sm4Crypto entity)
        {
            return entity.CryptoMode == Sm4CryptoEnum.CBC ? EncryptCBC(entity) : EncryptECB(entity);
        }

        /// <summary>
        /// ECB加密
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string EncryptECB(Sm4Crypto entity)
        {
            try
            {
                Sm4Context ctx = new Sm4Context
                {
                    IsPadding = true,
                    Mode = SM4.SM4_ENCRYPT
                };

                byte[] keyBytes = entity.HexString ? Hex.Decode(entity.Key) : Encoding.Default.GetBytes(entity.Key);

                SM4 sm4 = new SM4();
                sm4.SetKeyEnc(ctx, keyBytes);
                byte[] encrypted = sm4.Sm4CryptEcb(ctx, Encoding.Default.GetBytes(entity.Data));

                if (entity.HexString)
                {
                    return entity.encoding == EncodingEnum.UTF8 ?
                          Encoding.UTF8.GetString(Hex.Encode(encrypted))
                        : Encoding.Default.GetString(Hex.Encode(encrypted));
                }
                else
                {
                    // ToBase64String
                    //byte[] temp = Encoding.Convert(Encoding.Default, Encoding.UTF8, encrypted);
                    return Convert.ToBase64String(encrypted);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("字符设定与原字符不匹配：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// CBC加密
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string EncryptCBC(Sm4Crypto entity)
        {
            Sm4Context ctx = new Sm4Context
            {
                IsPadding = true,
                Mode = SM4.SM4_ENCRYPT
            };

            byte[] keyBytes = entity.HexString ? Hex.Decode(entity.Key) : Encoding.Default.GetBytes(entity.Key);
            byte[] ivBytes = entity.HexString ? Hex.Decode(entity.Iv) : Encoding.Default.GetBytes(entity.Iv);

            SM4 sm4 = new SM4();
            sm4.SetKeyEnc(ctx, keyBytes);
            byte[] encrypted = sm4.Sm4CryptCbc(ctx, ivBytes, Encoding.Default.GetBytes(entity.Data));

            return entity.encoding == EncodingEnum.UTF8 ?
                  Encoding.UTF8.GetString(Hex.Encode(encrypted))
                : Encoding.Default.GetString(Hex.Encode(encrypted));
        }
        #endregion


        #region 解密
        public object Decrypt(Sm4Crypto entity)
        {
            return entity.CryptoMode == Sm4CryptoEnum.CBC ? DecryptCBC(entity) : DecryptECB(entity);
        }

        /// <summary>
        ///  ECB解密
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string DecryptECB(Sm4Crypto entity)
        {
            Sm4Context ctx = new Sm4Context
            {
                IsPadding = true,
                Mode = SM4.SM4_DECRYPT
            };

            byte[] keyBytes = entity.HexString ? Hex.Decode(entity.Key) : Encoding.Default.GetBytes(entity.Key);

            SM4 sm4 = new SM4();
            sm4.Sm4SetKeyDec(ctx, keyBytes);

            byte[] decrypted;
            try
            {
                decrypted = sm4.Sm4CryptEcb(ctx, Hex.Decode(entity.Data));
                return entity.encoding == EncodingEnum.UTF8 ?
                      Encoding.UTF8.GetString(decrypted)
                    : Encoding.Default.GetString(decrypted);
            }
            catch (Exception)
            {
                byte[] contentBytes = Convert.FromBase64String(entity.Data);
                decrypted = sm4.Sm4CryptEcb(ctx, contentBytes);

                return entity.encoding == EncodingEnum.UTF8 ?
                      Encoding.UTF8.GetString(decrypted)
                    : Encoding.Default.GetString(decrypted);
            }
        }

        /// <summary>
        /// CBC解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string DecryptCBC(Sm4Crypto entity)
        {
            Sm4Context ctx = new Sm4Context
            {
                IsPadding = true,
                Mode = SM4.SM4_DECRYPT
            };

            byte[] keyBytes = entity.HexString ? Hex.Decode(entity.Key) : Encoding.Default.GetBytes(entity.Key);
            byte[] ivBytes = entity.HexString ? Hex.Decode(entity.Iv) : Encoding.Default.GetBytes(entity.Iv);

            SM4 sm4 = new SM4();
            sm4.Sm4SetKeyDec(ctx, keyBytes);
            byte[] decrypted = sm4.Sm4CryptCbc(ctx, ivBytes, Convert.FromBase64String(entity.Data));

            return entity.encoding == EncodingEnum.UTF8 ?
                Encoding.UTF8.GetString(decrypted) : Encoding.Default.GetString(decrypted);
        }
        #endregion

        /// <summary>
        /// 加密类型
        /// </summary>
        public enum Sm4CryptoEnum
        {
            /// <summary>
            /// ECB(电码本模式)
            /// </summary>
            [Description("ECB模式")]
            ECB = 0,

            /// <summary>
            /// CBC(密码分组链接模式)
            /// </summary>
            [Description("CBC模式")]
            CBC = 1
        }

        /// <summary>
        /// 编码类型
        /// </summary>
        public enum EncodingEnum
        {
            /// <summary>
            /// 默认编码
            /// </summary>
            [Description("默认编码")]
            Default = 0,

            /// <summary>
            /// UFT8编码
            /// </summary>
            [Description("UFT8编码")]
            UTF8 = 1
        }
    }
}
