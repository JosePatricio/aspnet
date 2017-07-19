﻿using System;
using PersistenciaSigeor;

namespace Negocio.Job
        public static void EjecutarProceso()

                ThreadPool.QueueUserWorkItem(PeticionAutomaticaServidor);

                ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
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
                

                

                
                JobDetailImpl jobDetail = new JobDetailImpl("JobProcesarEor", "GroupEor", myJob.GetType());
                _scheduler.ScheduleJob(jobDetail, trigger);
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
            catch (Exception ex)



        }