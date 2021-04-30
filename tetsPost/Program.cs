using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace tetsPost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //  PostData("http://192.168.11.254/webAPI/YuanTuApi/QueryPatient", testData.New("009999206209414171274"));
            //var aa=  GetData("http://192.168.8.241:21000/getServerDate");
            var date = GetServerDate();
            Console.WriteLine(date);
            Console.WriteLine($@"时间格式化{ date.ToString("yyyyMMddHHmmss").Trim()}");

            //var dd = HttpPostClient("http://192.168.11.254/webAPI/YuanTuApi/QueryPatient", testData.New("8004187171365370555"));
            //Console.WriteLine(dd);
            //随机函数测试
            Console.WriteLine(new Random().Next(10000) + 1);

            Console.WriteLine("----------Ascii码进位-----------");

            Console.WriteLine(PubLib.StrGetNextID("adbcZ",1));

            Console.WriteLine("-------StrGetValue-------");

            Console.WriteLine(PubLib.StrGetValue("abad", "a"));


            Console.ReadLine();
        }
       

        #region "httpWebRequest(GET,POST)"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="data">json参数</param>
        public static string HttpPost(string url, object data)
        {
          var requestData = JsonConvert.SerializeObject(data);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] byteData = Encoding.UTF8.GetBytes(requestData);

            request.ContentLength = byteData.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(byteData, 0, byteData.Length);
            writer.Close();
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            Console.WriteLine(responseString.ToString());
            //MessageBox.Show(responseString.ToString());
            return responseString;

        }
        public static string HttpGet(string Url)
        {
            try
            {
                string retString = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";
                request.ContentType = "application/json;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(myResponseStream);
                retString = streamReader.ReadToEnd();
                streamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region " WebClient(GET,POST)"
        /// <summary>
        /// Http同步Get同步请求
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <param name="encode">编码(默认UTF8)</param>
        /// <returns></returns>
        public static string HttpGetClient(string url, Encoding encode = null)
        {
            string result;

            try
            {
                var webClient = new WebClient { Encoding = Encoding.UTF8 };

                if (encode != null)
                    webClient.Encoding = encode;

                result = webClient.DownloadString(url);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        /// <summary>
        /// Http同步Get异步请求
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <param name="callBackDownStringCompleted">回调事件</param>
        /// <param name="encode">编码(默认UTF8)</param>
        public static void HttpGetAsync(string url,
            DownloadStringCompletedEventHandler callBackDownStringCompleted = null, Encoding encode = null)
        {
            var webClient = new WebClient { Encoding = Encoding.UTF8 };

            if (encode != null)
                webClient.Encoding = encode;

            if (callBackDownStringCompleted != null)
                webClient.DownloadStringCompleted += callBackDownStringCompleted;

            webClient.DownloadStringAsync(new Uri(url));
        }

        /// <summary>
        ///  Http同步Post同步请求
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <param name="postStr">请求Url数据</param>
        /// <param name="encode">编码(默认UTF8)</param>
        /// <returns></returns>
        public static string HttpPostClient(string url, object postStr = null, Encoding encode = null)
        {
            string result;

            try
            {
                var webClient = new WebClient { Encoding = Encoding.UTF8 };

                if (encode != null)
                    webClient.Encoding = encode;

                var sendData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( postStr));

                webClient.Headers.Add("Content-Type", "application/json;charset=UTF-8");
                webClient.Headers.Add("ContentLength", sendData.Length.ToString(CultureInfo.InvariantCulture));

                var readData = webClient.UploadData(url, "POST", sendData);

                //result = Encoding.GetEncoding("GB2312").GetString(readData);
                result = Encoding.UTF8.GetString(readData);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }




        #endregion

        public static DateTime GetServerDate()
        {
            var data = HttpGetClient("http://192.168.8.241:21000/getServerDate");
            JObject obj = JObject.Parse(data);
            string serverDate = obj["data"].ToString();
            return Convert.ToDateTime(serverDate);
        }

        public class testData
        {
            public string patientId { get; set; }

            protected testData(string id)
            {
                this.patientId = id;
            }

            public static testData New(string id) => new testData(id);
        }



    }
}
