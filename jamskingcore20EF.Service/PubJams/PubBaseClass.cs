using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace jamskingcore20EF.Service.PubJams
{
    public class PubBaseClass
    {
        
        public PubBaseClass()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public string BId { get; set; }
        public string BVaule { get; set; }
        #region SOM（签证类：单次或多次）
        /// <summary>
        /// 说明：签证类：单次或多次
        /// 参数：签证类
        /// 创建日期：2018-5-11
        /// 创建人：jamsking
        /// </summary>

        public object SOMdt()
        {
            var lstRes = new List<object>();
            string[] stmx = { "未选", "单次", "多次", "其他" };
            for (int i = 0; i < 4; i++)
            {
                lstRes.Add(new { valuefield = i, textfield = stmx[i] });
            }
            return lstRes;

        }
        public string SOMre(string Value)

        {
            string str1 = Value;
            switch (Value)
            {
                case "0":
                    str1 = "未选";
                    break;
                case "1":
                    str1 = "单次";
                    break;
                case "2":
                    str1 = "多次";
                    break;
                case "3":
                    str1 = "其他";
                    break;
            }
            return str1;
        }
        public string SOMreo(string Value)

        {
            string str1 = Value;
            switch (Value)
            {
                case "未选":
                    str1 = "0";
                    break;
                case "单次":
                    str1 = "1";
                    break;
                case "多次":
                    str1 = "2";
                    break;
                case "其他":
                    str1 = "3";
                    break;
            }
            return str1;
        }
        #endregion
        #region SOM（签证类：单次或多次）
        /// <summary>
        /// 说明：签证类：单次或多次
        /// 参数：签证类
        /// 创建日期：2018-5-11
        /// 创建人：jamsking
        /// </summary>

        public object GOLdt()
        {
            var lstRes = new List<object>();
            string[] stmx = { "未选", "男", "女", "其他" };
            for (int i = 0; i < 4; i++)
            {
                lstRes.Add(new { valuefield = i, textfield = stmx[i] ,namefield="GOLRADIO"});
            }
            return lstRes;

        }
        public string GOLre(string Value)

        {
            string str1 = Value;
            switch (Value)
            {
                case "0":
                    str1 = "未选";
                    break;
                case "1":
                    str1 = "男";
                    break;
                case "2":
                    str1 = "女";
                    break;
                case "3":
                    str1 = "其他";
                    break;
            }
            return str1;
        }
        public string GOLreo(string Value)

        {
            string str1 = Value;
            switch (Value)
            {
                case "未选":
                    str1 = "0";
                    break;
                case "男":
                    str1 = "1";
                    break;
                case "女":
                    str1 = "2";
                    break;
                case "其他":
                    str1 = "3";
                    break;
            }
            return str1;
        }
        #endregion
        #region 加密字符串
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="name">查询字段</param>
        /// <returns></returns>
        string _QueryStringKey = "abcdefgh"; //URL传输参数加密Key
        string _PassWordKey = "hgfedcba";  //PassWord加密Key
        /// 
        /// 加密URL传输的字符串
        /// 
        public string EncryptQueryString(string QueryString)
        {
            return Encrypt(QueryString, _QueryStringKey);
        }

        /// 
        /// 解密URL传输的字符串
        /// 
        /// 
        /// 
        public string DecryptQueryString(string QueryString)
        {
            return Decrypt(QueryString, _QueryStringKey);
        }

        /// 
        /// 加密帐号口令
        /// 
        /// 
        /// 
        public string EncryptPassWord(string PassWord)
        {
            return Encrypt(PassWord, _PassWordKey);
        }

        /// 
        /// 解密帐号口令
        /// 
        /// 
        /// 
        public string DecryptPassWord(string PassWord)
        {
            return Decrypt(PassWord, _PassWordKey);
        }

        /// 
        /// DEC 加密过程
        /// 
        /// 
        /// 
        /// 
        public string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();  //把字符串放到byte数组中  

            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //byte[]  inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);  

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);  //建立加密对象的密钥和偏移量
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);   //原文使用ASCIIEncoding.ASCII方法的GetBytes方法 
            MemoryStream ms = new MemoryStream();     //使得输入密码必须输入英文文本
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /// 
        /// DEC 解密过程
        /// 
        /// 
        /// 
        /// 
        public string Decrypt(string pToDecrypt, string sKey)
        {
            if (pToDecrypt == null || pToDecrypt == string.Empty)
            {

            }
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);  //建立加密对象的密钥和偏移量，此值重要，不能修改  
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            try
            {
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
            }
            catch
            {

            }
            StringBuilder ret = new StringBuilder();  //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }

        /// 
        /// 检查己加密的字符串是否与原文相同
        /// 
        public bool ValidateString(string EnString, string FoString, int Mode)
        {
            switch (Mode)
            {
                default:
                case 1:
                    if (Decrypt(EnString, _QueryStringKey) == FoString.ToString())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    if (Decrypt(EnString, _PassWordKey) == FoString.ToString())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
        }
        #endregion

    }
}
