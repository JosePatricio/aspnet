using Negocio.Utilidades;
using PersistenciaSigeor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Negocio.Configuracion
{
    public class AlertaReparacionNegocio
    {
        public static void Insertar(AlertaReparacion alertaReparacion)
        {
            try
            {
                using (var context = new SigeorEntities())
                {
                    alertaReparacion.CampoCedulaUsuario = "AutoGenerado";
                    alertaReparacion.CampoIpUsuario = "Sistema";
                }
                AuditoriaNegocio.InsertarAuditoria(alertaReparacion, null, TipoAuditoriaEnum.INS);

            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo registrar la Alerta Reparacion: " + ex, EventLogEntryType.Error);
            }
        }

        public static void Modificar(string alertaReparacionSerializada)
        {
            try
            {

                var alertaReparacion = Serializador.DeSerializeEntity<AlertaReparacion>(alertaReparacionSerializada);


                if (alertaReparacion != null)
                {
                    var alertaAnterior = Reflection.ClonarEntidadAuditoria(alertaReparacion);
                    using (var context = new SigeorEntities())
                    {
                        alertaReparacion.Estado = false;
                        alertaReparacion.FechaRevision = DateTime.Now;
                        context.AlertaReparacion.Attach(alertaReparacion);
                        context.ObjectStateManager.ChangeObjectState(alertaReparacion, EntityState.Modified);
                        context.AlertaReparacion.ApplyCurrentValues(alertaReparacion);
                        context.SaveChanges();

                        AuditoriaNegocio.InsertarAuditoria(alertaReparacion, alertaAnterior, TipoAuditoriaEnum.UPD);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo modificar la Alerta de la Reparacion: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo modificar la Alerta de la Reparacion: " + ex.Message);
            }
        }

        public static AlertaReparacion ObtenerAlertaReparacionDesSerializado(string idAlertaReparacion)
        {
            AlertaReparacion alertaReparacion = null;
            try
            {
                using (var context = new SigeorEntities())
                {
                    var idGuid = Guid.Parse(idAlertaReparacion);
                    alertaReparacion = (from ent in context.AlertaReparacion
                                        where ent.Id == idGuid
                                        select ent).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo modificar el usuario: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo modificar el usuario: " + ex.Message);
            }
            return alertaReparacion;
        }

        public static string ObtenerAlertaReparacion(string idAlertaReparacion)
        {
            AlertaReparacion result = null;
            try
            {
                using (var context = new SigeorEntities())
                {
                    var idGuid = Guid.Parse(idAlertaReparacion);
                    result = (from ent in context.AlertaReparacion
                              where ent.Id == idGuid
                              select ent).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo modificar el usuario: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo modificar el usuario: " + ex.Message);
            }
            return result != null ? Serializador.SerializeEntity(result) : null;
        }

        public static string ObtenerAlertasPorEstadoPaginado(bool estado, int pagesize, int pageIndex, out int totalRegistros)
        {

            List<GET_ALERTAS_GENERADAS_Result> result;
            try
            {
                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {

                    using (var context = new SigeorEntities())
                    {
                        result = context.GET_ALERTAS_GENERADAS(string.Empty, string.Empty, estado ? "1":"0").ToList();
                    }
                    transactionScope.Complete();
                }
                totalRegistros = result.Count;
                result = result.Skip(pagesize * (pageIndex - 1)).Take(pagesize).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener las Alertas Reparaciones por estado paginado: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener las Alertas Reparaciones por estado paginado: " + ex.Message);
            }
            return result.Any() ? Serializador.SerializeEntity(result) : null;
        }

        public static string ObtenerAlertasPorEstado(bool estado)
        {

            List<GET_ALERTAS_GENERADAS_Result> result;
            try
            {
                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {

                    using (var context = new SigeorEntities())
                    {
                        result = context.GET_ALERTAS_GENERADAS(string.Empty, string.Empty, estado ? "1":"0").ToList();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener las Alertas Reparaciones por estado: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener las Alertas Reparaciones por estado: " + ex.Message);
            }
            return result.Any() ? Serializador.SerializeEntity(result) : null;
        }

        public static string ObtenerResumenAlertas()
        {

            List<GET_RESUMEN_ALERTAS_Result> result;
            try
            {
                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {

                    using (var context = new SigeorEntities())
                    {
                        result = context.GET_RESUMEN_ALERTAS().ToList();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener el resumen de las Alertas Reparaciones por estado: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener el resumen de las Alertas Reparaciones por estado: " + ex.Message);
            }
            return result.Any() ? Serializador.SerializeEntity(result) : null;
        }

        public static string ObtenerAlertaReparacionPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex, out int totalRegistros)        {            List<GET_ALERTAS_GENERADAS_Result> result;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        value = value.ToUpper();                        result = context.GET_ALERTAS_GENERADAS(string.Empty, value, estado ? "1":"0").ToList();                    }                    transactionScope.Complete();                }                totalRegistros = result.Count;                result = result.Skip(pagesize * (pageIndex - 1)).Take(pagesize).ToList();            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los usuarios por coincidencia paginado: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener los usuarios por coincidencia paginado: " + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }


        public static string ObtenerAlertaReparacionPorCoincidencia(string value, bool estado)        {            List<GET_ALERTAS_GENERADAS_Result> result;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        value = value.ToUpper();                        result = context.GET_ALERTAS_GENERADAS(string.Empty, value, estado ? "1":"0").ToList();                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener las Alertas de Reparaciones por coincidencia paginado: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener las Alertas de Reparaciones coincidencia paginado: " + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }



    }
}
