using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersistenciaSigeor;
using System.Transactions;
using System.Collections;
using Negocio.Utilidades;
using System.Reflection;
using System.Diagnostics;

namespace Negocio.Reportes
{
    public class EstadosReportesNegocio
    {

        public String ObtenerTipoContenedor()
        {

            List<ESTADO_EIR> resultado;
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
                        resultado = (from estados in context.ESTADO_EIR
                                     select estados
                              ).OrderBy(x => x.NOM_ESTADO).ToList();
                    }
                    transactionScope.Complete();
                }

            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener el tipo de contenedor: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener el tipo de contenedor: " + ex.Message);
            }
            return resultado.Any() ? Serializador.SerializeEntity(resultado) : null;

        }
    }
}
