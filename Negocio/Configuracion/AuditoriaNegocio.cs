using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Negocio.Utilidades;
using PersistenciaSigeor;
using System.Data.Objects.SqlClient;
using System.Transactions;
using System.Diagnostics;

namespace Negocio.Configuracion
{
    public class AuditoriaNegocio
    {
        private static SigeorEntities _context;


        private static List<string> ObtenerListaPkSigeorPorTabla(string nombreTabla)
        {
            List<string> result;
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
                        result = context.GET_PRIMARY_KEY_BY_TABLE(nombreTabla).ToList();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener la PK de la Sigeor.Tabla " + nombreTabla + ": " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener la PK de la Sigeor.Tabla " + nombreTabla + ": " + ex.Message);
            }
            return result;
        }


        //private static List<string> ObtenerListaPkSapPorTabla(string nombreTabla)
        //{
        //    List<string> result;
        //    try
        //    {
        //        TransactionOptions transactionOptions = new TransactionOptions
        //        {
        //            IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
        //        };
        //        using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
        //        {
        //            using (var context = new SigeorEntities())
        //            {
        //                result = context.GET_PRIMARY_KEY_BY_TABLE(nombreTabla).ToList();
        //            }
        //            transactionScope.Complete();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.WriteEntry("No se pudo obtener la PK de la Sap.Tabla " + nombreTabla + ": " + ex, EventLogEntryType.Error);
        //        throw new Exception("No se pudo obtener la PK de la Sap.Tabla " + nombreTabla + ": " + ex.Message);
        //    }
        //    return result;
        //}

        /// <summary>
        /// Retorna una lista de Auditoria, esto sucede por cada campo se que haya modificado
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="objetoActual">Objeto Actual</param>
        /// <param name="objetoAnterior">Objeto Anterior - Si es insercion debe ser null</param>
        /// <param name="tipoAuditoria">TipoAuditoriaEnum</param>
        /// <returns></returns>
        private static List<Auditoria> ListarAuditoriaPorCampos<T>(T objetoActual, T objetoAnterior, TipoAuditoriaEnum tipoAuditoria)
        {
            var listaAuditoriaPorCampos = new List<Auditoria>();

            try
            {
                var listaPropiedades =
                        objetoActual.GetType()
                            .GetProperties()
                            .Where(ent => (ent != null && (!ent.Name.StartsWith("Campo") &&
                            ((!ent.PropertyType.IsClass && !ent.PropertyType.IsEnum) ||
                            ent.PropertyType.Name.ToLower().Equals("string")))));


                var listaPks = ObtenerListaPkSigeorPorTabla(objetoActual.GetType().Name).ToList();

             

                var pks = string.Empty;
                var separador = listaPks.Count > 1 ? ";" : string.Empty;
                foreach (var item in listaPks)
                {
                    if (!string.IsNullOrEmpty(separador))
                        pks += item + ": " + objetoActual.GetType().GetProperty(item).GetValue(objetoActual, null) + separador;
                    else
                        pks += objetoActual.GetType().GetProperty(item).GetValue(objetoActual, null);
                }

                if (tipoAuditoria.Equals(TipoAuditoriaEnum.INS))
                {
                    var tipoAuditoriaEntity =
                        _context.TipoAuditoria.ToList().Find(ent => ent.Codigo == tipoAuditoria.ToString());

                    var auditoria = new Auditoria
                    {
                        Id = Guid.NewGuid(),
                        Cedula =
                                objetoActual.GetType().GetProperty("CampoCedulaUsuario").GetValue(objetoActual, null).ToString(),
                        Descripcion = tipoAuditoriaEntity.Descripcion,
                        Ip = objetoActual.GetType().GetProperty("CampoIpUsuario").GetValue(objetoActual, null).ToString(),
                        Fecha = DateTime.Today,
                        Hora = DateTime.Now.ToString("HH:mm:ss"),
                        IdObjeto = pks,
                        NombreTabla = objetoActual.GetType().Name,
                        ValorActual = string.Empty,
                        ValorAnterior = string.Empty,//valorAnterior,
                        NombreCampo = string.Empty,
                        CodigoTipo = tipoAuditoriaEntity.Codigo
                    };
                    listaAuditoriaPorCampos.Add(auditoria);
                }


                if (tipoAuditoria.Equals(TipoAuditoriaEnum.UPD) || tipoAuditoria.Equals(TipoAuditoriaEnum.DEL))
                {
                    listaAuditoriaPorCampos.AddRange(from propiedad in listaPropiedades
                        let valuePropActual = objetoActual != null ? propiedad.GetValue(objetoActual, null) : null
                        let valuePropAnterior = objetoAnterior != null ? propiedad.GetValue(objetoAnterior, null) : null
                        let valorActual = objetoActual != null && valuePropActual != null ? valuePropActual.ToString() : string.Empty
                        let valorAnterior = valuePropAnterior != null && propiedad.GetValue(objetoAnterior, null) != null ? valuePropAnterior.ToString() : string.Empty
                        where valorActual == null || !valorActual.Equals(valorAnterior)
                        where !propiedad.Name.ToUpper().Contains("FECHA_MOD") && !propiedad.Name.ToUpper().Contains("FECHAMODIFICACION") && !propiedad.Name.ToUpper().Contains("FECHAMODIFICA") && !propiedad.Name.ToUpper().Contains("USUARIOMODIFICA") && !propiedad.Name.ToUpper().Contains("USUARIO_MOD")
                        let auxTipoAuditoria = tipoAuditoria.ToString()
                        let tipoAuditoriaEntity = (from tipo in _context.TipoAuditoria where tipo.Codigo == auxTipoAuditoria select tipo).FirstOrDefault()
                        let nombreObjeto = ((objetoActual.GetType().GetProperty("Nombre") ?? objetoActual.GetType().GetProperty("Descripcion")) ?? objetoActual.GetType().GetProperty("DESCRIPCION")) ?? objetoActual.GetType().GetProperty("DESCRIP") ?? objetoActual.GetType().GetProperty("Id")
                        select new Auditoria
                        {
                            Id = Guid.NewGuid(), Cedula = objetoActual.GetType().GetProperty("CampoCedulaUsuario").GetValue(objetoActual, null).ToString(), Descripcion = tipoAuditoriaEntity.Descripcion, Ip = objetoActual.GetType().GetProperty("CampoIpUsuario").GetValue(objetoActual, null).ToString(), Fecha = DateTime.Today, Hora = DateTime.Now.ToString("HH:mm:ss"), IdObjeto = pks, NombreTabla = objetoActual.GetType().Name, ValorActual = valorActual, ValorAnterior = valorAnterior, NombreCampo = propiedad.Name, CodigoTipo = tipoAuditoriaEntity.Codigo
                        });
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo lista los campos del objeto " + objetoActual.GetType().Name + ": " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo lista los campos del objeto " + objetoActual.GetType().Name + ": " + ex.Message);
            }
            return listaAuditoriaPorCampos;
        }

        /// <summary>
        /// Inserta la auditoria realizada al objeto.
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="entidadActual">Objeto Actual</param>
        /// <param name="entidadAnterior">Objeto Anterior</param>
        /// <param name="tipoAuditoria">TipoAuditoriaEnum</param>

        public static void InsertarAuditoria<T>(T entidadActual, T entidadAnterior, TipoAuditoriaEnum tipoAuditoria)
        {
            try
            {
                _context = new SigeorEntities();

                var listaAuditada = ListarAuditoriaPorCampos(entidadActual, entidadAnterior, tipoAuditoria);

                foreach (var auditoria in listaAuditada)
                {
                    if (auditoria.EntityState.Equals(EntityState.Unchanged))
                    {
                        _context.Auditoria.Attach(auditoria);
                        _context.ObjectStateManager.ChangeObjectState(auditoria, EntityState.Added);
                    }
                    else
                        _context.Auditoria.AddObject(auditoria);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo almacenar la auditoria generica: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo almacenar la auditoria generica: " + ex.Message);
            }
            //return listaAuditada.Any() ? listaAuditada.Count : 0;
        }

        public static void Insertar(string auditoriaSerializado)
        {
            try
            {
                _context = new SigeorEntities();
                var result = Serializador.DeSerializeEntity<Auditoria>(auditoriaSerializado);
                result.Fecha = DateTime.Today;
                result.Hora = DateTime.Now.ToString("HH:mm:ss");

                _context.Auditoria.AddObject(result);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo almacenar la auditoria: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo almacenar la auditoria: " + ex.Message);
            }
        }


        public static string ObtenerAuditoria()
        {
            List<Auditoria> lista;
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
                        lista = (from auditoria in context.Auditoria
                                 orderby auditoria.Fecha, auditoria.Hora
                                 select auditoria).ToList();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener las Auditoria almacenadas: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener las Auditoria almacenadas: " + ex.Message);
            }
            return lista.Any() ? Serializador.SerializeEntity(lista.OrderBy(ent => ent.Fecha).ThenBy(ent => ent.Hora).ToList()) : null;
        }

        public static string ObtenerAuditoriaPorCoincidencia(string parametro)
        {
            List<GET_AUDITORIA_Result> result;
            try
            {
                var param = Serializador.DeSerializeEntity<ClaseBasica>(parametro);

                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    using (var context = new SigeorEntities())
                    {
                        result = context.GET_AUDITORIA(param.FechaDateTimeStringUno, param.FechaDateTimeStringDos, param.Descripcion, param.DescripcionUno).ToList();
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener las Auditoria por cincidencias: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener las Auditoria por cincidencias: " + ex.Message);
            }
            return result.Any() ? Serializador.SerializeEntity(result) : null;
        }

        public static string ObtenerAuditoriaPorCoincidenciaPaginado(string parametro, int pagesize, int pageIndex, out int totalRegistros)
        {
            List<GET_AUDITORIA_Result> lista = null;
            try
            {
                var param = Serializador.DeSerializeEntity<ClaseBasica>(parametro);

                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    using (var context = new SigeorEntities())
                    {
                        lista = context.GET_AUDITORIA(param.FechaDateTimeStringUno, param.FechaDateTimeStringDos, param.Descripcion, param.DescripcionUno).ToList();
                    }
                    totalRegistros = lista.Count;
                    lista = lista.Skip(pagesize * (pageIndex-1)).Take(pagesize).ToList();
                    transactionScope.Complete();                    
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo obtener las Auditoria Paginada: " + ex, EventLogEntryType.Error);
                throw new Exception("No se pudo obtener las Auditoria Paginada: " + ex.Message);
            }
            return lista.Any() ? Serializador.SerializeEntity(lista) : null;
        }

    }
}
