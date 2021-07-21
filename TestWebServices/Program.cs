using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Xml;
using System.Web;
namespace TestWebServices
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceReference1.HoslinkClient hoslinkClient = new ServiceReference1.HoslinkClient();
            var result = hoslinkClient.listStation("c4fc739e68f333ba9b00b1ac9c368442");
            Console.WriteLine(result);
            Console.ReadLine();

            //DataTable dt = obj as DataTable;
        }
        //public string HttpPostWebService(string url, string method, string data)
        //{
        //    string result = string.Empty;
        //    string param = string.Empty;
        //    byte[] bytes = null;

        //    Stream writer = null;
        //    HttpWebRequest request = null;
        //    HttpWebResponse response = null;
        //    //HttpUtility.UrlEncode("MethodID") + "=" + HttpUtility.UrlEncode(method) + "&" +
        //    //param =  HttpUtility.UrlEncode("data") + "=" + HttpUtility.UrlEncode(data);
        //    param = HttpUtility.UrlEncode(data);
        //    bytes = Encoding.UTF8.GetBytes(param);

        //    //request = (HttpWebRequest)WebRequest.Create(url + "/" + method);
        //    request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "POST";
        //    request.ContentType = "application/json";
        //    request.ContentLength = bytes.Length;

        //    try
        //    {
        //        writer = request.GetRequestStream();  //获取用于写入请求数据的Stream对象
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }

        //    writer.Write(bytes, 0, bytes.Length);  //把参数数据写入请求数据流
        //    writer.Close();

        //    try
        //    {
        //        response = (HttpWebResponse)request.GetResponse();  //获得响应
        //    }
        //    catch (WebException ex)
        //    {
        //        return "";
        //    }

        //    #region 这种方式读取到的是一个返回的结果字符串
        //    //Stream stream = response.GetResponseStream();  //获取响应流
        //    //XmlTextReader Reader = new XmlTextReader(stream);
        //    //Reader.MoveToContent();
        //    //result = Reader.ReadInnerXml();
        //    #endregion

        //    #region 这种方式读取到的是一个Xml格式的字符串
        //    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        //    result = reader.ReadToEnd();
        //    #endregion

        //    //response.Dispose();
        //    response.Close();
        //    reader.Dispose();
        //    reader.Close();


        //    //Reader.Dispose();
        //    //Reader.Close();

        //    //stream.Dispose();
        //    //stream.Close();

        //    return result;

        //}
        //     public static XmlDocument Test1_QueryPostWebService(string URL,
        //     string MethodName, Hashtable Pars)
        //     {
        //         HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL + "/" + MethodName);
        //         request.Method = "POST";
        //         request.ContentType = "application/x-www-form-urlencoded";
        //         request.Credentials = CredentialCache.DefaultCredentials;
        //         request.Timeout = 10000;


        //         #region 参数拼接成字符串，最后编码
        //         StringBuilder sb = new StringBuilder();
        //         foreach (string k in Pars.Keys)
        //         {
        //             if (sb.Length > 0)
        //             {
        //                 sb.Append("&");
        //             }
        //             sb.Append(
        //                HttpUtility.UrlEncode(k) + "="
        // + HttpUtility.UrlEncode(Pars[k].ToString())
        //);
        //         }
        //         byte[] data = Encoding.UTF8.GetBytes(sb.ToString());

        //         #endregion

        //         #region  把编码后的参数写入请求流中
        //         request.ContentLength = data.Length;
        //         Stream writer = request.GetRequestStream();
        //         writer.Write(data, 0, data.Length);
        //         writer.Close();

        //         #endregion

        //         #region 读取结果，创建XmlDocument对象，对象加载结果
        //         var response = request.GetResponse();
        //         StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        //         String retXml = sr.ReadToEnd();
        //         sr.Close();
        //         XmlDocument doc = new XmlDocument();
        //         doc.LoadXml(retXml);

        //         #endregion

        //         return doc;
        //     }


    }
}
