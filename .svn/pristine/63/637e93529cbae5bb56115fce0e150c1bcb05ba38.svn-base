using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using Negocio.Utilidades;
using PersistenciaSigeor;

namespace Negocio.Sigeor.GestionMgl
{
    public class AgenciaNegocio
    {
        public static string ObtenerAgencias()
        {
            List<M_AGENCIA> result;
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

                        result = (from deposito in context.M_AGENCIA
                                  orderby deposito.NOMBRE_AGENCIA
                                  select deposito).ToList();

                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo cargar los agencias: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo cargar los agencias: " + ex);
            }
            return result.Any() ? Serializador.SerializeEntity(result) : null;
        }

        public static string ObtenerAgenciasPorEstado(string estado)
        {
            List<M_AGENCIA> result;
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

                        result = (from deposito in context.M_AGENCIA
                                  orderby deposito.NOMBRE_AGENCIA
                                  where deposito.ESTADO == estado
                                  select deposito).ToList();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo cargar las agencias por estado: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo cargar las agencias por estado: " + ex);
            }
            return result.Any() ? Serializador.SerializeEntity(result) : null;
        }

        public static string ObtenerAgenciaPorCodigo(string parametro)
        {
            M_AGENCIA result;
            try
            {
                var param = Serializador.DeSerializeEntity<ClaseBasica>(parametro);
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    using (var context = new SigeorEntities())
                    {
                        result = (from deposito in context.M_AGENCIA
                                  where deposito.COD_AGENCIA.Equals(param.IdStringUno)
                                  orderby deposito.NOMBRE_AGENCIA
                                  select deposito).FirstOrDefault();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener la agencia por código: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener la agencia por código: " + ex);
            }
            return result != null ? Serializador.SerializeEntity(result) : null;
        }
    }
}
