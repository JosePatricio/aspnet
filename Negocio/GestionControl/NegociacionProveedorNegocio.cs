﻿using System;using System.Collections.Generic;using System.Data;using System.Data.Objects.SqlClient;using System.Linq;using Negocio.Configuracion;using Negocio.Utilidades;using PersistenciaSigeor;using System.Diagnostics;using System.Transactions;using PersistenciaAretina;using PersistenciaSap;namespace Negocio.Sigeor.GestionControl{    public class NegociacionProveedorNegocio    {        public static void Insertar(string negociacionSerializada)        {            try            {                using (var context = new SigeorEntities())                {                    NegociacionProveedor negociacion = Serializador.DeSerializeEntity<NegociacionProveedor>(negociacionSerializada);                    negociacion.FechaCrea = DateTime.Now;                    //context.NegociacionProveedor.Attach(negociacion);                    //context.ObjectStateManager.ChangeObjectState(negociacion, EntityState.Added);                    context.NegociacionProveedor.AddObject(negociacion);                    context.SaveChanges();                    AuditoriaNegocio.InsertarAuditoria(negociacion, null, TipoAuditoriaEnum.INS);                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo registrar la negociacion por proveedor: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo registrar la negociacion por proveedor: " + ex);            }        }        public static void Modificar(string negociacionSerializada)        {            try            {                using (var context = new SigeorEntities())                {                    var result = Serializador.DeSerializeEntity<NegociacionProveedor>(negociacionSerializada);                    if (result != null)                    {                        result.FechaModifica = DateTime.Now;                        var busqueda = (from linea in context.NegociacionProveedor                                        where linea.Id.Equals(result.Id)                                        select linea).FirstOrDefault();                        NegociacionProveedor doc = null;                        if (busqueda != null)                            doc = Reflection.ClonarEntidadAuditoria(busqueda);                        context.NegociacionProveedor.ApplyCurrentValues(result);                        context.SaveChanges();                        AuditoriaNegocio.InsertarAuditoria(result, doc, TipoAuditoriaEnum.UPD);                    }                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo modificar la negociacion por proveedor: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo modificar la negociacion por proveedor: " + ex);            }        }        public static void Eliminar(string negociacionSerializada)        {            try            {                using (var context = new SigeorEntities())                {                    NegociacionProveedor negociacion = Serializador.DeSerializeEntity<NegociacionProveedor>(negociacionSerializada);                    context.NegociacionProveedor.Attach(negociacion);                    context.ObjectStateManager.ChangeObjectState(negociacion, EntityState.Deleted);                    context.SaveChanges();                    AuditoriaNegocio.InsertarAuditoria(negociacion, null, TipoAuditoriaEnum.DEL);                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo eliminar la negociacion por proveedor: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo eliminar la negociacion por proveedor: " + ex);            }        }        public static string ObtenerNegociaciones()        {            List<NegociacionProveedor> result;            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from negociacion in context.NegociacionProveedor                                  orderby negociacion.Descripcion                                  select negociacion).ToList();                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener las negociaciones por proveedor: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener las negociaciones por proveedor: " + ex);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerNegociacionesPorEstado(bool estado)        {            List<NegociacionProveedor> result;            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from negociacion in context.NegociacionProveedor                                  where negociacion.Estado.Equals(estado)                                  orderby negociacion.Descripcion                                  select negociacion).ToList();                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener las negociaciones por proveedor por estado: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener las negociaciones por proveedor por estado: " + ex);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerNegociacionesPorId(string idSerializado)        {            NegociacionProveedor result;            try            {                var idResult = Serializador.DeSerializeEntity<ClaseBasica>(idSerializado);                Guid id = idResult.IdGuid;                var transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from negociacion in context.NegociacionProveedor                                  where negociacion.Id.Equals(id)                                  select negociacion).FirstOrDefault();                        result = CargarProveedorDeposito(result);                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la negociacion por proveedor por Id: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener la negociacion por proveedor por Id: " + ex);            }            return result != null ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerNegociacionesPorCoincidencia(string value, bool estado)        {            List<NegociacionProveedor> result;            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (                        from negociacion in context.NegociacionProveedor                        where                             negociacion.Descripcion.ToUpper().Contains(value.ToUpper()) ||                             value.Contains(SqlFunctions.StringConvert(negociacion.ValorNegoMaterialEstructura)) ||                             value.Contains(SqlFunctions.StringConvert(negociacion.ValorNegoMaterialMaquinaria)) ||                             value.Contains(SqlFunctions.StringConvert(negociacion.ValorNegoHHEst)) ||                             value.Contains(SqlFunctions.StringConvert(negociacion.ValorNegoHHMaq)) &&                             negociacion.Estado.Equals(estado)                        orderby negociacion.Descripcion                        select negociacion).ToList();                        result = CargarProveedorDeposito(result);                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener las negociaciones por proveedor por coincidencia: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener las negociaciones por proveedor por coincidencia: " + ex);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerNegociacionesPaginado(int pagesize, int pageIndex, out int totalRegistros)        {            List<NegociacionProveedor> result;            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from negociacion in context.NegociacionProveedor                                  orderby negociacion.Descripcion                                  select negociacion).ToList();                        totalRegistros = result.Count;                        result = result.Skip(pagesize * (pageIndex-1)).Take(pagesize).ToList();                        result = CargarProveedorDeposito(result);                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                throw new Exception("No se pudo obtener las negociaciones por lineas paginadas" + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerNegociacionesPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex, out int totalRegistros)        {            List<NegociacionProveedor> result;            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (                        from negociacion in context.NegociacionProveedor                        where                             negociacion.Descripcion.ToUpper().Contains(value.ToUpper()) ||                             value.Contains(SqlFunctions.StringConvert(negociacion.ValorNegoMaterialEstructura)) ||                             value.Contains(SqlFunctions.StringConvert(negociacion.ValorNegoMaterialMaquinaria)) ||                             value.Contains(SqlFunctions.StringConvert(negociacion.ValorNegoHHEst)) ||                             value.Contains(SqlFunctions.StringConvert(negociacion.ValorNegoHHMaq)) &&                             negociacion.Estado.Equals(estado)                        orderby negociacion.Descripcion                        select negociacion).ToList();                        result = result.OrderBy(ent => ent.Descripcion).ToList();                        totalRegistros = result.Count;                        result = result.Skip(pagesize * (pageIndex-1)).Take(pagesize).ToList();                        result = CargarProveedorDeposito(result);                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                throw new Exception("No se pudo obtener las negociaciones por lineas por coincidencia paginado" + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerNegociacionesPorEstadoPaginado(bool estado, int pagesize, int pageIndex, out int totalRegistros)        {            List<NegociacionProveedor> result;            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from negociacion in context.NegociacionProveedor                                  where negociacion.Estado.Equals(estado)                                  orderby negociacion.Descripcion                                  select negociacion).ToList();                        totalRegistros = result.Count;                        result = result.Skip(pagesize * (pageIndex-1)).Take(pagesize).ToList();                        result = CargarProveedorDeposito(result);                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                throw new Exception("No se pudo obtener las negociacione por linea por estado paginado" + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static void ModificarMasivamente(string value, bool estado)        {            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        List<NegociacionProveedor> lista = new List<NegociacionProveedor>();                        string result;                        if (!string.IsNullOrEmpty(value))                        {                            result = ObtenerNegociacionesPorCoincidencia(value, estado);                            lista = !string.IsNullOrEmpty(result)                                ? Serializador.DeSerializeEntity<List<NegociacionProveedor>>(result) : null;                        }                        if (string.IsNullOrEmpty(value))                        {                            result = ObtenerNegociacionesPorEstado(estado);                            lista = !string.IsNullOrEmpty(result)                                ? Serializador.DeSerializeEntity<List<NegociacionProveedor>>(result) : null;                        }                        foreach (var negociacion in lista)                        {                            negociacion.Estado = !negociacion.Estado;                            if (negociacion.EntityState.Equals(EntityState.Detached))                            {                                context.NegociacionProveedor.Attach(negociacion);                                context.ObjectStateManager.ChangeObjectState(negociacion, EntityState.Modified);                            }                            context.NegociacionProveedor.ApplyCurrentValues(negociacion);                            context.SaveChanges();                        }                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                throw new Exception("No se pudo modificar las negociaciones por linea de forma masiva" + ex.Message);            }        }        private static List<NegociacionProveedor> CargarProveedorDeposito(List<NegociacionProveedor> value)        {            try            {                if (value != null && value.Any())                {                    value.ForEach(ent =>                    {                        var transactionOptions = new TransactionOptions                        {                            IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                        };                        using (                            var transactionScope = new TransactionScope(TransactionScopeOption.Required,                                transactionOptions))                        {                            using (var context = new SigeorEntities())                            {                                var firstOrDefault = (context.S_OCRD.Where(prov => prov.CardCode == ent.IdProveedor)).FirstOrDefault();                                if (firstOrDefault != null)                                    ent.CampoNombreProveedor = firstOrDefault.CardName;                                //ent.CampoNombreProveedor = ent.Proveedor.Nombre;                            }                            transactionScope.Complete();                        }                        ent.CampoNombreDeposito = ent.SM_DEPOSITO.NOMBRE_DEPOSITO;                    });                }            }            catch (Exception ex)            {                throw new Exception("No se pudo cargar la linea de esta negociacion" + ex.Message);            }            return value;        }        private static NegociacionProveedor CargarProveedorDeposito(NegociacionProveedor ent)        {            try            {                if (ent != null)                {                    var transactionOptions = new TransactionOptions                    {                        IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                    };                    using (                        var transactionScope = new TransactionScope(TransactionScopeOption.Required,                            transactionOptions))                    {                        using (var context = new SigeorEntities())                        {                            var firstOrDefault = (context.S_OCRD.Where(prov => prov.CardCode == ent.IdProveedor)).FirstOrDefault();                            if (firstOrDefault != null)                                ent.CampoNombreProveedor = firstOrDefault.CardName;                            //ent.CampoNombreProveedor = ent.Proveedor.Nombre;                        }                        transactionScope.Complete();                    }                    ent.CampoNombreDeposito = ent.SM_DEPOSITO.NOMBRE_DEPOSITO;                }            }            catch (Exception ex)            {                throw new Exception("No se pudo cargar la linea de esta negociacion" + ex.Message);            }            return ent;        }    }}