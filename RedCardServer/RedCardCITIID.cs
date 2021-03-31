using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RedCardServer
{
    class RedCardCITIID
    {
        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="Insize"></param>
        /// <returns></returns>
        [DllImport(@"HD100\SSCARD_HD.dll")]
        private extern static Int32 iOpenPort(byte[] Insize);

        /// <summary>
        /// 读身份证信息
        /// </summary>
        /// <param name="pPicFilePath"></param>
        /// <param name="cardinfo"> 身份证基本信息</param>
        /// <param name="base64Data"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        [DllImport(@"HD100\SSCARD_HD.dll")]
        private extern static Int32 iReaderIDCard_CS(ref IntPtr pPicFilePath, byte[] cardinfo, byte[] base64Data, byte[] ErrMsg);
        /// <summary>
        /// 读身份证ID
        /// </summary>
        /// <param name="cardinfo"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        [DllImport(@"HD100\SSCARD_HD.dll")]
        private extern static Int32 iReadCertID_CS(byte[] cardinfo, ref byte[] ErrMsg);
        /// <summary>
        /// 读社保卡
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cardinfo"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        [DllImport(@"HD100\SSCARD_HD.dll")]
        private extern static Int32 iReadSicard_CS(int id, byte[] cardinfo, byte[] ErrMsg);

        /// <summary>
        /// 建立连接
        /// </summary>
        /// <returns></returns>
        private static bool CardInit()
        {
            byte[] inSize = new byte[512];
            var result = iOpenPort(inSize);
            return result != 0 ? false : true;
        }

        /// <summary>
        /// 读身份证信息
        /// </summary>
        /// <returns></returns>
        public static CardInfo ReadCard()
        {
            byte[] info = new byte[512];
            CardInfo cardinfo = new CardInfo();
            string[] pic = new string[1];
            pic[0] = "";
            var pintptr = ToIntptr(pic[0]);
            try
            {
                if (CardInit() == true)
                {
                    if (iReaderIDCard_CS(ref pintptr, info, new byte[14100], new byte[512]) == 0)
                    {
                        //安装codepages包转码为gb2312
                        //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        //var x = System.Text.Encoding.Default.GetString(info).Split("|");
                        var x = System.Text.Encoding.Default.GetString(info).Split('|');
                        cardinfo.CardID = "";
                        cardinfo.CitiID = x[5];
                        cardinfo.CardName = x[0];
                        cardinfo.CardSex = x[1];
                        cardinfo.Nation = x[2];
                        cardinfo.Birthday = x[3].Substring(0, 4) + "-" + x[3].Substring(4, 2) + "-" + x[3].Substring(6, 2);
                        cardinfo.Address = x[4];
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return cardinfo;
        }

        /// <summary>
        /// 读医保卡返回身份证号
        /// </summary>
        /// <returns></returns>
        public static string InsurCitiid()
        {
            string[] result = new string[6];
            byte[] info = new byte[512];
            byte[] msg = new byte[512];

            var insurcitiid = "";
            try
            {
                if (CardInit() == true)
                {
                    if (iReadSicard_CS(17, info, msg) == 0)
                    {
                        var x = Encoding.Default.GetString(info).Split((char)(0))[0].Split('|');
                        result[0] = x[0];
                        result[1] = x[1];
                        result[2] = x[2];
                        result[3] = x[3];
                        result[4] = x[4];
                        result[5] = x[5].Substring(0, 4);
                        //result(5) = Left(x(5), 4) & "-" & Mid(x(5), 5, 2) & "-" & Mid(x(5), 7)
                    }
                }
                return insurcitiid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static IntPtr ToIntptr(String strData)
        {
            byte[] btData = System.Text.Encoding.Default.GetBytes(strData);
            IntPtr m_ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(btData.Length);
            byte[] btZero = new byte[btData.Length + 1];
            System.Runtime.InteropServices.Marshal.Copy(btZero, 0, m_ptr, btZero.Length);
            System.Runtime.InteropServices.Marshal.Copy(btData, 0, m_ptr, btData.Length);
            return m_ptr;
        }


        private static IntPtr ToIntptr(Int32 length)
        {
            IntPtr m_ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(length);
            byte[] btZero = new byte[length + 1];
            System.Runtime.InteropServices.Marshal.Copy(btZero, 0, m_ptr, btZero.Length);
            System.Runtime.InteropServices.Marshal.Copy(btZero, 0, m_ptr, length);
            return m_ptr;
        }


    }
}
