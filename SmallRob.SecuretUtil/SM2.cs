using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallRob.SecuretUtil
{
    /// <summary>
    /// 加密处理中心
    /// </summary>
    public class SM2
    {
        public static SM2 Instance
        {
            get
            {
                return new SM2();
            }

        }
        public static SM2 InstanceTest
        {
            get
            {
                return new SM2();
            }

        }

        #region 曲线参数
        /// <summary>
        /// 曲线参数
        /// </summary>
        public static readonly string[] CurveParameter = {
            "FFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00000000FFFFFFFFFFFFFFFF",// p,0
            "FFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00000000FFFFFFFFFFFFFFFC",// a,1
            "28E9FA9E9D9F5E344D5A9E4BCF6509A7F39789F515AB8F92DDBCBD414D940E93",// b,2
            "FFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFF7203DF6B21C6052B53BBF40939D54123",// n,3
            "32C4AE2C1F1981195F9904466A39C9948FE30BBFF2660BE1715A4589334C74C7",// gx,4
            "BC3736A2F4F6779C59BDCEE36B692153D0A9877CC62A474002DF32E52139F0A0" // gy,5
        };
        /// <summary>
        /// 椭圆曲线参数
        /// </summary>
        public string[] EccParam = CurveParameter;
        /// <summary>
        /// 椭圆曲线参数P
        /// </summary>
        public readonly BigInteger EccP;
        /// <summary>
        /// 椭圆曲线参数A
        /// </summary>
        public readonly BigInteger EccA;
        /// <summary>
        /// 椭圆曲线参数B
        /// </summary>
        public readonly BigInteger EccB;
        /// <summary>
        /// 椭圆曲线参数N
        /// </summary>
        public readonly BigInteger EccN;
        /// <summary>
        /// 椭圆曲线参数Gx
        /// </summary>
        public readonly BigInteger EccGx;
        /// <summary>
        /// 椭圆曲线参数Gy
        /// </summary>
        public readonly BigInteger EccGy;
        #endregion
        /// <summary>
        /// 椭圆曲线
        /// </summary>
        public readonly ECCurve EccCurve;
        /// <summary>
        /// 椭圆曲线的点G
        /// </summary>
        public readonly ECPoint EccPointG;
        /// <summary>
        /// 椭圆曲线 bc规范
        /// </summary>
        public readonly ECDomainParameters EccBcSpec;
        /// <summary>
        /// 椭圆曲线密钥对生成器
        /// </summary>
        public readonly ECKeyPairGenerator EccKeyPairGenerator;

        private SM2()
        {
            EccParam = CurveParameter;


            EccP = new BigInteger(EccParam[0], 16);
            EccA = new BigInteger(EccParam[1], 16);
            EccB = new BigInteger(EccParam[2], 16);
            EccN = new BigInteger(EccParam[3], 16);
            EccGx = new BigInteger(EccParam[4], 16);
            EccGy = new BigInteger(EccParam[5], 16);


            ECFieldElement ecc_gx_fieldelement = new FpFieldElement(EccP, EccGx);
            ECFieldElement ecc_gy_fieldelement = new FpFieldElement(EccP, EccGy);

            EccCurve = new FpCurve(EccP, EccA, EccB);
            EccPointG = new FpPoint(EccCurve, ecc_gx_fieldelement, ecc_gy_fieldelement);

            EccBcSpec = new ECDomainParameters(EccCurve, EccPointG, EccN);

            ECKeyGenerationParameters ecc_ecgenparam;
            ecc_ecgenparam = new ECKeyGenerationParameters(EccBcSpec, new SecureRandom());

            EccKeyPairGenerator = new ECKeyPairGenerator();
            EccKeyPairGenerator.Init(ecc_ecgenparam);
        }

        /// <summary>
        /// 获取杂凑值H
        /// </summary>
        /// <param name="z">Z值</param>
        /// <param name="data">待签名消息</param>
        /// <returns></returns>
        public virtual byte[] Sm2GetH(byte[] z, byte[] data)
        {
            SM3Digest sm3 = new SM3Digest();
            //Z
            sm3.BlockUpdate(z, 0, z.Length);

            //待签名消息
            sm3.BlockUpdate(data, 0, data.Length);

            // H
            byte[] md = new byte[sm3.GetDigestSize()];
            sm3.DoFinal(md, 0);

            return md;
        }

        /// <summary>
        /// 获取Z值
        /// Z=SM3(ENTL∣∣userId∣∣a∣∣b∣∣gx∣∣gy ∣∣x∣∣y) 
        /// </summary>
        /// <param name="userId">签名方的用户身份标识</param>
        /// <param name="userKey">签名方公钥</param>
        /// <returns></returns>
        public virtual byte[] Sm2GetZ(byte[] userId, ECPoint userKey)
        {
            SM3Digest sm3 = new SM3Digest();
            byte[] p;
            // ENTL由2个字节标识的ID的比特长度 
            int len = userId.Length * 8;
            sm3.Update((byte)(len >> 8 & 0x00ff));
            sm3.Update((byte)(len & 0x00ff));

            // userId用户身份标识ID
            sm3.BlockUpdate(userId, 0, userId.Length);

            // a,b为系统曲线参数；
            p = EccA.ToByteArray();
            sm3.BlockUpdate(p, 0, p.Length);
            p = EccB.ToByteArray();
            sm3.BlockUpdate(p, 0, p.Length);
            //  gx、gy为基点
            p = EccGx.ToByteArray();
            sm3.BlockUpdate(p, 0, p.Length);
            p = EccGy.ToByteArray();
            sm3.BlockUpdate(p, 0, p.Length);

            // x,y用户的公钥的X和Y
            p = userKey.Normalize().XCoord.ToBigInteger().ToByteArray();
            sm3.BlockUpdate(p, 0, p.Length);
            p = userKey.Normalize().YCoord.ToBigInteger().ToByteArray();
            sm3.BlockUpdate(p, 0, p.Length);

            // Z
            byte[] md = new byte[sm3.GetDigestSize()];
            sm3.DoFinal(md, 0);

            return md;
        }
    }
}
