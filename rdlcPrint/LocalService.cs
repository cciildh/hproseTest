using Hprose.RPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace rdlcPrint
{
  public  class LocalService
    {
        public LocalService Create() => new LocalService();

        private HttpListener listener;
        public void Start()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(Properties.Settings.Default.URL);
            listener.Start();

            Service service = new Service();


            //service.AddInstanceMethods(new LocalInsurService());
            service.AddInstanceMethods(new PrintService());
            //service.AddInstanceMethods(new LocalInsurService());
            //DataModel.RegisterModels.Register();//注册类
            service.Bind(listener);

        }

        public void Stop()
            => listener?.Stop();
    }
}
