using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Negocio.Configuracion;

namespace Negocio.Sigeor.Configuracion
{
    public class ConfigurarEmailNegocio
    {
        public static void InsertarConfiguracionEmail(string emailSerializado)
        {
            try
            {
                var result = Serializador.DeSerializeEntity<Email>(emailSerializado);

                using (var context = new SigeorEntities())
                {
                    var email = (from mail in context.Email
                                 select mail).FirstOrDefault();

                    var anteriorClonado = Reflection.ClonarEntidadAuditoria(email);

                    if (email != null)
                    {
                        result.Id = email.Id;
                        email.DirEMail = result.DirEMail;
                        email.Password = result.Password;
                        email.Puerto = result.Puerto;
                        email.Host = result.Host;
                        email.Ssl = result.Ssl;
                        context.Email.ApplyCurrentValues(email);
                        context.SaveChanges();
                        AuditoriaNegocio.InsertarAuditoria(result, anteriorClonado, TipoAuditoriaEnum.UPD);
                    }
                    else
                    {
                        result.Id = Guid.NewGuid();
                        context.Email.AddObject(result);
                        context.SaveChanges();
                        AuditoriaNegocio.InsertarAuditoria(result, null, TipoAuditoriaEnum.INS);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo guardar la configuracion del email: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo guardar la configuracion del email: " + ex.Message);
            }
        }

        public static string ObtenerConfiguracionEmail()
        {
            Email result;
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
                        result = (from email in context.Email
                                  select email
                            ).FirstOrDefault();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener la configuracion del email: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener la configuracion del email: " + ex.Message);
            }
            return result != null ? Serializador.SerializeEntity(result) : null;
        }
    }
}
