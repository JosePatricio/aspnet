using System;using System.Collections.Generic;using System.Linq;using System.Text;using Quartz;using Quartz.Impl;using Quartz.Impl.Triggers;using Negocio.Utilidades;using System.Diagnostics;using System.Net;using System.Net.Sockets;using System.Threading;using Negocio.Sigeor.Configuracion;
using PersistenciaSigeor;

namespace Negocio.Job{    public class EjecutarJob    {        private static IScheduler _scheduler;        private static string _configuracionPorDefecto = "0 0 0 1/1 * ? *"; // Todos los días a las 24:00
        public static void EjecutarProceso()        {            try            {

                ThreadPool.QueueUserWorkItem(PeticionAutomaticaServidor);

                ISchedulerFactory schedulerFactory = new StdSchedulerFactory();                _scheduler = schedulerFactory.GetScheduler();                _scheduler.Start();                var politica = PoliticasCorporativasNegocio.ObtenerPoliticaPorCodigoDesSerializada(ConstantesNegocioUtil.COD_CONF_EJECUCION_PROC);                if (politica == null)
                {
                    politica = new PoliticasCorporativas
                    {
                        Codigo = ConstantesNegocioUtil.COD_CONF_EJECUCION_PROC,
                        Nombre = "POL_EJEC_PROC",
                        Descripcion = "POLITICA PARA CONFIGURAR LA EJECUCION DEL PROCESO",
                        Grupo = "GR_POL_DIF",
                        TextValueUno = _configuracionPorDefecto,
                        Estado = true
                    };

                    using (var context = new SigeorEntities())
                    {
                        context.PoliticasCorporativas.AddObject(politica);
                        context.SaveChanges();
                    }
                }
                

                

                                IProcesarEor myJob = new ProcesarEor(); //This Constructor needs to be parameterless
                JobDetailImpl jobDetail = new JobDetailImpl("JobProcesarEor", "GroupEor", myJob.GetType());                CronTriggerImpl trigger = new CronTriggerImpl("Trigger1", "Group1", politica.TextValueUno); //run every minute between the hours of 8am and 5pm
                _scheduler.ScheduleJob(jobDetail, trigger);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo instanciar el \"Cron\" para ejecutar el proceso: " + ex, EventLogEntryType.Error);            }        }        public static void PeticionAutomaticaServidor(Object stateInfo)        {            try
            {
                int minutos = 1;
                while (true)
                {

                    IPAddress[] serverOwnIp = Array.FindAll(
                                Dns.GetHostEntry(Dns.GetHostName()).AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);

                    //var serverOwnIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(o => o.AddressFamily == AddressFamily.InterNetwork).ToString();
                    var req = (HttpWebRequest)WebRequest.Create(new Uri("http://" + serverOwnIp.FirstOrDefault().ToString() + @"/Sigeor"));
                    req.Method = "GET";
                    var response = (HttpWebResponse)req.GetResponse();
                    var respStream = response.GetResponseStream();
                    var delay = new TimeSpan(0, 0, minutos, 0);
                    Log.WriteEntry("Peticion Automatica a IIS", EventLogEntryType.Information);
                    Thread.Sleep(delay);
                }
            }
            catch (Exception ex)            {                Log.WriteEntry("No se pudo realizar la peticion automatica al Servidor IIS: " + ex, EventLogEntryType.Error);            }



        }    }}