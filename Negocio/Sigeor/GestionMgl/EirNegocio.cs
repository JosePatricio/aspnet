using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Negocio.Utilidades;
using PersistenciaSigeor;

namespace Negocio.Sigeor.GestionMgl
{
    public class EirNegocio
    {
        public static string ObtenerEirPorCodigo(string parametro)
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
                        var query = (from eir in context.C_EIR
                                     where eir.ID_EIR.Trim().Equals(param.IdStringUno)
                                     select eir).FirstOrDefault();
                        result = Serializador.SerializeEntity(query);
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception)
            {

                throw new Exception("No se pudo obtener el Eir");
            }
            return result;
        }
    }
}
