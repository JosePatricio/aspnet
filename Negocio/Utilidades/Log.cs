﻿using System;using System.Collections.Generic;using System.Diagnostics;using System.IO;using System.Linq;using System.Text;namespace Negocio.Utilidades{    public class Log    {        //private static EventLog _log;        private static void CreateLog()        {            try            {                if (!File.Exists(@"C:\SigeorLog\SigeorLog.txt"))                {                    Directory.CreateDirectory(@"C:\SigeorLog");                    var file = File.Create(@"C:\SigeorLog\SigeorLog.txt");                    file.Close();                }                //_log = new EventLog("SigeorLog") { Source = "SigeorLog" };            }            catch (Exception ex)            {                throw new Exception(ex.Message);            }        }        public static void WriteEntry(string cadena, EventLogEntryType eventLogEntryType)        {            try            {                CreateLog();                using (var sw = new StreamWriter(@"C:\SigeorLog\SigeorLog.txt", true))                {                    var tipoError = string.Empty;                    if (EventLogEntryType.Error.Equals(eventLogEntryType))                        tipoError = "ERROR";                    else                        if (EventLogEntryType.FailureAudit.Equals(eventLogEntryType))                            tipoError = "FAILUREAUDIT";                        else                            if (EventLogEntryType.Information.Equals(eventLogEntryType))                                tipoError = "INFORMACIÓN";                            else if (EventLogEntryType.SuccessAudit.Equals(eventLogEntryType))                                tipoError = "SUCCESSAUDIT";                            else if (EventLogEntryType.Warning.Equals(eventLogEntryType))                                tipoError = "WARNING";                    sw.WriteLine(DateTime.Now + " " + tipoError + ": " + cadena);                    sw.Flush();                    sw.Close();                }                //_log.WriteEntry(cadena, eventLogEntryType);            }            catch (Exception ex)            {                            }        }    }}
