using Com_CSSkin;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Utilities.Encoders;
using SmallRob.SecuretUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZCS_Common;
using static SmallRob.SecuretTool.EncryptEnum;
using static SmallRob.SecuretUtil.Sm4Crypto;
using SM2Utils = SmallRob.SecuretUtil.SM2Utils;

namespace SmallRob.SecuretTool
{
    /// <summary>
    /// 字符加密/解密工具
    /// </summary>
    public partial class From_Securet : CSSkinMain
    {
        public From_Securet()
        {
            InitializeComponent();
        }

        private IList<EnumListModel> lstDecryptType = EnumHelper.GetEnumList(typeof(EncryptType));

        private void From_Securet_Load(object sender, EventArgs e)
        {
            txtKey.Text = txtVector.Text = "";
            pnlCode.Visible = false;
            pnlPadding.Visible = false;

            foreach (EnumListModel item in lstDecryptType)
            {
                cmbDecryptType.Items.Add(item.EnumDescrip);
            }
            cmbDecryptType.SelectedIndex = 0;
        }

        /// <summary>
        /// 选择加密算法
        /// </summary>
        private void cmbDecryptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKey.Clear();
            txtVector.Clear();

            if (cmbDecryptType.SelectedIndex >= 0)
            {
                EncryptType encryptType = EnumHelper.GetEnumByDescription<EncryptType>(cmbDecryptType.Text);

                string configKey = Enum.GetName(typeof(EncryptEnum.EncryptType), encryptType) + "Key";
                Object key = ConfigurationManager.AppSettings[configKey];

                if (key != null)
                {
                    txtKey.Text = key.ToString();
                }

                btnDecrypt.Enabled = true;
                txtKey.Enabled = txtVector.Enabled = true;

                ckbBase64Out.Visible = false;
                pnlPadding.Visible = pnlCode.Visible = false;

                lblKey1.Text = "密钥:";
                lblKey2.Text = "向量:";

                switch (encryptType)
                {
                    case EncryptType.AES:

                        break;
                    case EncryptType.DES:

                        txtVector.Clear();
                        txtVector.Enabled = false;
                        break;
                    case EncryptType.MD5:

                        ckbBase64Out.Visible = true;
                        txtKey.Enabled = txtVector.Enabled = false;
                        btnDecrypt.Enabled = false;
                        break;
                    case EncryptType.SM4:

                        pnlPadding.Visible = true;
                        pnlCode.Visible = true;
                        break;
                    case EncryptType.SM3:

                        btnDecrypt.Enabled = false;
                        txtKey.Enabled = txtVector.Enabled = false;
                        break;
                    case EncryptType.SM2:

                        lblKey1.Text = "公钥:";
                        lblKey2.Text = "私钥:";

                        //公钥
                        ECPoint publicKey = null;

                        //私钥
                        BigInteger privateKey = null;

                        //生成公钥和私钥
                        SM2Utils.GenerateKeyPair(out publicKey, out privateKey);

                        txtKey.Text = Encoding.Default.GetString(Hex.Encode(publicKey.GetEncoded())).ToUpper();
                        txtVector.Text = Encoding.Default.GetString(Hex.Encode(privateKey.ToByteArray())).ToUpper();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            //EncryptEnum.EncryptType type = (EncryptEnum.EncryptType)Enum.Parse(typeof(EncryptEnum.EncryptType), cmbDecryptType.Text);

            EncryptType type = EnumHelper.GetEnumByDescription<EncryptType>(cmbDecryptType.Text);

            string strData = rtbTxt1.Text.Trim();
            string curKey = txtKey.Text;

            switch (type)
            {
                case EncryptEnum.EncryptType.AES:

                    if (string.IsNullOrEmpty(txtVector.Text))
                    {
                        rtbTxt2.Text = AES.AESEncrypt(strData, curKey);
                    }
                    else
                    {
                        rtbTxt2.Text = AES.AESEncrypt(strData, curKey, txtVector.Text);
                    }
                    break;

                case EncryptEnum.EncryptType.DES:

                    rtbTxt2.Text = DES.Encrypt(strData, curKey);
                    break;

                case EncryptEnum.EncryptType.MD5:

                    rtbTxt2.Text = MD5Utils.Md5StringCode(strData);

                    if (ckbBase64Out.Checked)
                    {
                        rtbTxt2.Text = MD5Utils.Md5ToBase64String(strData);
                    }
                    break;
                case EncryptEnum.EncryptType.SM4:

                    if (string.IsNullOrEmpty(rtbTxt1.Text)) return;

                    var sm4 = new Sm4Crypto();
                    sm4.Key = curKey;
                    sm4.HexString = rdbBase64.Checked ? false : true;
                    sm4.Data = strData;
                    sm4.encoding = rdoButtonDefault.Checked ? EncodingEnum.Default : EncodingEnum.UTF8;

                    if (string.IsNullOrEmpty(txtVector.Text))
                    {
                        sm4.CryptoMode = Sm4CryptoEnum.ECB;
                        rtbTxt2.Text = Sm4Crypto.EncryptECB(sm4);
                    }
                    else
                    {
                        sm4.Iv = txtVector.Text;
                        sm4.CryptoMode = Sm4CryptoEnum.CBC;
                        rtbTxt2.Text = Sm4Crypto.EncryptCBC(sm4);
                    }
                    break;
                case EncryptEnum.EncryptType.SM3:

                    byte[] md = new byte[32];
                    byte[] msg1 = Encoding.Default.GetBytes(strData);
                    SM3Digest sm3 = new SM3Digest();
                    sm3.BlockUpdate(msg1, 0, msg1.Length);
                    sm3.DoFinal(md, 0);
                    string s = new UTF8Encoding().GetString(Hex.Encode(md));

                    rtbTxt2.Text = s;
                    break;

                case EncryptEnum.EncryptType.SM2:

                    rtbTxt2.Text = SM2Utils.Encrypt(Hex.Decode(curKey), Encoding.Default.GetBytes(strData));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbTxt1.Text)) return;

            EncryptEnum.EncryptType type = (EncryptEnum.EncryptType)Enum.Parse(typeof(EncryptEnum.EncryptType), cmbDecryptType.Text);
            string strData = rtbTxt1.Text.Trim();
            string curKey = txtKey.Text;

            switch (type)
            {
                case EncryptEnum.EncryptType.AES:

                    if (string.IsNullOrEmpty(txtVector.Text))
                    {
                        rtbTxt2.Text = AES.AESDecrypt(strData, curKey);
                    }
                    else
                    {
                        rtbTxt2.Text = AES.AESDecrypt(strData, curKey, txtVector.Text);
                    }
                    break;

                case EncryptEnum.EncryptType.DES:

                    rtbTxt2.Text = DES.Decrypt(strData, txtKey.Text);
                    break;
                case EncryptEnum.EncryptType.SM4:

                    var sm4 = new Sm4Crypto();
                    sm4.Key = curKey;
                    sm4.HexString = rdbBase64.Checked ? false : true;
                    sm4.Data = strData;
                    sm4.encoding = rdoButtonDefault.Checked ? EncodingEnum.Default : EncodingEnum.UTF8;

                    if (string.IsNullOrEmpty(txtVector.Text))
                    {
                        sm4.CryptoMode = Sm4CryptoEnum.ECB;
                        rtbTxt2.Text = Sm4Crypto.DecryptECB(sm4);
                    }
                    else
                    {
                        sm4.Iv = txtVector.Text;
                        sm4.CryptoMode = Sm4CryptoEnum.CBC;
                        rtbTxt2.Text = Sm4Crypto.DecryptCBC(sm4);
                    }
                    break;
                case EncryptEnum.EncryptType.SM3:

                    break;

                case EncryptEnum.EncryptType.SM2:

                    rtbTxt2.Text = Encoding.Default.GetString(SM2Utils.Decrypt(Hex.Decode(txtVector.Text), Hex.Decode(strData)));
                    break;
                default:
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbTxt1.Text = "";
            rtbTxt2.Text = "";
            rtbTxt1.Focus();
        }
    }
}
