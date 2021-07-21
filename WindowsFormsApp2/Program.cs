using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //开机自启动
            string menuShortcut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs), string.Format(@"{0}\{1}.appref-ms", "李道华", "测试本地服务"));
            MessageBox.Show(menuShortcut);
            string startupShortcut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Path.GetFileName(menuShortcut));
            //Console.Out.WriteInfo(startupShortcut);
            string k = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();

            MessageBox.Show(startupShortcut);
            try
            {
                if (!File.Exists(startupShortcut))
                {
                    File.Copy(menuShortcut, startupShortcut);
                    //Console.Out.WriteTip("开机启动 Ok.");
                }
                else
                {
                    File.Delete(startupShortcut);
                    //Console.Out.WriteTip("开机禁止 Ok.");
                }
            }
            catch (Exception)
            {
            }
           

            //RegistryKey regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //string publisherName = Application.CompanyName;
            //string productName = Application.ProductName;
            //string allProgramsPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            //string shortcutPath = Path.Combine(allProgramsPath, publisherName);
            //shortcutPath = Path.Combine(shortcutPath, productName) + ".appref - ms";
            //regkey.DeleteSubKey("YourApplication", false);//delete old key if exists
            //regkey.SetValue("YourApplication", shortcutPath);


            //ApplicationDeployment.CurrentDeployment.CheckForUpdateAsync();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           

            //DoStartup(args);

        }

 
    }
}
