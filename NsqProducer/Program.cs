using NsqSharp;
using System;

namespace NsqProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nsq消息生产者!");

            var topicName = "test-Nsq-Core";//主题消息头
            //消息内容
            var message = EmpInfo.New("李嘉诚", "女", 18, "黑龙江哈尔滨").ToJson();

            SendMessage(topicName, message);

            Console.ReadLine();

        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="topicName">主题消息头</param>
        /// <param name="message">消息内容</param>
        public static void SendMessage( string topicName, string message)
        {
            var servers = "192.168.9.120:4150";//nsq服务
            var producer = new Producer(servers);
            producer.Publish(topicName, message);

            Console.WriteLine("消息发送成功！");
            Console.WriteLine($"{ topicName}：{message}");
            producer.Stop();

        }
    }
}
