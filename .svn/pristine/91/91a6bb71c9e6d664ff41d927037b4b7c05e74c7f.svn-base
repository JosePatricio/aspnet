using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Negocio.Utilidades;
using PersistenciaSigeor;
using System.Diagnostics;

namespace Negocio.Sigeor.GestionMgl
{
    public class EorEstructuraNegocio
    {
        public static string ObtenerEorEstructuraPorNumEor(string parametro)
        {
            string result;
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
                        var query = (from cabeceraEor in context.C_EORESTRUCTURA
                                     where cabeceraEor.NUM_EOREST.Trim().Equals(param.IdStringUno) &&
                                           cabeceraEor.COD_DEPOSITO.Trim().Equals(param.IdStringDos) &&
                                           cabeceraEor.COD_RESPONSABLE.Trim().Equals(param.IdStringTres) &&
                                           cabeceraEor.APROBADO.Trim().Equals(param.EstadoString)
                                     select cabeceraEor).FirstOrDefault();

                        if (query != null)
                        {
                            var detalle = ObtenerDetalleEorEstructuraPorNumEor(parametro);
                            query.DetalleEorEstructura = !string.IsNullOrEmpty(detalle)
                                ? Serializador.DeSerializeEntity<List<D_EORESTRUCTURA>>(detalle)
                                : new List<D_EORESTRUCTURA>();

                            param.IdStringUno = query.COD_DEPOSITO;
                            var deposito = DepositoNegocio.ObtenerDepositoPorCodigo(Serializador.SerializeEntity(param));
                            query.CampoDeposito = !string.IsNullOrEmpty(deposito)
                                ? Serializador.DeSerializeEntity<M_DEPOSITO>(deposito)
                                : new M_DEPOSITO();

                            param.IdStringUno = query.COD_RESPONSABLE;
                            var responsable = ResponsableReparacionNegocio.ObtenerResponsablePorCodigo(Serializador.SerializeEntity(param));
                            query.CampoResponsable = !string.IsNullOrEmpty(responsable)
                                ? Serializador.DeSerializeEntity<ESTIMATE_PARTY_RESPON>(deposito)
                                : new ESTIMATE_PARTY_RESPON();


                            param.IdStringUno = query.ID_EIR;
                            var eir = EirNegocio.ObtenerEirPorCodigo(Serializador.SerializeEntity(param));
                            query.CampoEir = !string.IsNullOrEmpty(eir)
                                ? Serializador.DeSerializeEntity<C_EIR>(eir)
                                : new C_EIR();
                        }

                        result = query != null ? Serializador.SerializeEntity(query) : null;
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener el Eor por estructura: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener el Eor por estructura: " + ex);
            }
            return result;
        }

        public static string ObtenerDetalleEorEstructuraPorNumEor(string parametro)
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

                        var query = (from detalleEor in context.D_EORESTRUCTURA
                                     where detalleEor.NUM_EOREST.Equals(param.IdStringUno) &&
                                           detalleEor.AproRepara.Equals(param.EstadoString)
                                     select detalleEor).ToList();

                        if (query.Any())
                        {
                            var dEorestructura = query.FirstOrDefault();

                            if (dEorestructura != null)
                            {
                                param.IdStringUno = dEorestructura.COD_LINEA;

                                var resultLinea = LineaNegocio.ObtenerLineaPorCodigo(Serializador.SerializeEntity(param));
                                var linea = !string.IsNullOrEmpty(resultLinea)
                                    ? Serializador.DeSerializeEntity<M_LINEA>(resultLinea)
                                    : new M_LINEA();

                                query.ForEach(ent => { ent.Linea = linea; });
                            }
                            result = query.Any() ? Serializador.SerializeEntity(query) : null;
                        }


                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener el Eor por estructura por numero de Eor: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener el Eor por estructura por numero de Eor: " + ex);
            }
            return result;
        }


    }
}
