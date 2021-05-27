using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallRob.SecuretUtil
{
    public class SM4
    {
        /// <summary>
        /// 加密
        /// </summary>
        public const int SM4_ENCRYPT = 1;

        /// <summary>
        /// 解密
        /// </summary>
        public const int SM4_DECRYPT = 0; 

        /// <summary>
        /// 加密 非线性τ函数B=τ(A)
        /// </summary>
        /// <param name="b"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static long GetULongByBe(byte[] b, int i)
        {
            long n = (long)(b[i] & 0xff) << 24 |
                (long)((b[i + 1] & 0xff) << 16) |
                (long)((b[i + 2] & 0xff) << 8) |
                (long)(b[i + 3] & 0xff) & 0xffffffffL;
            return n;
        }
        /// <summary>
        /// 解密 非线性τ函数B=τ(A)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="b"></param>
        /// <param name="i"></param>
        private static void PutULongToBe(long n, byte[] b, int i)
        {
            b[i] = (byte)(int)(0xFF & n >> 24);
            b[i + 1] = (byte)(int)(0xFF & n >> 16);
            b[i + 2] = (byte)(int)(0xFF & n >> 8);
            b[i + 3] = (byte)(int)(0xFF & n);
        }

        /// <summary>
        /// 循环移位,为32位的x循环左移n位
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static long Rotl(long x, int n)
        {
            return ((x & 0xFFFFFFFF) << n) | x >> (32 - n);
        }

        /// <summary>
        /// 将密钥逆序
        /// </summary>
        /// <param name="sk"></param>
        /// <param name="i"></param>
        private static void Swap(long[] sk, int i)
        {
            long t = sk[i];
            sk[i] = sk[(31 - i)];
            sk[(31 - i)] = t;
        }
        /// <summary>
        /// S盒 
        /// </summary>
        public byte[] SboxTable = new byte[] {
         //   0     1     2     3     4     5     6     7     8     9     a     b     c     d     e     f
            (byte)0xd6, (byte)0x90, (byte)0xe9, (byte)0xfe, (byte)0xcc, (byte)0xe1, (byte)0x3d, (byte)0xb7, (byte)0x16, (byte)0xb6, (byte)0x14, (byte)0xc2, (byte)0x28, (byte)0xfb, (byte)0x2c, (byte)0x05,
            (byte)0x2b, (byte)0x67, (byte)0x9a, (byte)0x76, (byte)0x2a, (byte)0xbe, (byte)0x04, (byte)0xc3, (byte)0xaa, (byte)0x44, (byte)0x13, (byte)0x26, (byte)0x49, (byte)0x86, (byte)0x06, (byte)0x99,
            (byte)0x9c, (byte)0x42, (byte)0x50, (byte)0xf4, (byte)0x91, (byte)0xef, (byte)0x98, (byte)0x7a, (byte)0x33, (byte)0x54, (byte)0x0b, (byte)0x43, (byte)0xed, (byte)0xcf, (byte)0xac, (byte)0x62,
            (byte)0xe4, (byte)0xb3, (byte)0x1c, (byte)0xa9, (byte)0xc9, (byte)0x08, (byte)0xe8, (byte)0x95, (byte)0x80, (byte)0xdf, (byte)0x94, (byte)0xfa, (byte)0x75, (byte)0x8f, (byte)0x3f, (byte)0xa6,
            (byte)0x47, (byte)0x07, (byte)0xa7, (byte)0xfc, (byte)0xf3, (byte)0x73, (byte)0x17, (byte)0xba, (byte)0x83, (byte)0x59, (byte)0x3c, (byte)0x19, (byte)0xe6, (byte)0x85, (byte)0x4f, (byte)0xa8,
            (byte)0x68, (byte)0x6b, (byte)0x81, (byte)0xb2, (byte)0x71, (byte)0x64, (byte)0xda, (byte)0x8b, (byte)0xf8, (byte)0xeb, (byte)0x0f, (byte)0x4b, (byte)0x70, (byte)0x56, (byte)0x9d, (byte)0x35,
            (byte)0x1e, (byte)0x24, (byte)0x0e, (byte)0x5e, (byte)0x63, (byte)0x58, (byte)0xd1, (byte)0xa2, (byte)0x25, (byte)0x22, (byte)0x7c, (byte)0x3b, (byte)0x01, (byte)0x21, (byte)0x78, (byte)0x87,
            (byte)0xd4, (byte)0x00, (byte)0x46, (byte)0x57, (byte)0x9f, (byte)0xd3, (byte)0x27, (byte)0x52, (byte)0x4c, (byte)0x36, (byte)0x02, (byte)0xe7, (byte)0xa0, (byte)0xc4, (byte)0xc8, (byte)0x9e,
            (byte)0xea, (byte)0xbf, (byte)0x8a, (byte)0xd2, (byte)0x40, (byte)0xc7, (byte)0x38, (byte)0xb5, (byte)0xa3, (byte)0xf7, (byte)0xf2, (byte)0xce, (byte)0xf9, (byte)0x61, (byte)0x15, (byte)0xa1,
            (byte)0xe0, (byte)0xae, (byte)0x5d, (byte)0xa4, (byte)0x9b, (byte)0x34, (byte)0x1a, (byte)0x55, (byte)0xad, (byte)0x93, (byte)0x32, (byte)0x30, (byte)0xf5, (byte)0x8c, (byte)0xb1, (byte)0xe3,
            (byte)0x1d, (byte)0xf6, (byte)0xe2, (byte)0x2e, (byte)0x82, (byte)0x66, (byte)0xca, (byte)0x60, (byte)0xc0, (byte)0x29, (byte)0x23, (byte)0xab, (byte)0x0d, (byte)0x53, (byte)0x4e, (byte)0x6f,
            (byte)0xd5, (byte)0xdb, (byte)0x37, (byte)0x45, (byte)0xde, (byte)0xfd, (byte)0x8e, (byte)0x2f, (byte)0x03, (byte)0xff, (byte)0x6a, (byte)0x72, (byte)0x6d, (byte)0x6c, (byte)0x5b, (byte)0x51,
            (byte)0x8d, (byte)0x1b, (byte)0xaf, (byte)0x92, (byte)0xbb, (byte)0xdd, (byte)0xbc, (byte)0x7f, (byte)0x11, (byte)0xd9, (byte)0x5c, (byte)0x41, (byte)0x1f, (byte)0x10, (byte)0x5a, (byte)0xd8,
            (byte)0x0a, (byte)0xc1, (byte)0x31, (byte)0x88, (byte)0xa5, (byte)0xcd, (byte)0x7b, (byte)0xbd, (byte)0x2d, (byte)0x74, (byte)0xd0, (byte)0x12, (byte)0xb8, (byte)0xe5, (byte)0xb4, (byte)0xb0,
            (byte)0x89, (byte)0x69, (byte)0x97, (byte)0x4a, (byte)0x0c, (byte)0x96, (byte)0x77, (byte)0x7e, (byte)0x65, (byte)0xb9, (byte)0xf1, (byte)0x09, (byte)0xc5, (byte)0x6e, (byte)0xc6, (byte)0x84,
            (byte)0x18, (byte)0xf0, (byte)0x7d, (byte)0xec, (byte)0x3a, (byte)0xdc, (byte)0x4d, (byte)0x20, (byte)0x79, (byte)0xee, (byte)0x5f, (byte)0x3e, (byte)0xd7, (byte)0xcb, (byte)0x39, (byte)0x48
        };

        /// <summary>
        /// 系统参数FK
        /// </summary>
        public uint[] FK = { 0xa3b1bac6, 0x56aa3350, 0x677d9197, 0xb27022dc };
        /// <summary>
        /// 固定参数CK
        /// </summary>
        public uint[] CK = {
            0x00070e15,0x1c232a31,0x383f464d,0x545b6269,
            0x70777e85,0x8c939aa1,0xa8afb6bd,0xc4cbd2d9,
            0xe0e7eef5,0xfc030a11,0x181f262d,0x343b4249,
            0x50575e65,0x6c737a81,0x888f969d,0xa4abb2b9,
            0xc0c7ced5,0xdce3eaf1,0xf8ff060d,0x141b2229,
            0x30373e45,0x4c535a61,0x686f767d,0x848b9299,
            0xa0a7aeb5,0xbcc3cad1,0xd8dfe6ed,0xf4fb0209,
            0x10171e25,0x2c333a41,0x484f565d,0x646b7279
        };

        /// <summary>
        /// Sm4的S盒取值
        /// </summary>
        /// <param name="inch"></param>
        /// <returns></returns>
        private byte Sm4Sbox(byte inch)
        {
            int i = inch & 0xFF;
            byte retVal = SboxTable[i];
            return retVal;
        }

        /// <summary>
        /// 线性变换 L
        /// </summary>
        /// <param name="ka"></param>
        /// <returns></returns>
        private long Sm4Lt(long ka)
        {
            byte[] a = new byte[4];
            byte[] b = new byte[4];
            PutULongToBe(ka, a, 0);
            b[0] = Sm4Sbox(a[0]);
            b[1] = Sm4Sbox(a[1]);
            b[2] = Sm4Sbox(a[2]);
            b[3] = Sm4Sbox(a[3]);
            long bb = GetULongByBe(b, 0);
            long c = bb ^ Rotl(bb, 2) ^ Rotl(bb, 10) ^ Rotl(bb, 18) ^ Rotl(bb, 24);
            return c;
        }
        /// <summary>
        /// 轮函数 F
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        /// <param name="rk"></param>
        /// <returns></returns>
        private long Sm4F(long x0, long x1, long x2, long x3, long rk)
        {
            return x0 ^ Sm4Lt(x1 ^ x2 ^ x3 ^ rk);
        }

        /// <summary>
        /// 轮密钥rk
        /// </summary>
        /// <param name="ka"></param>
        /// <returns></returns>
        private long Sm4CalciRk(long ka)
        {
            byte[] a = new byte[4];
            byte[] b = new byte[4];
            PutULongToBe(ka, a, 0);
            b[0] = Sm4Sbox(a[0]);
            b[1] = Sm4Sbox(a[1]);
            b[2] = Sm4Sbox(a[2]);
            b[3] = Sm4Sbox(a[3]);
            long bb = GetULongByBe(b, 0);
            long rk = bb ^ Rotl(bb, 13) ^ Rotl(bb, 23);
            return rk;
        }

        /// <summary>
        /// 加密密钥
        /// </summary>
        /// <param name="SK"></param>
        /// <param name="key"></param>
        private void SetKey(long[] SK, byte[] key)
        {
            //加密密钥长度为 128 比特
            long[] MK = new long[4];
            int i = 0;
            MK[0] = GetULongByBe(key, 0);
            MK[1] = GetULongByBe(key, 4);
            MK[2] = GetULongByBe(key, 8);
            MK[3] = GetULongByBe(key, 12);

            long[] k = new long[36];
            //轮密钥生成方法
            k[0] = MK[0] ^ (long)FK[0];
            k[1] = MK[1] ^ (long)FK[1];
            k[2] = MK[2] ^ (long)FK[2];
            k[3] = MK[3] ^ (long)FK[3];
            for (; i < 32; i++)
            {
                k[(i + 4)] = (k[i] ^ Sm4CalciRk(k[(i + 1)] ^ k[(i + 2)] ^ k[(i + 3)] ^ (long)CK[i]));
                SK[i] = k[(i + 4)];
            }
        }
        /// <summary>
        /// 解密函数
        /// </summary>
        /// <param name="sk">轮密钥</param>
        /// <param name="input">输入分组的密文</param>
        /// <param name="output">输出的对应的分组明文</param>
        private void Sm4OneRound(long[] sk, byte[] input, byte[] output)
        {
            int i = 0;
            long[] ulbuf = new long[36];
            ulbuf[0] = GetULongByBe(input, 0);
            ulbuf[1] = GetULongByBe(input, 4);
            ulbuf[2] = GetULongByBe(input, 8);
            ulbuf[3] = GetULongByBe(input, 12);
            while (i < 32) //开始32轮解密 ，一次进行4轮，共计八次
            {
                ulbuf[(i + 4)] = Sm4F(ulbuf[i], ulbuf[(i + 1)], ulbuf[(i + 2)], ulbuf[(i + 3)], sk[i]);
                i++;
            }
            PutULongToBe(ulbuf[35], output, 0);
            PutULongToBe(ulbuf[34], output, 4);
            PutULongToBe(ulbuf[33], output, 8);
            PutULongToBe(ulbuf[32], output, 12);
        }

        /// <summary>
        /// 补足 16 进制字符串的 0 字符，返回不带 0x 的16进制字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="mode">1表示加密，0表示解密</param>
        /// <returns></returns>
        private byte[] Padding(byte[] input, int mode)
        {
            if (input == null)
            {
                return null;
            }

            byte[] ret = (byte[])null;
            if (mode == SM4_ENCRYPT)
            {
                int p = 16 - input.Length % 16;
                ret = new byte[input.Length + p];
                Array.Copy(input, 0, ret, 0, input.Length);
                for (int i = 0; i < p; i++)
                {
                    ret[input.Length + i] = (byte)p;
                }
            }
            else
            {
                int p = input[input.Length - 1];
                ret = new byte[input.Length - p];
                Array.Copy(input, 0, ret, 0, input.Length - p);
            }
            return ret;
        }

        /// <summary>
        /// 设置加密的key
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="key"></param>
        public void SetKeyEnc(Sm4Context ctx, byte[] key)
        {
            ctx.Mode = SM4_ENCRYPT;
            SetKey(ctx.Key, key);
        }
        /// <summary>
        /// 设置解密的key
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="key"></param>
        public void Sm4SetKeyDec(Sm4Context ctx, byte[] key)
        {
            ctx.Mode = SM4_DECRYPT;
            SetKey(ctx.Key, key);
            int i;
            for (i = 0; i < 16; i++)
            {
                Swap(ctx.Key, i);
            }
        }
        /// <summary>
        /// ECB
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public byte[] Sm4CryptEcb(Sm4Context ctx, byte[] input)
        {
            if (ctx.IsPadding && (ctx.Mode == SM4_ENCRYPT))
            {
                input = Padding(input, 1);
            }

            int length = input.Length;
            byte[] bins = new byte[length];
            Array.Copy(input, 0, bins, 0, length);
            byte[] bous = new byte[length];
            for (int i = 0; length > 0; length -= 16, i++)
            {
                byte[] inBytes = new byte[16];
                byte[] outBytes = new byte[16];
                Array.Copy(bins, i * 16, inBytes, 0, length > 16 ? 16 : length);
                Sm4OneRound(ctx.Key, inBytes, outBytes);
                Array.Copy(outBytes, 0, bous, i * 16, length > 16 ? 16 : length);
            }

            if (ctx.IsPadding && ctx.Mode == SM4_DECRYPT)
            {
                bous = Padding(bous, 0);
            }
            return bous;
        }

        /// <summary>
        /// CBC
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="iv"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public byte[] Sm4CryptCbc(Sm4Context ctx, byte[] iv, byte[] input)
        {
            if (ctx.IsPadding && ctx.Mode == SM4_ENCRYPT)
            {
                input = Padding(input, 1);
            }

            int length = input.Length;
            byte[] bins = new byte[length];
            Array.Copy(input, 0, bins, 0, length);
            List<byte> bousList = new List<byte>();

            int i;
            if (ctx.Mode == SM4_ENCRYPT)
            {
                for (int j = 0; length > 0; length -= 16, j++)
                {
                    byte[] inBytes = new byte[16];
                    byte[] outBytes = new byte[16];
                    byte[] out1 = new byte[16];

                    Array.Copy(bins, j * 16, inBytes, 0, length > 16 ? 16 : length);
                    for (i = 0; i < 16; i++)
                    {
                        outBytes[i] = ((byte)(inBytes[i] ^ iv[i]));
                    }
                    Sm4OneRound(ctx.Key, outBytes, out1);
                    Array.Copy(out1, 0, iv, 0, 16);
                    for (int k = 0; k < 16; k++)
                    {
                        bousList.Add(out1[k]);
                    }
                }
            }
            else
            {
                byte[] temp = new byte[16];
                for (int j = 0; length > 0; length -= 16, j++)
                {
                    byte[] inBytes = new byte[16];
                    byte[] outBytes = new byte[16];
                    byte[] out1 = new byte[16];

                    Array.Copy(bins, j * 16, inBytes, 0, length > 16 ? 16 : length);
                    Array.Copy(inBytes, 0, temp, 0, 16);
                    Sm4OneRound(ctx.Key, inBytes, outBytes);
                    for (i = 0; i < 16; i++)
                    {
                        out1[i] = ((byte)(outBytes[i] ^ iv[i]));
                    }
                    Array.Copy(temp, 0, iv, 0, 16);
                    for (int k = 0; k < 16; k++)
                    {
                        bousList.Add(out1[k]);
                    }
                }

            }

            if (ctx.IsPadding && ctx.Mode == SM4_DECRYPT)
            {
                byte[] bous = Padding(bousList.ToArray(), SM4_DECRYPT);
                return bous;
            }
            else
            {
                return bousList.ToArray();
            }
        }
    }
}
