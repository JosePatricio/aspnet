using Negocio.Utilidades;
using PersistenciaSigeor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Negocio.Dashboard
{
    public class DashboardNegocio
    {
        public static List<GET_ESTIMADOS_LINEA_POR_ANIO_Result> ObtenerEstimadoLineaPorAnio(int anio)
        {

            List<GET_ESTIMADOS_LINEA_POR_ANIO_Result> result;
            try
            {
                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    using (var context = new SigeorEntities())
                    {
                        result = context.GET_ESTIMADOS_LINEA_POR_ANIO(anio).ToList();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener los estimados linea por año: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener los estimados linea por año: " + ex.Message);
            }
            return result;
        }

        public static List<GET_ESTIMADOS_POR_LINEA_POR_MESES_Result> ObtenerEstimadoLineaPorMeses(int anio)
        {

            List<GET_ESTIMADOS_POR_LINEA_POR_MESES_Result> result;
            try
            {
                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    using (var context = new SigeorEntities())
                    {
                        result = context.GET_ESTIMADOS_POR_LINEA_POR_MESES(anio).ToList();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener los estimados de lineas por meses: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener los estimados de lineas por meses: " + ex.Message);
            }
            return result;
        }


        public static List<GET_ANIOS_MESES_ESTIMADOS_Result> ObtenerAnioEstimados()
        {

            List<GET_ANIOS_MESES_ESTIMADOS_Result> result;
            try
            {
                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    using (var context = new SigeorEntities())
                    {
                        result = context.GET_ANIOS_MESES_ESTIMADOS().ToList();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener los años y meses estimados: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener los años y meses estimados: " + ex.Message);
            }
            return result;
        }

    }
}
