using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ElectronicInvoiceTest
{
    public class EBillInterface
    {
        //private const string Url = "http://218.29.120.86:8321/api/hospital/";
        //private const string AppID = "171861E611787172B3203DE8EB55EFF4";
        //private const string Appkey = "1FE5FB38958EF621B1BC3FB2CF43FF5E";
        //private const string Empty2MD5 = "D41D8CD98F00B204E9800998ECF8427E";

        //private const string ApiContentType = "application/json;charset=UTF-8";
        //正式
        private const string Url = "http://192.168.200.105:8321/api/hospital/";
        private const string AppID = "70A1647256B59D1E4407908326A3B99E"; //分配的appid
        private const string Appkey = "E9B75CC60A395A611FD54FC20DA4B99C";
        private const string Empty2MD5 = "D41D8CD98F00B204E9800998ECF8427E";
        private const string ApiContentType = "application/json;charset=UTF-8";
        /// <summary>
        /// MD5加密后的串
        /// </summary>
        private string Signature;
        /// <summary>
        /// 调用接口参数（json）
        /// </summary>
        public string RequestBody { private get; set; }
        /// <summary>
        /// 随机字符串(随机数)
        /// </summary>
        public string RequestNonce { private get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string RequestTimestamp { private get; set; }
        /// <summary>
        /// 接口方法
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName">接口方法</param>
        /// <param name="requestBody">调用接口参数（json）</param>
        /// <param name="requestNonce">随机字符串</param>
        /// <param name="requestTimestamp">时间戳</param>
        public EBillInterface(string methodName, string requestBody, string requestNonce, string requestTimestamp)
        {
            RequestBody = requestBody;
            RequestNonce = requestNonce;
            RequestTimestamp = requestTimestamp;
            MethodName = methodName;
        }
        private string GetSignature()
        {
            return string.Empty;
        }

        /// <summary>
        /// 获取用于数据完整性检验的MD5加密字符串
        /// </summary>
        /// <param name="data">待加密字符串</param>
        /// <returns>加密字符串</returns>
        private string GetMD5StringForCheck(string data)
        {
            if (string.IsNullOrEmpty(data))
                return Empty2MD5;
            MD5 md5Hasher = MD5.Create();
            byte[] dataByte = md5Hasher.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(data));
            StringBuilder sBuilder = new StringBuilder();
            dataByte.ToList().ForEach(_ => sBuilder.Append(_.ToString("X2")));
            return sBuilder.ToString();
        }
        public string Trade()
        {
            MakeSignature();
            string _url = $"{Url}{MethodName}?appid={AppID}&nonce={RequestNonce}&timestamp={RequestTimestamp}&signature={Signature}";
            string jsonParam = RequestBody;
            var request = (HttpWebRequest)WebRequest.Create(_url);
            request.Method = "POST";
            request.ContentType = ApiContentType;
            byte[] byteData = Encoding.UTF8.GetBytes(jsonParam);
            int length = byteData.Length;
            request.ContentLength = length;
            Stream writer = request.GetRequestStream();
            writer.Write(byteData, 0, length);
            writer.Close();
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            return responseString.ToString();
        }
        private void MakeSignature()
        {
            string postBody;
            if (RequestBody == string.Empty)
                postBody = Empty2MD5;
            else
                postBody = GetMD5StringForCheck(RequestBody);
            Signature = GetMD5StringForCheck(Appkey + postBody + RequestNonce + RequestTimestamp + Appkey);
        }
    }
}
