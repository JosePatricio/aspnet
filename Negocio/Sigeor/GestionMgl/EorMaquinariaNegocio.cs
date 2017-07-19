using System;
using System.Linq;
using System.Transactions;
using Negocio.Utilidades;
using PersistenciaSigeor;
using System.Diagnostics;

namespace Negocio.Sigeor.GestionMgl
{
    public class EorMaquinariaNegocio
    {
        public static string ObtenerDetalleEorMaquinariaPorNumEor(string parametro)
        {
            string result = null;
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

                        var query = (from detalle in context.D_EORMAQUINARIA
                                     where detalle.NUM_EORMAQ.Trim().Equals(param.IdStringUno) &&
                                           detalle.AproRepara.Trim().Equals(param.EstadoString)
                                     select detalle).ToList();

                        if (query.Any())
                        {
                            var detEorMaquinaria = query.FirstOrDefault();

                            if (detEorMaquinaria != null)
                            {
                                param.IdStringUno = detEorMaquinaria.COD_LINEA;

                                var resultLinea = LineaNegocio.ObtenerLineaPorCodigo(Serializador.SerializeEntity(param));
                                var linea = !string.IsNullOrEmpty(resultLinea)
                                    ? Serializador.DeSerializeEntity<M_LINEA>(resultLinea)
                                    : new M_LINEA();

                                //query.ForEach(ent => { ent.Linea = linea; });
                            }
                            result = query.Any() ? Serializador.SerializeEntity(query) : null;
                        }


                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener el Eor por maquinaria: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener el Eor por maquinaria: " + ex);
            }
            return result;
        }
    }
}
