using System.Threading;
using System.Windows.Forms;

namespace rdlcPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            //单实例运行
            using (Mutex m = new Mutex(true, Application.ProductName, out bool createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormLocalResources());
                }
                else
                {
                    MessageBox.Show("程序已执行，只能运行一个实例!");
                }
            }


        }
    }
}
