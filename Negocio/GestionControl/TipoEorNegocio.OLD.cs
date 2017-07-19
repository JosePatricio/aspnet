using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Negocio.Utilidades;
using PersistenciaSigeor;
using System.Diagnostics;

namespace Negocio.Sigeor.GestionMgl
{
    public class TipoEorNegocio
    {
        public static string ObtenerTiposEorPorEstado(bool estado)
        {
            string result = string.Empty;
            try
            {
                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                using (var context = new SigeorEntities())
                {

                    //var query = (from tipoReparacionEor in context.TipoReparacionEor
                    //             where tipoReparacionEor.Estado.Equals(estado)
                    //             orderby tipoReparacionEor.Nombre
                    //             select tipoReparacionEor).ToList();
                    //result = query.Any() ? Serializador.SerializeEntity(query) : null;
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {                
                Log.WriteEntry("No se pudo cargar los tipos de Eor: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo cargar los tipos de Eor: " + ex);
            }
            return result;
        }
    }
}
