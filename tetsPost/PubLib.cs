using System;
using System.Collections.Generic;
using System.Text;

namespace tetsPost
{
   public class PubLib
    {
        /// <summary>
        /// 获取进位数据
        /// </summary>
        /// <param name="strCurID">需要进位的原始数据</param>
        /// <param name="intFixSerialLen">需要进位的length</param>
        /// <returns></returns>
        public static string StrGetNextID(string strCurID, int intFixSerialLen)
        {
            string text;
            string str;
            if (intFixSerialLen > strCurID.Length)
            {
                text = strCurID;
                str = "";
            }
            else
            {
                text = strCurID.Substring(strCurID.Length - intFixSerialLen, intFixSerialLen);
                str = strCurID.Substring(0, strCurID.Length - intFixSerialLen);
            }
            text = StrGetNextID(text);
            return str + text.Substring(text.Length - intFixSerialLen, intFixSerialLen);
        }

        private static string StrGetNextID(string strCurID)
        {
            int num = strCurID.Length;
            string text = "";
            string result;
            if (num < 0)
            {
                result = "";
            }
            else
            {
                strCurID = strCurID.Trim();
                char c;
                do
                {
                    num--;
                    c = NextChar(strCurID[num], true);
                    text = c + text;
                }
                while (c == '0' & num > 0);
                if (c == '0' & num == 0)
                {
                    result = "1" + text;
                }
                else
                {
                    result = strCurID.Substring(0, num) + text;
                }
            }
            return result;
        }

        private static char NextChar(char curChar, bool isUseLetter)
        {
            char result;
            if (isUseLetter)
            {
                if (curChar == '9')
                {
                    result = 'A';
                }
                else if (curChar == 'Z' | curChar == 'z')
                {
                    result = '0';
                }
                else if (curChar >= '0' & curChar < '9')
                {
                    result = (char)(curChar + '\u0001');
                }
                else if (char.IsLetter(curChar))
                {
                    result = (char)(curChar + '\u0001');
                }
                else
                {
                    result = '?';
                }
            }
            else if (curChar == '9')
            {
                result = '0';
            }
            else if (curChar >= '0' & curChar < '9')
            {
                result = (char)(curChar + '\u0001');
            }
            else if (char.IsLetter(curChar))
            {
                result = '0';
            }
            else
            {
                result = '?';
            }
            return result;
        }

        public static string StrGetValue(string strSetting, string strName)
        {
            return StrGetValue(strSetting, strName, ",");
        }
        public static string StrGetValue(string strSetting, string strName, string strSplit)
        {
            int num = strSetting.ToUpper().IndexOf(strSplit + strName.ToUpper() + "=");
            string result;
            if (num < 0)
            {
                result = "";
            }
            else
            {
                num = num + strName.Length + strSplit.Length + 1;
                int num2 = strSetting.ToUpper().IndexOf(strSplit, num);
                result = strSetting.Substring(num, num2 - num);
            }
            return result;
        }
       
    }
}
