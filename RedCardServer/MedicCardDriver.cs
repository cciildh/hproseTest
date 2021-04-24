using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace RedCardServer
{
    public static class MedicCardDriver
    {
        /// <summary>
        /// 查找硬件
        /// </summary>
        /// <returns></returns>
        [DllImport("CapacityReader.dll", EntryPoint = "EnumerateReader", CharSet = CharSet.Auto)]
        private static extern int EnumerateReader();

        [DllImport("CapacityReader.dll", EntryPoint = "ReleaseBuffer", CharSet = CharSet.Auto)]
        private static extern void HIDReader_ReleaseBuffer();

        /// <summary>
        /// 连接硬件
        /// </summary>
        /// <param name="readerIndex">找到的已知硬件索引</param>
        /// <param name="slotComm">命令</param>
        /// <param name="outbuffer">返回值字节数组</param>
        /// <param name="outLength">返回值有效长度</param>
        /// <returns></returns>
        [DllImport("CapacityReader.dll", EntryPoint = "Connect", CharSet = CharSet.Auto)]
        private static extern int HIDReader_Connect(Byte readerIndex, Byte slotComm, Byte[] outbuffer, out int outLength);

        /// <summary>
        /// 硬件控制命令
        /// </summary>
        /// <param name="readerIndex">已知的硬件索引</param>
        /// <param name="slotComm">命令</param>
        /// <param name="cmd">入参</param>
        /// <param name="cmdLength">入参有效长度</param>
        /// <param name="outbuffer">出参</param>
        /// <param name="outLength">出参有效长度</param>
        /// <param name="timeout">延迟等待时间</param>
        /// <returns></returns>
        [DllImport("CapacityReader.dll", EntryPoint = "Control", CharSet = CharSet.Auto)]
        private static extern int HIDReader_Control(byte readerIndex, byte slotComm, byte[] cmd, int cmdLength, byte[] outbuffer, out int outLength, int timeout);
        /// <summary>
        /// 硬件数据传输
        /// </summary>
        /// <param name="readerIndex"></param>
        /// <param name="slotComm"></param>
        /// <param name="cmd"></param>
        /// <param name="cmdLength"></param>
        /// <param name="outbuffer"></param>
        /// <param name="outLength"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        [DllImport("CapacityReader.dll", EntryPoint = "Transmit", CharSet = CharSet.Auto)]
        private static extern int HIDReader_Transmit(byte readerIndex, byte slotComm, byte[] cmd, int cmdLength, byte[] outbuffer, out int outLength, int timeout);


        public static void RedCard(out string cliniccardid, out string patiid)
        {
            try
            {
                //------建立建立
                ConntCard();
                Music();
                //----------------------------读卡
                if (OutWriteCard(out cliniccardid, out patiid) == false)
                    throw new Exception("读取卡内容失败");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="cliniccardid">就诊卡号</param>
        /// <param name="patiid">人员ID</param>
        public static bool WriteCard(string cliniccardid, string patiid)
        {
            try
            {
                if (!string.IsNullOrEmpty(cliniccardid) && !string.IsNullOrEmpty(patiid))
                {
                    //------建立建立
                    ConntCard();
                    Music();
                    //-读取第一扇区校验
                    if (RedSection() == false)
                        throw new Exception("扇区读取失败");
                    //修改扇区密钥
                    if (UpdateSection() == false)
                        throw new Exception("该已被写过不能再写！请换新卡！");
                    //------建立建立
                    ConntCard();
                    //写卡
                    if (SaveCard(cliniccardid,patiid)==false)
                    {
                        ConntCard();
                        //还原扇区
                        RestoreSection();
                        return false;
                    }
                }
                else
                {
                    throw new Exception("卡号不能为空！");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  读卡器校验（用于收费时验证卡是否在）
        /// </summary>
        /// <param name="cliniccardid">卡号</param>
        /// <returns></returns>
        public static bool Check_Card(string cliniccardid)
        {
            var outcliniccardid = string.Empty;
            var outpatiid = string.Empty;
            try
            {
                //------建立建立
                ConntCard();
                Music();
                //----------------------------读卡
                if (OutWriteCard(out outcliniccardid, out outpatiid) == false)
                    throw new Exception("读取卡内容失败");
                if (cliniccardid != outcliniccardid)
                    throw new Exception("身份信息与卡信息不符！");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }
        /// <summary>
        /// 就诊卡还原
        /// </summary>
        /// <returns></returns>
        public static bool CardRestore()
        {
            try
            {
                //------建立建立
                ConntCard();
                Music();
                //----读取扇区
                //if (RedSection() == true)
                //    throw new Exception("该就诊卡已是出厂状态无需还原！");
                if (RestoreSection() == false)
                    throw new Exception("就诊卡还原失败！");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }


        /// <summary>
        /// 连接读卡器
        /// </summary>
        private static void ConntCard()
        {
            try
            {
                var outBuffer = new byte[512];
                int outLength = 0;
                var resultHd = EnumerateReader();
                if (resultHd <= 0)
                    throw new Exception("未找到读卡设备！");
                var resultConnt = HIDReader_Connect(Convert.ToByte(0), Convert.ToByte(1), outBuffer, out outLength);
                if (resultConnt != 0)
                    throw new Exception("设备连接失败！");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 声音
        /// </summary>
        /// <returns></returns>
        private static bool Music()
        {
            var ApduResponse = new byte[512];
            int outLength = 0;
            byte[] inBuf = ConvertStringToByte("FF02010100");
            int inLen = inBuf.Length;
            HIDReader_Control(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
            if (ConvertByteToString(ApduResponse, outLength) != "9000")
                return false;
            else
                return true;
        }

        /// <summary>
        /// 读取1#扇区
        /// </summary>
        /// <returns></returns>
        private static bool RedSection()
        {
            byte[] ApduResponse = new byte[512];
            int outLength = 0;
            byte[] inBuf = ConvertStringToByte("FF82000006FFFFFFFFFFFF");
            int inLen = inBuf.Length;
            try
            {
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                {
                    throw new Exception("请放入就诊卡！");
                }
                inBuf = ConvertStringToByte("FF880070026100");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                {
                    throw new Exception("获取秘钥失败,该卡已被写过！");
                }
                inBuf = ConvertStringToByteOld("FFB0004010");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                var r4 = ConvertByteToString(ApduResponse, outLength);
                if (r4.Substring(r4.Length - 4, 4) != "9000")
                {
                    return false;
                }
                inBuf = ConvertStringToByte("FFB0005010");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                var rf5 = ConvertByteToString(ApduResponse, outLength);
                if (rf5.Substring(rf5.Length - 4, 4) != "9000")
                {
                    return false;
                }
                inBuf = ConvertStringToByte("FFB0006010");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                var rf6 = ConvertByteToString(ApduResponse, outLength);
                if (rf6.Substring(rf6.Length - 4, 4) != "9000")
                {
                    return false;
                }
                inBuf = ConvertStringToByte("FFB0007010");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                var rf7 = ConvertByteToString(ApduResponse, outLength);
                if (rf6.Substring(rf6.Length - 4, 4) != "9000")
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 修改扇区秘钥
        /// </summary>
        /// <returns></returns>
        private static bool UpdateSection()
        {
            byte[] ApduResponse = new byte[512];
            int outLength = 0;

            byte[] inBuf = ConvertStringToByte("FF82000006FFFFFFFFFFFF");
            int inLen = inBuf.Length;
            HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
            if (ConvertByteToString(ApduResponse, outLength) != "9000")
                return false;

            inBuf = ConvertStringToByteOld("FF880070026100");
            inLen = inBuf.Length;
            HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
            if (ConvertByteToString(ApduResponse, outLength) != "9000")
                return false;

            inBuf = ConvertStringToByteOld("FFD60070100000000000007F07886987337679FFFF");
            inLen = inBuf.Length;
            HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
            if (ConvertByteToString(ApduResponse, outLength) != "9000")
                return false;

            return true;
        }
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="cliniccardid">卡号</param>
        /// <param name="patiid"></param>
        /// <returns></returns>
        private static bool SaveCard(string cliniccardid, string patiid)
        {
            //int lengthtemp = 42;
            byte[] ApduResponse = new byte[512];
            int outLength = 0;

            try
            {
                byte[] inBuf = ConvertStringToByteOld("FF8200000687337679FFFF");
                int inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                    throw new Exception("请放入就诊卡！");

                inBuf = ConvertStringToByteOld("FF880070026100");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                    return false;


                inBuf = ConvertStringToByte($"FFD6004010{cliniccardid.Trim()}FF");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                    return false;

                inBuf = ConvertStringToByte($"FFD6005010{patiid.Trim()}FF");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }




        /// <summary>
        /// 返回写卡信息
        /// </summary>
        /// <param name="cliniccardid"></param>
        /// <param name="patiid"></param>
        /// <returns></returns>
        private static bool OutWriteCard(out string cliniccardid, out string patiid)
        {
            byte[] ApduResponse = new byte[512];
            int outLength = 0;

            try
            {
                byte[] inBuf = ConvertStringToByteOld("FF8200000687337679FFFF");
                int inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                    throw new Exception("请放入就诊卡！");

                inBuf = ConvertStringToByteOld("FF880070026100");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                    throw new Exception("该卡未写入信息！");

                inBuf = ConvertStringToByte("FFB0004010");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                cliniccardid = Regex.Split(ConvertByteToString(ApduResponse, outLength), "FF", RegexOptions.IgnoreCase)[0];

                inBuf = ConvertStringToByte("FFB0005010");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                patiid = Regex.Split(ConvertByteToString(ApduResponse, outLength), "FF", RegexOptions.IgnoreCase)[0];

                inBuf = ConvertStringToByte("FFB0006010");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);


                inBuf = ConvertStringToByte("FFB0007010");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;

        }

        /// <summary>
        /// 还原扇区
        /// </summary>
        /// <returns></returns>
        private static bool RestoreSection()
        {
            byte[] ApduResponse = new byte[512];
            int outLength = 0;
            try
            {
                byte[] inBuf = ConvertStringToByteOld("FF8200000687337679FFFF");
                int inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                    throw new Exception("请放入就诊卡！");

                inBuf = ConvertStringToByteOld("FF880070026100");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                    throw new Exception("该就诊卡已是出厂状态无需还原！");

                inBuf = ConvertStringToByteOld("FFD6007010FFFFFFFFFFFFFF078069FFFFFFFFFFFF");
                inLen = inBuf.Length;
                HIDReader_Transmit(Convert.ToByte(0), Convert.ToByte(1), inBuf, inLen, ApduResponse, out outLength, 10000);
                if (ConvertByteToString(ApduResponse, outLength) != "9000")
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }

        #region 私有Utils方法

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <param name="len">有效长度</param>
        /// <returns></returns>
        private static string ConvertByteToString(byte[] data, int len)
        {
            StringBuilder sDataOut;
            if (!(data == null))
            {
                sDataOut = new StringBuilder(len * 2);
                for (int nI = 0; nI < len; nI++)
                {
                    sDataOut.AppendFormat("{0:X02}", data[nI]);
                }
            }
            else
                sDataOut = new StringBuilder();
            return sDataOut.ToString();
        }
        /// <summary>
        /// 16进制字符串转字节数组
        /// </summary>
        /// <param name="data">16进制字符串</param>
        /// <returns></returns>
        private static byte[] ConvertStringToByte(string data)
        {
            byte[] bData;
            string sData;
            if (Convert.ToInt32(data.Length / 2) * 2 != data.Length)
                sData = data + "0";
            else
                sData = data;

            if (sData.Length > 0)
            {
                bData = new byte[Convert.ToInt32(sData.Length / 2)];
                int nK = 0;
                for (int nJ = 0; nJ < bData.Length; nJ++)
                {
                    bData[nK / 2] = byte.Parse(sData.Substring(nK, 2), NumberStyles.AllowHexSpecifier);
                    nK += 2;
                }
                return bData;
            }
            else
                return null;
        }

        private static byte[] ConvertStringToByteOld(string data)
        {
            byte[] bData;
            string sData = data;
            if (sData.Length > 0)
            {
                bData = new byte[sData.Length / 2];
                for (int nJ = 0; nJ < sData.Length; nJ += 2)
                {
                    bData[nJ / 2] = byte.Parse(sData.Substring(nJ, 2), NumberStyles.AllowHexSpecifier);
                }
                return bData;
            }
            else
                return null;

        }
        #endregion

    }
}
