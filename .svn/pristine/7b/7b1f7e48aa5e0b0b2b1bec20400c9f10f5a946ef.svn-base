using Negocio.Job;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Sigeor
{
    public class Global : System.Web.HttpApplication
    {
        public Global()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            EjecutarJob.EjecutarProceso();
        }

    }
}