namespace SmallRob.SecuretTool
{
    partial class From_Securet
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(From_Securet));
            this.skinLabel1 = new Com_CSSkin.SkinControl.SkinLabel();
            this.rtbTxt1 = new Com_CSSkin.SkinControl.RtfRichTextBox();
            this.lblKey1 = new Com_CSSkin.SkinControl.SkinLabel();
            this.skinLabel3 = new Com_CSSkin.SkinControl.SkinLabel();
            this.cmbDecryptType = new Com_CSSkin.SkinControl.SkinComboBox();
            this.rtbTxt2 = new Com_CSSkin.SkinControl.RtfRichTextBox();
            this.skinLabel4 = new Com_CSSkin.SkinControl.SkinLabel();
            this.btnEncrypt = new Com_CSSkin.SkinControl.SkinButton();
            this.btnDecrypt = new Com_CSSkin.SkinControl.SkinButton();
            this.btnClear = new Com_CSSkin.SkinControl.SkinButton();
            this.lblKey2 = new Com_CSSkin.SkinControl.SkinLabel();
            this.pnlCode = new ZCS_FormUI.Controls.PanelEx(this.components);
            this.rdoButtonUTF8 = new Com_CSSkin.SkinControl.SkinRadioButton();
            this.rdoButtonDefault = new Com_CSSkin.SkinControl.SkinRadioButton();
            this.skinLabel2 = new Com_CSSkin.SkinControl.SkinLabel();
            this.txtKey = new ZCS_FormUI.Controls.TextBoxEx(this.components);
            this.txtVector = new ZCS_FormUI.Controls.TextBoxEx(this.components);
            this.pnlPadding = new ZCS_FormUI.Controls.PanelEx(this.components);
            this.rdbBase64 = new Com_CSSkin.SkinControl.SkinRadioButton();
            this.rdbHex = new Com_CSSkin.SkinControl.SkinRadioButton();
            this.ckbBase64Out = new Com_CSSkin.SkinControl.SkinCheckBox();
            this.pnlCode.SuspendLayout();
            this.pnlPadding.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(37, 50);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(65, 20);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "原字符：";
            // 
            // rtbTxt1
            // 
            this.rtbTxt1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbTxt1.HiglightColor = Com_CSSkin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.rtbTxt1.Location = new System.Drawing.Point(108, 50);
            this.rtbTxt1.Name = "rtbTxt1";
            this.rtbTxt1.Size = new System.Drawing.Size(479, 127);
            this.rtbTxt1.TabIndex = 1;
            this.rtbTxt1.Text = "";
            this.rtbTxt1.TextColor = Com_CSSkin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.BackColor = System.Drawing.Color.Transparent;
            this.lblKey1.BorderColor = System.Drawing.Color.White;
            this.lblKey1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey1.Location = new System.Drawing.Point(268, 199);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(51, 20);
            this.lblKey1.TabIndex = 2;
            this.lblKey1.Text = "密钥：";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(23, 199);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(79, 20);
            this.skinLabel3.TabIndex = 4;
            this.skinLabel3.Text = "加密算法：";
            // 
            // cmbDecryptType
            // 
            this.cmbDecryptType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDecryptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDecryptType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDecryptType.FormattingEnabled = true;
            this.cmbDecryptType.Location = new System.Drawing.Point(108, 196);
            this.cmbDecryptType.Name = "cmbDecryptType";
            this.cmbDecryptType.Size = new System.Drawing.Size(125, 27);
            this.cmbDecryptType.TabIndex = 5;
            this.cmbDecryptType.WaterText = "";
            this.cmbDecryptType.SelectedIndexChanged += new System.EventHandler(this.cmbDecryptType_SelectedIndexChanged);
            // 
            // rtbTxt2
            // 
            this.rtbTxt2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbTxt2.HiglightColor = Com_CSSkin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.rtbTxt2.Location = new System.Drawing.Point(108, 379);
            this.rtbTxt2.Name = "rtbTxt2";
            this.rtbTxt2.ReadOnly = true;
            this.rtbTxt2.Size = new System.Drawing.Size(479, 137);
            this.rtbTxt2.TabIndex = 7;
            this.rtbTxt2.Text = "";
            this.rtbTxt2.TextColor = Com_CSSkin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(16, 382);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(79, 20);
            this.skinLabel4.TabIndex = 6;
            this.skinLabel4.Text = "输出结果：";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.Transparent;
            this.btnEncrypt.ControlState = Com_CSSkin.SkinClass.ControlState.Normal;
            this.btnEncrypt.DownBack = null;
            this.btnEncrypt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEncrypt.Location = new System.Drawing.Point(170, 334);
            this.btnEncrypt.MouseBack = null;
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.NormlBack = null;
            this.btnEncrypt.Size = new System.Drawing.Size(84, 28);
            this.btnEncrypt.TabIndex = 8;
            this.btnEncrypt.Text = "加密(&E)";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.BackColor = System.Drawing.Color.Transparent;
            this.btnDecrypt.ControlState = Com_CSSkin.SkinClass.ControlState.Normal;
            this.btnDecrypt.DownBack = null;
            this.btnDecrypt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDecrypt.Location = new System.Drawing.Point(281, 334);
            this.btnDecrypt.MouseBack = null;
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.NormlBack = null;
            this.btnDecrypt.Size = new System.Drawing.Size(84, 28);
            this.btnDecrypt.TabIndex = 9;
            this.btnDecrypt.Text = "解密(&D)";
            this.btnDecrypt.UseVisualStyleBackColor = false;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.ControlState = Com_CSSkin.SkinClass.ControlState.Normal;
            this.btnClear.DownBack = null;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(392, 334);
            this.btnClear.MouseBack = null;
            this.btnClear.Name = "btnClear";
            this.btnClear.NormlBack = null;
            this.btnClear.Size = new System.Drawing.Size(84, 28);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "清空(&C)";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.BackColor = System.Drawing.Color.Transparent;
            this.lblKey2.BorderColor = System.Drawing.Color.White;
            this.lblKey2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey2.Location = new System.Drawing.Point(268, 267);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(51, 20);
            this.lblKey2.TabIndex = 11;
            this.lblKey2.Text = "向量：";
            // 
            // pnlCode
            // 
            this.pnlCode.Controls.Add(this.rdoButtonUTF8);
            this.pnlCode.Controls.Add(this.rdoButtonDefault);
            this.pnlCode.Controls.Add(this.skinLabel2);
            this.pnlCode.Location = new System.Drawing.Point(17, 246);
            this.pnlCode.Name = "pnlCode";
            this.pnlCode.Size = new System.Drawing.Size(226, 72);
            this.pnlCode.TabIndex = 14;
            // 
            // rdoButtonUTF8
            // 
            this.rdoButtonUTF8.AutoSize = true;
            this.rdoButtonUTF8.BackColor = System.Drawing.Color.Transparent;
            this.rdoButtonUTF8.ControlState = Com_CSSkin.SkinClass.ControlState.Normal;
            this.rdoButtonUTF8.DownBack = null;
            this.rdoButtonUTF8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoButtonUTF8.Location = new System.Drawing.Point(90, 38);
            this.rdoButtonUTF8.MouseBack = null;
            this.rdoButtonUTF8.Name = "rdoButtonUTF8";
            this.rdoButtonUTF8.NormlBack = null;
            this.rdoButtonUTF8.SelectedDownBack = null;
            this.rdoButtonUTF8.SelectedMouseBack = null;
            this.rdoButtonUTF8.SelectedNormlBack = null;
            this.rdoButtonUTF8.Size = new System.Drawing.Size(66, 24);
            this.rdoButtonUTF8.TabIndex = 7;
            this.rdoButtonUTF8.Text = "UTF-8";
            this.rdoButtonUTF8.UseVisualStyleBackColor = false;
            // 
            // rdoButtonDefault
            // 
            this.rdoButtonDefault.AutoSize = true;
            this.rdoButtonDefault.BackColor = System.Drawing.Color.Transparent;
            this.rdoButtonDefault.Checked = true;
            this.rdoButtonDefault.ControlState = Com_CSSkin.SkinClass.ControlState.Normal;
            this.rdoButtonDefault.DownBack = null;
            this.rdoButtonDefault.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoButtonDefault.Location = new System.Drawing.Point(90, 8);
            this.rdoButtonDefault.MouseBack = null;
            this.rdoButtonDefault.Name = "rdoButtonDefault";
            this.rdoButtonDefault.NormlBack = null;
            this.rdoButtonDefault.SelectedDownBack = null;
            this.rdoButtonDefault.SelectedMouseBack = null;
            this.rdoButtonDefault.SelectedNormlBack = null;
            this.rdoButtonDefault.Size = new System.Drawing.Size(126, 24);
            this.rdoButtonDefault.TabIndex = 6;
            this.rdoButtonDefault.TabStop = true;
            this.rdoButtonDefault.Text = "默认编码(ANSI)";
            this.rdoButtonDefault.UseVisualStyleBackColor = false;
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(6, 9);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(79, 20);
            this.skinLabel2.TabIndex = 5;
            this.skinLabel2.Text = "字符编码：";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKey.Location = new System.Drawing.Point(325, 196);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.OtherText = null;
            this.txtKey.Size = new System.Drawing.Size(262, 53);
            this.txtKey.TabIndex = 13;
            // 
            // txtVector
            // 
            this.txtVector.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVector.Location = new System.Drawing.Point(325, 264);
            this.txtVector.Multiline = true;
            this.txtVector.Name = "txtVector";
            this.txtVector.OtherText = null;
            this.txtVector.Size = new System.Drawing.Size(262, 53);
            this.txtVector.TabIndex = 12;
            // 
            // pnlPadding
            // 
            this.pnlPadding.Controls.Add(this.rdbBase64);
            this.pnlPadding.Controls.Add(this.rdbHex);
            this.pnlPadding.Location = new System.Drawing.Point(10, 105);
            this.pnlPadding.Name = "pnlPadding";
            this.pnlPadding.Size = new System.Drawing.Size(92, 72);
            this.pnlPadding.TabIndex = 15;
            // 
            // rdbBase64
            // 
            this.rdbBase64.AutoSize = true;
            this.rdbBase64.BackColor = System.Drawing.Color.Transparent;
            this.rdbBase64.Checked = true;
            this.rdbBase64.ControlState = Com_CSSkin.SkinClass.ControlState.Normal;
            this.rdbBase64.DownBack = null;
            this.rdbBase64.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbBase64.Location = new System.Drawing.Point(10, 40);
            this.rdbBase64.MouseBack = null;
            this.rdbBase64.Name = "rdbBase64";
            this.rdbBase64.NormlBack = null;
            this.rdbBase64.SelectedDownBack = null;
            this.rdbBase64.SelectedMouseBack = null;
            this.rdbBase64.SelectedNormlBack = null;
            this.rdbBase64.Size = new System.Drawing.Size(74, 24);
            this.rdbBase64.TabIndex = 7;
            this.rdbBase64.TabStop = true;
            this.rdbBase64.Text = "Base64";
            this.rdbBase64.UseVisualStyleBackColor = false;
            // 
            // rdbHex
            // 
            this.rdbHex.AutoSize = true;
            this.rdbHex.BackColor = System.Drawing.Color.Transparent;
            this.rdbHex.ControlState = Com_CSSkin.SkinClass.ControlState.Normal;
            this.rdbHex.DownBack = null;
            this.rdbHex.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbHex.Location = new System.Drawing.Point(10, 10);
            this.rdbHex.MouseBack = null;
            this.rdbHex.Name = "rdbHex";
            this.rdbHex.NormlBack = null;
            this.rdbHex.SelectedDownBack = null;
            this.rdbHex.SelectedMouseBack = null;
            this.rdbHex.SelectedNormlBack = null;
            this.rdbHex.Size = new System.Drawing.Size(71, 24);
            this.rdbHex.TabIndex = 6;
            this.rdbHex.Text = "16进制";
            this.rdbHex.UseVisualStyleBackColor = false;
            // 
            // ckbBase64Out
            // 
            this.ckbBase64Out.AutoSize = true;
            this.ckbBase64Out.BackColor = System.Drawing.Color.Transparent;
            this.ckbBase64Out.ControlState = Com_CSSkin.SkinClass.ControlState.Normal;
            this.ckbBase64Out.DownBack = null;
            this.ckbBase64Out.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbBase64Out.Location = new System.Drawing.Point(20, 336);
            this.ckbBase64Out.MouseBack = null;
            this.ckbBase64Out.Name = "ckbBase64Out";
            this.ckbBase64Out.NormlBack = null;
            this.ckbBase64Out.SelectedDownBack = null;
            this.ckbBase64Out.SelectedMouseBack = null;
            this.ckbBase64Out.SelectedNormlBack = null;
            this.ckbBase64Out.Size = new System.Drawing.Size(145, 24);
            this.ckbBase64Out.TabIndex = 16;
            this.ckbBase64Out.Text = "输出Base64位字符";
            this.ckbBase64Out.UseVisualStyleBackColor = false;
            this.ckbBase64Out.Visible = false;
            // 
            // From_Securet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CaptionBackColorBottom = System.Drawing.Color.AliceBlue;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(610, 536);
            this.CloseBoxSize = new System.Drawing.Size(32, 26);
            this.Controls.Add(this.ckbBase64Out);
            this.Controls.Add(this.pnlPadding);
            this.Controls.Add(this.pnlCode);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtVector);
            this.Controls.Add(this.lblKey2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.rtbTxt2);
            this.Controls.Add(this.skinLabel4);
            this.Controls.Add(this.cmbDecryptType);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.lblKey1);
            this.Controls.Add(this.rtbTxt1);
            this.Controls.Add(this.skinLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(610, 536);
            this.MaxSize = new System.Drawing.Size(32, 26);
            this.MdiBackColor = System.Drawing.Color.AntiqueWhite;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(610, 536);
            this.Name = "From_Securet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密符转换窗口";
            this.Load += new System.EventHandler(this.From_Securet_Load);
            this.pnlCode.ResumeLayout(false);
            this.pnlCode.PerformLayout();
            this.pnlPadding.ResumeLayout(false);
            this.pnlPadding.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com_CSSkin.SkinControl.SkinLabel skinLabel1;
        private Com_CSSkin.SkinControl.RtfRichTextBox rtbTxt1;
        private Com_CSSkin.SkinControl.SkinLabel lblKey1;
        private Com_CSSkin.SkinControl.SkinLabel skinLabel3;
        private Com_CSSkin.SkinControl.SkinComboBox cmbDecryptType;
        private Com_CSSkin.SkinControl.RtfRichTextBox rtbTxt2;
        private Com_CSSkin.SkinControl.SkinLabel skinLabel4;
        private Com_CSSkin.SkinControl.SkinButton btnEncrypt;
        private Com_CSSkin.SkinControl.SkinButton btnDecrypt;
        private Com_CSSkin.SkinControl.SkinButton btnClear;
        private Com_CSSkin.SkinControl.SkinLabel lblKey2;
        private ZCS_FormUI.Controls.TextBoxEx txtVector;
        private ZCS_FormUI.Controls.TextBoxEx txtKey;
        private ZCS_FormUI.Controls.PanelEx pnlCode;
        private Com_CSSkin.SkinControl.SkinRadioButton rdoButtonDefault;
        private Com_CSSkin.SkinControl.SkinLabel skinLabel2;
        private Com_CSSkin.SkinControl.SkinRadioButton rdoButtonUTF8;
        private ZCS_FormUI.Controls.PanelEx pnlPadding;
        private Com_CSSkin.SkinControl.SkinRadioButton rdbBase64;
        private Com_CSSkin.SkinControl.SkinRadioButton rdbHex;
        private Com_CSSkin.SkinControl.SkinCheckBox ckbBase64Out;
    }
}

